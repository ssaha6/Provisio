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
import traceback
from analysis import Analysis

#setting paths
# devenv_path = '/mnt/c/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio\ 10.0/Common7/IDE/'
# pex_path = '/mnt/c/Program\ Files\ \(x86\)/Microsoft\ Pex/bin/'


dataStructureReportLocation = "BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/reports"
codeContractReportLocation = "BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/bin/Debug/reports"
holaReportLocation = "BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/bin/Debug/reports"
dsaReportLocation = "BenchmarksAll/eva-dsa/Dsa.PUTs/bin/Debug/reports"
quickGraphReportLocation =  "BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/reports"

def main():
    
    pex = 'pex.exe'
    c5Exact = ".\learners\C50exact\c5.0dbg.exe"
    c5p2n = ".\learners\C50p2n\c5.0dbg.exe"
    
    
    # run_StackCommuteOnly(c5Exact, pex, "exact","100","StackEqualityAllNoBoundsExact.txt")
    # run_StackCommuteOnly(c5p2n, pex, "prune","80","EqualityAllNoBounds80")
    
    # run_QueueCommuteOnly(c5Exact, pex,"exact","100","QueueEqualityAllNoBoundsExact.txt")
    #run_QueueCommuteOnly(c5p2n, pex,"prune" , "80")
    
    
    
    
    
    # run_PriorityQueueCommutativity(c5Exact,pex,"exact","100","QuickGraphPriorityQueueEqualityExact.txt")
    # run_BinaryHeapCommutativity3(c5Exact,pex,"exact","100","QuickGraph3BinaryHeapEqualityExact.txt")
    
    
    
    # run_SetCommuteOnly(c5Exact, pex,"exact","100","SetEqualityAllBoundsExact.txt")
    #run_SetCommuteOnly(c5p2n, pex, "prune" , "80")
    
    # run_MapCommuteOnly(c5Exact,pex,"exact","100","MapEqualityAllBoundsExact.txt")
    #run_MapCommuteOnly(c5p2n,pex,"prune" , "80")
    
    run_ArrayList(c5Exact,pex,"exact","100","ArrayEqualityAllBoundsExact.txt")
    # #run_ArrayList(c5p2n,pex,"prune" , "80")
    
    run_BinaryHeapCommutativity(c5Exact,pex,"exact","100","QuickGraphBinaryHeapEqualityExact.txt")
    
    run_QuickGraphCommutivity(c5Exact,pex,"exact","100","QuickGraphEqualityExact.txt")
    
    
    #Exception Cases
   	# run_BinaryHeapException(c5Exact,pex,"exact","100","QuickGraphBinaryHeapExceptionExact.txt")
    #run_CodeContracts(c5Exact,pex,"exact","100","CCheckEqualityAllNoBoundsExact.txt")
    #run_Hola(c5Exact,pex,"exact","100","HolaEqualityAllNoBoundsExact.txt")
    #run_DSA(c5Exact,pex,"exact","100", "DSAEqualityExact.txt")


def printToFile(name, p , rounds, time, data, file, pexTime, normalExec):
    with io.open(file,"a", encoding='utf-8-sig') as myfile:
        myfile.write(unicode("Evaluation for method: " +name+"\r\n"))
        if normalExec:
            myfile.write(unicode('{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t\r\n'.format(name," "," "," "," "," ", p," ", rounds, time," " ," " ," " ," " , data,pexTime)))
            print '{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t'.format(name," "," "," "," "," ", p," ", rounds, time," " ," " ," " ," " , data,pexTime)   
        else:
            myfile.write(unicode('{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t{}\t\r\n'.format(name," "," "," "," "," ", "error"," ","", time," " ," " ," " ," " , data, pexTime) ))
            print "error"

