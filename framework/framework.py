import subprocess
import sys
import re
import os
import time
import argparse
import collections
import pprint
import csv
import json
import time
import shutil
import io
import logging
from os import sys,path
sys.path.append(path.dirname(path.abspath(__file__)))
sys.path.append(path.dirname(path.dirname(path.abspath(__file__))))

#import learner
#import teacher
##from utilityPython import utils
##from benchmarkSet import BenchmarkSet

#from learner import Learner
from teacher import *
from learner import *
from benchmark import *


class Framework:

    def __init__(self, putName, benchmark, learner, teacher):
        self.putName = putName
        self.benchmark = benchmark
        self.learner = learner
        self.teacher = teacher
        self.dataPoints = set()
        self.precondition = "true"
        self.postcondition = "false"
        self.rounds = 0
        self.numPredicates = 0
        self.teacherTime = 0.0
        self.learnerTime = 0.0


    def checkPrecondition(self, precondition, PTest):
        if PTest: 
            modifycode.remove_assumes(self.benchmark.testFile, self.putName)
            modifycode.insert_p_in_put(self.benchmark.testFile, self.putName, precondition)
        else:
            modifycode.insert_p_in_put(self.benchmark.testFile, self.putName, "!("+precondition+")")
            modifycode.insert_assumes(self.benchmark.testFile, self.putName)

        modifycode.runCompiler("MSBuild.exe", self.benchmark.solutionFile)
        
        self.teacher.runTeacher(self.benchmark.testDll, self.putName, self.benchmark.testNamespace, self.benchmark.testType)
        self.teacherTime += self.teacher.time
        
        return self.teacher.parseReportPre(self.benchmark.pexReportFolder)
        
        
    
    def learnPrecondition(self):
        allPreconditions = []
        self.rounds = 1
        self.learnerTime = 0.0
        self.teacherTime = 0.0
        while True:
            
            print  "Round " + str(self.rounds) + " : Running Pex",
            sys.stdout.flush()
            
            PDataPoints = self.checkPrecondition(self.precondition, PTest = True)
            notPDataPoints = self.checkPrecondition(self.precondition, PTest = False) 
            self.dataPoints.extend(PDataPoints + notPDataPoints)
            
            # conflict Resolver
            # self.dataPoints = filterDataPointConflicts(self.dataPoints)
            
            print  "\rRound " + str(self.rounds) + " : Running Learner",
            sys.stdout.flush()
            self.precondition = self.learner.learn(self.dataPoints)
            self.learnerTime += self.learner.time
            
            print  "\rRound " + str(self.rounds) + " : Precondition Learned: " + self.precondition
            
            if self.precondition in allPreconditions:
                break
            
            if self.rounds >= 50:
                break
            
            allPreconditions.append(self.precondition)
            self.rounds = self.rounds +1
        
        return self.precondition, self.rounds, len(self.dataPoints), round(self.learnerTime, 2), round(self.teacherTime, 2)
            
        
        

    def checkPostcondition(self, postcondition):
        modifycode.insertPostConditionInPexAssert(self.benchmark.testFile, self.putName, postcondition)
        modifycode.runCompiler("MSBuild.exe", self.benchmark.solutionFile)
        self.teacher.runTeacher(self.benchmark.testDll, self.putName, self.benchmark.testNamespace, self.benchmark.testType)
        return self.teacher.parseReportPost(self.benchmark.pexReportFolder)
    
        
    def learnPostcondition(self):
        allPostconditions = []
        self.rounds = 1
        while True:
            currentDataPoints = set()
            currentDataPoints = self.checkPostcondition(self.postcondition)
            print "\nDatapoints in Round: " + str(self.rounds)
            logger.info("# Round: "+ str(self.rounds))
            print currentDataPoints
            
            self.dataPoints = self.dataPoints.union(currentDataPoints)
            print "\nAll Datapoints accumulated: "
            print self.dataPoints
            
            self.postcondition = self.learner.learn(self.dataPoints)
            print  "Round " + str(self.rounds) + " : Postcondition Learned: " + self.postcondition

            if self.postcondition in allPostconditions:
                break
            
            if self.rounds >= 20:
                break
            
            allPostconditions.append(self.postcondition)
            self.rounds = self.rounds +1        


if __name__ == '__main__':
    
    benchmark = Benchmark(
        solutionFile = "../ContractsSubjects/Stack/Stack.sln",
        testDll = "../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll",
        testFile = "../ContractsSubjects/Stack/StackTest/StackContractTest.cs",
        classFile = '../ContractsSubjects/Stack/Stack/Stack.cs',
        testNamespace = "Stack.Test",
        testType = "StackContractTest",
        pexReportFolder = "../ContractsSubjects/Stack/StackTest/bin/Debug"
    )
    putName = "PUT_PushContract"
    #putName = "PUT_PopContract"
            
    logger = logging.getLogger("Framework")
    logger.setLevel(logging.INFO)
    
    # create the logging file handler
    fh = logging.FileHandler("information")

    formatter = logging.Formatter('%(message)s')
    fh.setFormatter(formatter)

    # add handler to logger object
    logger.addHandler(fh)
            
    #for opt in options:
    entropy = True
    numerical = False
    allPredicates = True
    
    logging.disable(logging.NOTSET)
    
    logger.info("Program started")
    logger.info("configuration: "+ "entropy: "+str(entropy)+ " numerical: "+ str(numerical)+ " all: "+ str(allPredicates) )
    
    #learner = HoudiniExtended("HoudiniExtended","","","")
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    #boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    
    learner = DisjunctiveLearner("DisjunctiveLearner", "", "", "")
    learner.entropy = entropy
    learner.numerical = numerical
    learner.allPredicates = allPredicates

    intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_ret','New_ret']
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top']
    boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    #boolVariables = []
    
    learner.setVariables(intVariables, boolVariables)
    
    teacher = Pex(  "pex.exe",
                    len(learner.intVariables) + len(learner.boolVariables),
                    ['/nor']
                )
    
    framework = Framework(putName, benchmark, learner, teacher)
    
    framework.learnPostcondition()
    logger.info("Done")
    logger.info("")
    #break
        