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

import z3simplify


class DisjunctiveLearner(Learner):


    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
    
    def generateFiles(self):
        pass
    
    def readResults(self):
        pass
    
    
    def shannonsEntropy(self, labels, base=None):
        value,counts = np.unique(labels, return_counts=True)
        norm_counts =  np.true_divide(counts, counts.sum())
        base = math.e if base is None else base
        return - (norm_counts * np.log(norm_counts) / np.log(base)).sum()
        
        
        
        
    
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
    
    
 