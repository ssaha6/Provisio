from benchmark import Benchmark
from framework import *
from learner import *
from teacher import *
import argparse
import collections
import csv
import io
import json
import os
import pprint
import re
import shutil
import subprocess
import sys
import time
import traceback
import logging
from os import sys, path
sys.path.append(path.dirname(path.abspath(__file__)))
sys.path.append(path.dirname(path.dirname(path.abspath(__file__))))


# logging


class Logging:
    def __init__(self, fileName):
        self.fileName = fileName
        self.header = ["MethodName", "Precondition", "Num. Rounds",
                       "Num. DataPoints", "Learner Time(s)", "Teacher Time(s)", "Total Time(s)"]
        with open(self.fileName, 'wb') as myfile:
            wr = csv.writer(myfile)
            wr.writerow(self.header)

    def append(self, method, precondition, rounds, numDataPoints, learnerTime, teacherTime, totalTime):
        with open(self.fileName, 'a') as myfile:
            wr = csv.writer(myfile)
            wr.writerow([method, precondition, rounds, numDataPoints,
                         learnerTime, teacherTime, totalTime])


def runnerPost(benchmark, methodParameters, logFile, exception=False):
    entropy = True
    numerical = False

    pexBinary = "pex.exe"
    #debug
    logger = logging.getLogger("Runner")
    logger.setLevel(logging.INFO)
    # create the logging file handler
    fh = logging.FileHandler("information")
    formatter = logging.Formatter('%(message)s')
    fh.setFormatter(formatter)
    # add handler to logger object
    logger.addHandler(fh)
    logger.info("Program started")
    logger.info("configuration: " + "entropy: "+str(entropy) +
                " numerical: " + str(numerical))
    #endDebug
    log = Logging(logFile)
    for element in methodParameters:
        # if exception:
        #    (putName, methodUnderTest, boolVariables, intVariables) = element
        (putName, boolVariables, intVariables) = element
        logger.info("################### Method: "+ putName)
        
        print "\n\nLearning postcondition for method: " + putName
        print "--------------------------------------------------------------------------------"

        #try:
        learner = DisjunctiveLearner("DisjunctiveLearner", "", "", "")
        # debug
        learner.entropy = entropy
        learner.numerical = numerical
        
        #enddebug
        learner.setVariables(intVariables, boolVariables)
        teacher = Pex(pexBinary, len(learner.intVariables) +
                len(learner.boolVariables), ['/nor'])
        # if exception:
        #    framework = FrameworkException(putName, methodUnderTest, benchmark, learner, teacher)
        framework = Framework(putName, benchmark, learner, teacher)
        postcondition, rounds, numDataPoints, learnerTime, teacherTime = framework.learnPostcondition()
        #log.append(putName, postcondition, rounds, numDataPoints,
        #           learnerTime, teacherTime, learnerTime + teacherTime)
        log.append(putName, postcondition, "","","","","")
        print "--------------------------------------------------------------------------------"
        print "Method Name        : " + putName
        print "Final PostCondition : " + postcondition
        print "Number of rounds   : " + str(rounds)
        print "Number of Points   : " + str(numDataPoints)
        print "Learner time(s)    : " + str(learnerTime)
        print "Teacher time(s)    : " + str(teacherTime)
        print "Total Time(s)      : " + str(learnerTime + teacherTime)

        #except Exception as e:
        #    print "\n!!! Exception found !!!"
        #    traceback.print_exc(file=sys.stdout)

    logger.info("done!")
    logger.info("")


def run_StackContractPostOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/Stack/Stack.sln",
        testDll="../ContractsSubjects/Stack/StackTest/bin/Debug/StackTest.dll",
        testFile="../ContractsSubjects/Stack/StackTest/StackContractTest.cs",
        classFile='../ContractsSubjects/Stack/Stack/Stack.cs',
        testNamespace="Stack.Test",
        testType="StackContractTest",
        pexReportFolder="../ContractsSubjects/Stack/StackTest/bin/Debug"
    )

    methodParameters = [
        ('PUT_PushContract', ["Old_s1ContainsX", "New_s1ContainsX"], ['Old_s1Count', 'New_s1Count', 'Old_Top', 'New_Top', 'Old_x', 'New_x']),
        ('PUT_PopContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_Ret', 'New_Ret']),
        ('PUT_PeekContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_Ret', 'New_Ret']),
        ('PUT_CountContract', [], ['Old_s1Count', 'New_s1Count', 'Old_Top', 'New_Top', 'Old_Ret', 'New_Ret']),
        ('PUT_ContainsContract', ['Old_Ret', 'New_Ret', 'Old_s1ContainsX', 'New_s1ContainsX'], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top'])
    ]

    file ="stack_post.csv"
    #file = "stack_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+ file)

