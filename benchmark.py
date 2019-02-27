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


class Benchmark:
    
    def __init__(self, solutionFile, testDll, testFile, classFile, testNamespace, testType, pexReportFolder):
        self.solutionFile = solutionFile
        self.testDll = testDll
        self.testFile = testFile
        self.classFile = classFile
        self.testNamespace = testNamespace
        self.testType = testType
        self.pexReportFolder = pexReportFolder
    
