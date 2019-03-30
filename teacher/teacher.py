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
import shutil
import io
##from utilityPython import utils
##from benchmarkSet import BenchmarkSet
from lxml import etree
#import modifycode
#import reportparser
#import pex
#import csharp


class Teacher:

    #def __init__(self, testMethod, benchmarkSet, compilerCommand, pexBinary, precondition = "true"):
    #   self.testMethod = testMethod
    #   self.benchmarkSet = benchmarkSet
    #   self.compilerCommand = compilerCommand
    #   self.pexBinary = pexBinary
    #   self.precondition = precondition
    #   self.num_pred = 0
    #   self.done = False
    binary =""
    arguments =[]

    def __init__(self, binary, arguments):
        self.binary = binary
        self.arguments = arguments

    def runTeacher(self):
        pass
    
    def generateSamples(self, pexReportFolder):
        pass


