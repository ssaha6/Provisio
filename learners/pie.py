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


class PIE(Learner):


    def generateFeatures(self):
        features =  \
"""
        ~features:[]
"""
        return features
        
        
        
#     def getConclusion(Self):
#         conclusion = \
# """
# let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
# """        

#         return conclusion


    def getConclusion(Self):
        conclusion = \
"""
 let disablesynth_config : PIE.config = 
 {   for_BFL = BFL.default_config ;  
     synth_logic = Logic.of_string "LIA" ;  
     disable_synth = true ;  
     max_conflict_group_size = PIE.base_max_conflict_group_size ; 
 }

 let () = Stdio.print_endline(
  Log.enable ~msg:"RECORD" (Some "FeatureLogNoSynth.txt");
 PIE.cnf_opt_to_desc (PIE.learnPreCond ~conf:(disablesynth_config) precondition_job))
"""        
        return conclusion




    def generateFiles(self):

        prelude = \
"""     
open Base
open LoopInvGen
            
let precondition_job = Job.create
"""


        functionDef = \
"""
~f:(fun [@warning "-8"] [{inputParams}] -> Bool (
match {match}  with
{truthTable}
))
"""

        args = \
"""
~args:([ {arguments} ])
"""


        postCondition = \
"""
~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)

"""


        testcases = \
"""
[ 
{testInputs}
]
"""




        inputParams = []    # Int x ; Bool y
        arguments = []      # ("x", Type.INT) ; ("y",Type.BOOL)
        match = []          # x, y, 
        for var in self.symbolicIntVariables: 
            inputParams.append("Int " + var)
            arguments.append("(\"" + var + "\", " + "Type.INT)")
            match.append(var)
        
        for var in self.symbolicBoolVariables:
            inputParams.append("Bool " + var)
            arguments.append("(\"" + var + "\", " + "Type.BOOL)")
            match.append(var)
        
        
        
        truthTable = []
        # 0 , true  -> false
        # | _ ->   false
        
        testInputs = []
        # [Int 0    ; Bool true ] ; [Int 0    ; Bool true ] ...
        
        variableTypes = ["Int" for var in self.symbolicIntVariables] + ["Bool" for var in self.symbolicBoolVariables]

        
        for test in self.dataPoints:
            truthTable.append( ", ".join(map(lambda x : "("+str(x)+")", test[:-1])) + " -> " + str(test[-1]))
            elementList = [ i[0] + " " + "(" + str(i[1]) + ")"   for i in zip(variableTypes, test[:-1])]    
            testInputs.append( "[ " + " ; ".join(elementList) + " ]" )
            
            
        truthTable.append(" _ -> false ")
        
        program = prelude + \
                    functionDef.format(inputParams = " ; ".join(inputParams), truthTable = " \n| ".join(truthTable), match= ", ".join(match) ) + \
                    args.format(arguments = " ; ".join(arguments)) + \
                    self.generateFeatures() + postCondition + \
                    testcases.format(testInputs = "\n ; ".join(testInputs)) + \
                    self.getConclusion()
        
        
        shell.writeFile(self.tempLocation, "App.ml", program)
    
    
    
    
    def runLearner(self):
        absBinary = shell.sanitizePath(self.binary, "wsl")
                
        args = " ".join(['wsl', absBinary]) 
        result = shell.runCommand(args)
        return result 
        
        
        
    # def readResults(self):
    #     return self.precondition
        
        
        
# TO RUN PIE
# Modify: learner\PIE\app\App.ml
# root@Yoga15:/mnt/d/LearningContracts/tools/learner/PIE:
# dune build app/App.exe ;  dune exec app/App.exe



if __name__ == '__main__':
    learner = PIE("piee", "learners/PIE/runPIE.sh", "", "learners/PIE/app") 


    # intVariables = ['inta', 'intb', 'intc']
    # boolVariables = ['b1', 'b2']
    # learner.setVariables(intVariables, boolVariables)


    # dataPoints = [[1, -1, 0, "false", "true", "false"],
    #             [2, 0, 0, "true", "true", "false"],
    #             [1, 0, 0, "true", "true", "true"],
    #             [0, 2, -2, "false", "false", "false"],
    #             # [0, 2147483647, 0, "false", "false", "false"],
    #             [0, 2, 0, "false", "false", "false"],
    #             [3, 0, 0, "true", "true", "false"],
    #             [0, 0, 0, "false", "false", "true"],
    #             [2, 0, 1, "true", "false", "false"],
    #             [0, 2, 2, "false", "false", "true"],
    #             [2, 0, 0, "true", "true", "false"],
    #             [5, 0, 0, "true", "true", "false"],
    #             #[0, -2147483647, -2147483648, "false", "false", "false"]
    #             ]
    
    # learner.setDataPoints(dataPoints)
    # learner.generateFiles()
    # print learner.runLearner()
    
    # print learner.learn(dataPoints)
    
    
        
    boolVariables = [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(y1)']
    intVariables = ['s1.Count', 'x', 'y', 'y1']
    learner.setVariables(intVariables, boolVariables)
    
    dataPoints = [[0,            
  0,            
  0,            
  0,            
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false"],       
 [1, 0, 0, 0, "true", "true", "true", "true", "true", "true", "false"],  
 [1,            
  4,            
  4,            
  4,            
  "true",         
  "true",         
  "true",         
  "false",        
  "false",        
  "false",        
  "false"],       
 [1,            
  3,            
  10,           
  10,           
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false"],       
 [2,            
  0,            
  0,            
  0,            
  "false",        
  "false",        
  "false",        
  "true",         
  "true",         
  "true",         
  "false"],       
 [2,            
  3,            
  4,            
  10,           
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false",        
  "false"],       
 [5, 0, 0, 0, "true", "true", "true", "true", "true", "true", "false"],  
 [1,            
  0,            
  10,           
  10,           
  "true",         
  "false",        
  "false",        
  "true",         
  "false",        
  "false",        
  "true"]]    
  
    print learner.learn(dataPoints)    













# Boilerplate
# --------------------------------------
# open Base
# open LoopInvGen
#
# let precondition_job = Job.create
#     ~f:(fun [@warning "-8"] [ Int x ; Bool y ] -> Bool (
#             match x, y  with
#                      0 , true  -> false
#                 | (10), false  -> false
#                 |     9, true  -> true
#                 | _ ->   false
#             ))
#
#     ~args:([ ("x", Type.INT) ; ("y",Type.BOOL)])
#
#     ~post:(fun inp res ->
#             match inp, res with
#             | _ ,  Ok (Bool ret_val) -> ret_val
#             | _ -> false)
#
#     ~features:[]
#
#         [ [Int 0    ; Bool true ]
#         ; [Int (10); Bool false]
#         ; [Int 9    ; Bool true ]
#         ]
#
# let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
