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
import itertools 

import reviewData
from learner import Learner
import shell
from pie import PIE

class PieFeatures(PIE):
    
        
    def generateFeatures(self):
        allCombinations = self.make_linear_combination(len(self.symbolicIntVariables), -1, +1)
        
        allVariables = []
        for i in self.symbolicIntVariables:
            allVariables.append( "Value.Int " + i)

        for i in self.symbolicBoolVariables:
            allVariables.append( "_" )

        allVariables = " ; ".join(allVariables)


        allFeatures = []
        prelude = ["(", "fun", "[@warning \"-8\"]", "[" , allVariables , "]", "->" ]
        
        
        for combination in allCombinations:
            blessCombination = map(lambda x: str(x),  combination)
            combination = map(lambda x: "(" + str(x) + ")" if x < 0 else str(x),  combination)
            infix = [ ("( " + j + " * " + i + " )") for  i, j in zip(self.symbolicIntVariables, combination)]
            prefix = [ ("( * " + j + " " + i + " )") for  i, j in zip(self.symbolicIntVariables, blessCombination)]
            oneFeature =  "(" +  \
                            " ".join(prelude) + "(" + " + ".join(infix) + " <= " + str(0) + ")"  + ")" + \
                            "," +  \
                            "\"( <= ( + " + " ".join(prefix) + " ) " + str(0) + " )\"" + \
                          ")\n"
            
            # print oneFeature
            allFeatures.append(oneFeature)
            
        allEquality = []
        for var1, var2  in  list(itertools.combinations(self.symbolicIntVariables, 2)):
            equality =[]
            for i in self.symbolicIntVariables:
                if i == var1:
                    equality.append("Value.Int " + i)
                elif i == var2:
                    equality.append("Value.Int " + i)
                else:
                    equality.append("_")
            
            for v in self.symbolicBoolVariables:
                equality.append("_") 
                
            oneEqFeature = ["(", "(", "fun", "[@warning \"-8\"]", "[" , " ; ".join(equality) , "]", "->", "(", var1, "=", var2, ")", ")", ",", "\"", "(", "=", var1, var2, ")", "\"", ")", "\n"]
            
            allEquality.append(" ".join(oneEqFeature))
                             
                             
            #  ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ; Value.Bool variableBool000 ; _ ; _ ; _ ; _ ; _ ] -> (  variableBool000 ) ) , " variableBool000 " ) 
            allBooleans = []
            preludeBooleans = ["(", "(", "fun", "[@warning \"-8\"]", "[ " ]
            for i in self.symbolicBoolVariables:
                variablesAllBools = []
                for j in self.symbolicIntVariables:
                    variablesAllBools.append("_")
                for k in self.symbolicBoolVariables:
                    if i == k :
                        variablesAllBools.append("Value.Bool " + i)
                    else :
                        variablesAllBools.append("_")
                                                 
                allBooleans.append(  " ".join(preludeBooleans) + " ; ".join(variablesAllBools) + " ] -> ("  + i + " ) ) , \"" + i + "\")"  )
            
        return "\n~features:[ " +  " \n; ".join(allBooleans + allEquality + allFeatures)  + " ] \n"
        

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
    


if __name__ == '__main__':
    learner = PieFeatures("piee", "learners/PIE/runPIE.sh", "", "learners/PIE/app") 
    

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
    
    #                       0                   1                       2                   3                       4
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
    
    # "variableInt000","variableInt001","variableInt002","variableInt003",
    # "variableBool000", "variableBool001", "variableBool002", "variableBool003", "variableBool004", "variableBool005"]

