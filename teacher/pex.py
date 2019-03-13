import subprocess
import sys
import re
import os
from os.path import join
import time
import argparse
import collections
import pprint
import csv
import json
import time
import shutil
import io
##from utilityPython import utils
##from benchmarkSet import BenchmarkSet
from teacher import Teacher
from lxml import etree
import executecommand
import time

from benchmark import Benchmark


class Pex(Teacher):


    def __init__(self, binary, numVariables, otherArgs):
        Teacher.__init__(self, binary, otherArgs)
        self.numVariables = numVariables
        self.pexReportFormat = 'Xml'
        self.rn = "XmlReport"  
        self.ro = "r1" 
        self.time = 0.0
        
    def runTeacher(self, dll, testMethod, testNamespace, testType):
        self.time = 0.0
        start_time = time.time()
        args = self.getExecCommand(dll, testMethod, testNamespace, testType)
        pexOutput = executecommand.runCommand(args)
        self.time = time.time() - start_time
        # print "pex argument: " + ' '.join(args)
        #sys.exit(0)
        #pexOutput = subprocess.check_output(args , shell=True)
        
        
    def parseReportPre(self, pexReportFolder):
        pexReportFile = os.path.join(pexReportFolder, self.ro, self.rn, "report.per")
        tree = etree.parse(pexReportFile)
        dataPoints = []
        for test in tree.xpath('//generatedTest'):
            
            singlePoint = []
            for value in test.xpath('./value'):
                if re.match("^\$.*", value.xpath('./@name')[0]):
                    singlePoint.append(str(value.xpath('string()')))

            if test.get('status') == 'normaltermination':
                singlePoint.append('true')

            elif test.get('status') == 'assumptionviolation':
                continue
            elif test.get('status') == 'minimizationrequest':
                continue
            # REMIENDER: will need to add more cases for pex internal failures such as the above. We do not want to create feature from these values
            else:
                singlePoint.append('false')
            # alternatives: test.get('failed') => true / None
            # exceptionState
            # failureText
            dataPoints.append(singlePoint)
        return dataPoints
    
    
    
    
    # refactor this later
    def parseReportPost(self, pexReportFolder):
        if True:  #learner.name == "HoudiniExtended":
            pexReportFile = os.path.join(pexReportFolder, self.ro, self.rn, "report.per")
            tree = etree.parse(pexReportFile)
            dataPoints = set()
            for test in tree.xpath('//generatedTest'):
                # REMIENDER: will need to add more cases for pex internal failures such as the above. We do not want to create feature from these values
                if test.get('status') == 'assumptionviolation' or test.get('status') == 'minimizationrequest':
                    continue
                singlePoint = ()
                for value in test.xpath('./value'):
                    if re.match("^\$.*", value.xpath('./@name')[0]):
                        val = str(value.xpath('string()'))
                        val = self.replaceIntMinAndMax(val)
                        singlePoint = singlePoint + (val,)

                if test.get('status') == 'normaltermination':
                    singlePoint = singlePoint + ('true',)

                else:
                    # Houdini - Only positive points
                    singlePoint = singlePoint +('true',)
                    
                if len(singlePoint) < self.numVariables:
                    continue
                dataPoints.add(singlePoint)
            
            return dataPoints

    def getExecCommand(self,testDll, testMethod, testNamespace, testType):
        
        cmd_exec =[self.binary,testDll ,'/membernamefilter:M:'+testMethod+'!', '/methodnamefilter:'+testMethod+'!','/namespacefilter:'+testNamespace +'!', '/typefilter:'+testType+'!']
        cmd_exec.extend(['/ro:'+self.ro, '/rn:'+self.rn,'/rl:'+self.pexReportFormat])
        cmd_exec.extend(self.arguments)
        
        return cmd_exec
    
    def replaceIntMinAndMax(self, number):
        if number.find("int.MinValue") != -1:
            return "-2147483648"
        elif number.find("int.MaxValue") != -1:
            return "2147483647"
        return number