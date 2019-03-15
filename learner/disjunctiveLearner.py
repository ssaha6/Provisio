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

from learner import Learner
from houdiniExtended import HoudiniExtended
from houdini import Houdini

import z3simplify
import logging




logger = logging.getLogger("Framework.DisjunctLearner")
# TODO: calling learner.SetDataPoints changes list of list to list of tuples.

class DisjunctiveLearner(Learner):


    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
        self.entropy = True
        self.numerical = True
        self.allPredicates = True

    def generateFiles(self):
        pass

    def readResults(self):
        pass

    def splitSamples(self, predicate, houdiniEx, datapoints):
        allInputVariables = self.intVariables + self.boolVariables
        pos = []
        neg = []
        for dp in datapoints:
            state = houdiniEx.createStateInformation(
                allInputVariables, dp[0:-1])
            if eval(predicate, state):
                pos.append(dp)
            else:
                neg.append(dp)

        return pos, neg

            #remove the predicate we are splitting on from vocabulary
            #predicatesToSplitOnCopy = list(predicatesToSplitOn)
            
            #predicatesToSplitOn.remove(predicateSplitP)
            #columnsToKeep = range(i)
            #columnsToKeep.extend(range(i+1,len(boolPDatapoints[0])))
            
            #numpyBoolPDatapoints = np.array(boolPDatapoints)[:,columnsToKeep]
            #numpyBoolNegPDatapoints = np.array(boolNegPDatapoints)[:,columnsToKeep]

            #columnPredicateSplitPosEval= 
            #columnPredicateSplitNegEval= boolNegPDatapoints[i]

            #add predicateSplit back to list otherwise indexOutRangeException at loopheader
            #predicatesToSplitOn.insert(i,predicateSplitP)
            #
            #houd.setVariables([], remainingPredicatesInfix)
            #conjP = houd.learn(numpyBoolPDatapoints.tolist(), simplify=False)
            # add predicate we are splitting on to left side of disjunction
            #conjPList = [predicateSplitP] + conjPList
            #conjN = houd.learn(numpyBoolNegPDatapoints.tolist(), simplify=False)
            
            #add predicateSplit back to list otherwise indexOutRangeException at loopheader
            #predicatesToSplitOn.insert(i,predicateSplitP)
            #boolPDatapoints.insert(i,columnPredicateSplitPosEval)
            #boolNegPDatapoints.insert(i,columnPredicateSplitNegEval)
    def scorePredicatesToSplitOn(self,candidatePredicatesToSplitOn, houdiniEx, houd ):
        score = []
        for i in xrange(0, len(candidatePredicatesToSplitOn)):
            positiveP = []
            negativeP = []
            predicateSplitP = candidatePredicatesToSplitOn[i]
            positiveP, negativeP = self.splitSamples(predicateSplitP, houdiniEx, self.dataPoints)
            assert(len(positiveP) + len(negativeP) == len(self.dataPoints))
            if len(positiveP) == 0 and len(negativeP) > 0:
                #predicate is always false so skip it:
                continue            
            # a predicate can only be true or false  
            assert( (not (len(positiveP) == 0 and len(negativeP) == 0)) )
            #this should never happen otherwise. We are only dealing with predicates that are not always true.
            assert((not (len(positiveP) > 0 and len(negativeP) == 0 )) )
            # if we don't fail then we are in this case: len(positiveP) > 0 and len(negativeP) > 0:
            boolPositiveDatapoints = []
            boolNegativeDatapoints = []
            allInputVariables = self.intVariables + self.boolVariables
            boolPositiveDatapoints = houdiniEx.computeBooleanDataPoints(allInputVariables,candidatePredicatesToSplitOn, positiveP)
            boolNegativeDatapoints = houdiniEx.computeBooleanDataPoints(allInputVariables,candidatePredicatesToSplitOn, negativeP)
            
            assert(len(boolPositiveDatapoints) > 0)
            assert(len(boolNegativeDatapoints) > 0)
            
            houd.setVariables([], candidatePredicatesToSplitOn)
            conjP = houd.learn(boolPositiveDatapoints, simplify=False)
            conjPList = houd.learntConjuction
            conjN = houd.learn(boolNegativeDatapoints, simplify=False)
            conjNList = houd.learntConjuction
            
            posMultiplier = len(conjPList)
            negMultiplier = len(conjNList)
            if len(conjPList) == 1 and 'true' in conjPList:
                posMultiplier = 0
            if len(conjNList) == 1 and 'true' in conjPList:
                negMultiplier = 0

            plusLabel = ['+'] * posMultiplier
            minusLabel = ['-'] * negMultiplier
            entropyR = 0
            if self.entropy:
                entropyR = self.shannonsEntropy(plusLabel+minusLabel)
            else:
                entropyR = self.scoreByLen(conjPList,conjNList) 
            #score.append({'predicate': predicateSplitP,
            # 'score':self.scoreByLen(conjPList, conjNList) , 'left': conjPList, 'right': conjNList})
            score.append({'predicate': predicateSplitP,
                          'score': entropyR, 'left': conjPList, 'right': conjNList})

        return score

    def learn(self, dataPoints, simplify=True):
        assert (len(dataPoints) != 0)
        # Intuition: Only need HoudiniExt to call createAllPredicates()
        # Need Houdini to Learn conjunction
        self.setDataPoints(dataPoints)
        ##logger.info("learner "+ str(self.entropy) +str(self.numerical)+ str(self.allPredicates))
        
        houdiniEx = HoudiniExtended("HoudiniExtended", "", "", "")
        houdiniEx.setVariables(self.intVariables, self.boolVariables)
        houdiniEx.setDataPoints(self.dataPoints)
        # for debugging
        houdiniEx.numerical = self.numerical
        
        if len(self.dataPoints) == 1:
            return houdiniEx.learn(self.dataPoints, simplify=True)
        # createAllPredicates() returns
        allSynthesizedPredicatesPrefix, allSynthesizedPredicatesInfix = houdiniEx.createAllPredicates()
        booleanData = []
        allInputVars = []
        allInputVars = self.intVariables+self.boolVariables
        # the infix form of the predicates are used to evalute them (into true or false
        booleanData = houdiniEx.computeBooleanDataPoints(allInputVars, allSynthesizedPredicatesInfix, self.dataPoints)

        # Call Houdini directly
        # Compute All True predicates
        listAllSynthesizedPredInfix = list(allSynthesizedPredicatesInfix)
        houd = Houdini("Houdini", "", "", "")
        houd.setVariables([], listAllSynthesizedPredInfix)
        houd.learn(booleanData, simplify=False)
        #TODO: if houd.LearntConjunction is true, then either we cannot express post condition
        #or postcondition requires disjunction; In case it requires disjunction we need to change the format
        # of output formula at the end of this code
        assert(not (len(houd.learntConjuction) == 1 and "true" in houd.learntConjuction))
        assert(len(houd.learntConjuction) > 0)
        alwaysTruePredicateInfix = []        
        alwaysTruePredicateInfix = houd.learntConjuction

        # TODO: compute with prefix otherwie z3 throws error
        remainingPredicatesInfix = list(set(
            listAllSynthesizedPredInfix).symmetric_difference(set(alwaysTruePredicateInfix)))
        # remainingPredicatesPrefix = list(set(listAllSynthesizePredPrefix).symmetric_difference(set(alwaysTruePredicateInfix)))
        # for computing disjunctions, we only need to considr p or not p both not both
        mapPredicateScores = []
        sorteMapPredicateScores = []

        mapPredicateScores = self.scorePredicatesToSplitOn(remainingPredicatesInfix, houdiniEx, houd)
        
        if len(mapPredicateScores) == 0:
            # This is the case where we could not find a predicate to split on
            alwaysTruePrefix = self.findPrefixForm(alwaysTruePredicateInfix,
                                               allSynthesizedPredicatesInfix, allSynthesizedPredicatesPrefix)
            z3StringFormula = "(and " +' '.join(alwaysTruePrefix)+")"
            z3StringFormula = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, z3StringFormula)
            return z3StringFormula
                         
        mapPredicateScores = sorted(mapPredicateScores, key=lambda x: x['score'])
        leftDisjunct = []
        rightDisjunct = []
        choosePtoSplitOn = ""
        if not self.entropy:
            choosePtoSplitOn = mapPredicateScores[-1]['predicate']
            leftDisjunct = mapPredicateScores[-1]['left']
            rightDisjunct = mapPredicateScores[-1]['right']
        else:
            for pred in mapPredicateScores:
                if pred['score'] != 0:
                    #print "predicate:"
                    #print pred['predicate']
                    choosePtoSplitOn = pred['predicate']
                    #print "left:"
                    #print pred['left']
                    leftDisjunct = pred['left']
                    #print "right:"
                    #print pred['right']
                    rightDisjunct = pred['right']
                    break

        #print "always true: "
        #print alwaysTruePredicateInfix
        #logger.info(' '.join(alwaysTruePredicateInfix))
        alwaysTruePrefix = self.findPrefixForm(alwaysTruePredicateInfix,
                                               allSynthesizedPredicatesInfix, allSynthesizedPredicatesPrefix)
        
        
        
        #print "or"
        #print leftDisjunct
        #logger.info(' '.join(leftDisjunct))

        leftDisjunctPrefix = self.findPrefixForm(leftDisjunct,
                                                 allSynthesizedPredicatesInfix, allSynthesizedPredicatesPrefix)
        #print rightDisjunct
        #logger.info(' '.join(rightDisjunct))

        rightDisjunctPrefix = self.findPrefixForm(
            rightDisjunct, allSynthesizedPredicatesInfix, allSynthesizedPredicatesPrefix)
        
        self.debugSplitDisjunction(leftDisjunct,leftDisjunctPrefix,rightDisjunct,rightDisjunctPrefix,alwaysTruePrefix,choosePtoSplitOn)
        
        if self.allPredicates:
            z3StringFormula = "(and " +' '.join(alwaysTruePrefix) + "(or " + "(and " + ' '.join(leftDisjunctPrefix) + ") " +"(and "+ ' '.join(rightDisjunctPrefix) +")))"
            z3FormulaInfix = ' && '.join(alwaysTruePredicateInfix)  + " && ((" +' && '.join(leftDisjunct) +") || (" +' && '.join(rightDisjunct)+ "))"             
        else:
            z3StringFormula = "(or " + "(and " + ' '.join(leftDisjunctPrefix) + ") " +"(and "+ ' '.join(rightDisjunctPrefix) +"))"
            z3FormulaInfix = "("+ ' && '.join(leftDisjunct) +" || " +' && '.join(rightDisjunct)+ ")"             

        #logger.info("Raw z3 formula: "+ z3StringFormula)
        logger.info("###### Raw Z3: ")
        logger.info("###### "+z3FormulaInfix)

        z3StringFormula = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, z3StringFormula)
       
        #logger.info("Simplified z3 formula: "+z3StringFormula)
        logger.info("###### Simplified Z3 Final formula: ")
        logger.info("###### "+z3StringFormula+ os.linesep)
        #print z3StringFormula
        #return alwaysTrueSimp + " && ( "+leftSimp+" || "+ rightSimp  +")"
        return z3StringFormula
        # return "(Old_s1Count != New_s1Count )"

    def findPrefixForm(self, infixForm, allInFixPredicateList, allPrefixPredicateList):
        prefixForm = []

        for predToConvert in infixForm:
            assert(not("false" == predToConvert))
            if "true" == predToConvert:
                return ["true"]
            indexToConvert = allInFixPredicateList.index(predToConvert)
            prefixForm.append(allPrefixPredicateList[indexToConvert])

        return prefixForm

    def scoreByLen(self, conjPList, conjNList):
        return len(conjPList)+len(conjNList)

    def scoreByEntropy(self, conjPList, conjNlist):
        pass

    def shannonsEntropy(self, labels, base=None):
        value, counts = np.unique(labels, return_counts=True)
        totalSample = counts.sum()
        norm_counts = np.true_divide(counts,totalSample )
        base = math.e if base is None else base
        return - (norm_counts * np.log(norm_counts) / np.log(base)).sum()

    def debugSplitDisjunction(self,leftDisjunct,leftDisjunctPrefix,rightDisjunct,rightDisjunctPrefix,alwaysTruePrefix,choosePtoSplitOn):
        #Debug 
        alwaysTrueSimp =""
        logger.info("### Always True Simplified:")
        alwaysTrueSimp = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, "(and "+ ' '.join(alwaysTruePrefix)+" )" )
        logger.info(alwaysTrueSimp+ os.linesep )

        logger.info("############ Predicate to split on:")
        logger.info("############ "+ choosePtoSplitOn+ os.linesep )
        #
        
        leftRaw=""
        logger.info("### Left Raw:")
        leftRaw = "("+' && '.join(leftDisjunct)+")"
        logger.info(leftRaw)

        leftSimp =""
        logger.info("### Left Simplified:")
        leftSimp = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables, "(and "+ ' '.join(leftDisjunctPrefix)+ " )")
        logger.info(leftSimp+ os.linesep )

        rightRaw = ""
        logger.info("### Right Raw:")
        rightRaw = "("+' && '.join(rightDisjunct)+")"
        logger.info(rightRaw)
        
        rightSimp =""
        logger.info("### Right Simplified:")
        rightSimp = z3simplify.simplify(self.symbolicIntVariables, self.symbolicBoolVariables,  "(and "+ ' '.join(rightDisjunctPrefix)+ " )" )
        logger.info(rightSimp+ os.linesep) 
        #end debug

if __name__ == '__main__':

    learner = DisjunctiveLearner("disjunctiveLearner", "", "", "")

    # intVariables = ['oldCount', 's1.Count', 'oldTop', 's1.Peek()', 'oldx', 'x']
    intVariables = ['Old_s1.Count', 'New_s1.Count',
                    'Old_s1.Peek()', 'New_s1.Peek()', 'Old_x', 'New_x']

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
