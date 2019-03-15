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


class SygusLIA(Sygus):


    # todo: allow Int flag
    def generateGrammar(self, allowInt=False):
        
        #print "in generateGrammar SygusLIA!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
        intConsts = ["0", "1"]
        # boolConsts = ["true", "false"]

        intProductions = [["(+ StartInt StartInt)"], ["(- StartInt StartInt)"]] #, ["(ite StartBool StartInt StartInt)"]]
        # intCompareProductions = [["(<=  StartInt StartInt)"], ["(= StartInt StartInt)"], ["(>=  StartInt StartInt)"]]

        # boolProductions = [["(and StartBool StartBool)"], ["(or StartBool StartBool)"], ["(not StartBool)"]]
        
        
        # boolGrammar = [     ["(", "StartBool", "Bool", "("],
        #                     [boolConsts],
        #                     [self.symbolicBoolVariables],
        #                     [boolProductions],
        #                     [intCompareProductions],
        #                     [ ")", ")" ]
        #                 ]

        intGrammar = [      ["(", "StartInt", "Int", "("],
                            [intConsts],
                            [self.symbolicIntVariables],
                            [intProductions],
                            [")", ")"]
                        ]

        startSymbolBool = ["(", "Start",  "Int",  "(StartInt)", ")"]

        synthFuncDecl = "synth-fun Precondition"

        # boolDecl = map(lambda x: "(" + x + " Bool)", self.symbolicBoolVariables)
        intDecl = map(lambda x: "(" + x + " Int)", self.symbolicIntVariables)
        
        # grammar =   [       [ "(", synthFuncDecl,"("] +  intDecl + boolDecl + [")", "Bool", "(" ],
        grammar =   [       [ "(", synthFuncDecl,"("] +  intDecl + [")", "Int", "(" ],
                            [startSymbolBool],
                            # [boolGrammar],
                            [intGrammar],
                            [ ")", ")"]
                    ]
        
        return grammar


    def generateConstraints(self, dataPoints):
        constraints = []
        for point in dataPoints:
            fnCall =  ["(", "= ", "(", "Precondition"]  +  list(point[:-1]) + [ ")", point[-1], ")"]
            
            # if point[-1] == "false":
            #     fnCall = ["(", "not"] + fnCall + [")"]

            constraints.append(["(", "constraint"] + fnCall + [")"])
        return constraints

    
    def readResults(self, result):
        resultRegex = '(\(\s*define-fun\s+Precondition\s*\((?:\(\s*[_0-9A-Za-z]+\s*(?:Int)\s*\)\s*)*\)\s*Int\s+(.*)\)|(No\s*Solutions!))'
        
        regex = re.search(resultRegex, result,  re.MULTILINE | re.DOTALL)
        
        if regex:
            program  = regex.group(2)
            if program is None:
                program = regex.group(3)
            return program
        else:
            raise(NameError("couldnot parse sygus output:" +result ))
            # shell.printExceptionAndExit(NameError("couldnot parse sygus output"), "output:" + result)
        
        
        

#test
if __name__ == '__main__':
    learner = SygusLIA("esolver", "learner/EnumerativeSolver/bin/starexec_run_Default", "", "tempLocation")

    # learner = Sygus("cvc4", "learner/Sygus/CVC4-061117-sygus-comp-2017/bin/starexec_run_sygus_c_GENERAL", "", "tempLocation")
    # learner = Sygus("cvc4", "learner\\Sygus\\CVC4-061117-sygus-comp-2017\\bin\\starexec_run_sygus_c_GENERAL", "", "tempLocation")
    # learner = Sygus("alchemistcs", "learner/Sygus/Alchemist CS/bin/starexec_run_alchemist_cs_lia", "", "tempLocation")
    # learner = Sygus("eusolvernew", "learner/Sygus/EUSolver_new/bin/starexec_run_default", "", "tempLocation")
    
    # print dir(learner)
    
    intVariables = ['x', 's1Count', 's1Peek']
    dataPoints = [
        ['1', '1', '0', '2'],
        ['0', '2', '10', '3'],
        ['0', '1', '1', '2'],
        ['2', '1', '-5', '2'],
        ['0', '1', '10', '2'],
        ['0', '1', '2', '2'],
        ['0', '1', '0', '2']
    ]
    
    
    learner.setVariables(intVariables, [])
    
    print learner.learn(dataPoints, simplify=False)
    
    
    
    
    
# CLIA TRACK SYNTAX
# (set-logic LIA)
# (synth-fun max2 ((x Int)(y Int)) Int
#     ((Start Int (StartInt))
#         (StartInt Int (x y ConstantInt
#         (+ StartInt StartInt)
#         (- StartInt StartInt)
#         (* StartInt ConstantInt)
#         (* ConstantInt StartInt)
#         (div StartInt ConstantInt)
#         (mod StartInt ConstantInt)
#         (ite StartBool StartInt StartInt)))

# (ConstantInt (Constant Int))

# (StartBool Bool (true false
#         (and StartBool StartBool)
#         (or StartBool StartBool)
#         (=> StartBool StartBool)
#         (xor StartBool StartBool)
#         (xnor StartBool StartBool)
#         (nand StartBool StartBool)
#         (nor StartBool StartBool)
#         (iff StartBool StartBool)
#         (not StartBool)
#         (= StartBool StartBool)
#         (<= StartInt StartInt)
#         (= StartInt StartInt)
#         (>= StartInt StartInt)
#         (> StartInt StartInt)
#         (< StartInt StartInt)))))

# (declare-var x Int)
# (declare-var y Int)
# (constraint (>= (max2 x y) x))
# (constraint (>= (max2 x y) y))
# (constraint (or (= x (max2 x y)) (= y (max2 x y))))
# (check-synth)