def run_StackCommuteOnly(learner, pex,typeLearner, thres,file):
    
    dataStructSolutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln'
    dataStructTestDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll'
    stackTestFile = 'BenchmarksAll/DataStructures/DataStructuresTest/StackCommuteTest.cs'
    stackClassFile='BenchmarksAll/DataStructures/DataStructures/Stack.cs'
    stackTestNamespace = 'DataStructures.Comm.Test'
    stackTestType = 'StackCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0
    listOfInputs =[
    ('PUT_CommutativityPeekPeekComm', [ ], ['s1.Count', 's1.Peek()'], 0), 
    ('PUT_CommutativityPeekPopComm', [ ], ['s1.Count', 's1.Peek()'], 1), 
    ('PUT_CommutativityPopPopComm', [ ], ['s1.Count', 's1.Peek()'], 2), 
    ('PUT_CommutativityPushPeekComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 3), 
    ('PUT_CommutativityPushPopComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 4), 
    ('PUT_CommutativityPushPushComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.Peek()'], 5), 
    ('PUT_CommutativitySizePeekComm', [ ], ['s1.Count', 's1.Peek()'], 6), ('PUT_CommutativitySizePopComm', [ ], ['s1.Count', 's1.Peek()'], 7), 
    ('PUT_CommutativitySizePushComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 8), ('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count', 's1.Peek()'], 9)
    ]

    print "***** Beginning Stack Commutativity Analysis *****"
    #print "***** starting Exact *****"
    
    for i in xrange(0,1):
        if os.path.exists(dataStructureReportLocation):
            shutil.rmtree(dataStructureReportLocation)
        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            
            name,p,rounds,data, pexTime = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile, 
               dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e


def run_QueueCommuteOnly(learner, pex,typeLearner, thres,file):

    dataStructSolutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln'
    dataStructTestDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll'
    queueTestFile = 'BenchmarksAll/DataStructures/DataStructuresTest/QueueCommuteTest.cs'
    queueClassFile='BenchmarksAll/DataStructures/DataStructures/Queue.cs'
    queueTestNamespace = 'DataStructures.Comm.Test'
    queueTestType = 'QueueCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0

    pexTime = 0.0
    listOfInputs =  [
 ('PUT_CommutativityPeekPeekComm', [ ], ['s1.Count', 's1.Peek()'], 0),
 ('PUT_CommutativityPeekDequeueComm', [ ], ['s1.Count', 's1.Peek()'], 1),
 ('PUT_CommutativityDequeueDequeueComm', [ ], ['s1.Count', 's1.Peek()'], 2),
 ('PUT_CommutativityEnqueuePeekComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 3),
 ('PUT_CommutativityEnqueueDequeueComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 4),
 ('PUT_CommutativityEnqueueEnqueueComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.Peek()'], 5),
 ('PUT_CommutativitySizePeekComm', [ ], ['s1.Count', 's1.Peek()'], 6),
 ('PUT_CommutativitySizeDequeueComm', [ ], ['s1.Count', 's1.Peek()'], 7),
 ('PUT_CommutativitySizeEnqueueComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'], 8),
 ('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count', 's1.Peek()'], 9)
 ]

    print "***** Beginning QueueComm Commutativity Analysis *****"
    print "***** starting Exact *****"
    
    for i in xrange(0,10):
        
        if os.path.exists(dataStructureReportLocation):
            shutil.rmtree(dataStructureReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        try:    
            t0 = time.time()
            myAnalysis = Analysis()
            
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, queueTestFile, 
                dataStructTestDll, pex, queueTestNamespace, queueTestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)

        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e

def run_SetCommuteOnly(learner, pex, typeLearner, thres,file):
    dataStructSolutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln'
    dataStructTestDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll'
    setTestFile = 'BenchmarksAll/DataStructures/DataStructuresTest/HashSetCommuteTest.cs'
    setClassFile='BenchmarksAll/DataStructures/DataStructures/HashSet.cs'
    setTestNamespace = 'DataStructures.Comm.Test'
    setTestType = 'HashSetCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0

    pexTime = 0.0
    listOfInputs =[
    #  ('PUT_CommutativityContainsContainsComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 0),
    ('PUT_CommutativityContainsAddComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 1),
    ('PUT_CommutativityContainsRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 2),
    #  ('PUT_CommutativityContainsSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'], 3),
    ('PUT_CommutativityAddAddComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 4),
    #  ('PUT_CommutativityAddRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 5),
    #  ('PUT_CommutativityAddSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'], 6),
    ('PUT_CommutativityRemoveRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 7),
    #  ('PUT_CommutativityRemoveSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'], 8),
    #  ('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count'], 9)
    ]

    print "***** Beginning Set Commutativity Analysis *****"
    
    
    for i in xrange(0, len(listOfInputs)):
        if os.path.exists(dataStructureReportLocation):
            shutil.rmtree(dataStructureReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime  = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, setTestFile, 
                dataStructTestDll, pex, setTestNamespace, setTestType, learner, typeLearner, thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e

def run_MapCommuteOnly(learner, pex,typeLearner, thres,file):
    dataStructSolutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln'
    dataStructTestDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll'
    mapTestFile = 'BenchmarksAll/DataStructures/DataStructuresTest/DictionaryCommuteTest.cs'
    mapClassFile='BenchmarksAll/DataStructures/DataStructures/Dictionary.cs'
    mapTestNamespace = 'DataStructures.Comm.Test'
    mapTestType = 'DictionaryCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    
    pexTime = 0.0
    listOfInputs = [
    ('PUT_CommutativityRemoveRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'], 0), 
    ('PUT_CommutativityRemoveAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'y', 'y1'], 1), 
    ('PUT_CommutativityAddAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'], 2), 
    # # ('PUT_CommutativityGetGetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'], 3), 
    ('PUT_CommutativityGetAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'y', 'y1'], 4), 
    # # ('PUT_CommutativityGetRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'], 5), 
    ('PUT_CommutativitySetSetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'], 6), 
    ('PUT_CommutativitySetAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'], 7), 
    # # ('PUT_CommutativitySetRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)'], ['s1.Count', 'x', 'x1', 'y'], 8), 
    ('PUT_CommutativitySetGetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)'], ['s1.Count', 'x', 'x1', 'y'], 9)
    ]
     
    print "***** Beginning Map Commutativity Analysis *****"
    print "***** starting Map *****"

    for i in xrange(0,len(listOfInputs)):
        if os.path.exists(dataStructureReportLocation):
            shutil.rmtree(dataStructureReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime  = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, mapTestFile, 
                dataStructTestDll, pex, mapTestNamespace, mapTestType, learner, typeLearner, thres, learnerOutputDir)  
            
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e
    

def run_ArrayList(learner, pex, typeLearner, thres,file):

    dataStructSolutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln'
    dataStructTestDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll'
    stackTestFile = 'BenchmarksAll/DataStructures/DataStructuresTest/ArrayListTest.cs'
    setClassFile='BenchmarksAll/DataStructures/DataStructures/ArrayList.cs'
    stackTestNamespace = 'DataStructures.Test'
    stackTestType = 'ArrayListTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0

    pexTime = 0.0
    listOfInputs = [
        # ('PUT_CommutativityAddAdd', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 0),
        ('PUT_CommutativityAddContains', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 1),
        # ('PUT_CommutativityAddCount', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)'], 2),
        # ('PUT_CommutativityAddGet', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 3),
        ('PUT_CommutativityAddIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 4),
        # ('PUT_CommutativityAddInsert', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.IndexOf(y1)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)', 's1.LastIndexOf(y1)'], 5),
        # ('PUT_CommutativityAddLastIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 6),
        ('PUT_CommutativityAddRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 7),
        # ('PUT_CommutativityAddRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 8),
        ('PUT_CommutativityAddSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.IndexOf(y1)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)', 's1.LastIndexOf(y1)'], 9),
        # ('PUT_CommutativityContainsContains', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 10),
        # ('PUT_CommutativityContainsCount', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)'], 11),
        # ('PUT_CommutativityContainsGet', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 12),
        # ('PUT_CommutativityContainsIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 13),
        # ('PUT_CommutativityContainsInsert', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.IndexOf(y1)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)', 's1.LastIndexOf(y1)'], 14),
        # ('PUT_CommutativityContainsRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'], 15),
        # ('PUT_CommutativityContainsRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'], 16),
        # ('PUT_CommutativityContainsSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1'], 17),
        # ('PUT_CommutativityCountCount', [ ], ['s1.Count'], 18),
        # ('PUT_CommutativityCountGet', [ 's1.Contains(y)'], ['s1.Count', 'y'], 19),
        # ('PUT_CommutativityCountIndexOf', [ 's1.Contains(y)'], ['s1.Count', 'y'], 20),
        # ('PUT_CommutativityCountInsert', [ 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 21),
        # ('PUT_CommutativityCountLastIndexOf', [ 's1.Contains(y)'], ['s1.Count', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 22),
        # ('PUT_CommutativityCountRemove', [ 's1.Contains(y)'], ['s1.Count', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 23),
        # ('PUT_CommutativityCountRemoveAt', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)'], 24),
        # ('PUT_CommutativityCountSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 25),
        # ('PUT_CommutativityGetGet', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 26),
        # ('PUT_CommutativityGetIndexof', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 27),
        # ('PUT_CommutativityGetInsert', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 28),
        # ('PUT_CommutativityGetLastIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 29),
        # ('PUT_CommutativityGetRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 30),
        # ('PUT_CommutativityGetRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 31),
        # ('PUT_CommutativityGetSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 32),
        # ('PUT_CommutativityIndexOfIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 33),
        # ('PUT_CommutativityIndexOfInsert', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 34),
        # ('PUT_CommutativityIndexOfLastIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 35),
        # ('PUT_CommutativityIndexOfRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 36),
        # ('PUT_CommutativityIndexOfRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 37),
        # ('PUT_CommutativityIndexOfSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 38),
        # ('PUT_CommutativityInsertInsert', [ 's1.Contains(x)', 's1.Contains(x1)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'x1', 's1.IndexOf(x1)', 's1.LastIndexOf(x1)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 39),
        # ('PUT_CommutativityInsertLastIndexOf', [ 's1.Contains(x)', 's1.Contains(x1)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'x1', 's1.IndexOf(x1)', 's1.LastIndexOf(x1)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 40),
        # ('PUT_CommutativityInsertRemove', [ 's1.Contains(x)', 's1.Contains(x1)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'x1', 's1.IndexOf(x1)', 's1.LastIndexOf(x1)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 41),
        # ('PUT_CommutativityInsertRemoveAt', [ 's1.Contains(x)', 's1.Contains(x1)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'x1', 's1.IndexOf(x1)', 's1.LastIndexOf(x1)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 42),
        # ('PUT_CommutativityInsertSet', [ 's1.Contains(x)', 's1.Contains(x1)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'x1', 's1.IndexOf(x1)', 's1.LastIndexOf(x1)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 43),
        # ('PUT_CommutativityLastIndexOfLastIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 44),
        # ('PUT_CommutativityLastIndexOfRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 45),
        # ('PUT_CommutativityLastIndexOfRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 46),
        # ('PUT_CommutativityLastIndexOfSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 47),
        # ('PUT_CommutativityRemoveRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 48),
        # ('PUT_CommutativityRemoveRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 49),
        # ('PUT_CommutativityRemoveSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1', 's1.IndexOf(y1)', 's1.LastIndexOf(y1)'], 50),
        # ('PUT_CommutativityRemoveAtRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)'], 51),
        # ('PUT_CommutativityRemoveAtSet', [ ], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)', 'y', 's1.IndexOf(y)', 's1.LastIndexOf(y)', 'y1'], 52)
        ]
    
    print "***** Beginning ArrayList Commutativity Analysis *****"
    print "***** starting Exact *****"

    for i in xrange(0,len(listOfInputs)):

        if os.path.exists(dataStructureReportLocation):
            shutil.rmtree(dataStructureReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]

        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile,
                dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner, thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e



def run_QuickGraphCommutivity(learner, pex,typeLearner, thres,file):

    dataStructSolutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln'
    dataStructTestDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll'
    stackTestFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/UndirectedGraphCommuteTest.cs'
    stackClassFile = 'BenchmarksAll/QuickGraph/QuickGraph/UndirectedGraph.cs'
    stackTestNamespace = 'QuickGraphTest'
    stackTestType = 'UndirectedGraphCommuteTest'
    learnerOutputDir = 'BenchmarksAll'
    
    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    #   , 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'
    pexTime = 0.0
    listOfInputs = [
        
        #using
        ('PUT_CommutativityAddVertexAddVertexComm', [ 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 0),

        # ('PUT_CommutativityAddVertexRemoveVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 1),
        # ('PUT_CommutativityAddVertexClearAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 2),
        # ('PUT_CommutativityAddVertexContainsEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 3),
        ('PUT_CommutativityAddVertexAdjacentEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount'], 4),
        ('PUT_CommutativityAddVertexIsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 5),
        # ('PUT_CommutativityAddVertexVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 6),
        # ('PUT_CommutativityAddVertexContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 7),
        # ('PUT_CommutativityAddVertexAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 8),
        # ('PUT_CommutativityAddVertexAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 9),
        # ('PUT_CommutativityAddVertexRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 10),
        # ('PUT_CommutativityAddVertexRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 11),
        # ('PUT_CommutativityAddVertexIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 12),
        # ('PUT_CommutativityAddVertexEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 13),
        # ('PUT_CommutativityAddVertexContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 14),
        # ('PUT_CommutativityAddVertexAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 15),
        # ('PUT_CommutativityAddVertexAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 16),
        # ('PUT_CommutativityAddVertexIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 17),
        # ('PUT_CommutativityRemoveVertexRemoveVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 18),
        # ('PUT_CommutativityRemoveVertexClearAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 19),
        # ('PUT_CommutativityRemoveVertexContainsEdge1Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 20),
        # ('PUT_CommutativityRemoveVertexAdjacentEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount'], 21),
        # ('PUT_CommutativityRemoveVertexIsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 22),
        # ('PUT_CommutativityRemoveVertexVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 23),
        # ('PUT_CommutativityRemoveVertexContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount'], 24),
        # ('PUT_CommutativityRemoveVertexAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 25),
        # ('PUT_CommutativityRemoveVertexAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 26),
        # ('PUT_CommutativityRemoveVertexRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount'], 27),
        # ('PUT_CommutativityRemoveVertexRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.AllowParallelEdges', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 28),
        # ('PUT_CommutativityRemoveVertexIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount'], 29),
        # ('PUT_CommutativityRemoveVertexEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 30),
        # ('PUT_CommutativityRemoveVertexContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 31),
        # ('PUT_CommutativityRemoveVertexAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 32),
        # ('PUT_CommutativityRemoveVertexAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 33),
        # ('PUT_CommutativityRemoveVertexIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 34),
        # ('PUT_CommutativityClearAdjacentEdgesClearAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 35),
        # ('PUT_CommutativityClearAdjacentEdgesContainsEdge1Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 36),
        # ('PUT_CommutativityClearAdjacentEdgesAdjacentEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 37),
        # ('PUT_CommutativityClearAdjacentEdgesIsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 38),
        # ('PUT_CommutativityClearAdjacentEdgesVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 39),
        # ('PUT_CommutativityClearAdjacentEdgesContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 40),
        # ('PUT_CommutativityClearAdjacentEdgesAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 41),
        # ('PUT_CommutativityClearAdjacentEdgesAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 42),
        # ('PUT_CommutativityClearAdjacentEdgesRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 43),
        # ('PUT_CommutativityClearAdjacentEdgesRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'srcs.Contains(node) | tars.Contains(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 44),
        # ('PUT_CommutativityClearAdjacentEdgesIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 45),
        # ('PUT_CommutativityClearAdjacentEdgesEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 46),
        # ('PUT_CommutativityClearAdjacentEdgesContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 47),
        # ('PUT_CommutativityClearAdjacentEdgesAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 48),
        # ('PUT_CommutativityClearAdjacentEdgesAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 49),
        # ('PUT_CommutativityClearAdjacentEdgesIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 50),
        # ('PUT_CommutativityContainsEdge1ContainsEdge1Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 51),
        # ('PUT_CommutativityContainsEdge1AdjacentEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 52),
        # ('PUT_CommutativityContainsEdge1IsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 53),
        # ('PUT_CommutativityContainsEdge1VertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 54),
        # ('PUT_CommutativityContainsEdge1ContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 55),
        # ('PUT_CommutativityContainsEdge1AddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 56),
        # ('PUT_CommutativityContainsEdge1AddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 57),
        # ('PUT_CommutativityContainsEdge1RemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 58),
        # ('PUT_CommutativityContainsEdge1RemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 59),
        # ('PUT_CommutativityContainsEdge1IsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 60),
        # ('PUT_CommutativityContainsEdge1EdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 61),
        # ('PUT_CommutativityContainsEdge1ContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 62),
        # ('PUT_CommutativityContainsEdge1AdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 63),
        # ('PUT_CommutativityContainsEdge1AdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 64),
        # ('PUT_CommutativityContainsEdge1IsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 65),
        # ('PUT_CommutativityAdjacentEdgeAdjacentEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index1', 'index2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 66),
        # ('PUT_CommutativityAdjacentEdgeIsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 67),
        # ('PUT_CommutativityAdjacentEdgeVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 68),
        # ('PUT_CommutativityAdjacentEdgeContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 69),
        # ('PUT_CommutativityAdjacentEdgeAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 70),
        # ('PUT_CommutativityAdjacentEdgeAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 71),
        # ('PUT_CommutativityAdjacentEdgeRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 72),
        # ('PUT_CommutativityAdjacentEdgeRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 73),
        # ('PUT_CommutativityAdjacentEdgeIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 74),
        # ('PUT_CommutativityAdjacentEdgeEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 75),
        # ('PUT_CommutativityAdjacentEdgeContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 76),
        # ('PUT_CommutativityAdjacentEdgeAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 77),
        # ('PUT_CommutativityAdjacentEdgeAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 78),
        # ('PUT_CommutativityAdjacentEdgeIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 79),
        # ('PUT_CommutativityIsVerticesEmptyIsVerticesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 80),
        # ('PUT_CommutativityIsVerticesEmptyVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 81),
        # ('PUT_CommutativityIsVerticesEmptyContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 82),
        # ('PUT_CommutativityIsVerticesEmptyAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 83),
        # ('PUT_CommutativityIsVerticesEmptyAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 84),
        # ('PUT_CommutativityIsVerticesEmptyRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 85),
        # ('PUT_CommutativityIsVerticesEmptyRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 86),
        # ('PUT_CommutativityIsVerticesEmptyIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 87),
        # ('PUT_CommutativityIsVerticesEmptyEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 88),
        # ('PUT_CommutativityIsVerticesEmptyContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 89),
        # ('PUT_CommutativityIsVerticesEmptyAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 90),
        # ('PUT_CommutativityIsVerticesEmptyAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 91),
        # ('PUT_CommutativityIsVerticesEmptyIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 92),
        # ('PUT_CommutativityVertexCountVertexCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 93),
        # ('PUT_CommutativityVertexCountContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 94),
        # ('PUT_CommutativityVertexCountAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 95),
        # ('PUT_CommutativityVertexCountAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 96),
        # ('PUT_CommutativityVertexCountRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 97),
        # ('PUT_CommutativityVertexCountRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 98),
        # ('PUT_CommutativityVertexCountIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 99),
        # ('PUT_CommutativityVertexCountEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 100),
        # ('PUT_CommutativityVertexCountContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 101),
        # ('PUT_CommutativityVertexCountAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 102),
        # ('PUT_CommutativityVertexCountAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 103),
        # ('PUT_CommutativityVertexCountIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 104),
        # ('PUT_CommutativityContainsVertexContainsVertexComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 105),
        # ('PUT_CommutativityContainsVertexAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 106),
        # ('PUT_CommutativityContainsVertexAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 107),
        # ('PUT_CommutativityContainsVertexRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 108),
        # ('PUT_CommutativityContainsVertexRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 109),
        # ('PUT_CommutativityContainsVertexIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 110),
        # ('PUT_CommutativityContainsVertexEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 111),
        # ('PUT_CommutativityContainsVertexContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 112),
        # ('PUT_CommutativityContainsVertexAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 113),
        # ('PUT_CommutativityContainsVertexAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 114),
        # ('PUT_CommutativityContainsVertexIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 115),
        # ('PUT_CommutativityAddEdgeAddEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 116),
        # ('PUT_CommutativityAddEdgeAddEdgeRangeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)', 'edges.Contains(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 117),
        # ('PUT_CommutativityAddEdgeRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 118),
        # ('PUT_CommutativityAddEdgeRemoveEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)', 'edges.Contains(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 119),
        # ('PUT_CommutativityAddEdgeIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 120),
        # ('PUT_CommutativityAddEdgeEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 121),
        # ('PUT_CommutativityAddEdgeContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 122),
        # ('PUT_CommutativityAddEdgeAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 123),
        # ('PUT_CommutativityAddEdgeAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 124),
        # ('PUT_CommutativityAddEdgeIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 125),
        # ('PUT_CommutativityAddEdgeRangeAddEdgeRangeComm', [ 'srcs1.Length', 'srcs2.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 126),
        # ('PUT_CommutativityAddEdgeRangeRemoveEdgeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)', 'edges.Contains(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 127),
        # ('PUT_CommutativityAddEdgeRangeRemoveEdgesComm', [ 'srcs1.Length', 'srcs2.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 128),
        # ('PUT_CommutativityAddEdgeRangeIsEdgesEmptyComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 129),
        # ('PUT_CommutativityAddEdgeRangeEdgeCountComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 130),
        # ('PUT_CommutativityAddEdgeRangeContainsEdge2Comm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 131),
        # ('PUT_CommutativityAddEdgeRangeAdjacentEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 132),
        # ('PUT_CommutativityAddEdgeRangeAdjacentDegreeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 133),
        # ('PUT_CommutativityAddEdgeRangeIsAdjacentEdgesEmptyComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 134),
        # ('PUT_CommutativityRemoveEdgeRemoveEdgeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 135),
        # ('PUT_CommutativityRemoveEdgeRemoveEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)', 'edges.Contains(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 136),
        # ('PUT_CommutativityRemoveEdgeIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 137),
        # ('PUT_CommutativityRemoveEdgeEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 138),
        # ('PUT_CommutativityRemoveEdgeContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 139),
        # ('PUT_CommutativityRemoveEdgeAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 140),
        # ('PUT_CommutativityRemoveEdgeAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 141),
        # ('PUT_CommutativityRemoveEdgeIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 142),
        # ('PUT_CommutativityRemoveEdgesRemoveEdgesComm', [ 'srcs1.Length', 'srcs2.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 143),
        # ('PUT_CommutativityRemoveEdgesIsEdgesEmptyComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 144),
        # ('PUT_CommutativityRemoveEdgesEdgeCountComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 145),
        # ('PUT_CommutativityRemoveEdgesContainsEdge2Comm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 146),
        # ('PUT_CommutativityRemoveEdgesAdjacentEdgesComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 147),
        # ('PUT_CommutativityRemoveEdgesAdjacentDegreeComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 148),
        # ('PUT_CommutativityRemoveEdgesIsAdjacentEdgesEmptyComm', [ 'srcs.Length', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 149),
        # ('PUT_CommutativityIsEdgesEmptyIsEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 150),
        # ('PUT_CommutativityIsEdgesEmptyEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 151),
        # ('PUT_CommutativityIsEdgesEmptyContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 152),
        # ('PUT_CommutativityIsEdgesEmptyAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 153),
        # ('PUT_CommutativityIsEdgesEmptyAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 154),
        # ('PUT_CommutativityIsEdgesEmptyIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 155),
        # ('PUT_CommutativityEdgeCountEdgeCountComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['g1.VertexCount', 'g1.EdgeCount'], 156),
        # ('PUT_CommutativityEdgeCountContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 157),
        # ('PUT_CommutativityEdgeCountAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 158),
        # ('PUT_CommutativityEdgeCountAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 159),
        # ('PUT_CommutativityEdgeCountIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)'], 160),
        # ('PUT_CommutativityContainsEdge2ContainsEdge2Comm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsEdge(e1)', 'g1.ContainsEdge(e2)'], ['e1.Source', 'e1.Target', 'e2.Source', 'e2.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(e1.Source)', 'g1.AdjacentDegree(e1.Target)', 'g1.AdjacentDegree(e2.Source)', 'g1.AdjacentDegree(e2.Target)', 'g1.ContainsVertex(e1.Source)', 'g1.ContainsVertex(e1.Target)', 'g1.ContainsVertex(e2.Source)', 'g1.ContainsVertex(e2.Target)'], 161),
        # ('PUT_CommutativityContainsEdge2AdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 162),
        # ('PUT_CommutativityContainsEdge2AdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 163),
        # ('PUT_CommutativityContainsEdge2IsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)'], 164),
        # ('PUT_CommutativityAdjacentEdgesAdjacentEdgesComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 165),
        # ('PUT_CommutativityAdjacentEdgesAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 166),
        # ('PUT_CommutativityAdjacentEdgesIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 167),
        # ('PUT_CommutativityAdjacentDegreeAdjacentDegreeComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 168),
        # ('PUT_CommutativityAdjacentDegreeIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 169),
        # ('PUT_CommutativityIsAdjacentEdgesEmptyIsAdjacentEdgesEmptyComm', [ 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'], 170)
        ]
        
    
    print "***** Beginning Quick Graph Commutativity Analysis *****"
    #print "***** starting Exact *****"


    for i in xrange(0, len(listOfInputs)):
        if os.path.exists(quickGraphReportLocation):
            shutil.rmtree(quickGraphReportLocation)

        print "Evaluation for method: " + listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile,
            dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "**********************"
            print e

def run_BinaryHeapCommutativity(learner, pex, typeLearner, thres, file):

    dataStructSolutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln'
    dataStructTestDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll'
    stackTestFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/BinaryHeapCommuteTest.cs'
    stackClassFile = 'BenchmarksAll/QuickGraph/QuickGraph/BinaryHeap.cs'
    stackTestNamespace = 'QuickGraphTest'
    stackTestType = 'BinaryHeapCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    listOfInputs = [
        #  ('PUT_CommutativityCapacityCapacityComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 0),
        #  ('PUT_CommutativityCapacityCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 1),
        #  ('PUT_CommutativityCapacityAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 2),
        #  ('PUT_CommutativityCapacityMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 3),
        #  ('PUT_CommutativityCapacityRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 4),
    
        #done
        ('PUT_CommutativityCapacityRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 5),
    
    
        #  ('PUT_CommutativityCapacityIndexOfComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 6),
        #  ('PUT_CommutativityCapacityUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 7),
        #  ('PUT_CommutativityCountCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 8),
        #  ('PUT_CommutativityCountAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 9),
        #  ('PUT_CommutativityCountMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 10),
        #  ('PUT_CommutativityCountRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 11),
        #  ('PUT_CommutativityCountRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 12),
        #  ('PUT_CommutativityCountIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 13),
        #  ('PUT_CommutativityCountUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 14),
       
        #done
        ('PUT_CommutativityAddAddComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 15),
        
        #done
        ('PUT_CommutativityAddMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 16),
        
        #done
        ('PUT_CommutativityAddRemoveMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 17),
        
        #done
        ('PUT_CommutativityAddRemoveAtComm', [ ], ['priority', 'value', 'index', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 18),
        
       
        ('PUT_CommutativityAddIndexOfComm', [ ], ['priority', 'value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 19),
        ('PUT_CommutativityAddUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 20),
        ('PUT_CommutativityMinimumMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 21),
        ('PUT_CommutativityMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 22),
        ('PUT_CommutativityMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 23),
        #  ('PUT_CommutativityMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 24),
        ('PUT_CommutativityMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 25),
        #  ('PUT_CommutativityRemoveMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 26),
        #  ('PUT_CommutativityRemoveMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 27),
        ('PUT_CommutativityRemoveMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 28),
        #  ('PUT_CommutativityRemoveMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 29),
        #  ('PUT_CommutativityRemoveAtRemoveAtComm', [ ], ['index1', 'index2', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 30),
        #  ('PUT_CommutativityRemoveAtIndexOfComm', [ ], ['index', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 31),
        #  ('PUT_CommutativityRemoveAtUpdateComm', [ ], ['index', 'priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 32),
        #  ('PUT_CommutativityIndexOfIndexOfComm', [ ], ['value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 33),
        #  ('PUT_CommutativityIndexOfUpdateComm', [ ], ['value1', 'priority', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 34),
        #  ('PUT_CommutativityUpdateUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 35)
        ]

    print "***** Beginning Binary Heap Commutativity Analysis *****"
    #print "***** starting Exact *****"

    for i in xrange(0, len(listOfInputs)):
        if os.path.exists(quickGraphReportLocation):
            shutil.rmtree(quickGraphReportLocation)

        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime  = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile,
            dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "**********************"
            print e

def run_BinaryHeapCommutativity3(learner, pex, typeLearner, thres, file):

    #Entire quickgraph project is too large; build test project only and compiler will compile needed dependencies
    dataStructSolutionFile = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/QuickGraph.Tests.csproj'
    dataStructTestDll = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/bin/Debug/QuickGraph.Tests.dll'
    stackTestFile = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/Collections/BinaryHeapTest.cs'
    stackClassFile = 'BenchmarksAll/QuickGraph3/QuickGraph/Collections/BinaryHeap.cs'
    stackTestNamespace = 'QuickGraph.Collections'
    stackTestType = 'BinaryHeapCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    listOfInputs = [
 ('PUT_CommutativityCapacityCapacityComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 0),
 ('PUT_CommutativityCapacityCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 1),
 ('PUT_CommutativityCapacityAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 2),
 ('PUT_CommutativityCapacityMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 3),
 ('PUT_CommutativityCapacityRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 4),
 ('PUT_CommutativityCapacityRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 5),
 ('PUT_CommutativityCapacityIndexOfComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 6),
 ('PUT_CommutativityCapacityUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 7),
 ('PUT_CommutativityCountCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 8),
 ('PUT_CommutativityCountAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 9),
 ('PUT_CommutativityCountMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 10),
 ('PUT_CommutativityCountRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 11),
 ('PUT_CommutativityCountRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 12),
 ('PUT_CommutativityCountIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 13),
 ('PUT_CommutativityCountUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 14),
 ('PUT_CommutativityAddAddComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 15),
 ('PUT_CommutativityAddMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 16),
 ('PUT_CommutativityAddRemoveMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 17),
 ('PUT_CommutativityAddRemoveAtComm', [ ], ['priority', 'value', 'index', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 18),
 ('PUT_CommutativityAddIndexOfComm', [ ], ['priority', 'value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 19),
 ('PUT_CommutativityAddUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 20),
 ('PUT_CommutativityMinimumMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 21),
 ('PUT_CommutativityMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 22),
 ('PUT_CommutativityMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 23),
 ('PUT_CommutativityMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 24),
 ('PUT_CommutativityMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 25),
 ('PUT_CommutativityRemoveMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 26),
 ('PUT_CommutativityRemoveMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 27),
 ('PUT_CommutativityRemoveMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 28),
 ('PUT_CommutativityRemoveMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 29),
 ('PUT_CommutativityRemoveAtRemoveAtComm', [ ], ['index1', 'index2', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'], 30),
 ('PUT_CommutativityRemoveAtIndexOfComm', [ ], ['index', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 31),
 ('PUT_CommutativityRemoveAtUpdateComm', [ ], ['index', 'priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'], 32),
 ('PUT_CommutativityIndexOfIndexOfComm', [ ], ['value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 33),
 ('PUT_CommutativityIndexOfUpdateComm', [ ], ['value1', 'priority', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 34),
 ('PUT_CommutativityUpdateUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'], 35)]

    print "***** Beginning Binary Heap Commutativity Analysis *****"
    #print "***** starting Exact *****"

    for i in xrange(5, 6):
        if os.path.exists(quickGraphReportLocation):
            shutil.rmtree(quickGraphReportLocation)

        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime  = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile,
            dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "**********************"
            print e

def run_BinaryHeapException(learner, pex, typeLearner, thres, file):
    dataStructSolutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln'
    dataStructTestDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll'
    stackTestFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/BinaryHeapTest.cs'
    stackClassFile = 'BenchmarksAll/QuickGraph/QuickGraph/BinaryHeap.cs'
    stackTestNamespace = 'QuickGraphTest'
    stackTestType = 'BinaryHeapTest'
    learnerOutputDir = 'BenchmarksAll'

    print "***** Beginning Binary Heap Exception Analysis *****"
    print "***** starting Exact *****"

    listOfInputs =[ ("PUT_Add", "Add", [ ], ['priority', 'value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'], 0),
                 ("PUT_Minimum", "Minimum", [ ], ['bh.Count', 'bh.Capacity'], 1),
                 ("PUT_RemoveMinimum", "RemoveMinimum",[ ], ['bh.Count', 'bh.Capacity'], 2),
                 ("PUT_RemoveAt", "RemoveAt" ,[ ], ['index', 'bh.Count', 'bh.Capacity'], 3),
                 ("PUT_IndexOf", "IndexOf" , [ ], ['value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'], 4),
                 ("PUT_Update", "Update", [ ], ['priority', 'value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'], 5)]

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    for i in xrange(2, 3):
        if os.path.exists(quickGraphReportLocation):
            shutil.rmtree(quickGraphReportLocation)
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3], dataStructSolutionFile, stackTestFile,
            stackClassFile, dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e
            traceback.print_exc()



def run_DSA(learner, pex, typeLearner, thres, file):
    dsaSolutionFile = 'BenchmarksAll\eval-dsa\Dsa.sln'
    dsaTestFile = 'BenchmarksAll\eval-dsa\Dsa.PUTs\Algorithms\NumbersTest.cs'
    dsaTestDll ='BenchmarksAll/eval-dsa/Dsa.PUTs/bin/Debug/DsaPUTs.dll'
    dsaClassFile = "Benchmarks/eval-dsa/Dsa/Algorithms/Numbers.cs"
    dsaTestNamespace = 'Dsa.PUTs'
    dsaTestType = 'NumbersTest'
    learnerOutputDir ='BenchmarksAll'
    

    print "*****Beginning DSA*****"
    print "***** starting Exact *****" 
    
    listOfInputs =[("PUT_ToBinary","ToBinary",[],['value'],0), 
    ("PUT_ToOctal","ToOctal",[],['value'],1),  ("PUT_GreatestCommonDenominator","GreatestCommonDenominator",[],['first','second'],2),
    ("PUT_Fibonacci","Fibonacci",[],['number'] ,3) ]


    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    for i in xrange(3,4):
        if os.path.exists(dsaReportLocation):
            shutil.rmtree(dsaReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3],dsaSolutionFile, 
        dsaTestFile, dsaClassFile, dsaTestDll, pex, dsaTestNamespace, dsaTestType, learner, typeLearner,thres,learnerOutputDir)
            t1 = time.time()
            print "total time: "+ str(t1-t0)
            printToFile(name,p,rounds, str(t1-t0), data,file,str(pexTime),True)
        
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e

def run_Hola(learner, pex, typeLearner,thres, file):

    print "*****Beginning Hola*****"
    print "***** starting Exact *****"

    holaSolutionFile = 'BenchmarksAll/HolaBenchmarks/HolaBenchmarks.sln'
    holaTestFile = 'BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/HolaTest.cs'
    holaTestDll ='BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/bin/Debug/HolaBenchmarksTest.dll'
    holaClassFile='BenchmarksAll/HolaBenchmarks/HolaBenchmarks/Hola.cs'
    holaTestNamespace = 'HolaBenchmarks.Test'
    holaTestType = 'HolaTest'
    learnerOutputDir ='BenchmarksAll'

    listOfInputs =[("PUT_dig01","dig01", [],['n'],0), ("PUT_dig07","dig07",[],['n','u1'],1),
    ("PUT_dig14","dig14",[],['m','u4'],2),
    ("PUT_dig15","dig15",[],['n','k'],3),
    ("PUT_dig19","dig19",[],['m','n'],4),
    ("PUT_dig21","dig21",[],['n','j','v','u4'],5),
    ("PUT_dig31","dig31",[],['m','n','u1'],6),
    ("PUT_dig39","dig39",[],['MAXPATHLEN','u'],7),
    ("PUT_dig41","dig41",[],['n','kt','flag'],8),
    ("PUT_dig43","dig43",[],['x','y','u1'],9)]

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0
    for i in xrange(0,10):
        if os.path.exists(holaReportLocation):
            shutil.rmtree(holaReportLocation)
        
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data, pexTime = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3],holaSolutionFile, 
                holaTestFile, holaClassFile, holaTestDll, pex, holaTestNamespace, holaTestType, learner, typeLearner,thres,learnerOutputDir)
            t1 = time.time()
            print "total time: "+ str(t1-t0)
            printToFile(name,p,rounds, str(t1-t0), data,file,True)
        
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,False)
            print "***************"
            print e

def run_CodeContracts(learner, pex, typeLearner,thres,file):
    CCSolutionFile = 'BenchmarksAll/CodeContractBenchmark/CodeContractBenchmark.sln'
    ccTestFile = 'BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/CodeContractBenchmarkTest.cs'
    ccTestDll ='BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/bin/Debug/CodeContractBenchmarkTest.dll'
    ccClassFile='BenchmarksAll/CodeContractBenchmark/CodeContractBenchmark/CodeContractBenchmark.cs'
    ccTestNamespace = 'CodeContractBenchmark.Test'
    ccTestType = 'CodeContractBenchmarkTest'
    learnerOutputDir = 'BenchmarksAll'

    print "***** Beginning CodeContracts *****"
    print "***** starting Exact *****"

    listOfInputs =[
    ("PUT_AfterWhileLoop_ConditionAlwaysTrue","AfterWhileLoop_ConditionAlwaysTrue",[],['x','z'],0),
    ("PUT_AfterWhileLoop_Symbolic","AfterWhileLoop_Symbolic",[],['x'],1),    ("PUT_AssertGeqZero","AssertGeqZero",[],['x'],2),
    ("PUT_AssertGTZero","AssertGTZero",[],['x'],3),   ("PUT_AssertInsideWhileLoop","AssertInsideWhileLoop",[],['x'], 4),
    ("PUT_AssertLTZero","AssertLTZero",[],['x'],5),  ("PUT_GTZero","GTZero",[],['x'],6),   
    ("PUT_GTZeroAfterCondition","GTZeroAfterCondition",['b'],['x'],7),    ("PUT_GTZeroInConditional","GTZeroInConditional",['b'],['x'],8), 
    ("PUT_InsideWhileLoop","InsideWhileLoop",[],['x'],9),      ("PUT_Loop","Loop",[],['input'],10),
    ("PUT_Loop2","Loop2",[],['x'],11),        ("PUT_Loop4","Loop4",[],['m1','f'],12),
    ("PUT_RepeatedPreconditionInference","RepeatedPreconditionInference",[],['x','z','k'] ,13),
    ("PUT_Shuvendu","Shuvendu",[],['x','t'],14),
    ("PUT_Simplification1","Simplification1",[],['x'],15),   ("PUT_Simplification2","Simplification2",[],['x'],16),
    ("PUT_Simplification3","Simplification3",[],['x'],17),   ("PUT_Simplification4","Simplification4",[],['x'],18),
    ("PUT_SrivastavaGulwaniPLDI09","SrivastavaGulwaniPLDI09",[],['x','y'],19)  ] 

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0
    for i in xrange(0,10):
        if os.path.exists(codeContractReportLocation):
            shutil.rmtree(codeContractReportLocation)
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data, pexTime  = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3], CCSolutionFile, ccTestFile,
            ccClassFile, ccTestDll, pex, ccTestNamespace, ccTestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,False)
            print "***************"
            print e

def run_PriorityQueueCommutativity(learner, pex, typeLearner, thres, file):

    dataStructSolutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln'
    dataStructTestDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll'
    stackTestFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/PriorityQueueCommuteTest.cs'
    stackClassFile = 'BenchmarksAll/QuickGraph/QuickGraph/PriorityQueue.cs'
    stackTestNamespace = 'QuickGraphTest'
    stackTestType = 'PriorityQueueCommuteTest'
    learnerOutputDir = 'BenchmarksAll'

    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    listOfInputs = [
 ('PUT_CommutativityUpdateUpdateComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 0),
 ('PUT_CommutativityUpdateCountComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 1),
 ('PUT_CommutativityUpdateContainsComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 2),
 ('PUT_CommutativityUpdateEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 3),
 ('PUT_CommutativityUpdateDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 4),
 ('PUT_CommutativityUpdatePeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 5),
 ('PUT_CommutativityCountCountComm', [ ], ['pq1.Count'], 6),
 ('PUT_CommutativityCountContainsComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 7),
 ('PUT_CommutativityCountEnqueueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 8),
 ('PUT_CommutativityCountDequeueComm', [ ], ['pq1.Count'], 9),
 ('PUT_CommutativityCountPeekComm', [ ], ['pq1.Count'], 10),
 ('PUT_CommutativityContainsContainsComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 11),
 ('PUT_CommutativityContainsEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 12),
 ('PUT_CommutativityContainsDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 13),
 ('PUT_CommutativityContainsPeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 14),
 ('PUT_CommutativityEnqueueEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'], 15),
 ('PUT_CommutativityEnqueueDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 16),
 ('PUT_CommutativityEnqueuePeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'], 17),
 ('PUT_CommutativityDequeueDequeueComm', [ ], ['pq1.Count'], 18),
 ('PUT_CommutativityDequeuePeekComm', [ ], ['pq1.Count'], 19),
 ('PUT_CommutativityPeekPeekComm', [ ], ['pq1.Count'], 20)]

    print "***** Beginning Priority Queue Commutativity Analysis *****"
    #print "***** starting Exact *****"

    for i in xrange(0, 21):
        if os.path.exists(quickGraphReportLocation):
            shutil.rmtree(quickGraphReportLocation)

        print "Evaluation for method: " + listOfInputs[i][0]
        name = listOfInputs[i][0]
        
        try:
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime  = myAnalysis.learnPreconditionForCommutativityMultipleLearner(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2], dataStructSolutionFile, stackTestFile,
            dataStructTestDll, pex, stackTestNamespace, stackTestType, learner, typeLearner,thres, learnerOutputDir)
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "**********************"
            print e


if __name__ == '__main__':
    main()