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
        solutionFile = "../ContractsSubjects/Stack/Stack.sln"
        testType = "StackContractTest"
        testNamespace = "Stack.Test"
        testDll = "../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll"
        allPostconditions = []
        allDataPoints = [['1', '2', '10', '0', '0', '0', 'false', 'true', 'true'], ['1', '2', '10', '0', '0', '0', 'false', 'true', 'true'], 
        ['1', '2', '10', '1', '1', '1', 'false', 'true', 'true'],['1', '2', '0', '0', '0', '0', 'true', 'true', 'true'],['1', '2', '1', '1', '1', '1', 'true', 'true', 'true'], 
        ['2', '3', '10', '0', '0', '0', 'false', 'true', 'true']]
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
            print "Postcoundition in Round: "+ str(round) + " "+postcondition

            if postcondition in allPostconditions:
                break
            if round == 2:
                break
            allPostconditions.append(postcondition)
            round = round +1

if __name__ == '__main__':
    
    learner = HoudiniExtended("HoudiniExtended","","","")
    intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    learner.setVariables(intVariables, boolVariables)
    
    
    #learner = DisjunctiveLearner("", "", "", "")
    #intVariables = ['Old_s1Count', 'New_s1Count','Old_Top','New_Top', 'Old_x','New_x']
    #boolVariables = ["Old_s1ContainsX", "New_s1ContainsX"]
    #learner.setVariables(intVariables, boolVariables)

    
    # Report path is relative to vscode root dir... 
    teacher = Pex(  "pex.exe",
                    "../ContractsSubjects/Stack/StackTest/bin/Debug",
                    len(learner.intVariables) + len(learner.boolVariables),
                    ['/nor']
                )
    
    framework = Framework(learner, teacher)
    framework.learnPostcondition()