def run_QueueContractPostOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/Queue/Queue.sln",
        testDll="../ContractsSubjects/Queue/QueueTest/bin/Debug/QueueTest.dll",
        testFile="../ContractsSubjects/Queue/QueueTest/QueueContractTest.cs",
        classFile='../ContractsSubjects/Queue/Queue/Queue.cs',
        testNamespace="Queue.Test",
        testType="QueueContractTest",
        pexReportFolder="../ContractsSubjects/Queue/QueueTest/bin/Debug"
    )

    methodParameters = [
        ('PUT_EnqueueContract', ["Old_s1ContainsX", "New_s1ContainsX"], ['Old_s1Count', 'New_s1Count', 'Old_Top', 'New_Top', 'Old_x', 'New_x']),
        ('PUT_DequeueContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_Ret', 'New_Ret']) ,
        ('PUT_PeekContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_Ret', 'New_Ret'] ),
        ('PUT_CountContract', [], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top', 'Old_Ret', 'New_Ret'] ),
        ('PUT_ContainsContract', ["Old_Ret", "New_Ret","Old_s1ContainsX", "New_s1ContainsX"], ['Old_s1Count', 'New_s1Count','Old_Top', 'New_Top'])
    ]
    file ="queue_post.csv"
    #file = "queue_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)

def run_HashSetContractOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/HashSet/HashSet.sln",
        testDll="../ContractsSubjects/HashSet/HashSetTest/bin/Debug/HashSetTest.dll",
        testFile="../ContractsSubjects/HashSet/HashSetTest/HashSetContractTest.cs",
        classFile='../ContractsSubjects/HashSet/HashSet/HashSet.cs',
        testNamespace="HashSet.Test",
        testType="HashSetContractTest",
        pexReportFolder="../ContractsSubjects/HashSet/HashSetTest/bin/Debug"
    )
    
    methodParameters = [
        ('PUT_AddContract', ["Old_Ret", "New_Ret","Old_hsContainsX", "New_hsContainsX"], ['Old_hsCount', 'New_hsCount', 'Old_x', 'New_x'])#,
        #('PUT_RemoveContract', ["Old_Ret", "New_Ret","Old_hsContainsX", "New_hsContainsX"], ['Old_hsCount', 'New_hsCount', 'Old_x', 'New_x']),
        #('PUT_CountContract', [], ['Old_hsCount', 'New_hsCount', 'Old_Ret', 'New_Ret']),
        #('PUT_ContainsContract', ["Old_Ret", "New_Ret","Old_hsContainsX", "New_hsContainsX"], ['Old_hsCount', 'New_hsCount', 'Old_x', 'New_x'])

    ]

    #file ="hashset_post.csv"
    file ="hashset_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)

def run_DictionaryContractOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/Dictionary/Dictionary.sln",
        testDll="../ContractsSubjects/Dictionary/DictionaryTest/bin/Debug/DictionaryTest.dll",
        testFile="../ContractsSubjects/Dictionary/DictionaryTest/DictionaryContractTest.cs",
        classFile='../ContractsSubjects/Dictionary/Dictionary/Dictionary.cs',
        testNamespace="Dictionary.Test",
        testType="DictionaryContractTest",
        pexReportFolder="../ContractsSubjects/Dictionary/DictionaryTest/bin/Debug"
    )
    
    methodParameters = [
        ('PUT_AddContract', ['Old_dContainsKeyX', 'New_dContainsKeyX','Old_dContainsValueY', 'New_dContainsValueY'], ['Old_dCount', 'New_dCount', 'Old_x', 'New_x', 'Old_y', 'New_y']),
        ('PUT_RemoveContract', ['Old_Ret', 'New_Ret','Old_dContainsKeyX', 'New_dContainsKeyX'], ['Old_dCount', 'New_dCount', 'Old_x', 'New_x']),
        ('PUT_GetContract', ['Old_dContainsKeyX', 'New_dContainsKeyX'], ['Old_dCount', 'New_dCount', 'Old_x', 'New_x', 'Old_Ret', 'New_Ret']),
        ('PUT_SetContract', ['Old_dContainsKeyX', 'New_dContainsKeyX','Old_dContainsValueY', 'New_dContainsValueY'], ['Old_dCount', 'New_dCount', 'Old_x', 'New_x', 'Old_y', 'New_y']),
        ('PUT_ContainsKeyContract', ['Old_Ret', 'New_Ret','Old_dContainsKeyX', 'New_dContainsKeyX'], ['Old_dCount', 'New_dCount', 'Old_x', 'New_x']),   
        ('PUT_ContainsValueContract', ['Old_Ret', 'New_Ret','Old_dContainsValueY', 'New_dContainsValueY'], ['Old_dCount', 'New_dCount', 'Old_y', 'New_y']),
        ('PUT_CountContract', [], ['Old_dCount', 'New_dCount', 'Old_Ret', 'New_Ret'])
    ]
    
    file ="dictionary_post.csv"
    #file ="dictionary_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)

