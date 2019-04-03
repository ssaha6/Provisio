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
        PosPoints = []
        NegPoints = []
        for test in tree.xpath('//generatedTest'):
            
            if test.get('status') == 'assumptionviolation' or test.get('status') == 'minimizationrequest':
                continue
            
            singlePoint = []
            
            for value in test.xpath('./value'):
                if re.match("^\$.*", value.xpath('./@name')[0]):
                    val = str(value.xpath('string()'))
                    val = self.sanitizeValue(val)
                    
                    if val:
                        singlePoint.append(val)
            
            if len(singlePoint) != self.numVariables:
                continue
            
            if test.get('status') == 'normaltermination':
                singlePoint.append('true')
                PosPoints.append(singlePoint)
            
            else:
                # DuplicatePath SystemEnvironmentExit Retry PathBoundsExceeded MissingException InconclusiveException ExpectedException Exception
                # ? Which of these statuses means ignore point
                if test.get('name').find("TermDestruction") != -1:
                    continue
                singlePoint.append('false')
                NegPoints.append(singlePoint)
            
        return(PosPoints, NegPoints)
    

    # Check for only assertion violation
    # if 'failureWikiTopic' in test.attrib:
    #     if  test.attrib['failureWikiTopic'] == 'Assertion Violation':
    #         singlePoint.append('false')
    #         NegPoints.append(singlePoint)
    
    
    

    def getExecCommand(self,testDll, testMethod, testNamespace, testType):
        
        cmd_exec =[self.binary,testDll ,'/membernamefilter:M:'+testMethod+'!', '/methodnamefilter:'+testMethod+'!','/namespacefilter:'+testNamespace +'!', '/typefilter:'+testType+'!']
        cmd_exec.extend(['/ro:'+self.ro, '/rn:'+self.rn,'/rl:'+self.pexReportFormat])
        cmd_exec.extend(self.arguments)
        
        return cmd_exec


    def sanitizeValue(self, value):
        value = re.sub(r'\s+', '', value)
        
        try:
            int(value)
            return value
        except :
            pass 
        
        if value == "true" or value == "false":
            return value
        
        try:
            float(value)
            return value
        except :
            pass 
        
        if value.find("int.MinValue") != -1:
            return "-2147483648"
        elif value.find("int.MaxValue") != -1:
            return "2147483647"
        
        if value.find("Count") != -1:
            return ""
        elif value.find('0x') != -1:
            return ""
        else:
            return value
        
        # other possible values 
        # short.MaxValue, short.MinValue
        # uint.MaxValue, 
        # ulong.MaxValue
        # long.MaxValue, long.MinValue
        