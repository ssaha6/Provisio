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

class Pex(Teacher):


	def __init__(self, binary, pexReportFolder, numVariables, otherArgs):
		Teacher.__init__(self, binary, otherArgs)
		self.pexReportFolder = pexReportFolder 
		self.numVariables = numVariables
		self.pexReportFormat = 'Xml'
		self.rn = "XmlReport"  
		self.ro = "r1" 


	def runTeacher(self, dll, testMethod, testNamespace, testType):
		
		args = self.getExecCommand(dll,testMethod,testNamespace,testType)
		#print "pex argument: " + ' '.join(args)
		pexOutput = executecommand.runCommand(args)
	
	# refactor this later
	def generateSamples(self):
		if True:  #learner.name == "HoudiniExtended":
			pexReportFile = os.path.join(self.pexReportFolder, self.ro, self.rn, "report.per")
			tree = etree.parse(pexReportFile)
			dataPoints = []
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
				dataPoints.append(singlePoint)
			
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