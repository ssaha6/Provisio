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
import itertools
import io
from lxml import etree

from learners.sygus import Sygus
from learners.pie import PIE
from learners.dtlearner import DTLearner
from learners.sygusEU import SygusEU
from learners.pieFeatures import PieFeatures

from learners.z3 import z3
from pprint import pprint 
import datetime
import shutil


#setting paths
# devenv_path = '/mnt/c/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio\ 10.0/Common7/IDE/'
# pex_path = '/mnt/c/Program\ Files\ \(x86\)/Microsoft\ Pex/bin/'
class Analysis:

    #def __init__(self):
    allDataSet = set()
    
    def debug_print(this,text, flag):
        flag = True
        if flag:
            print text

    def set_compiler_args(this, sln_file):
        compile_command = 'MSBuild.exe'
        solution_file = sln_file
        compile_option = '/t:rebuild'
        build_mode = 'debug'
        ignore_warning = '/property:WarningLevel=2'
        cmd_exec = [compile_command, solution_file, compile_option,ignore_warning]
        return cmd_exec


    def run_compiler(this, args):
        try:
            #print "Compilation Started:"
            compile_result = ""
            build_output =""
            this.debug_print(' '.join(args), False)
            #compile_output = subprocess.check_output(args ,shell=True)
            
            buildRun = subprocess.Popen(args, stdout= subprocess.PIPE, stderr=subprocess.PIPE)
            #(build_output, build_err) = buildRun.communicate()
            for line in buildRun.stdout:
                build_output = build_output +os.linesep +str(line.rstrip())
            
            buildRun.stdout.close()

            compile_result = (build_output.split(os.linesep))[-4:-2]
            
            if "Build FAILED." in compile_result:    
                this.debug_print(compile_result, False)
                this.debug_print("Compilation Exception", True)
                this.debug_print(compile_result, True)
                sys.exit(1)
        except:
            this.debug_print("Compilation Exception", True)
            this.debug_print(compile_result, True)
            sys.exit(1)


    def set_pex_args(this, pex_method,test_dll,pex_bin, namespace, typ):
        pex_other_options = '/nor'
        #cmd_exec = [pex_bin ,  test_dll , '/membernamefilter:M:' + pex_method+'!', '/methodnamefilter:' + pex_method+'!' , '/namespacefilter:'+namespace+'!', '/typefilter:'+ typ+ '!', pex_other_options,'/NoConsole']
        cmd_exec = [pex_bin ,  test_dll , '/methodnamefilter:' + pex_method+'!' , '/namespacefilter:'+namespace+'!', '/typefilter:'+ typ+ '!', '/nor',  '/ro:myreport',  '/rn:rep', '/NoConsole']
        
        #return str(pex_bin + ' ' + test_dll + ' /membernamefilter:M:' + pex_method + '! /methodnamefilter:' + pex_method + '! /namespacefilter:'+namespace+'! /typefilter:'+ typ+ '! ' + pex_other_options)
        return cmd_exec

    def run_pex(this, args):
        
        try:
            this.debug_print('Pex is running', False)
            this.debug_print(' '.join(args), False)
            
            pex_output = subprocess.check_output(' '.join(args) , shell=True) #stderr= subprocess.STDOUT
            
            print pex_output
            #m = re.search('(.*)(EXPLORATION SUCCESS)(.*)',pex_output,re.DOTALL)
            # m = re.search('(.*)(Pex Done Generating Tests)(.*)',pex_output,re.DOTALL )
            

            # if m:
            #     try:
            #     #print "regex search succeeded"
            #         #parser_output = m.group(3)
            #
            #         #print pex_output
            #         parser_output = m.group(3)
            #         #if(parser_output is None):
            #         #    print 'bug'
            #         #    sys.exit(-1)
            #         #print "Parser Output:"
            #         #print parser_output
            #         ind = parser_output.find('Passing Test: ')
            #         indFail =parser_output.find('Failing Test: ')
            #         if ind != -1:
            #             if not (parser_output[ind+14:len(parser_output)].find(os.linesep) is None):
            #                 #passing =  parser_output[ind+14:((ind+14) + (parser_output[ind+14:len(parser_output)-1].find(os.linesep)))]
            #                 if indFail != -1:
            #                     passing =  parser_output[ind+14:indFail]
            #                 else:
            #                     passing =  parser_output[ind+14:]
                            
            #                 if not (passing is None):
            #                     this.debug_print("(From run.py) Passing Test: "+ passing, False)
                        
            #         if indFail != -1:
            #             #print '(From run.py) Failing Test: '+ parser_output[indFail+14:((indFail+14) +(parser_output[indFail+14:len(parser_output)-1].find(os.linesep)))]
            #             failing =  parser_output[indFail+14:]
            #             if not (failing is None):
            #                 this.debug_print("(From run.py) Failing Test: "+ failing, False)

            #         if parser_output.find("Pex Found No Error") != -1:
            #             return "success"
            #         if parser_output.find("No passing or failing inputs were generated") != -1:
            #             return "debug"
            #         return "not done yet"
                
            #     except Exception as ex:
            #         template = "An exception of type {0} occurred. Arguments:\n{1!r}"
            #         message = template.format(type(ex).__name__, ex.args)
            #         print message
            #         print str("-"*60)
            #         traceback.print_exc(file=sys.stdout)
            #         print str("-"*60)
            #         print "Pex STDOUT: "
            #         print pex_output
            #         sys.exit(-1) 

            # else:
            #     this.debug_print('something went wrong in PEX', True)
            #     this.debug_print(pex_output, True)
            #     raise ValueError() 
        
        except ValueError as err:
            print "type"
            print type(err) 
            this.debug_print("Pex Exited Abnormally", True)
            sys.exit(1)

        except IOError as e:
            print "Pex STDOUT: "
            print pex_output
            
            print str("-"*60)
            traceback.print_exc(file=sys.stdout)
            print str("-"*60)

    def make_linear_combination(this,number_of_variables, low, high):
        init_list = [ [i] for i in range(low, high+1)]
        
        a = init_list
        b = init_list
        for i in range(1,number_of_variables):
            a = [ x+y for x in a for y in init_list] # x + y -- concatenation of lists
        return a

    def create_names_file(this, IntVariables, low, high, filename): 
        coeff_combination = this.make_linear_combination(len(IntVariables),low,high)
        names_file = 'precondition.'
        
        for var in IntVariables:
            names_file += '\n' + var + ':  continuous.'


        # check equality of integer variables
        if len(IntVariables) >= 2: 
            all_combination = itertools.combinations(IntVariables, 2)
            for (var1,var2) in all_combination: 
                expr = "(" + var1 + " = " + var2 + ")"
                name_expr = var1 + " == " + var2
                names_file += '\n' + name_expr + ' := ' + expr + ' .'

        # TODO: the learner needs to produce the exact same order of combination ????

        for coeff in  coeff_combination:
            expr = ''
            name_expr = ''
            join = ''
            not_redundant = 0 
            for i in range(0, len(coeff)):
                not_redundant += coeff[i] * coeff[i] 

                if coeff[i] == 0: 
                    continue
                elif coeff[i] == 1: 
                    expr = expr + join + IntVariables[i] 
                    name_expr = name_expr + join + IntVariables[i]
                elif coeff[i] == -1:
                    expr = expr + join + '(-' + IntVariables[i]+')'
                    name_expr = name_expr + join + '-' + IntVariables[i]
                else: 
                    expr = expr + join + '(' + str(coeff[i]) + '*' + IntVariables[i] + ')'
                    name_expr = name_expr + join + str(coeff[i]) + '*' + IntVariables[i]

                if not join:
                    join = ' + '

            if not_redundant >=2 :
                names_file += '\n' + name_expr + ' := ' + expr + ' .'

        # old way of generating all possible combinations
        # expr = ' + '.join(map(lambda x,y: "(" + str(x) + "*" + str(y) + ")", coeff, IntVariables))
        # name_expr = ' + '.join(map(lambda x,y: str(x) + "*" + str(y), coeff, IntVariables))
        # names_file += '\n' + name_expr +  ' := ' + expr + ' .' 
        
        names_file += '\nprecondition:    true,false.'
        file = open(filename,'w')
        file.write(names_file) 
        file.close()

    def create_names_file_with_bool(this, BoolVariables, IntVariables, low, high, filename): 
        coeff_combination = this.make_linear_combination(len(IntVariables),low,high)
        names_file = 'precondition.'
        
        for var in IntVariables:
            names_file += '\n' + var + ':  continuous.'

        # adding boolean observer method features
        for var in BoolVariables:
            names_file += '\n' + var + ':  true, false.'
        

        # check equality of integer variables
        if len(IntVariables) >= 2:
            all_combination = itertools.combinations(IntVariables, 2)
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
                    expr = expr + join + IntVariables[i]
                    name_expr = name_expr + join + IntVariables[i]
                elif coeff[i] == -1:
                    expr = expr + join + '(-' + IntVariables[i]+')'
                    name_expr = name_expr + join + '-' + IntVariables[i]
                else:
                    expr = expr + join + '(' + str(coeff[i]) + '*' + IntVariables[i] + ')'
                    name_expr = name_expr + join + str(coeff[i]) + '*' + IntVariables[i]

                if not join:
                    join = ' + '

            if not_redundant >= 2:
                names_file += '\n' + name_expr + ' := ' + expr + ' .'

        # old way of generating all possible combinations
        # expr = ' + '.join(map(lambda x,y: "(" + str(x) + "*" + str(y) + ")", coeff, IntVariables))
        # name_expr = ' + '.join(map(lambda x,y: str(x) + "*" + str(y), coeff, IntVariables))
        # names_file += '\n' + name_expr +  ' := ' + expr + ' .'

        

        names_file += '\nprecondition:    true,false.'

        with open(filename,'w') as f:
            f.write(names_file) 
                

    def set_c50_args(this, pre_file, c50_binary,kind,threshold):
        if sys.platform == 'cygwin':
            c50_binary = './learners/C50p2n/c5.0dbg.exe'
            c50_file = pre_file 
        
        else:
            c50_file = os.getcwd() + '\{}'.format(pre_file) 

        if kind == 'exact':
            c50_options = '-I 1 -m 1'

        else:
            c50_options = '-z '+threshold+ ' -I 1 -m 1'

        return c50_binary + ' ' + c50_options + ' -f ' + c50_file 
        
        

    def call_c50(this,args):
        c50_output = ""    
        try:
            this.debug_print("C5.0 Started", False)
            this.debug_print(args, True)
            c50_output = subprocess.check_output(args , shell=True)
            this.debug_print(c50_output, True)
        except: 
            this.debug_print(c50_output, True)
            this.debug_print("c5.0 error", True)
            raise Exception("error with learner")

    def simplifyFalse(this,pre):
        originalIndex = pre.find(" && (false))")
        endIndex = originalIndex+ 11
        #print endIndex
        rightParenSeen = 1
        leftParenSeen =0 # unmatched
        index = originalIndex
        if index != -1: # found it

            tmpPre =""
            while index != 0:
                
                if pre[index] == ")":
                    rightParenSeen = rightParenSeen+ 1

                elif pre[index] == "(":
                    leftParenSeen = leftParenSeen + 1

                if rightParenSeen == leftParenSeen:
                    #print "index: " +str(index)
                    #print "substringto substitute: "+ pre[index: endIndex+1]
                    tmpPre = pre[:index-1]+"(false)"+pre[endIndex+1:]
                    break
                index = index - 1
            tmpPre = tmpPre.replace("|| (false)", "")
            tmpPre = tmpPre.replace("(false) ||", "")
            return tmpPre
        return pre
    def parse_tree(this,tree):
        if (tree['children'] is None):
            return '  ' + str(tree['classification']).strip().lower()
        

        elif (len(tree['children'])== 2):
            # for parsing bools
            if 'partition' in tree:

                if "s1.ContainsValueAt(x.x1)" in tree['attribute']:
                    node = 's1.ContainsValueAt(x, x1)'  
                else:
                    node = tree['attribute']
                #if str(tree['attribute']).find("Contains") != -1 and ( (tree['children'][0]['attribute'] != "" or tree['children'][1]['attribute'] != "" ) or (tree['children'][0]['attribute']== "" or tree['children'][1]['attribute'] == "" ) ):
                #    node= '( ' +  tree['attribute'] +' )'     
                
                #elif str(tree['attribute']).find("s1.TryGetValue(x.out.val)") != -1 and ( (tree['children'][0]['attribute'] != "" or tree['children'][1]['attribute'] != "" ) or (tree['children'][0]['attribute']== "" or tree['children'][1]['attribute'] == "" ) ):
                #    node= '( ' +  's1.TryGetValue(x, out val)' +' )'     

                #elif str(tree['attribute']).find("s1.TryPeek(out.dummy)") != -1 and str(tree['attribute']).find("s1.TryPeek(out.dummy).s1.Peek().negSevenPlus.x") == -1 and ( (tree['children'][0]['attribute'] != "" or tree['children'][1]['attribute'] != "" ) or (tree['children'][0]['attribute']== "" or tree['children'][1]['attribute'] == "" ) ):
                #        node= '( ' +  's1.TryPeek(out dummy)' +' )'
           
            
            else:
                #if  str(tree['attribute']).find("s1.TryPeek(out.dummy).s1.Peek().negSevenPlus.x") != -1:
                #    node = '( '+ tree['attribute'].replace("s1.TryPeek(out.dummy).s1.Peek().negSevenPlus.x", "(s1.TryPeek(out dummy)?s1.Peek(): -7 + x)")  + ' <= ' +  str(tree['cut'])  + ' )'
                #else:
                node= tree['attribute'] + ' <= ' +  str(tree['cut']) 
            
            
                #if "true" == left.strip():
                #    return " ("+node +") || "+ " ((!"+node +") && ("+ right.strip() +"))"
                #if "true" == right.strip():
                #    return " ("+node +" && ("+ left.strip() +")) || "+ " ((!"+node +"))"

                #if "false" == right.strip():
                #    return " ("+node +" && ("+ left.strip() +"))"
                
                #if "false" == left.strip():
                #    return " ((!"+node +") && ("+ right.strip() +")) "
            left = this.parse_tree(tree['children'][0]) 
            right = this.parse_tree(tree['children'][1])
            
            tmp = " ("+node +" && ("+ left.strip() +")) || "+ " ((!("+node +")) && ("+ right.strip() +")) "
            tmp = tmp.replace(" && (true))",")")
            tmp = this.simplifyFalse(tmp)
            return tmp
        else:
            this.debug_print("*** parsing json error ***", True)
            sys.exit(1)



    def get_pre_from_json(this,file):
        precondition = "true"
        if os.path.exists(file):
            with open(file) as json_file:
                tree = json.load(json_file)
                precondition = this.parse_tree(tree)
        
        return precondition
        

    def removeOldPreFiles(this, methodname,learnerOutDir):
        try:
            # print "Compiling ReportParser"
            # run_compiler(set_compiler_args('ReportParser/ReportParserLearning/ReportParserLearning.sln'))
            # print "Compiling C5.0"
            # subprocess.check_output('make -C C50 clean all', shell=True)
            if os.path.exists(learnerOutDir+"/pre.data"):
                os.remove(learnerOutDir+"/pre.data")
            
            if os.path.exists(learnerOutDir+"/pre.names"):
                os.remove(learnerOutDir+"/pre.names")
            
            if os.path.exists(learnerOutDir+"/pre.json"):
                os.remove(learnerOutDir+"/pre.json")
            if os.path.exists(learnerOutDir+"/pre.out"):
                os.remove(learnerOutDir+"/pre.out")
            if os.path.exists(learnerOutDir+"/pre.tmp"):
                os.remove(learnerOutDir+"/pre.tmp")
            if os.path.exists(learnerOutDir+"/pre.tree"):
                os.remove(learnerOutDir+"/pre.tree")
            #subprocess.check_output('rm -f test_subjects/pre.*', shell=True)
            
            #Debug add seed data ##
            #write_file = open("Benchmarks/pre.data", 'w')
            #write_file.write("%s\n" % "11,1,false")
            #write_file.write("%s\n" % "9,1,true")
            #write_file.close()
            ########################
        except Exception as e:
            print e
            print "init error"
            sys.exit(1)
            

        
        
    def sort_and_unique_preds(this,data_file, log, round, methodName):
        # print subprocess.check_output('sed  -i \'/^\s*$/d\' '+  data_file, shell=True)
        # print subprocess.check_output('sort -u ' + data_file + ' -o ' + data_file, shell=True)
        # num_pred = subprocess.check_output('wc -l ' + data_file, shell=True)
        # sorted_unique_lines = set()
        # with open(data_file) as f_in:
        #     lines = filter(None, (line.rstrip() for line in f_in))
        #     sorted_unique_lines = sorted(set(lines))
        # # print "================="
        # with open(data_file, 'w') as f_in:
        #     for item in sorted_unique_lines:
        #         f_in.write("%s\n" % item)
        
        # return len(sorted_unique_lines)
        inputm = []
        dataToPrint = list()
        with open(data_file) as f_in:
            reader = csv.reader(f_in)
            for row in reader:
                if len(row) > 0: 
                    inputm.append(row)
            
            finalset = set()
            for row in inputm:
                row_backup = list(row)
                if row[-1] == 'true':
                    row_backup[-1] = 'false'
                    if row_backup in inputm:
                        this.debug_print("****found conflict****", False)
                    else:
                        finalset.add(tuple(row)) 
                else:
                    finalset.add(tuple(row))
            #loggin code
            if log:
                for item in finalset:
                    if not (item in this.allDataSet):
                        dataToPrint.append(item)
                
                this.allDataSet = this.allDataSet.union(finalset)
                with open(methodName+"_round_"+str(round)+".txt", 'w') as f_out:
                    csv_out = csv.writer(f_out)
                    for item in this.allDataSet:
                        csv_out.writerow(item) 
            # end of logging code
        finalset = sorted(finalset)
        with open(data_file, 'wb') as f_out:
            csv_out = csv.writer(f_out)
            for item in finalset:
                csv_out.writerow(item)

        return len(finalset)
    
    
    
    
    
    def sort_and_uniqueue_datapoints(this, dataPoints):
        inputm = []
        dataToPrint = list()

        for row in dataPoints:
            if len(row) > 0: 
                inputm.append(row)
        flag = False
        finalset = set()
        for row in inputm:
            row_backup = list(row)
            if row[-1] == 'true':
                row_backup[-1] = 'false'
                if row_backup in inputm:
                    this.debug_print("************found conflict****************", True)
                    flag = True
                else:
                    finalset.add(tuple(row)) 
            else:
                finalset.add(tuple(row))
                
        
        finalset = sorted(finalset)
        if not flag:
            this.debug_print(" NO Conflict Found ****************", True)
        
        return list(finalset)
        
        
    
    
    
    
    
    
    
    def insert_p_in_put(this, CSharpFile, precondition, methodname):
        fullPathCsharpFile= os.path.abspath(CSharpFile)
        file = list()
        with io.open(fullPathCsharpFile, 'r',encoding='utf-8-sig') as f:
            file = f.read().splitlines()
        

        begin = False
        index = -1
        once = True
        
        with io.open(fullPathCsharpFile  , 'w',encoding='utf-8-sig') as fWrite:
            for line in file:
                if line.find(methodname) != -1 and once:
                    begin = True
                    once = False
                elif begin and line.find("AssumePrecondition.IsTrue(") != -1:
                    index = line.find("AssumePrecondition.IsTrue(")
                    line = line[:index+26]+ precondition+ ");"
                    begin = False
                    #print line.encode.encode("utf-8")("utf-8")

                fWrite.write("%s\n" % line)

    def insert_not_p_in_put(this,testFile, precondition, testMethodname):
        fullTestFilePath = os.path.abspath(testFile)
        
        file = list()
        #reding test file to extract all lines
        with io.open(fullTestFilePath  , 'r',encoding='utf-8-sig') as f:
            file = f.read().splitlines()
        
        #inserting not p in put in test file
        begin = False
        once =True
        index = -1
        with io.open(fullTestFilePath  , 'w',encoding='utf-8-sig') as fWrite:
            for line in file:
                if line.find(testMethodname) != -1 and once:
                    begin = True
                    once = False
                elif begin and line.find("/*Change*/PexAssume.IsTrue(") != -1:
                    index = line.find("/*Change*/PexAssume.IsTrue(")
                    line = line[:index+27]+ "!("+precondition+"));"
                    this.debug_print("Not P: " + line, True)
                    begin = False
                    #print line.encode.encode("utf-8")("utf-8")
                fWrite.write("%s\n" % line)
        

    def insert_assumes(this, ClassFilePath, methodUnderTest):
            #reading file od class under test
        contentsLines = list()
        with io.open(ClassFilePath  , 'r',encoding='utf-8-sig') as f:
            contentsLines = f.read().splitlines()
        
        begin = False
        index = -1
        once =True
        nextLine = False
        with io.open(ClassFilePath  , 'w',encoding='utf-8-sig') as fWrite:
            for line in contentsLines:

                if line.find(methodUnderTest) != -1 and once:
                    #this.debug_print("method under test: " + methodUnderTest, False)
                    begin = True
                    once = False
                elif begin and line.find('//NotpAssume.IsTrue') != -1:
                    #print "********before: "+line
                    line = line.replace('//',"")
                    nextLine = True
                elif nextLine and  line.find('//try{PexAssert.IsTrue') != -1:
                    line = line.replace('//',"")
                    nextLine = False
                    #print "********uncommented: "+line

                elif begin and re.search(r"(?:(?:public)|(?:private)|(?:static)|(?:protected)\s+).*",line,re.DOTALL):# if we see the signature for next method, stop collecting assumes
                    begin = False

                fWrite.write("%s\n" % line)
        

    def remove_assumes(this, ClassFilePath, methodUnderTest):
        file = list()
        with io.open(ClassFilePath  , 'r',encoding='utf-8-sig') as f:
            file = f.read().splitlines()

        begin = False
        index = -1
        once =True
        nextLine = False
        with io.open(ClassFilePath  , 'w',encoding='utf-8-sig') as fWrite:
            for line in file:
                if line.find(methodUnderTest) != -1 and once:
                    begin = True
                    once = False
                #elif begin and line.find("/*Change*/PexAssume.IsTrue(") != -1:
                elif begin and line.find('NotpAssume.IsTrue') != -1 and line.find('//NotpAssume.IsTrue') == -1:
                    #print "********before: "+line
                    line = line.replace('Notp',"//Notp")
                    nextLine = True

                elif nextLine and  line.find('try{PexAssert.IsTrue') != -1 and line.find('//try{PexAssert.IsTrue') == -1:
                    line = line.replace('try{PexAssert',"//try{PexAssert")
                    nextLine = False
                    #print "********commenting: "+line

                elif begin and re.search(r"(?:(?:public)|(?:private)|(?:static)|(?:protected)\s+).*",line,re.DOTALL):# if we see the signature for next method, stop collecting assumes
                    begin = False
                    
                fWrite.write("%s\n" % line)

    def learnPreconditionForException(this,testMethod,mut,boolparams, intparams, vsSolution, vsTestFile, vsClassFile, vsTestDll, pexBin , vsNamespace, vsType, c5Bin, typeLearner, threshold, learnerOutDir):
        print "Beginning! -- initializing"
        this.removeOldPreFiles(testMethod,learnerOutDir)
        #comment_assumes(vsClassFile ,mut)

        this.create_names_file_with_bool(boolparams,intparams, -1, 1, '{}\{}'.format(learnerOutDir, 'pre.names'))
        old_precondition = "true"
        precondition = "true"

        loop = 1
        old_num_pred = 0
        num_pred = 0
        pexT = 0.0
        while True:
            print "loop count: " + str(loop)
            ret_p = ""
            ret_not_p = ""
            ret = ""
            
           
            #comment assume statements from not p test or  previous experiments
            this.remove_assumes(vsClassFile ,mut)
            #P Test: getting negative counter examples
            this.insert_p_in_put(vsTestFile, precondition, testMethod)
            this.debug_print("compile for p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))
            
            t0 = time.time()
            ret_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            t1 = time.time()
            pexT = pexT + (t1-t0)

            #not P Test: getting positive counter examples
            this.insert_p_in_put(vsTestFile, "!("+precondition+")", testMethod)
            this.debug_print("Adding assumes in  proj under test..", False)
            this.insert_assumes(vsClassFile, mut)
            #debug = raw_input("debug ")
            this.debug_print("compile for not p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))

            t2 = time.time()
            ret_not_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            t3 = time.time()
            pexT = pexT + (t3-t2)
            

            # No need to compile again since after inserting precondition a the top of the loop 
            # will compile again

            #sort data - get number of unique examples- resolve csonflict.
            num_pred = this.sort_and_unique_preds('{}\{}'.format(learnerOutDir, 'pre.data'), False, loop, testMethod)

            #call learner
            this.call_c50(this.set_c50_args(('{}\{}'.format(learnerOutDir, 'pre')), c5Bin, typeLearner, threshold ))
            precondition = this.get_pre_from_json('{}\{}'.format(learnerOutDir, 'pre.json'))
            this.debug_print("Precondition Learned: " + str(precondition)+os.linesep, True)
            


            #debug = raw_input("debug ")

            if ret_p == "success" and old_precondition == precondition:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Ideal: " + str(num_pred)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT

            if ret_p == "success" and num_pred == old_num_pred:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if old_precondition == precondition and num_pred == old_num_pred: 
                """and num_pred == old_num_pred"""
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print ret_p + "! precondition has not changed and no new inputs"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if loop == 100:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "max rounds reached: "+str(loop)
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            #if( num_pred == old_num_pred):
            #    print "No new inputs added"
            #    print "final Precondition: "+ str(precondition) +" in "+ str(loop)+" rounds"
            #    break

            old_precondition = precondition
            old_num_pred = num_pred
            ret_p = ""

            loop += 1            

    #Max Rounds seen in evaluations of data structure 22: so set max rounds to 50. 
    def learnPreconditionForCommutativity(this,testMethod, boolparams ,intparams, vsSolution, vsTestFile, vsTestDll, pexBin , vsNamespace, vsType, c5Bin, typeLearner, threshold, learnerOutDir):
        print "Beginning! -- initializing"
        this.removeOldPreFiles(testMethod, learnerOutDir)
        #remove_assumes(vsClassFile ,mut)

        intparams
        this.create_names_file_with_bool(boolparams,intparams, -1, 1, '{}\{}'.format(learnerOutDir, 'pre.names'))
        old_precondition = "true"
        precondition = "true"
        #this.debug_print("cleaning solution...", False)

        loop = 1
        old_num_pred = 0
        num_pred = 0
        pexT = 0.0
        while True:
            print "loop count: " + str(loop)
            ret_p = ""
            ret_not_p = ""
            ret = ""

            #comment assume statements from not p test or  previous experiments
            this.remove_assumes(vsTestFile ,testMethod)
            #P Test: getting negative counter examples
            this.insert_p_in_put(vsTestFile, precondition, testMethod)
            this.debug_print("compile for p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))

            t0 = time.time()
            ret_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            t1 = time.time()
            pexT = pexT + (t1-t0)
            #not P Test: getting positive counter examples
            this.insert_p_in_put(vsTestFile, "!("+precondition+")", testMethod)
            this.debug_print("Adding assumes in  proj under test..", False)
            this.insert_assumes(vsTestFile, testMethod)
            #debug = raw_input("debug ")
            this.debug_print("compile for not p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))
            
            t2 = time.time()
            ret_not_p = this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            t3 = time.time()
            pexT = pexT + (t3-t2)
            # No need to compile again since after inserting precondition a the top of the loop 
            # will compile again

            #this.debug_print("compile", False)
            #this.run_compiler(this.set_compiler_args(vsSolution))
   
            #sort data - get number of unique examples- resolve csonflict.
            num_pred = this.sort_and_unique_preds('{}\{}'.format(learnerOutDir, 'pre.data'), False, loop, testMethod)

            #call learner
            this.call_c50(this.set_c50_args(('{}\{}'.format(learnerOutDir, 'pre')), c5Bin, typeLearner, threshold ))
            precondition = this.get_pre_from_json('{}\{}'.format(learnerOutDir, 'pre.json'))
            this.debug_print("Precondition Learned: " + str(precondition)+os.linesep, True)
        
            #debug = raw_input("check p test data points ")
            #debug = raw_input("debug ")
            #debug = raw_input("debug ")

            if ret_p == "success" and old_precondition == precondition:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Ideal: " + str(num_pred)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT

            if ret_p == "success" and num_pred == old_num_pred:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if old_precondition == precondition and num_pred == old_num_pred: 
                """and num_pred == old_num_pred"""
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print ret_p + "! precondition has not changed and no new inputs"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if loop == 100:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "max rounds reached: "+str(loop)
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            #if( num_pred == old_num_pred):
            #    print "No new inputs added"
            #    print "final Precondition: "+ str(precondition) +" in "+ str(loop)+" rounds"
            #    break

            old_precondition = precondition
            old_num_pred = num_pred
            ret_p = ""

            loop += 1



    def parseReport(this, reportPath):
        tree = etree.parse(reportPath)
        dataPoints = []
        for test in tree.xpath('//generatedTest'):
            singlePoint = []
            for value in test.xpath('./value'):
                if re.match("^\$.*", value.xpath('./@name')[0]):
                    singlePoint.append(value.xpath('string()'))

            if test.get('status') == 'normaltermination':
                singlePoint.append('true')
            else:
                singlePoint.append('false')
            # alternatives: test.get('failed') => true / None
            # exceptionState
            # failureText

            dataPoints.append(singlePoint)
        return dataPoints



    def getPexResult(this, reportPoints ):
        # pex results
        # if parser_output.find("Pex Found No Error") != -1:
        #         return "success"
        #     if parser_output.find("No passing or failing inputs were generated") != -1:
        #         return "debug"
        #     return "not done yet"
    

        if len(reportPoints) == 0 :
            return "debug"

        if "false" in [row[-1] for row in reportPoints]:
            return "not done yet"
        else: 
            return "success"
        
    
    
    #Max Rounds seen in evaluations of data structure 22: so set max rounds to 50. 
    def learnPreconditionForCommutativityMultipleLearner(this,testMethod, boolparams ,intparams, vsSolution, vsTestFile, vsTestDll, pexBin , vsNamespace, vsType, c5Bin, typeLearner, threshold, learnerOutDir):
        print "Beginning! -- initializing"
        this.removeOldPreFiles(testMethod, learnerOutDir)
        #remove_assumes(vsClassFile ,mut)
        
        # ADDED: INIT
        # learner = Sygus("esolver", "learners/EnumerativeSolver/bin/starexec_run_Default", "", "tempLocation")
        
        # learner = PIE("piee", "learners/PIE/runPIE.sh", "", "learners/PIE/app") 
        # learner = SygusEU("eusolver", "learners/eusolver/eusolver.sh", "", "tempLocation")
        learner = PieFeatures("piee", "learners/PIE/runPIE.sh", "", "learners/PIE/app") 
        
        
        
        learner.setVariables(intparams, boolparams)
        dataPoints = []
        
        intparams
        # this.create_names_file_with_bool(boolparams,intparams, -1, 1, '{}\{}'.format(learnerOutDir, 'pre.names'))
        old_precondition = "true"
        precondition = "true"
        #this.debug_print("cleaning solution...", False)
        
        loop = 1
        old_num_pred = 0
        num_pred = 0
        pexT = 0.0
        while True:
            print datetime.datetime.now()
            print "loop count: " + str(loop)
            ret_p = ""
            ret_not_p = ""
            ret = ""

            #comment assume statements from not p test or  previous experiments
            this.remove_assumes(vsTestFile ,testMethod)
            #P Test: getting negative counter examples
            this.insert_p_in_put(vsTestFile, precondition, testMethod)
            this.debug_print("compile for p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))
            
            shutil.rmtree(os.path.split(vsTestDll)[0] + '/myreport', ignore_errors=True, onerror=None)
            
            t0 = time.time()
            this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            
            # ADDED: EXTRAXT DATAPOINTS
            reportPoints = this.parseReport(os.path.split(vsTestDll)[0] + '/myreport/rep/report.per')
            ret_p = this.getPexResult(reportPoints)
            pprint(reportPoints)
            for point in reportPoints: dataPoints.append (point)

            
            t1 = time.time()
            pexT = pexT + (t1-t0)
            #not P Test: getting positive counter examples
            this.insert_p_in_put(vsTestFile, "!("+precondition+")", testMethod)
            this.debug_print("Adding assumes in  proj under test..", False)
            this.insert_assumes(vsTestFile, testMethod)
            #debug = raw_input("debug ")
            this.debug_print("compile for not p", False)
            this.run_compiler(this.set_compiler_args(vsSolution))
            
            shutil.rmtree(os.path.split(vsTestDll)[0] + '/myreport', ignore_errors=True, onerror=None)

            
            t2 = time.time()
            this.run_pex(this.set_pex_args(testMethod, vsTestDll, pexBin,vsNamespace, vsType ))
            
            #ADDED: EXTRACT DATAPOINTS
            reportPoints = this.parseReport(os.path.split(vsTestDll)[0] + '/myreport/rep/report.per')
            pprint(reportPoints)
            ret_not_p = this.getPexResult(reportPoints)

            for point in reportPoints: dataPoints.append (point)
            
            
            t3 = time.time()
            pexT = pexT + (t3-t2)
            # No need to compile again since after inserting precondition a the top of the loop 
            # will compile again

            #this.debug_print("compile", False)
            #this.run_compiler(this.set_compiler_args(vsSolution))
   
            # ADDED:SORT AND UNIQUEUE
            dataPoints = this.sort_and_uniqueue_datapoints(dataPoints)
            num_pred = len(dataPoints)
            
            
            #sort data - get number of unique examples- resolve csonflict.
            # num_pred = this.sort_and_unique_preds('{}\{}'.format(learnerOutDir, 'pre.data'), False, loop, testMethod)

            print datetime.datetime.now()
            # ************ call new learner********************
            precondition = learner.learn(dataPoints)
            this.debug_print("Precondition Learned: " + str(precondition)+os.linesep, True)
            
        
            #COMMENTED OUT
            #call learner
            # this.call_c50(this.set_c50_args(('{}\{}'.format(learnerOutDir, 'pre')), c5Bin, typeLearner, threshold ))
            # precondition = this.get_pre_from_json('{}\{}'.format(learnerOutDir, 'pre.json'))
            # this.debug_print("Precondition Learned: " + str(precondition)+os.linesep, True)
            
            
            #debug = raw_input("check p test data points ")
            #debug = raw_input("debug ")
            #debug = raw_input("debug ")
            
            if ret_p == "success" and old_precondition == precondition:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Ideal: " + str(num_pred)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT

            if ret_p == "success" and num_pred == old_num_pred:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "No Errors Founds!"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if old_precondition == precondition and num_pred == old_num_pred: 
                """and num_pred == old_num_pred"""
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print ret_p + "! precondition has not changed and no new inputs"
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            
            if loop == 100:
                this.insert_p_in_put(vsTestFile, precondition, testMethod)
                print "Data Set Size: " + str(num_pred)
                print "max rounds reached: "+str(loop)
                print "final Precondition: "
                return testMethod, str(precondition), str(loop), num_pred, pexT
            #if( num_pred == old_num_pred):
            #    print "No new inputs added"
            #    print "final Precondition: "+ str(precondition) +" in "+ str(loop)+" rounds"
            #    break

            old_precondition = precondition
            old_num_pred = num_pred
            ret_p = ""

            loop += 1




