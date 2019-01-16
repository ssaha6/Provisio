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
import numpy as np

from learner import Learner
from sygusLIA import SygusLIA
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
        


    def evalauteDataPoint(self, allVariables, dataPoint, allPredicates): 
        
        for i in range(0,  len(allVariables)):
            exec(allVariables[i] + " = " + self.csToPythonData(dataPoint[i]))
        
        extendedPoint = []
        for predicate in allPredicates:
            extendedPoint.append(self.pythonToCSData(eval(predicate)))
        
        return extendedPoint
       
        

    def splitNewOldVariables(self, variableList):
        result = {}
        for i in range(0, len(variableList)):
            match = re.search("(New|Old)_(.*)", variableList[i])
            if match:
                varState, varName = match.group(1), match.group(2)
                if not varState in result:
                    result[varState] = {}
                result[varState][varName] = i                    
                
        return result
        
        
    
    def createFunctionPredicates(self):
        
        intVarSplitByState = self.splitNewOldVariables(self.symbolicIntVariables)
        
        npDataPoints = np.array(self.dataPoints)

        #extract columns    
        # Assuming: 
        #       The data points are structured as: 
        #                  first the integer datapoints, then the boolean datapoints
        intDataPoints = npDataPoints[:, range(0,len(self.symbolicIntVariables))] 
        oldIntVarData = intDataPoints[:,list(intVarSplitByState['Old'].values())] 
        
        result = [] 
        # all the old and new variables can interleaf but order among new is preserved.
        for newIntVar in intVarSplitByState['New'].keys():
            #labels of new datapoints
            fnValue = intDataPoints[:, [intVarSplitByState['New'][newIntVar]]]
                            
            #features of new datapoints
            newdata = np.concatenate((oldIntVarData, fnValue), axis=1) 
            
            sygusLearner = SygusLIA("esolver", "learner/EnumerativeSolver/bin/starexec_run_Default", "grammar=True", "tempLocation")
            
            #variables for new datapoints
            sygusLearner.setVariables( map(lambda x: "Old_" + x, intVarSplitByState['Old'].keys()), [])
            
            nameExpr = " ".join(["(", "=", str("New_" + newIntVar), sygusLearner.learn(newdata.tolist(), simplify=False), ")"])
            
                  
            dataExpr = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, nameExpr)
            
            result.append((nameExpr, dataExpr))
            
        #  Results contains the predicate functions.
        return result


    
    def createThresholdPredicates(self, intVar, dataPoints):
        result = list()
        i = 0
        for i in range(0, len(intVar)):
            
            intVarValues = [row[i] for row in dataPoints]
            maxValue = max(intVarValues)
            minValue = min(intVarValues)
            result.append((
                            "( <= " + intVar[i] + " " + str(maxValue) + ")",
                            "( " + intVar[i] + " <= " + maxValue + " )"
                        ))
                        
            result.append((
                            "( >= " + intVar[i] + " " + str(minValue) + ")",
                            "( " + intVar[i] + " >= " + str(minValue) + ")"
                        ))            
            
        return result
                
        

    def createAllPredicates(self):
        allPredicates = [(x,x) for x in self.symbolicBoolVariables]
        allPredicates = allPredicates + self.createEqualityPredicates(self.symbolicIntVariables)
        allPredicates = allPredicates + self.createFunctionPredicates()
        allPredicates = allPredicates + self.createThresholdPredicates(self.symbolicIntVariables, self.dataPoints)
        
        return zip(*allPredicates)
        
        
    # TODO: Add sanity Check
    def learn(self, dataPoints, simplify=True):
        
        self.setDataPoints(dataPoints)

        # Format: allPredicates  = [ (namesExpr, DataExpr) ] 
        predicateNamesExpr, predicatesDataExpr = self.createAllPredicates()
        
        combinedData = []  
        # iterating over rows
        for point in self.dataPoints:
            combinedData.append(self.evalauteDataPoint(self.symbolicIntVariables + self.symbolicBoolVariables, point[0:-1], predicatesDataExpr) + [point[-1]])
            # all predicates used to evaluate  data in infix
                    
        houdini = Houdini("houdini", "", "", "")
        houdini.setVariables([], predicateNamesExpr)
        # predicates here need to be in prefix...as names
        
        
        #turning simplify off so that it is still in infix form??? 
        result = houdini.learn(combinedData, simplify=False)
        
        
        if simplify:
            result = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, result)
        
        restoredResults = self.restoreVariables(result)
        
        return restoredResults
        
        
        
if __name__ == '__main__':
    
    
    learner = HoudiniExtended("houdini", "", "", "")

    # intVariables = ['oldCount', 's1.Count', 'oldTop', 's1.Peek()', 'oldx', 'x']
    intVariables = ['Old_s1.Count', 'New_s1.Count', 'Old_s1.Peek()', 'New_s1.Peek()', 'Old_x', 'New_x']

    boolVariables = ["Old_s1.Contains(x)"]

    learner.setVariables(intVariables, boolVariables)
    
    dataPoints = [
        ['1', '2', '10', '0', '0', '0', 'true', 'true'],
        ['2', '3', '10', '0', '0', '0', 'true', 'true'],
        ['1', '2', '0', '0', '0', '0', 'true', 'true'],
        ['1', '2', '-5', '2', '2', '2', 'true', 'true'],
        ['1', '2', '0', '1', '1', '1', 'true', 'true'],
        ['1', '2', '1', '0', '0', '0', 'true', 'true'],
        ['1', '2', '2', '0', '0', '0', 'true', 'true']
    ]

    print learner.learn(dataPoints)
    
    