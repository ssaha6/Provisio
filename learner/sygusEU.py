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


from learner import Learner
from sygus import Sygus
import shell


class SygusEU(Sygus):


    def generateConstraints(self, dataPoints):
        constraints = []
        
        allDomains = [ "Int" for i in self.symbolicIntVariables] + [ "Bool" for i in self.symbolicBoolVariables]        
        for i in range(0, len(allDomains)): 
            constraints.append(["(", "declare-var", "x" + str(i), allDomains[i], ")" ])
        
        
        for point in dataPoints:
            fnCall = ["(", "Precondition"] + [ "x"+str(i) for i in  range(0, len(allDomains))] + [ ")" ]
            if point[-1] == "false":
                fnCall = ["(", "not"] + fnCall + [")"]
            
            dataConstraint = reduce((lambda x, y : x+y), [[ "(", "=", "x"+str(i), str(point[i]), ")"] for i in range(0, len(allDomains))] )
            
            cons = ["(", "constraint", "(", "implies", "(",  "and"] + dataConstraint + [ ")"] + fnCall + [")", ")"]
    
            constraints.append(cons)
        return constraints
    
    def runLearner(self):
        # absBinary = shell.sanitizePath(self.binary, "wsl")
        args = " ".join(['wsl', shell.sanitizePath(self.binary, "wsl"), shell.sanitizePath(self.tempLocation + '/precondition.sl', "wsl")]) #redirect?
    
        result = shell.runCommand(args)
        result = self.readResults(result)        
        return result
        
        
        
    
if __name__ == '__main__':
    learner = SygusEU("eusolver", "learners/eusolver/eusolver.sh", "", "tempLocation")
    
    
    intVariables = ['inta', 'intb', 'intc']
    boolVariables = ['b1', 'b2']
    learner.setVariables(intVariables, boolVariables)
    
    dataPoints = [[1, 1, 0, "false", "true", "false"],
                [2, 0, 0, "true", "true", "false"],
                [1, 0, 0, "true", "true", "true"],
                [0, 2, 2, "false", "false", "false"],
                #[0, 2147483647, 0, "false", "false", "false"],
                [0, 02, 0, "false", "false", "false"],
                [3, 0, 0, "true", "true", "false"],
                [0, 0, 0, "false", "false", "true"],
                [2, 0, 1, "true", "false", "false"],
                [0, 2, -2, "false", "false", "true"],
                [2, 0, 0, "true", "true", "false"],
                [-5, 0, 0, "true", "true", "false"],
                #[0, -2147483647, -2147483648, "false", "false", "false"]
                ]
    
    learner.setDataPoints(dataPoints)
    learner.generateFiles()
    learner.runLearner()
    
    