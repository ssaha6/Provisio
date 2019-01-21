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

    learntConjuction =[]
    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)


    def generateFiles(self):
        pass

    def readResults(self):
        pass

    #Optimization: No further re-writing needed. Predicates are in z3 format(infix form)
    def setVariables(self, intVariables = [], boolVariables = []):
        #TODO:  assert boolVariables are in prefix notation
        #assert there are no integers
        assert(len(intVariables) == 0)
        self.symbolicIntVariables = intVariables
        self.symbolicBoolVariables = boolVariables
    
    def restoreVariables(self, Conjunction):
        return Conjunction

    # TODO: Add sanity Check
    def runLearner(self):
        #print os.linesep+ " bool variables renamed again: " + str(self.symbolicBoolVariables)
        # Numpy implementation, future work
        # A = np.array(np.array(self.dataPoints) == "true")
        # X, y = A[:, :-1], A[:, -1]
        
        #asset all data point elements are "true" or "false"
        if len(self.dataPoints) == 0:
            self.learntConjuction = ["true"]
            return "true"

        assert(len(self.dataPoints) or all ( all( v == "true" or v == "false" for v in dp) for dp in self.dataPoints))
        
        #Assign all predicate to true
        predAssignment = {varIndex: True for varIndex in range(0, len(self.symbolicBoolVariables))} 
        
        for varIndex in range(0, len(self.symbolicBoolVariables)):
            # not needed, but useful to prune: If a predicate is already evaluated to Flase, skip 
            if predAssignment[varIndex] == False:
                continue
            
            for dp in self.dataPoints:
                #There are no negative points for postcondition learning!!! Should not check for this
                if dp[-1] == "false":
                    #continue 
                    raise ValueError("Inspect ME, I may be wrong")
                
                #datapoint is posetive 
                #if datapoint on predicate is false
                if dp[varIndex]  == "false":
                    predAssignment[varIndex]  = False
                    break
        
        posPred = []
        for varIndex in range(0, len(self.symbolicBoolVariables)):
            if predAssignment[varIndex]:
                posPred.append(self.symbolicBoolVariables[varIndex])
        


        # This is also wrong!, if no positive predicates than we should not output false but rather TRUE;
        if len(posPred) == 0:
            conjunct = "true"
            # Quick Fix- to return list
            self.learntConjuction = ["true"]
        
        elif len(posPred) == 1:
            conjunct = posPred[0]
            # Quick Fix- to return list
            self.learntConjuction = posPred
        else: 
            conjunct = "(and " + " ".join(posPred) + ")"
            self.learntConjuction = posPred
        #print os.linesep+ "conjunct from houdini: "+ conjunct
        return conjunct
        
       
        


if __name__ == '__main__':
    
    learner = Houdini("houdini", "", "", "")
    
    intVariables = []
    boolVariables = ['b1', 'b2', ]
    learner.setVariables(intVariables, boolVariables)
    dataPoints =[
                ["false", "false", "true"],
                ["true", "true", "false"],
                ["false", "true", "true"],
                ["true", "false", "false"],
                ]
   
    # learner.setDataPoints(dataPoints)
    # learner.runLearner()
    
    print learner.learn(dataPoints)
    