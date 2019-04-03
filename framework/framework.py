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
from pprint import pprint
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
            
            PosPDataPoints, NegPDataPoints = self.checkPrecondition(self.precondition, PTest = True)
            PosnotPDataPoints, NegnotPDataPoints = self.checkPrecondition(self.precondition, PTest = False) 
            
            self.dataPoints.extend(PosPDataPoints + NegPDataPoints + PosnotPDataPoints + NegnotPDataPoints)
            
            # print "P Datapoints"
            # pprint(PosPDataPoints + NegPDataPoints)
            # print "not P datapoints"
            # pprint(PosnotPDataPoints+ NegnotPDataPoints)
            
            # conflict Resolver
            # self.dataPoints = filterDataPointConflicts(self.dataPoints)
            
            print  "\rRound " + str(self.rounds) + " : Running Learner",
            sys.stdout.flush()
            
            self.precondition = self.learner.learn(self.dataPoints)
            self.learnerTime += self.learner.time
            
            print  "\rRound " + str(self.rounds) + " : Precondition Learned: " + self.precondition
            
            # if len(NegPDataPoints) == 0 and float(len(PosnotPDataPoints))/float(len(self.dataPoints)) < 0.04  :
            #     break
            
            if len(NegPDataPoints) == 0 and len(PosnotPDataPoints) == 0 :
                break
            
            if self.precondition in allPreconditions:
                break
            
            if self.rounds >= 50:
                break
            
            allPreconditions.append(self.precondition)
            self.rounds = self.rounds +1
            
        return self.precondition, self.rounds, len(self.dataPoints), round(self.learnerTime, 2), round(self.teacherTime, 2)
        
        