def run_ArrayListContractOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/ArrayList/ArrayList.sln",
        testDll="../ContractsSubjects/ArrayList/ArrayListTest/bin/Debug/ArrayListTest.dll",
        testFile="../ContractsSubjects/ArrayList/ArrayListTest/ArrayListContractTest.cs",
        classFile='../ContractsSubjects/ArrayList/ArrayList/ArrayList.cs',
        testNamespace="ArrayList.Test",
        testType="ArrayListContractTest",
        pexReportFolder="../ContractsSubjects/ArrayList/ArrayListTest/bin/Debug"
    )
    
    methodParameters = [
        ('PUT_AddContract', ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX', 'Old_Ret', 'New_Ret'])#,
        # ('PUT_RemoveContract', ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX']),
        # ('PUT_InsertContract', ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_index', 'New_index', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX']),
        # ('PUT_SetContract',  ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_index', 'New_index', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX']),
        # ('PUT_GetContract', [], ['Old_alCount', 'New_alCount', 'Old_index', 'New_index', 'Old_Ret', 'New_Ret']),
        # ('PUT_ContainsContract', ['Old_Ret', 'New_Ret', 'Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX']),   
        # ('PUT_IndexOfContract', ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX', 'Old_Ret', 'New_Ret']),
        # ('PUT_LastIndexOfContract', ['Old_alContainsX', 'New_alContainsX'], ['Old_alCount', 'New_alCount', 'Old_x', 'New_x', 'Old_alIndexOfX', 'New_alIndexOfX', 'Old_alLastIndexOfX', 'New_alLastIndexOfX', 'Old_Ret', 'New_Ret']),
        # ('PUT_CountContract', [], ['Old_alCount', 'New_alCount', 'Old_Ret', 'New_Ret'])
    ]
    
    file ="arraylist_post.csv"
    #file ="arraylist_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)

def run_UndirectedGraphContractOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/UndirectedGraph/UndirectedGraph.sln",
        testDll="../ContractsSubjects/UndirectedGraph/UndirectedGraphTest/bin/Debug/UndirectedGraphTest.dll",
        testFile="../ContractsSubjects/UndirectedGraph/UndirectedGraphTest/UndirectedGraphContractTest.cs",
        classFile='../ContractsSubjects/UndirectedGraph/UndirectedGraph/UndirectedGraph.cs',
        testNamespace="UndirectedGraph.Test",
        testType="UndirectedGraphContractTest",
        pexReportFolder="../ContractsSubjects/UndirectedGraph/UndirectedGraphTest/bin/Debug"
    )
    
    methodParameters = [
        # ('PUT_AddVertexContract', ['Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x']),

        # ('PUT_AddVertexContract', ['Old_ugContainsVertexX', 'New_ugContainsVertexX'], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x']),
        ('PUT_RemoveVertexContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x']),
        ('PUT_ClearAdjacentEdgesContract', [ 'Old_ugContainsVertexX', 'New_ugContainsVertexX'  ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x']),
        ('PUT_ContainsEdgeContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexSource', 'New_ugContainsVertexSource', 'Old_ugContainsVertexTarget', 'New_ugContainsVertexTarget' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeSource', 'New_ugAdjacentDegreeSource', 'Old_ugAdjacentDegreeTarget', 'New_ugAdjacentDegreeTarget', 'Old_source', 'New_source', 'Old_target', 'New_target']),
        ('PUT_ContainsEdgeIntContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexSource', 'New_ugContainsVertexSource', 'Old_ugContainsVertexTarget', 'New_ugContainsVertexTarget' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeSource', 'New_ugAdjacentDegreeSource', 'Old_ugAdjacentDegreeTarget', 'New_ugAdjacentDegreeTarget', 'Old_source', 'New_source', 'Old_target', 'New_target']),
        ('PUT_AdjacentEdgeContract', ['Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x', 'Old_index', 'New_index', 'Old_Ret_Source', 'New_Ret_Source', 'Old_Ret_Target', 'New_Ret_Target']),
        ('PUT_IsVerticesEmptyContract', ['Old_Ret', 'New_Ret' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount']),
        ('PUT_VertexCountContract', ['Old_ugAllowParallelEdges', 'New_ugAllowParallelEdges'], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_Ret', 'New_Ret']),
        ('PUT_ContainsVertexContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x']),
        ('PUT_AddEdgeContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexSource', 'New_ugContainsVertexSource', 'Old_ugContainsVertexTarget', 'New_ugContainsVertexTarget' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeSource', 'New_ugAdjacentDegreeSource', 'Old_ugAdjacentDegreeTarget', 'New_ugAdjacentDegreeTarget', 'Old_source', 'New_source', 'Old_target', 'New_target']),
        ('PUT_RemoveEdgeContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexSource', 'New_ugContainsVertexSource', 'Old_ugContainsVertexTarget', 'New_ugContainsVertexTarget' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeSource', 'New_ugAdjacentDegreeSource', 'Old_ugAdjacentDegreeTarget', 'New_ugAdjacentDegreeTarget', 'Old_source', 'New_source', 'Old_target', 'New_target']),
        ('PUT_IsEdgesEmptyContract', ['Old_Ret', 'New_Ret' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount']),
        ('PUT_EdgeCountContract', ['Old_ugAllowParallelEdges', 'New_ugAllowParallelEdges'], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_Ret', 'New_Ret']),
        ('PUT_AdjacentDegreeContract', ['Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x', 'Old_Ret', 'New_Ret']),
        ('PUT_IsAdjacentEdgesEmptyContract', ['Old_Ret', 'New_Ret', 'Old_ugContainsVertexX', 'New_ugContainsVertexX' ], ['Old_ugVertexCount', 'New_ugVertexCount', 'Old_ugEdgeCount', 'New_ugEdgeCount', 'Old_ugAdjacentDegreeX', 'New_ugAdjacentDegreeX', 'Old_x', 'New_x'])
    ]
    
    file ="undirectedgraph_post.csv"
    #file ="undirectedgraph_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)

def run_BinaryHeapContractOnly():

    benchmark = Benchmark(
        solutionFile="../ContractsSubjects/BinaryHeap/BinaryHeap.sln",
        testDll="../ContractsSubjects/BinaryHeap/BinaryHeapTest/bin/Debug/BinaryHeapTest.dll",
        testFile="../ContractsSubjects/BinaryHeap/BinaryHeapTest/BinaryHeapContractTest.cs",
        classFile='../ContractsSubjects/BinaryHeap/BinaryHeap/BinaryHeap.cs',
        testNamespace="BinaryHeap.Test",
        testType="BinaryHeapContractTest",
        pexReportFolder="../ContractsSubjects/BinaryHeap/BinaryHeapTest/bin/Debug"
    )
    
    methodParameters = [
        ('PUT_AddContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhIndexOfValue', 'Newd_bhIndexOfValue', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_prioirty', 'New_prioirty', 'Old_value', 'New_value']),
        ('PUT_MinimumContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_Ret_Key', 'New_Ret_Key', 'Old_Ret_Value', 'New_Ret_Value']),
        ('PUT_RemoveMinimumContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_Ret_Key', 'New_Ret_Key', 'Old_Ret_Value', 'New_Ret_Value']),
        ('PUT_RemoveAtContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_index', 'New_index', 'Old_Ret_Key', 'New_Ret_Key', 'Old_Ret_Value', 'New_Ret_Value']),
        ('PUT_IndexOfContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_value', 'New_value', 'Old_Ret', 'New_Ret']),
        ('PUT_UpdateContract', [], ['Old_bhCount', 'New_bhCount', 'Old_bhCapacity', 'New_bhCapacity', 'Old_bhIndexOfValue', 'Newd_bhIndexOfValue', 'Old_bhMinimumKey', 'New_bhMinimumKey', 'Old_bhMinimumValue', 'New_bhMinimumValue', 'Old_prioirty', 'New_prioirty', 'Old_value', 'New_value'])
    ]
    
    file = "binaryheap_post.csv"
    #file ="binaryheap_postRegression.csv"
    runnerPost(benchmark, methodParameters, "results/"+file)


if __name__ == '__main__':
    
    print "starting"
    #run_StackContractPostOnly()
    #run_QueueContractPostOnly()
    run_HashSetContractOnly()
    #run_DictionaryContractOnly()
    #run_ArrayListContractOnly()
