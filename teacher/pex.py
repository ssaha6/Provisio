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

from benchmark import Benchmark


class Pex(Teacher):


	def __init__(self, binary, numVariables, otherArgs):
		Teacher.__init__(self, binary, otherArgs)
		self.numVariables = numVariables
		self.pexReportFormat = 'Xml'
		self.rn = "XmlReport"  
		self.ro = "r1" 
		
		
	def runTeacher(self, dll, testMethod, testNamespace, testType):
		
		args = self.getExecCommand(dll,testMethod,testNamespace,testType)
		print "pex argument: " + ' '.join(args)
		#sys.exit(0)
		#pexOutput = subprocess.check_output(args , shell=True)
		pexOutput = executecommand.runCommand(args)
		
		
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
	def generateSamplesPost(self, pexReportFolder):
		if True:  #learner.name == "HoudiniExtended":
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
					# Houdini - Only positive points
					singlePoint.append('')
					
				if len(singlePoint) < self.numVariables:
					continue
				
				dataPoints.append(singlePoint)
			
			return dataPoints

	def getExecCommand(self,testDll, testMethod, testNamespace, testType):
		
		cmd_exec =[self.binary,testDll ,'/membernamefilter:M:'+testMethod+'!', '/methodnamefilter:'+testMethod+'!','/namespacefilter:'+testNamespace +'!', '/typefilter:'+testType+'!']
		cmd_exec.extend(['/ro:'+self.ro, '/rn:'+self.rn,'/rl:'+self.pexReportFormat])
		cmd_exec.extend(self.arguments)
		
		return cmd_exec


	#def run_pex(args):
		#try:
			#pexOutput = executecommand.runCommand(args)
			# ????????????????????
			# if re.match('0 Error\(s\)', compilerOutput):
			#		 return
			#	 else:
			#		 raise ValueError('Pex Exploration has errors')
		#except Exception as e:
			#utils.debug_print("PEX Exception", True)
			#utils.printExceptionAndExit(e, "PEX error")


#Passing test
# <generatedTest id = "f16b07ac-faec-4fa6-9de2-b524c6e3725e" index = "2" run = "11" status = "normaltermination" generated = "true" new = "true" assemblyName = "DataStructuresTest" name = "PUT_CommutativityPeekPeekComm740" >

#failing test
# <generatedTest id="393c0160-be18-469d-84a2-d9e761312af1" index="1" run="9" exceptionState="unexpected" status="exception" failed="true" failureText="Exception not validated by contract requires failure at type-under-test surface, documented." generated="true" new="true" assemblyName="DataStructuresTest" name="PUT_CommutativityPeekPeekCommThrowsInvalidOperationException381">

# region
# def run_pex(self, args):
#	 try:
#		 print(args)
#		 pexOutput = ""
#		 # utils.debug_print('Pex is running', False)
#		 # args = ' '.join(args)
#		 # print(args)
#		 # pex_output = subprocess.check_output(args , shell=True) #stderr= subprocess.STDOUT

#		 pexRun = subprocess.Popen(args, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
#		 for line in pexRun.stdout:
#			 pexOutput = pexOutput + os.linesep + str(line.rstrip())
#		 pexRun.stdout.close()

#		 print(pex_output)
#	 except Exception as e:
#		 print(pexOutput)
#		 utils.printExceptionAndExit(e, "PEX Error")

#		 m = re.search('(.*)(EXPLORATION SUCCESS)(.*)',pex_output,re.DOTALL)
#		 m = re.search('(.*)(Pex Done Generating Tests)(.*)',pex_output,re.DOTALL )
#		 if m:
#			 try:
#			 #print "regex search succeeded"
#				 #parser_output = m.group(3)
#				 #print pex_output
#				 parser_output = m.group(3)
#				 #if(parser_output is None):
#				 #	print 'bug'
#				 #	sys.exit(-1)
#				 #print "Parser Output:"
#				 #print parser_output
#				 ind = parser_output.find('Passing Test: ')
#				 indFail =parser_output.find('Failing Test: ')
#				 if ind != -1:
#					 if not (parser_output[ind+14:len(parser_output)].find(os.linesep) is None):
#						 #passing =  parser_output[ind+14:((ind+14) + (parser_output[ind+14:len(parser_output)-1].find(os.linesep)))]
#						 if indFail != -1:
#							 passing =  parser_output[ind+14:indFail]
#						 else:
#							 passing =  parser_output[ind+14:]

#						 if not (passing is None):
#							 utils.debug_print("(From run.py) Passing Test: "+ passing, False)

#				 if indFail != -1:
#					 #print '(From run.py) Failing Test: '+ parser_output[indFail+14:((indFail+14) +(parser_output[indFail+14:len(parser_output)-1].find(os.linesep)))]
#					 failing =  parser_output[indFail+14:]
#					 if not (failing is None):
#						 utils.debug_print("(From run.py) Failing Test: "+ failing, False)

#				 if parser_output.find("Pex Found No Error") != -1:
#					 return "success"
#				 if parser_output.find("No passing or failing inputs were generated") != -1:
#					 return "debug"
#				 return "not done yet"

#			 except Exception as ex:
#				 template = "An exception of type {0} occurred. Arguments:\n{1!r}"
#				 message = template.format(type(ex).__name__, ex.args)
#				 print message
#				 print str("-"*60)
#				 traceback.print_exc(file=sys.stdout)
#				 print str("-"*60)
#				 print "Pex STDOUT: "
#				 print pex_output
#				 utils.printExceptionAndExit(ex, "PEX exception occured")

#		 else:
#			 utils.debug_print('something went wrong in PEX', True)
#			 utils.debug_print(pex_output, True)
#			 raise ValueError()

#	 except ValueError as err:
#		 print "type"
#		 print type(err)
#		 utils.debug_print("Pex Exited Abnormally", True)
#		 utils.printExceptionAndExit(err, "Pex Exited Abnormally")

#	 except IOError as e:
#		 print "Pex STDOUT: "
#		 print pex_output

#		 print str("-"*60)
#		 traceback.print_exc(file=sys.stdout)
#		 print str("-"*60)
# endregion
