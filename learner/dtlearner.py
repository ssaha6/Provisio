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


class DTLearner(Learner):


    def __init__(self, name, binary, parameters, tempLocation):
        Learner.__init__(self, name, binary, parameters, tempLocation)
        self.intHigh = 1
        self.intLow = -1


    def setIntLowHigh(self, intLow, intHigh):
        self.intLow = intLow
        self.intHigh = intHigh







    #TODO: needs rewriting for generating prefix terms with -1 * var
    
    
    def writePrefixNamesFile(self):
        try:
            coeff_combination = self.make_linear_combination(len(self.symbolicIntVariables), self.intLow, self.intHigh)
            names_file = 'precondition.'

            for var in self.symbolicIntVariables:
                names_file += '\n' + var + ':  continuous.'

            # adding boolean observer method features
            for var in self.symbolicBoolVariables:
                names_file += '\n' + var + ':  true, false.'

            # check equality of integer variables
            if len(self.symbolicIntVariables) >= 2:
                all_combination = itertools.combinations(self.symbolicIntVariables, 2)
                for (var1, var2) in all_combination:
                    expr = "(" + var1 + " = " + var2 + ")"
                    name_expr = "( = " + var1 + " " + var2 + " )"
                    names_file += '\n' + name_expr + ' := ' + expr + ' .' #needs change
    
            for coeff in coeff_combination:
                # old way of generating all possible combinations
                expr = ' + '.join(map(lambda x,y: "(" + str(x) + "*" + str(y) + ")", coeff, self.symbolicIntVariables))
                name_expr = ' ( + ' + ' '.join(map(lambda x,y: "( * " + str(x) + " " + str(y) + " )", coeff, self.symbolicIntVariables)) + ' )'
                names_file += '\n' + name_expr +  ' := ' + expr + ' .'
            
            
            names_file += '\nprecondition:    true,false.'

            shell.writeFile(self.tempLocation, 'pre.names', names_file)

        except Exception as e:
            shell.printExceptionAndExit(e, "Creating Names File")    
    
    
    
    def writeNamesFile(self):
        try:
            coeff_combination = self.make_linear_combination(len(self.symbolicIntVariables), self.intLow, self.intHigh)
            names_file = 'precondition.'

            for var in self.symbolicIntVariables:
                names_file += '\n' + var + ':  continuous.'

            # adding boolean observer method features
            for var in self.symbolicBoolVariables:
                names_file += '\n' + var + ':  true, false.'

            # check equality of integer variables
            if len(self.symbolicIntVariables) >= 2:
                all_combination = itertools.combinations(self.symbolicIntVariables, 2)
                for (var1, var2) in all_combination:
                    expr = "(" + var1 + " = " + var2 + ")"
                    name_expr = var1 + " == " + var2
                    names_file += '\n' + name_expr + ' := ' + expr + ' .'

            # TODO: for Boolean variables????
            # TODO: the learner needs to produce the exact same order of combination ????

            for coeff in coeff_combination:
                expr = ''
                name_expr = ''
                join = ''
                not_redundant = 0
                for i in range(0, len(coeff)):
                    not_redundant += coeff[i] * coeff[i]

                    if coeff[i] == 0:
                        continue
                    elif coeff[i] == 1:
                        expr = expr + join + self.symbolicIntVariables[i]
                        name_expr = name_expr + join + self.symbolicIntVariables[i]
                    elif coeff[i] == -1:
                        expr = expr + join + '(-' + self.symbolicIntVariables[i] + ')'
                        name_expr = name_expr + join + '-' + self.symbolicIntVariables[i]
                    else:
                        expr = expr + join + '(' + str(coeff[i]) + '*' + self.symbolicIntVariables[i] + ')'
                        name_expr = name_expr + join + str(coeff[i]) + '*' + self.symbolicIntVariables[i]

                    if not join:
                        join = ' + '

                if not_redundant >= 2:
                    names_file += '\n' + name_expr + ' := ' + expr + ' .'

            # old way of generating all possible combinations
            # expr = ' + '.join(map(lambda x,y: "(" + str(x) + "*" + str(y) + ")", coeff, IntVariables))
            # name_expr = ' + '.join(map(lambda x,y: str(x) + "*" + str(y), coeff, IntVariables))
            # names_file += '\n' + name_expr +  ' := ' + expr + ' .'

            names_file += '\nprecondition:    true,false.'

            shell.writeFile(self.tempLocation, 'pre.names', names_file)

        except Exception as e:
            shell.printExceptionAndExit(e, "Creating Names File")


    def writeDataFile(self):
        try:
            # change to shell.writeFile
            with open(os.path.join(self.tempLocation, 'pre.data'), 'wb') as f_out:
                csv_out = csv.writer(f_out)
                for item in self.dataPoints:
                    csv_out.writerow(item)
        except Exception as e:
            shell.printExceptionAndExit(e, "Creating Data File")


    def generateFiles(self):
        shell.resetFilesByRegex(self.tempLocation, 'pre\.*')
        # self.writeNamesFile()
        self.writePrefixNamesFile()
        self.writeDataFile()





    # threshold must be passed thtough learnerParameter: -z 80
    def set_c50_args(self):
        result = " ".join([shell.sanitizePath(self.binary, "win"), '-I 1', '-m 1',
                            self.parameters, '-f', shell.sanitizePath(self.tempLocation + '/pre', "win")])
        return  result


    def runLearner(self):
        shell.runCommand(self.set_c50_args())
        return self.readResults()
        
        
        

    def parse_tree(self, tree):
        try:
            if (tree['children'] is None):
                return '  ' + str(tree['classification']).strip().lower() + ' '

            elif (len(tree['children']) == 2):
                # for parsing bools
                if 'partition' in tree:
                    node =  tree['attribute'] 
                else:
                    node = '( <= ' + tree['attribute'] + ' ' + str(tree['cut']).replace(".0", "") + ' )'
                
                left = self.parse_tree(tree['children'][0]).strip()
                right = self.parse_tree(tree['children'][1]).strip()

                return  '(or   ( and ' +   node  + ' ' + left + ' )  ( and  ( not ' + node + ') ' + right + ' ))'
                # " (" + node + " && (" + left.strip() + ")) || ((!" + node + ") && (" + right.strip() + ")) "


            else:
                shell.printExceptionAndExit(e, "Parsing JSON File")

        except Exception as e:
            shell.printExceptionAndExit(e, "Parsing JSON File")


    def get_pre_from_json(self, path):
        try:
            precondition = "true"
            with open(path) as json_file:
                tree = json.load(json_file)
                precondition = self.parse_tree(tree)

            return precondition
        except Exception as e:
            shell.printExceptionAndExit(e, "Cannot open JSON File")


    def readResults(self):
        return self.get_pre_from_json(shell.sanitizePath(self.tempLocation + '/pre.json', "win"))




#test
if __name__ == '__main__':
    learner = DTLearner("dtsolver", "learner/C50exact/c5.0dbg.exe", "", "tempLocation")


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
    # print learner.readResults()

    # print learner.learn(dataPoints)
