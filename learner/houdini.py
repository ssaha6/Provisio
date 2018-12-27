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
import z3simplify

class Houdini(Learner):

    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
        
    def generateFiles(self):
        pass

    def readResults(self):
        pass


    def runLearner(self):
        # Numpy implementation, future work
        # A = np.array(np.array(self.dataPoints) == "true")
        # X, y = A[:, :-1], A[:, -1]
        
        
        #Assign all predicate to true
        predAssignment = {varIndex: True for varIndex in range(0, len(self.symbolicBoolVariables))} 
        
        for varIndex in range(0, len(self.symbolicBoolVariables)):
            # not needed, but useful to prune: If a predicate is already evaluated to Flase, skip 
            if predAssignment[varIndex] == False:
                continue
            
            for dp in self.dataPoints:
                #skip negetive points
                if dp[-1] == "false": 
                    continue
                
                #datapoint is posetive 
                #if datapoint on predicate is false
                if dp[varIndex]  == "false":
                    predAssignment[varIndex]  = False
                    break
        
        posPred = []
        for varIndex in range(0, len(self.symbolicBoolVariables)):
            if predAssignment[varIndex]:
                posPred.append(self.symbolicBoolVariables[varIndex])
        
        if len(posPred) == 0:
            conjunct = "false"
        elif len(posPred) == 1:
            conjunct = posPred[0]
        else: 
            conjunct = "( and " + " ".join(posPred) + " )"
        
        return conjunct
        
        
    def createBooleanPredicateData(self, intVars):
        names_file = list()

        if len(intVars) >= 2:
            all_combination = itertools.combinations(intVars, 2)
            for (var1, var2) in all_combination:
                name_expr = " ( " + var1 + " == " + var2 + " ) "
                names_file.append(name_expr)
                name_expr = "(not ("  + var1 + " == " + var2 + "))"
                names_file.append(name_expr)
        return names_file
        
        
    def createBooleanPredicate(self, intVars):
        names_file = list()

        if len(intVars) >= 2:
            all_combination = itertools.combinations(intVars, 2)
            for (var1, var2) in all_combination:
                name_expr = "(= " + var1 + " " + var2 + ")"
                names_file.append(name_expr)
                name_expr = "(not (= "  + var1 + " " + var2 + "))"
                names_file.append(name_expr)

        return names_file
        
        
        
    #TODO: NEEDS CLEANUP
    def learn(self, dataPoints):
        
        booleanPredicatesFeatures = list()
        
        #Convert Variables
        self.symbolicIntVariablesBackup = self.symbolicIntVariables
        booleanPredicatesFeatures =  self.createBooleanPredicate(self.symbolicIntVariables)
        
        print "=================="
        print booleanPredicatesFeatures
        print "=================="
        
        # why clear??
        self.symbolicIntVariables = []

        self.symbolicBoolVariablesBackup = self.symbolicBoolVariables
        # extend list of boolean predicates('equality predicates') with boolean observer method such as collection.Contains(item)  
        booleanPredicatesFeatures.extend(self.symbolicBoolVariables)
        self.symbolicBoolVariables = booleanPredicatesFeatures
        
        newDataPoints = []
        
        
        for dp in dataPoints:
            
            #createBooleanPredicate Assume all variables are integer variables
            consPredicateStr = self.createBooleanPredicateData(dp[0:len(self.symbolicIntVariablesBackup)])
            
            onePoint = eval("["+(",".join(consPredicateStr))+"]")
            onePoint = map((lambda b: "true" if b else "false"), onePoint)
            
            onePoint.extend(dp[len(self.symbolicIntVariablesBackup):])
            # appending to data points
            newDataPoints.append(onePoint)
            
        print "++++++++++++"
        print newDataPoints
        print "++++++++++++"

        self.setDataPoints(newDataPoints)

        #self.generateFiles()
        result =  self.runLearner()


        self.symbolicIntVariables = self.symbolicIntVariablesBackup
        self.symbolicBoolVariables = self.symbolicBoolVariablesBackup
        
        
        simplifiedResults = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, result)    
        restoredResults = self.restoreVariables(simplifiedResults)

        
        print "******  Round Result: "
        return restoredResults


if __name__ == '__main__':
    learner = Houdini("houdini", "", "", "")

    intVariables = ['oldCount', 's1.Count','oldTop','s1.Peek()', 'oldx','x']
    boolVariables = ["s1.Contains(x)"]

    learner.setVariables(intVariables, boolVariables)

    dataPoints = [ ['1','2','10','0','0','0','true','true'],['2','3','10','0','0','0', 'true', 'true'],['1','2','0','0','0','0','true','true'],['1','2','-5','2','2','2','true','true'],['1','2','0','1','1','1','true','true'],['1','2','1','0','0','0','true','true'],['1','2','2','0','0','0','true','true'] ]

    print learner.learn(dataPoints)