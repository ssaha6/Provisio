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


    #def dataPointsContainsNegPoints(self):
    #   pass

    #def reCompileAndRunPex(self):
    #   pass
        #utils.resetLocation(re.sub('\\\\rep\\\\report.per$', '', self.benchmarkSet.reportFile))

#       csharp.run_compiler(csharp.set_compiler_args(self.compilerCommand, self.benchmarkSet.solutionFile))
#       pex.run_pex(
#   pex.set_pex_args(
#               self.pexBinary, self.benchmarkSet.testDll, self.testMethod, self.benchmarkSet.testNamespace,
#               self.benchmarkSet.testType
#           )
#       )

    #   return reportparser.parseReport(self.benchmarkSet.reportPath)

    # def runPTest(self, precondition):
    #   # Remove all assumes
    #   modifycode.insert_p_in_put(self.benchmarkSet.testFile, precondition, self.testMethod)
    #   ret_p = self.reCompileAndRunPex()
    #   return ret_p

    # def runNotPTest(self, precondition):
    #   modifycode.insert_p_in_put(self.benchmarkSet.testFile, "!(" + precondition + ")", self.testMethod)
    #   # self.insert_assumes(self.benchmarkSet.testFile, self.testMethod)
    #   ret_not_p = self.reCompileAndRunPex()
    #   # cleaning up after not p test
    #   #modifycode.remove_assumes(self.bookmarkSet.testFile, self.testMethod)
    #   return ret_not_p
        
    #def check_precondition(precondition):
    #   pass

    # region: check precondition
    # def check_precondition(precondition):
    #     neg = getNegetiveCE()
    #     pos = getPosetiveCE()
    #     self.insert_p_in_put(vsTestFile, precondition, testMethod)
    #     utils.debug_print("compile for p", False)
    #     self.run_compiler(selfset_compiler_args(vsSolution))

    #     ret_p = self.run_pex(self.set_pex_args(testMethod, vsTestDll, pexBin, vsNamespace, vsType))
    #     #not P Test: getting positive counter examples
    #     self.insert_p_in_put(vsTestFile, "!("+precondition+")", testMethod)
    #     utils.debug_print("Adding assumes in  proj under test..", False)
    #     self.insert_assumes(vsTestFile, testMethod)
    #     #debug = raw_input("debug ")
    #     utils.debug_print("compile for not p", False)
    #     self.run_compiler(selfset_compiler_args(vsSolution))
    #     ret_not_p = self.run_pex(selfset_pex_args(testMethod, vsTestDll, pexBin, vsNamespace, vsType))

    #     #cleaning up after not p test
    #     selfremove_assumes(vsTestFile, testMethod)
    #     # No need to compile again since after inserting precondition a the top of the loop
    #     # will compile again

    #     #utils.debug_print("compile", False)
    #     #selfrun_compiler(selfset_compiler_args(vsSolution))
    # endregion

    #def stoppingCondition():
    #   pass

    # def stoppingCondition(old_precondition, precondition, old_num_predicates, num_predicates):
    #     if old_precondition == precondition and num_pred == old_num_pred:
    #         print "Data Set Size: " + str(num_pred)
    #         print "No Errors Founds!"
    #         print "final Precondition: "
    #         return self.benchmrkSet.testMethod, str(precondition), str(self.loop), self.num_pred

    #     if ret_p == "success" and num_pred == old_num_pred:
    #         print "Data Set Size: " + str(self.num_pred)
    #         print "No Errors Founds!"
    #         print "final Precondition: "
    #         return self.benchmrkSet.testMethod, str(precondition), str(loop), num_pred

    #     if ret_p == "debug" and num_pred == old_num_pred and old_precondition == precondition:
    #         print "Data Set Size: " + str(num_pred)
    #         print "stopping... self case needs debugging - p or not p blocks all (passing, failing) inputs"
    #         print "final Precondition: "
    #         return self.benchmrkSet.testMethod, str(precondition), str(loop), num_pred

    #     if old_precondition == precondition and num_pred == old_num_pred:
    #         """and num_pred == old_num_pred"""
    #         print "Data Set Size: " + str(num_pred)
    #         print ret_p + "! precondition has not changed and no new inputs"
    #         print "final Precondition: "
    #         return self.benchmrkSet.testMethod, str(precondition), str(loop), num_pred

    #     if loop == 50:
    #         print "Data Set Size: " + str(num_pred)
    #         print "max rounds reached: 50"
    #         print "final Precondition: "
    #         return self.benchmrkSet.testMethod, str(precondition), str(loop), num_pred

    #     if( num_pred == old_num_pred):
    #        print "No new inputs added"
    #        print "final Precondition: "+ str(precondition) +" in "+ str(loop)+" rounds"
    #        break
