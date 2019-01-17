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
		testClass = "C:/Users/astor/PexResearchTools/DataDriven/reportparserlearning/BenchmarksAll/DataStructures/DataStructuresTest/StackContractTest.cs"
		putName = "PUT_PushContract"
		solutionFile = "C:/Users/astor/PexResearchTools/DataDriven/reportparserlearning/BenchmarksAll/DataStructures/DataStructures.sln"
		testType = "StackContractTest"
		testNamespace = "DataStructures.Test"
		testDll = "C:/Users/astor/PexResearchTools/DataDriven/reportparserlearning/BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll"
		allPostconditions = []
		allDataPoints = []
		postcondition = "true"
		round = 1
		while True:
			
			modifycode.insertPostConditionInPexAssert(testClass,postcondition,putName)
			modifycode.runCompiler("MSBuild.exe",solutionFile)
			
			#def runTeacher(self, dll, testMethod, testNamespace, testType):
			self.teacher.runTeacher(testDll, putName,testNamespace, testType)
			datapoints = self.teacher.generateSamples("houdini")
			print datapoints
			allDataPoints.extend(datapoints)
			postcondition = self.learner.learn(allDataPoints)
			print "round: "+ str(round) + postcondition

			if postcondition in allPostconditions:
				break
			
			allPostconditions.append(postcondition)
			round = round +1

if __name__ == '__main__':

	learner = Houdini("houdini","","","")
	intVariables = ['oldCount', 's1.Count','oldTop','s1.Peek()', 'oldx','x']
	boolVariables = ["s1.Contains(x)"]
	learner.setVariables(intVariables, boolVariables)

	rootPathReport = 'C:\Users\\astor\PexResearchTools\DataDriven\MultiLearnerPrecondition'
	reportDirName = 'report'
	reportFormat = 'Xml'
	teacher = Pex("pex.exe", rootPathReport,reportDirName,reportFormat ,['/nor'])
	framework = Framework(learner, teacher)
	framework.learnPostcondition()


#     #Max Rounds seen in evaluations of data structure 22: so set max rounds to 50.
#     def dataStructureTest(this, testMethod, boolparams, intparams, vsSolution, vsTestFile, vsTestDll, pexBin, vsNamespace, vsType, c5Bin, typeLearner, threshold, learnerOutDir):
#         print "Beginning! -- initializing"
#         this.removeOldPreFiles(testMethod, learnerOutDir)
#         #remove_assumes(vsClassFile ,mut)

#         intparams
#         this.create_names_file_with_bool(boolparams, intparams, -1, 1, '{}\{}'.format(learnerOutDir, 'pre.names'))
#         old_precondition = "true"
#         precondition = "true"
#         #this.debug_print("cleaning solution...", False)

#         loop = 1
#         old_num_pred = 0
#         num_pred = 0

#         while True:
#             print "loop count: " + str(loop)
#             ret_p = ""
#             ret_not_p = ""
#             ret = ""

#             #P Test: getting negative counter examples
#             this.insert_p_in_put(vsTestFile, precondition, testMethod)
#             this.debug_print("compile for p", False)
#             this.run_compiler(this.set_compiler_args(vsSolution))

#             ret_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin, vsNamespace, vsType))

#             #not P Test: getting positive counter examples
#             this.insert_p_in_put(vsTestFile, "!("+precondition+")", testMethod)
#             this.debug_print("Adding assumes in  proj under test..", False)
#             this.insert_assumes(vsTestFile, testMethod)
#             #debug = raw_input("debug ")
#             this.debug_print("compile for not p", False)
#             this.run_compiler(this.set_compiler_args(vsSolution))
#             ret_not_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin, vsNamespace, vsType))

#             #cleaning up after not p test
#             this.remove_assumes(vsTestFile, testMethod)
#             # No need to compile again since after inserting precondition a the top of the loop
#             # will compile again

#             #this.debug_print("compile", False)
#             #this.run_compiler(this.set_compiler_args(vsSolution))

#             #sort data - get number of unique examples- resolve csonflict.
#             num_pred = this.sort_and_unique_preds('{}\{}'.format(learnerOutDir, 'pre.data'), False, loop, testMethod)

#             #call learner
#             this.call_c50(this.set_c50_args(('{}\{}'.format(learnerOutDir, 'pre')), c5Bin, typeLearner, threshold))
#             precondition = this.get_pre_from_json('{}\{}'.format(learnerOutDir, 'pre.json'))
#             this.debug_print("Precondition Learned: " + str(precondition)+os.linesep, True)

#             #debug = raw_input("check p test data points ")
#             #debug = raw_input("debug ")
#             #debug = raw_input("debug ")

#             if old_precondition == precondition and num_pred == old_num_pred:
#                 print "Data Set Size: " + str(num_pred)
#                 print "No Errors Founds!"
#                 print "final Precondition: "
#                 return testMethod, str(precondition), str(loop), num_pred

#             if ret_p == "success" and num_pred == old_num_pred:
#                 print "Data Set Size: " + str(num_pred)
#                 print "No Errors Founds!"
#                 print "final Precondition: "
#                 return testMethod, str(precondition), str(loop), num_pred

#             if ret_p == "debug" and num_pred == old_num_pred and old_precondition == precondition:
#                 print "Data Set Size: " + str(num_pred)
#                 print "stopping... This case needs debugging - p or not p blocks all (passing, failing) inputs"
#                 print "final Precondition: "
#                 return testMethod, str(precondition), str(loop), num_pred

#             if old_precondition == precondition and num_pred == old_num_pred:
#                 """and num_pred == old_num_pred"""
#                 print "Data Set Size: " + str(num_pred)
#                 print ret_p + "! precondition has not changed and no new inputs"
#                 print "final Precondition: "
#                 return testMethod, str(precondition), str(loop), num_pred

#             if loop == 50:

#                 print "Data Set Size: " + str(num_pred)
#                 print "max rounds reached: 50"
#                 print "final Precondition: "
#                 return testMethod, str(precondition), str(loop), num_pred
#             #if( num_pred == old_num_pred):
#             #    print "No new inputs added"
#             #    print "final Precondition: "+ str(precondition) +" in "+ str(loop)+" rounds"
#             #    break

#             old_precondition = precondition
#             old_num_pred = num_pred
#             ret_p = ""

#             loop += 1
