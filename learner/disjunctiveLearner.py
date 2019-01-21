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


# TODO: calling learner.SetDataPoints changes list of list to list of tuples.

class DisjunctiveLearner(Learner):

    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)

    def generateFiles(self):
        pass

    def readResults(self):
        pass

    def shannonsEntropy(self, labels, base=None):
        value, counts = np.unique(labels, return_counts=True)
        norm_counts = np.true_divide(counts, counts.sum())
        base = math.e if base is None else base
        return - (norm_counts * np.log(norm_counts) / np.log(base)).sum()

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

    def learn(self, dataPoints, simplify=True):
        # Intuition: Only need HoudiniExt to call createAllPredicates()
        # Need Houdini to Learn conjunction
        self.setDataPoints(dataPoints)

        houdiniEx = HoudiniExtended("HoudiniExtended", "", "", "")
        houdiniEx.setVariables(self.intVariables, self.boolVariables)
        houdiniEx.setDataPoints(self.dataPoints)
        if len(self.dataPoints) == 1:
            return houdiniEx.learn(dataPoints, simplify=True)

        # createAllPredicates() returns
        allSynthesizedPredicatesPrefix, allSynthesizedPredicatesInfix = houdiniEx.createAllPredicates()

        booleanData = []
        # iterating over rows
        for point in self.dataPoints:
            allInputVariables = self.intVariables + self.boolVariables
            state = houdiniEx.createStateInformation(
                allInputVariables, point[0:-1])
            # only give houdiniEx boolean because at this point no more integers
            booleanData.append(houdiniEx.evalauteDataPoint(
                allSynthesizedPredicatesInfix, state) + [point[-1]])
            # the infix form of the predicates are used to evalute them (into true or false)

        # print booleanData
        # Call Houdini directly
        listAllSynthesizePredInfix = list(allSynthesizedPredicatesInfix)
        houd = Houdini("Houdini", "", "", "")
        houd.setVariables([], listAllSynthesizePredInfix)
        houd.learn(booleanData, simplify=False)

        alwaysTruePredicateInfix = []
        if len(houd.learntConjuction) > 0:
            alwaysTruePredicateInfix = houd.learntConjuction

        # TODO: compute with prefix otherwie z3 throws error
        remainingPredicatesInfix = list(set(
            listAllSynthesizePredInfix).symmetric_difference(set(alwaysTruePredicateInfix)))
        # remainingPredicatesPrefix = list(set(listAllSynthesizePredPrefix).symmetric_difference(set(alwaysTruePredicateInfix)))
        # for computing disjunctions, we only need to considr p or not p both not both
        score = []
        sortedScore = []

        for i in xrange(0, len(allSynthesizedPredicatesInfix)):
            predicateSplitP = allSynthesizedPredicatesInfix[i]
            positiveP = []
            negativeP = []
            positiveP, negativeP = self.splitSamples(
                predicateSplitP, houdiniEx, self.dataPoints)
            print positiveP
            print negativeP
            boolPDatapoints = []
            boolNegPDatapoints = []
            for posPoint in positiveP:
                allInputVariables = self.intVariables + self.boolVariables
                state = houdiniEx.createStateInformation(
                    allInputVariables, posPoint[0:-1])
                boolPDatapoints.append(houdiniEx.evalauteDataPoint(
                    allSynthesizedPredicatesInfix, state) + [posPoint[-1]])

            for negPoint in negativeP:
                allInputVariables = self.intVariables + self.boolVariables
                state = houdiniEx.createStateInformation(
                    allInputVariables, negPoint[0:-1])
                boolNegPDatapoints.append(houdiniEx.evalauteDataPoint(
                    allSynthesizedPredicatesInfix, state) + [negPoint[-1]])

            houd.setVariables([], allSynthesizedPredicatesInfix)
            conjP = houd.learn(boolPDatapoints, simplify=False)
            conjPList = houd.learntConjuction
            conjN = houd.learn(boolNegPDatapoints, simplify=False)
            conjNList = houd.learntConjuction
            score.append({'predicate': predicateSplitP, 
            'score':self.scoreByLen(conjPList, conjNList) , 'left': conjPList, 'right': conjNList})
            # sortedScore = sorted(score.iteritems(), key=lambda (k,v): v['score'])
        sortedScore = sorted(score, key=lambda x: x['score'])
        print "predicate:"
        print sortedScore[-1]['predicate']
        print "left:"
        print sortedScore[-1]['left']
        print "right:"
        print sortedScore[-1]['right']
        return houdiniEx.learn(dataPoints, simplify=True)
        # return "(Old_s1Count != New_s1Count )"

    def scoreByLen(self, conjPList, conjNList):
        return len(conjPList)+len(conjNList)

if __name__ == '__main__':

    learner=DisjunctiveLearner("disjunctiveLearner", "", "", "")

    # intVariables = ['oldCount', 's1.Count', 'oldTop', 's1.Peek()', 'oldx', 'x']
    intVariables=['Old_s1.Count', 'New_s1.Count',
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
