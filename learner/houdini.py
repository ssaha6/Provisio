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

    
    # TODO: Add sanity Check
    def runLearner(self):
        # Numpy implementation, future work
        # A = np.array(np.array(self.dataPoints) == "true")
        # X, y = A[:, :-1], A[:, -1]
        
        
        #assert there are no integers
        assert(len(self.intVariables) == 0)

        #asset all data point elements are "true" or "false"
        assert(all ( all( v == "true" or v == "false" for v in dp) for dp in self.dataPoints))
        
        
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
    