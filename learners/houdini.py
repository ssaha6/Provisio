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

import reviewData
from learner import Learner
import shell

class Houdini(Learner):


    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
        
        
    def generateFiles(self):
        #assert there are no integers
        assert(len(self.intVariables) == 0)
    
        #asset all data point elements are "true" or "false"
        assert(all ( all( v == "true" or v == "false" for v in dp) for dp in self.dataPoints))
        

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
        
def createBooleanPredicate(intVars):
	names_file = list()

	#createEquality
	#predValues = map()
	#if len(intVars) >= 2:
	#		for i in xrange(0, len(intvars)):
	#			for n in xrange(i,len(intvars) )
	#				expr = "(" + intVars[i] + " = " + intVars[n] + ")"
	if len(intVars) >= 2:
	    all_combination = itertools.combinations(intVars, 2)
	    for (var1, var2) in all_combination:
			name_expr = var1 + " == " + var2
			names_file.append(name_expr)

	return names_file

if __name__ == '__main__':
	learner = Houdini("houdini", "", "", "")

	intVariablesTemp = [ 'oldCount' , 's1.Count','oldTop','s1.Peek()', 'oldx','x']
	boolVariablesTemp = ["s1.Contains(x)"]

	dataPoints = list()

	#samples: [(integer values, boolean values, label) ] label should always be true
	samples =[ (['1','2','10','0','0','0'],['true'],'true'), (['2','3','10','0','0','0'],['true'],'true') ]
	#=================================================================================

	booleanPredicatesFeatures =  createBooleanPredicate(intVariablesTemp)
	
	booleanPredicatesFeatures.extend(boolVariablesTemp)
	
	for sampInt,sampBool,label in samples:
		
		#createBooleanPredicate Assume all variables are integer variables
		consPredicateStr = createBooleanPredicate(sampInt)
		
		onePoint = eval("["+(",".join(consPredicateStr))+"]")
		onePoint = map((lambda b: "true" if b else "false"), onePoint)

		onePoint.extend(sampBool)
		onePoint.append(label)
		# appending to data points
		dataPoints.append(onePoint)
	
	print dataPoints
	#sys.exit(0)
	
	integerFeatures = []
	#boolVariables = ['b1', 'b2', ]
	learner.setVariables(integerFeatures, booleanPredicatesFeatures)

	# dataPoints =[
	#             ["true", "false", "true"],
	#             ["true", "true", "true"],
	#             ["true", "true", "true"],
	#             ["true", "true", "true"],
	#             ]

	# learner.setDataPoints(dataPoints)
	# learner.runLearner()
	print learner.learn(dataPoints)
    

