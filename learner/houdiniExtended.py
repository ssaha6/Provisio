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
import itertools
import random
from os import sys, path
import reviewData

from learner import Learner
from sygus import Sygus
from houdini import Houdini

import z3simplify


class HoudiniExtended(Learner):

    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
    
    def generateFiles(self):
        pass
    
    def readResults(self):
        pass
    
    
    
    
    def createEqualityPredicates(self, intVars):
        namesDataFile = list()
        if len(intVars) >= 2:
            all_combination = itertools.combinations(intVars, 2)
            for (var1, var2) in all_combination:
                namesExpr = "(= " + var1 + " " + var2 + ")"
                dataExpr = "(" + var1 + " == " + var2 + ")"
                namesDataFile.append((namesExpr, dataExpr))

                namesExpr = "(not (= "  + var1 + " " + var2 + "))"
                dataExpr = "(not ("  + var1 + " == " + var2 + "))"
                namesDataFile.append((namesExpr, dataExpr))
                
        return namesDataFile
        


    def csToPythonData(self, dataString):
        if dataString == "true":
            return "True"
        elif dataString == "false":
            return "False"
        else:
            return dataString
    
    def pythonToCSData(self, dataValue):
        if dataValue == True:
            return "true"
        elif dataValue == False:
            return "false"
        else:
            return dataValue


    def evalauteDataPoint(self, allVariables, dataPoint, allPredicates): 
        
        for i in range(0,  len(allVariables)):
            exec(allVariables[i] + " = " + self.csToPythonData(dataPoint[i]))
        
        extendedPoint = []
        for predicate in allPredicates:
            extendedPoint.append(self.pythonToCSData(eval(predicate)))
        
        return extendedPoint
        
        
    # TODO: Add sanity Check
    def learn(self, dataPoints):
        
        self.setDataPoints(dataPoints)

        # Format: allPredicates  = [ (namesExpr, DataExpr) ] 
        allPredicates = [(x,x) for x in self.symbolicBoolVariables]
        allPredicates = allPredicates + self.createEqualityPredicates(self.symbolicIntVariables)
        # allPredicates = allPredicates + self.createFunctionPredicates(intvars, boolvars)
        
        predicateNamesExpr, predicatesDataExpr = zip(*allPredicates)
        
        combinedData = []  
        for point in self.dataPoints:
            combinedData.append(self.evalauteDataPoint(self.symbolicIntVariables + self.symbolicBoolVariables, point[0:-1], predicatesDataExpr) + [point[-1]])
            # all predicates used to evaluate  data in infix
                    
        houdini = Houdini("houdini", "", "", "")
        houdini.setVariables([], predicateNamesExpr)
        # predicates here need to be in prefix...as names
        
        
        #turning simplify off so that it is still in infix form??? 
        result = houdini.learn(combinedData, simplify=False)
        
        
        result = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, result)

        restoredResults = self.restoreVariables(result)
        
        print restoredResults
        
        
        
if __name__ == '__main__':
    
    
    learner = HoudiniExtended("houdini", "", "", "")

    intVariables = ['oldCount', 's1.Count','oldTop','s1.Peek()', 'oldx','x']
    boolVariables = ["s1.Contains(x)"]

    learner.setVariables(intVariables, boolVariables)
    
    dataPoints = [ ['1','2','10','0','0','0','true','true'],['2','3','10','0','0','0', 'true', 'true'],['1','2','0','0','0','0','true','true'],['1','2','-5','2','2','2','true','true'],['1','2','0','1','1','1','true','true'],['1','2','1','0','0','0','true','true'],['1','2','2','0','0','0','true','true'] ]

    print learner.learn(dataPoints)
    
    