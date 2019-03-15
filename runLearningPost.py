from benchmark import Benchmark
from framework import *
from learner import *
from teacher import *
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
import logging
from os import sys, path
sys.path.append(path.dirname(path.abspath(__file__)))
sys.path.append(path.dirname(path.dirname(path.abspath(__file__))))


# logging


class Logging:
    def __init__(self, fileName):
        self.fileName = fileName
        self.header = ["MethodName", "Precondition", "Num. Rounds",
                       "Num. DataPoints", "Learner Time(s)", "Teacher Time(s)", "Total Time(s)"]
        with open(self.fileName, 'wb') as myfile:
            wr = csv.writer(myfile)
            wr.writerow(self.header)

    def append(self, method, precondition, rounds, numDataPoints, learnerTime, teacherTime, totalTime):
        with open(self.fileName, 'a') as myfile:
            wr = csv.writer(myfile)
            wr.writerow([method, precondition, rounds, numDataPoints,
                         learnerTime, teacherTime, totalTime])


def runnerPost(benchmark, methodParameters, logFile, exception=False):
    entropy = True
    numerical = False
    allPredicates = True

    pexBinary = "pex.exe"
    #debug
    logger = logging.getLogger("Runner")
    logger.setLevel(logging.INFO)
    # create the logging file handler
    fh = logging.FileHandler("information")
    formatter = logging.Formatter('%(message)s')
    fh.setFormatter(formatter)
    # add handler to logger object
    logger.addHandler(fh)
    logger.info("Program started")
    logger.info("configuration: " + "entropy: "+str(entropy) +
                " numerical: " + str(numerical) + " all: " + str(allPredicates))
    #endDebug
    log = Logging(logFile)
    for element in methodParameters:
        # if exception:
        #    (putName, methodUnderTest, boolVariables, intVariables) = element
        (putName, boolVariables, intVariables) = element
        print "\n\nLearning postcondition for method: " + putName
        print "--------------------------------------------------------------------------------"

        try:
            learner = DisjunctiveLearner("DisjunctiveLearner", "", "", "")
            # debug
            learner.entropy = entropy
            learner.numerical = numerical
            learner.allPredicates = allPredicates
            #enddebug
            learner.setVariables(intVariables, boolVariables)
            teacher = Pex(pexBinary, len(learner.intVariables) +
                  len(learner.boolVariables), ['/nor'])
            # if exception:
            #    framework = FrameworkException(putName, methodUnderTest, benchmark, learner, teacher)
            framework = Framework(putName, benchmark, learner, teacher)
            postcondition, rounds, numDataPoints, learnerTime, teacherTime = framework.learnPostcondition()
            log.append(putName, postcondition, rounds, numDataPoints,
                       learnerTime, teacherTime, learnerTime + teacherTime)

            print "--------------------------------------------------------------------------------"
            print "Method Name        : " + putName
            print "Final PostCondition : " + postcondition
            print "Number of rounds   : " + str(rounds)
            print "Number of Points   : " + str(numDataPoints)
            print "Learner time(s)    : " + str(learnerTime)
            print "Teacher time(s)    : " + str(teacherTime)
            print "Total Time(s)      : " + str(learnerTime + teacherTime)

        except Exception as e:
            print "\n!!! Exception found !!!"
            traceback.print_exc(file=sys.stdout)

    logger.info("done!")
    logger.info("")


def run_StackCommuteOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/Stack/Stack.sln",
        testDll="../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll",
        testFile="../ContractsSubjects/Stack/StackTest/StackContractTest.cs",
        classFile='../ContractsSubjects/Stack/Stack/Stack.cs',
        testNamespace="Stack.Test",
        testType="StackContractTest",
        pexReportFolder="../ContractsSubjects/Stack/StackTest/bin/Debug"
    )

    methodParameters = [
        ('PUT_PushContract', ["Old_s1ContainsX", "New_s1ContainsX"], ['Old_s1Count', 'New_s1Count', 'Old_Top', 'New_Top', 'Old_x', 'New_x']),
        ('PUT_PopContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_ret', 'New_ret'])  # ,
        #('PUT_CommutativityPopPopComm', [ ], ['s1.Count', 's1.Peek()'] ),
        #('PUT_CommutativityPushPopComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ),
    ]
    runnerPost(benchmark, methodParameters, "results/stack_post.csv")


if __name__ == '__main__':
    run_StackCommuteOnly()
