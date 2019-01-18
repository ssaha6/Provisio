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
import math

from houdiniExtended import HoudiniExtended
import z3simplify


class DisjunctiveLearner(HoudiniExtended):


    def __init__(self, name, binary, parameters, tempLocation):
        HoudiniExtended.__init__(self, name, binary, parameters, tempLocation)
    
    def generateFiles(self):
        pass
    
    def readResults(self):
        pass
    
    
    def shannonsEntropy(self, labels, base=None):
        value,counts = np.unique(labels, return_counts=True)
        norm_counts =  np.true_divide(counts, counts.sum())
        base = math.e if base is None else base
        return - (norm_counts * np.log(norm_counts) / np.log(base)).sum()
        
        
    # TODO: extremely inefficient
    def evalautePredicate(self, predicate, dataPoint ):
        
        allVariables = self.symbolicIntVariables + self.symbolicBoolVariables
        for i in range(0,  len(allVariables)):
            exec(allVariables[i] + " = " + self.csToPythonData(dataPoint[i]))
        
        return eval(predicate)
        
            
            
    # For any set of (positive) samples S, let me define a similarity measure
    # Sim(S):   
    #     Take every predicate r and look at the vector v where
    #     v[i]=+ if example i has p to be true and 
    #     v[i]=- if example i has p to be false
    #     Compute the entropy of this set.
    #     Sum the above up for every r
    
    def similarity(self, dataPoint, predicateNamesExpr, predicatesDataExpr):
        
        entropySum = 0
        for predicate in predicatesDataExpr:
            v = []
            for data in dataPoints:
                if self.evalautePredicate(predicate,data):
                    v.append("+")
                else:
                    v.append("-")
                    
            entropySum = entropySum + self.shannonsEntropy(v)
        return entropySum
    
    
    # TODO: genrate all preedicates
    
    
    def dividedata(self, predicate, dataPoints):
        allVariables = self.symbolicIntVariables + self.symbolicBoolVariables
        
        pos = []
        neg = []
        for dp in dataPoints:
            for i in range(0,  len(allVariables)):
                exec(allVariables[i] + " = " + self.csToPythonData(dp[i]))
        
            if eval(predicate):
                pos.append(dp)
            else:
                neg.append(dp)
              
        return (pos, neg)  
    
    # So the algorithm now does this. It picks each predicate p, and splits the sample
    # into S_p and S_notp. It then looks at the sum of Sim(S_p) and Sim(S_notp).
    # Note that this is already quadratic time (so this makes sense perhaps only
    # when we have more than two variables to choose to split on).
    # We then choose the p that has the minimum sum of Sims on splits, greedily.
    # Once we choose p, we dont look back. We examine each remaining set; if its
    # coverable by a conjunctive formula with a large number of conjuncts, we go ahead
    # with that conjunct.Otherwise we look for another variable to split on.

    def learn(self, dataPoints, simplify=True):
        
        self.setDataPoints(dataPoints)
        
        predicateNamesExpr, predicatesDataExpr = self.createAllPredicates()
        
        # print self.similarity(self.dataPoints, predicateNamesExpr, predicatesDataExpr)
        
        
        similarityScore = {}
        for predicate in predicatesDataExpr:
            posPoints, negPoints = self.dividedata(predicate, self.dataPoints)
            similarityScore[predicate] = self.similarity(posPoints, predicateNamesExpr, predicatesDataExpr ) + self.similarity(negPoints, predicateNamesExpr, predicatesDataExpr )
            
        print similarityScore
        
        # for key, value in sorted(x.items(), key=operator.itemgetter(1), reverse=True):
        #     learner = HoudiniExtended("houdini", "", "", "")
        #     learner.setVariables(self.symbolicIntVariables, self.symbolicBoolVariables)
        #     result = learner.learn(self.dataPoints, simplify=False)
        
        #     if result != False:
        #         break
        
        
        
            
        # return self.similarity(result)
        
        # for predicate in AllPredicate:
        #     learner.setVariables(intVariables, boolVariables)
        #     dp, notdp = divide data
        #     leftPredicate[predicate] = learner.learn(dp, simplify=False)
        #     rightPredicate[predicate] = learner.learn(notdp, simplify=False)
        #     score[predicate] = similarity(learnleft) + similarity(learnright)
        #     maxscore <= score
        #         maxscore = score
        #         maxpred = predicate
        # finalExpression = (or leftPredicate[maxpred] rightPredicate[maxpred])
        
        # if simplify:
        #     result = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, result)
        # restoredResults = self.restoreVariables(result)
        # return finalExpression
        
    
    
    
if __name__ == '__main__':
    
    
    learner = DisjunctiveLearner("disjunctiveLearner", "", "", "")
    
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
    
    
 