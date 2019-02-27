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
from framework import Framework

class FrameworkException(Framework):

    def __init__(self, putName, methodUnderTest, benchmark, learner, teacher):
        Framework.__init__(self, putName, benchmark, learner, teacher)
        self.methodUnderTest = methodUnderTest


    def checkPrecondition(self, precondition, PTest):
        if PTest: 
            modifycode.remove_assumes(self.benchmark.testFile, self.putName)
            modifycode.remove_assumes(self.benchmark.classFile, self.methodUnderTest)
            modifycode.insert_p_in_put(self.benchmark.testFile, self.putName, precondition)
        else:
            modifycode.insert_p_in_put(self.benchmark.testFile, self.putName, "!("+precondition+")")
            modifycode.insert_assumes(self.benchmark.classFile, self.methodUnderTest)
            modifycode.insert_assumes(self.benchmark.testFile, self.putName)

        modifycode.runCompiler("MSBuild.exe", self.benchmark.solutionFile)

        self.teacher.runTeacher(self.benchmark.testDll, self.putName, self.benchmark.testNamespace, self.benchmark.testType)
        self.teacherTime += self.teacher.time

        return self.teacher.parseReportPre(self.benchmark.pexReportFolder)



        
    

        
