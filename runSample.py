import argparse
import collections
import csv
import io
import json
import os
import pprint
import re
import shutil
import subprocess
import sys
import time
import traceback
from os import sys,path
sys.path.append(path.dirname(path.abspath(__file__)))
sys.path.append(path.dirname(path.dirname(path.abspath(__file__))))

from teacher import *
from learner import *
from framework import *
from benchmark import Benchmark


class Logging:
    def __init__(self, fileName):
        self.fileName = fileName
        self.header = ["MethodName", "Precondition", "Num. Rounds", "Num. DataPoints", "Learner Time(s)", "Teacher Time(s)", "Total Time(s)"]
        with open(self.fileName, 'wb') as myfile:
            wr = csv.writer(myfile)
            wr.writerow(self.header)
        
    def append(self, method, precondition, rounds, numDataPoints, learnerTime, teacherTime, totalTime):
        with open(self.fileName, 'a') as myfile:
            wr = csv.writer(myfile)
            wr.writerow([method, precondition, rounds, numDataPoints, learnerTime, teacherTime, totalTime])




def runner(benchmark, methodParameters, logFile, exception = False):
    
    learner = DTLearner("dtlearner", "learner/C50exact/c5.0dbg.exe", "", "tempLocation")
    pexBinary = "pex.exe"

    log = Logging(logFile)

    for element in methodParameters:
        
        if exception:
            (putName, methodUnderTest, boolVariables, intVariables) = element 
        else:
            (putName, boolVariables, intVariables) = element 


        print "\n\nLearning precondition for method: " + putName
        print "--------------------------------------------------------------------------------"

        try:
            learner.setVariables(intVariables, boolVariables)

            teacher = Pex( pexBinary,
            len(learner.intVariables) + len(learner.boolVariables),
            ['/nor']
            )
            
            if exception:
                framework = FrameworkException(putName, methodUnderTest, benchmark, learner, teacher)
            else: 
                framework = Framework(putName, benchmark, learner, teacher)
            

            precondition, rounds, numDataPoints, learnerTime, teacherTime = framework.learnPrecondition()

            log.append(putName, precondition, rounds, numDataPoints, learnerTime, teacherTime, learnerTime + teacherTime)
            print "--------------------------------------------------------------------------------"
            print "Method Name        : " + putName
            print "Final Precondition : " + precondition
            print "Number of rounds   : " + str(rounds)
            print "Number of Points   : " + str(numDataPoints)
            print "Learner time(s)    : " + str(learnerTime)
            print "Teacher time(s)    : " + str(teacherTime)
            print "Total Time(s)      : " + str(learnerTime + teacherTime)

        except Exception as e:
            print "\n!!! Exception found !!!"
            print str(e)

def main():
    run_Sample()

def run_Sample():

    benchmark = Benchmark(
        solutionFile = 'Sample/Sample.sln',
        testDll = 'Sample/ListTest/bin/Debug/ListTest.dll',
        testFile = 'Sample/ListTest/ListTest.cs',
        classFile = 'Sample/List/List.cs',
        testNamespace = 'SampleList.Test',
        testType = 'ListTest',
        pexReportFolder = "Sample/ListTest/bin/Debug"
    )
    methodParameters = [('CheckSample', [ ], ['x', 'l.Count()'])]    
    runner(benchmark, methodParameters, "results/sample.csv")

if __name__ == '__main__':
    main()
