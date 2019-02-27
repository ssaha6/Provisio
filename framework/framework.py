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



class Framework:

    def __init__(self, putName, benchmark, learner, teacher):
        self.putName = putName
        self.benchmark = benchmark
        self.learner = learner
        self.teacher = teacher
        self.dataPoints = []
        self.precondition = "true"
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
            
        
        
    def learnPostcondition(self):
        testClass = "../../ContractsSubjects/Stack/StackTest/StackContractTest.cs"
        putName = "PUT_PushContract"
        solutionFile = "../../ContractsSubjects/Stack/Stack.sln"
        testType = "StackContractTest"
        testNamespace = "Stack.Test"
        testDll = "../../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll"
        allPostconditions = []
        allDataPoints = []
        postcondition = "true"
        round = 1
        while True:
            modifycode.insertPostConditionInPexAssert(testClass, postcondition, putName)
            modifycode.runCompiler("MSBuild.exe",solutionFile)
            #def runTeacher(self, dll, testMethod, testNamespace, testType):
            self.teacher.runTeacher(testDll, putName,testNamespace, testType)
            
            datapoints = self.teacher.generateSamples()
            print "Datapoints in Round: " + str(round)
            print datapoints
            allDataPoints.extend(datapoints)
            print "All Datapoints accumulated: "
            print allDataPoints
            postcondition = self.learner.learn(allDataPoints)
            print "round: "+ str(round) + postcondition

            if postcondition in allPostconditions:
                break
            
            allPostconditions.append(postcondition)
            round = round + 1
        


if __name__ == '__main__':
    
    logger = logging.getLogger("Framework")
    logger.setLevel(logging.INFO)
    
    # create the logging file handler
    fh = logging.FileHandler("information")

    formatter = logging.Formatter('%(name)s- %(message)s')
    fh.setFormatter(formatter)

    # add handler to logger object
    logger.addHandler(fh)
    options = [[True,True,True],[True,True,False],[True,False,True],[False,True,True],
    [False,True,False],[False,False,True],[True,False,False],[False,False,False]]

    #options = [[True,False,True],[True,True,True],[True,True,False],[False,True,True],
    #[False,True,False],[False,False,True],[True,False,False],[False,False,False]]
    #for opt in options:
    #entropy = opt[0]
    #numerical = opt[1]
    #allPredicates = opt[2]
    entropy = False
    numerical = True
    allPredicates = True

    logger.info("Program started")
    logger.info("configuration: "+ "entropy: "+str(entropy)+ " numerical: "+ str(numerical)+ " all: "+ str(allPredicates) )
    #learner = HoudiniExtended("HoudiniExtended","","","")
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    #boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    learner = DisjunctiveLearner("DisjunctiveLearner", "", "", "")
    learner.entropy = entropy
    learner.numerical = numerical
    learner.allPredicates = allPredicates

    print "starting"
    intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_ret','New_ret']
    boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    #boolVariables = []
    learner.setVariables(intVariables, boolVariables)

    # Report path is relative to vscode root dir... 
    teacher = Pex(  "pex.exe",
                    "../ContractsSubjects/Stack/StackTest/bin/Debug",
                    len(learner.intVariables) + len(learner.boolVariables),
                    ['/nor']
                )
    
    framework = Framework(learner, teacher)
    framework.learnPostcondition()
    logger.info("Done")
    logger.info("")
    #break