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
import shell


class Sygus(Learner):



    def formatProgram(self, program, tab = 0):
        #is it a non list variable?
        if not isinstance(program, list):
            return str(program)

        #its a list, now:
        # are all elements of the array non lists??
        if reduce((lambda x, y: x and y), map(lambda x: not isinstance(x, list), program), True):
            return  ("\t" * tab + " ".join(map(lambda x: self.formatProgram(x, tab + 1), program)))

        #some element still has arrays
        else:
            return "\n".join(map(lambda x: self.formatProgram(x, tab + 1), program))


    # todo: allow Int flag
    def generateGrammar(self, allowInt=False):

        intConsts = ["0", "1"]
        boolConsts = ["true", "false"]

        intProductions = [["(+ StartInt StartInt)"], ["(- StartInt StartInt)"]] #, ["(ite StartBool StartInt StartInt)"]]
        intCompareProductions = [["(<=  StartInt StartInt)"], ["(= StartInt StartInt)"], ["(>=  StartInt StartInt)"]]

        boolProductions = [["(and StartBool StartBool)"], ["(or StartBool StartBool)"], ["(not StartBool)"]]
        
        
        boolGrammar = [     ["(", "StartBool", "Bool", "("],
                            [boolConsts],
                            [self.symbolicBoolVariables],
                            [boolProductions],
                            [intCompareProductions],
                            [ ")", ")" ]
                        ]

        intGrammar = [      ["(", "StartInt", "Int", "("],
                            [intConsts],
                            [self.symbolicIntVariables],
                            [intProductions],
                            [")", ")"]
                        ]

        startSymbolBool = ["(", "Start",  "Bool",  "(StartBool)", ")"]

        synthFuncDecl = "synth-fun Precondition"

        boolDecl = map(lambda x: "(" + x + " Bool)", self.symbolicBoolVariables)
        intDecl = map(lambda x: "(" + x + " Int)", self.symbolicIntVariables)

        grammar =   [       [ "(", synthFuncDecl,"("] +  intDecl + boolDecl + [")", "Bool", "(" ],
                            [startSymbolBool],
                            [boolGrammar],
                            [intGrammar],
                            [ ")", ")"]
                    ]

        return grammar


    def generateConstraints(self, dataPoints):
        constraints = []
        for point in dataPoints:
            fnCall =  ["(", "Precondition"]  +  list(point[:-1]) + [")"]

            if point[-1] == "false":
                fnCall = ["(", "not"] + fnCall + [")"]

            constraints.append(["(", "constraint"] + fnCall + [")"])
        return constraints




    def generateFiles(self):
        logic = "(set-logic LIA)"
        checkSynth = "(check-synth)"

        program = [logic, self.generateGrammar(), self.generateConstraints(self.dataPoints), checkSynth]
        fileContents = self.formatProgram(program)

        shell.resetFilesByRegex(self.tempLocation, '.*\.sl')
        shell.writeFile(self.tempLocation, 'precondition.sl', fileContents)

    
    def readResults(self, result):
        resultRegex = '\(\s*define-fun\s+Precondition\s*\((?:\(\s*[_0-9A-Za-z]+\s*(?:Int|Bool)\s*\)\s*)*\)\s*(?:Int|Bool)\s+(.*)\)'
        
        regex = re.search(resultRegex, result,  re.MULTILINE | re.DOTALL)
        
        if regex:
            program  = regex.group(1)
            return program
        else:
            raise(NameError("couldnot parse sygus output:" +result ))
            # shell.printExceptionAndExit(NameError("couldnot parse sygus output"), "output:" + result)
        
        
        
        
    def runLearner(self):
        absBinary = shell.sanitizePath(self.binary, "win")
        head, tail = os.path.split(absBinary)

        args = " ".join([shell.wslBin(), './' + tail, shell.sanitizePath(self.tempLocation + '/precondition.sl', "wsl")]) #redirect?
        
        result = shell.runCommand(args, head)
        result = self.readResults(result)        
        return result
        
        
        
        
#test
if __name__ == '__main__':
    learner = Sygus("esolver", "learner/EnumerativeSolver/bin/starexec_run_Default", "", "tempLocation")

    # learner = Sygus("cvc4", "learner/Sygus/CVC4-061117-sygus-comp-2017/bin/starexec_run_sygus_c_GENERAL", "", "tempLocation")
    # learner = Sygus("cvc4", "learner\\Sygus\\CVC4-061117-sygus-comp-2017\\bin\\starexec_run_sygus_c_GENERAL", "", "tempLocation")
    # learner = Sygus("alchemistcs", "learner/Sygus/Alchemist CS/bin/starexec_run_alchemist_cs_lia", "", "tempLocation")
    # learner = Sygus("eusolvernew", "learner/Sygus/EUSolver_new/bin/starexec_run_default", "", "tempLocation")
    
    # print dir(learner)

    intVariables = ['inta', 'intb', 'intc']
    boolVariables = ['b1', 'b2']
    learner.setVariables(intVariables, boolVariables)

    dataPoints = [[1, 1, 0, "false", "true", "false"],
                [2, 0, 0, "true", "true", "false"],
                [1, 0, 0, "true", "true", "true"],
                [0, 2, 2, "false", "false", "false"],
                #[0, 2147483647, 0, "false", "false", "false"],
                [0, 2, 0, "false", "false", "false"],
                [3, 0, 0, "true", "true", "false"],
                [0, 0, 0, "false", "false", "true"],
                [2, 0, 1, "true", "false", "false"],
                [0, 2, 2, "false", "false", "true"],
                [2, 0, 0, "true", "true", "false"],
                [5, 0, 0, "true", "true", "false"],
                #[0, -2147483647, -2147483648, "false", "false", "false"]
                ]

    # learner.setDataPoints(dataPoints)
    # learner.generateFiles()
    # learner.runLearner()
    
    print learner.learn(dataPoints)
    