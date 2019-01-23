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

    def __init__(self, learner, teacher):
        self.learner = learner
        self.teacher = teacher
        self.dataPoints = []
        self.precondition = "true"
        self.loop = 0
        self.numPredicates = 0

    def learnPostcondition(self):
        testClass = "../ContractsSubjects/Stack/StackTest/StackContractTest.cs"
        putName = "PUT_PushContract"
        #putName = "PUT_PeekContract"        
        #putName = "PUT_PopContract"
        solutionFile = "../ContractsSubjects/Stack/Stack.sln"
        testType = "StackContractTest"
        testNamespace = "Stack.Test"
        testDll = "../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll"
        allPostconditions = []
        #allDataPoints = [('1', '2', '0', '0', '0', '0', 'true', 'true', 'true'),
        #('2', '3', '10', '0', '0', '0', 'false', 'true', 'true'), 
        #('1', '2', '10', '0', '0', '0', 'false', 'true', 'true')]
        #allDataPoints = []
        allDataPoints=[]
        postcondition = "true"
        round = 1
        while True:
            modifycode.insertPostConditionInPexAssert(testClass, postcondition, putName)
            modifycode.runCompiler("MSBuild.exe",solutionFile)
            #def runTeacher(self, dll, testMethod, testNamespace, testType):
            self.teacher.runTeacher(testDll, putName,testNamespace, testType)
            
            datapoints = self.teacher.generateSamples()
            
            allDataPoints.extend(datapoints)
            logger = logging.getLogger("Framework.LearnPost")
            logger.info("round: "+ str(round))
            postcondition = self.learner.learn(allDataPoints)
            #print self.learner.dataPoints
            print "Postcoundition in Round: "+ str(round) + " "+postcondition

            if postcondition in allPostconditions:
                break
            #if round == 15:
            #    break
            allPostconditions.append(postcondition)
            round = round +1

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

    for opt in options:
        entropy = opt[0]
        numerical = opt[1]
        allPredicates = opt[2]

        
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
        break