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
from os import sys,path
sys.path.append(path.dirname(path.abspath(__file__)))
sys.path.append(path.dirname(path.dirname(path.abspath(__file__))))

from teacher import *
from learner import *
from framework import *
from benchmark import Benchmark


class Logging:
	def __init__(self, fileName):
		self.fileName = fileName
		self.header = ["MethodName", "Precondition", "NumRounds", "NumDataPoints", "LearnerTime", "TeacherTime"]
		with open(self.fileName, 'wb') as myfile:
			wr = csv.writer(myfile)
			wr.writerow(self.header)
		
	def append(self, method, precondition, rounds, numDataPoints, learnerTime, teacherTime):
		with open(self.fileName, 'a') as myfile:
			wr = csv.writer(myfile)
			wr.writerow([method, precondition, rounds, numDataPoints, learnerTime, teacherTime])
			



def runner(benchmark, methodParameters, logFile):
	
    learner = DTLearner("dtlearner", "learner/C50exact/c5.0dbg.exe", "", "tempLocation")
    pexBinary = "pex.exe"

    log = Logging(logFile)

    for putName, boolVariables, intVariables  in methodParameters:

        print "\n\nLearning precondition for method: " + putName
        print "--------------------------------------------------------------------------------"

        try:
            learner.setVariables(intVariables, boolVariables)

            teacher = Pex( pexBinary,
            len(learner.intVariables) + len(learner.boolVariables),
            ['/nor']
            )

            framework = Framework(putName, benchmark, learner, teacher)

            precondition, rounds, numDataPoints, learnerTime, teacherTime = framework.learnPrecondition()

            log.append(putName, precondition, rounds, numDataPoints, learnerTime, teacherTime)
            print "--------------------------------------------------------------------------------"
            print "Method Name        : " + putName
            print "Final Precondition : " + precondition
            print "Number of rounds   : " + str(rounds)
            print "Number of Points   : " + str(numDataPoints)
            print "Learner time(s)    : " + str(learnerTime)
            print "Teacher time(s)    : " + str(teacherTime)
            print "Total Time(s)      : " + str(learnerTime + teacherTime)

        except Exception as e:
            print "\n!!! Exception found !!!"
            print str(e)
        






def main():
	
	run_StackCommuteOnly()
	run_QueueCommuteOnly()
	run_SetCommuteOnly()
	run_MapCommuteOnly()
	run_ArrayListCommuteOnly()
	run_QuickGraphCommutivity()
	run_BinaryHeapCommutativity()
	run_BinaryHeapCommutativity3()
	run_PriorityQueueCommutativity()
	
	run_BinaryHeapException()
	run_DSA()
	run_Hola()
	run_CodeContracts()
	
	
	
	
def run_StackCommuteOnly():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln',
		testDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll',
		testFile = 'BenchmarksAll/DataStructures/DataStructuresTest/StackCommuteTest.cs',
		classFile='BenchmarksAll/DataStructures/DataStructures/Stack.cs',
		testNamespace = 'DataStructures.Comm.Test',
		testType='StackCommuteTest',
		pexReportFolder = "BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug"
	)
	
	methodParameters = [
		('PUT_CommutativityPeekPopComm', [ ], ['s1.Count', 's1.Peek()'] ), 
		('PUT_CommutativityPopPopComm', [ ], ['s1.Count', 's1.Peek()'] ), 
		('PUT_CommutativityPushPopComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ), 
		('PUT_CommutativityPushPeekComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ), 
		('PUT_CommutativityPeekPeekComm', [ ], ['s1.Count', 's1.Peek()'] ), 
		('PUT_CommutativityPushPushComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.Peek()'] ), 
		('PUT_CommutativitySizePeekComm', [], ['s1.Count', 's1.Peek()']),
		('PUT_CommutativitySizePopComm', [ ], ['s1.Count', 's1.Peek()'] ), 
		('PUT_CommutativitySizePushComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ), 
		('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count', 's1.Peek()'] )
	]
	
	runner(benchmark, methodParameters, "results/stack_comm.csv")
	
	

def run_QueueCommuteOnly():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln',
		testDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll',
		testFile = 'BenchmarksAll/DataStructures/DataStructuresTest/QueueCommuteTest.cs',
		classFile='BenchmarksAll/DataStructures/DataStructures/Queue.cs',
		testNamespace = 'DataStructures.Comm.Test',
		testType = 'QueueCommuteTest',
		pexReportFolder = 'BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug'
	)
	
	methodParameters =  [
		('PUT_CommutativityPeekPeekComm', [ ], ['s1.Count', 's1.Peek()'] ),
		('PUT_CommutativityPeekDequeueComm', [ ], ['s1.Count', 's1.Peek()'] ),
		('PUT_CommutativityDequeueDequeueComm', [ ], ['s1.Count', 's1.Peek()'] ),
		('PUT_CommutativityEnqueuePeekComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ),
		('PUT_CommutativityEnqueueDequeueComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ),
		('PUT_CommutativityEnqueueEnqueueComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.Peek()'] ),
		('PUT_CommutativitySizePeekComm', [ ], ['s1.Count', 's1.Peek()'] ),
		('PUT_CommutativitySizeDequeueComm', [ ], ['s1.Count', 's1.Peek()'] ),
		('PUT_CommutativitySizeEnqueueComm', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.Peek()'] ),
		('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count', 's1.Peek()'] )
	]

	runner(benchmark, methodParameters, "results/queue_comm.csv")



def run_SetCommuteOnly():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln',
		testDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll',
		testFile = 'BenchmarksAll/DataStructures/DataStructuresTest/HashSetCommuteTest.cs',
		classFile='BenchmarksAll/DataStructures/DataStructures/HashSet.cs',
		testNamespace = 'DataStructures.Comm.Test',
		testType = 'HashSetCommuteTest',
		pexReportFolder = 'BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug'
	)
   
	methodParameters =[
		('PUT_CommutativityContainsContainsComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityContainsAddComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityContainsRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityContainsSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'] ),
		('PUT_CommutativityAddAddComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityAddRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityAddSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'] ),
		('PUT_CommutativityRemoveRemoveComm', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y'] ),
		('PUT_CommutativityRemoveSizeComm', [ 's1.Contains(x)'], ['s1.Count', 'x'] ),
		('PUT_CommutativitySizeSizeComm', [ ], ['s1.Count'] )
	]

	runner(benchmark, methodParameters, "results/set_comm.csv")


def run_MapCommuteOnly():
	
	benchmark = Benchmark(	
		solutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln',
		testDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll',
		testFile = 'BenchmarksAll/DataStructures/DataStructuresTest/DictionaryCommuteTest.cs',
		classFile='BenchmarksAll/DataStructures/DataStructures/Dictionary.cs',
		testNamespace = 'DataStructures.Comm.Test',
		testType = 'DictionaryCommuteTest',
		pexReportFolder = 'BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug'
	)

	methodParameters = [
		('PUT_CommutativityRemoveRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'] ), 
		('PUT_CommutativityRemoveAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'y', 'y1'] ), 
		('PUT_CommutativityAddAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'] ), 
		('PUT_CommutativityGetGetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'] ), 
		('PUT_CommutativityGetAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'y', 'y1'] ), 
		('PUT_CommutativityGetRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsValue(x)', 's1.ContainsValue(y)'], ['s1.Count', 'x', 'y'] ), 
		('PUT_CommutativitySetSetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'] ), 
		('PUT_CommutativitySetAddComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsKey(y1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)', 's1.ContainsValue(y1)'], ['s1.Count', 'x', 'x1', 'y', 'y1'] ), 
		('PUT_CommutativitySetRemoveComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)'], ['s1.Count', 'x', 'x1', 'y'] ), 
		('PUT_CommutativitySetGetComm', [ 's1.ContainsKey(x)', 's1.ContainsKey(y)', 's1.ContainsKey(x1)', 's1.ContainsValue(x)', 's1.ContainsValue(y)', 's1.ContainsValue(x1)'], ['s1.Count', 'x', 'x1', 'y'] )
	]

	runner(benchmark, methodParameters, "results/map_comm.csv")


def run_ArrayListCommuteOnly():
	
	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/DataStructures/DataStructures.sln',
		testDll ='BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug/DataStructuresTest.dll',
		testFile = 'BenchmarksAll/DataStructures/DataStructuresTest/ArrayListTest.cs',
		classFile='BenchmarksAll/DataStructures/DataStructures/ArrayList.cs',
		testNamespace = 'DataStructures.Test',
		testType = 'ArrayListTest',
		pexReportFolder = 'BenchmarksAll/DataStructures/DataStructuresTest/bin/Debug'
	)

	methodParameters = [
		('PUT_CommutativityAddAdd', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddContains', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddCount', [ 's1.Contains(x)'], ['s1.Count', 'x', 's1.IndexOf(x)', 's1.LastIndexOf(x)'] ),
		('PUT_CommutativityAddGet', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddInsert', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.IndexOf(y1)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)', 's1.LastIndexOf(y1)'] ),
		('PUT_CommutativityAddLastIndexOf', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddRemove', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddRemoveAt', [ 's1.Contains(x)', 's1.Contains(y)'], ['s1.Count', 'x', 'y', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)'] ),
		('PUT_CommutativityAddSet', [ 's1.Contains(x)', 's1.Contains(y)', 's1.Contains(y1)'], ['s1.Count', 'x', 'y', 'y1', 's1.IndexOf(x)', 's1.IndexOf(y)', 's1.IndexOf(y1)', 's1.LastIndexOf(x)', 's1.LastIndexOf(y)', 's1.LastIndexOf(y1)'] ),
	   
	]

	runner(benchmark, methodParameters, "results/arraylist_comm.csv")


def run_QuickGraphCommutivity():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln',
		testDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll',
		testFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/UndirectedGraphCommuteTest.cs',
		classFile = 'BenchmarksAll/QuickGraph/QuickGraph/UndirectedGraph.cs',
		testNamespace = 'QuickGraphTest',
		testType = 'UndirectedGraphCommuteTest',
		pexReportFolder = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug'
	)

	methodParameters = [
		('PUT_CommutativityAddVertexAddVertexComm', ['g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)', 'g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexRemoveVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexContainsEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityAddVertexAdjacentEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexIsVerticesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityAddVertexVertexCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityAddVertexContainsVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexAddEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(src)', 'g1.AdjacentDegree(tar)']),
		('PUT_CommutativityAddVertexRemoveEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(src)', 'g1.AdjacentDegree(tar)']),
		('PUT_CommutativityAddVertexIsEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityAddVertexEdgeCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityAddVertexAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexAdjacentDegreeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityAddVertexIsAdjacentEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexRemoveVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexAdjacentEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexIsVerticesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexVertexCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexContainsVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexAddEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexRemoveEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexIsEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexEdgeCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityRemoveVertexAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexIsAdjacentEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityClearAdjacentEdgesClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node2)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityClearAdjacentEdgesIsVerticesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityClearAdjacentEdgesVertexCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityClearAdjacentEdgesContainsVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityClearAdjacentEdgesAddEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)']),
		('PUT_CommutativityClearAdjacentEdgesRemoveEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)', 'g1.AdjacentDegree(e.Source)', 'g1.AdjacentDegree(e.Target)']),
		('PUT_CommutativityClearAdjacentEdgesIsEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityClearAdjacentEdgesAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityClearAdjacentEdgesIsAdjacentEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)'])
	]

	runner(benchmark, methodParameters, "results/quickgraph_comm.csv")



def run_BinaryHeapCommutativity():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln',
		testDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll',
		testFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/BinaryHeapCommuteTest.cs',
		classFile = 'BenchmarksAll/QuickGraph/QuickGraph/BinaryHeap.cs',
		testNamespace = 'QuickGraphTest',
		testType = 'BinaryHeapCommuteTest',
		pexReportFolder = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug'
	)
  

	methodParameters = [
		#  ('PUT_CommutativityCapacityCapacityComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCapacityCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCapacityAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCapacityMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCapacityRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),

		#done
		('PUT_CommutativityCapacityRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),

		#  ('PUT_CommutativityCapacityIndexOfComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCapacityUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityCountUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),

		#done
		('PUT_CommutativityAddAddComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),

		#done
		('PUT_CommutativityAddMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),

		#done
		('PUT_CommutativityAddRemoveMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),

		#done
		('PUT_CommutativityAddRemoveAtComm', [ ], ['priority', 'value', 'index', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),

		('PUT_CommutativityAddIndexOfComm', [ ], ['priority', 'value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveAtRemoveAtComm', [ ], ['index1', 'index2', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveAtIndexOfComm', [ ], ['index', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityRemoveAtUpdateComm', [ ], ['index', 'priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityIndexOfIndexOfComm', [ ], ['value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityIndexOfUpdateComm', [ ], ['value1', 'priority', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		#  ('PUT_CommutativityUpdateUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] )
	]

	runner(benchmark, methodParameters, "results/binaryheap_comm.csv")


def run_BinaryHeapCommutativity3():

	benchmark = Benchmark(
		#Entire quickgraph project is too large; build test project only and compiler will compile needed dependencies
		solutionFile = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/QuickGraph.Tests.csproj',
		testDll = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/bin/Debug/QuickGraph.Tests.dll',
		testFile = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/Collections/BinaryHeapTest.cs',
		classFile = 'BenchmarksAll/QuickGraph3/QuickGraph/Collections/BinaryHeap.cs',
		testNamespace = 'QuickGraph.Collections',
		testType = 'BinaryHeapCommuteTest',
		pexReportFolder = 'BenchmarksAll/QuickGraph3/QuickGraph.Tests/bin/Debug'
	)


	methodParameters = [
		('PUT_CommutativityCapacityCapacityComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityIndexOfComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCapacityUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountCountComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountAddComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityCountUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddAddComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddRemoveMinimumComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddRemoveAtComm', [ ], ['priority', 'value', 'index', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddIndexOfComm', [ ], ['priority', 'value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityAddUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveMinimumRemoveMinimumComm', [ ], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveMinimumRemoveAtComm', [ ], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveMinimumIndexOfComm', [ ], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveMinimumUpdateComm', [ ], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveAtRemoveAtComm', [ ], ['index1', 'index2', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveAtIndexOfComm', [ ], ['index', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityRemoveAtUpdateComm', [ ], ['index', 'priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityIndexOfIndexOfComm', [ ], ['value1', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityIndexOfUpdateComm', [ ], ['value1', 'priority', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] ),
		('PUT_CommutativityUpdateUpdateComm', [ ], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key'] )
	]

	runner(benchmark, methodParameters, "results/binaryheap3_comm.csv")

 

def run_BinaryHeapException():

	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln',
		testDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll',
		testFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/BinaryHeapTest.cs',
		classFile = 'BenchmarksAll/QuickGraph/QuickGraph/BinaryHeap.cs',
		testNamespace = 'QuickGraphTest',
		testType = 'BinaryHeapTest',
		pexReportFolder = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug'
	)
   
	methodParameters = [
		("PUT_Add", "Add", [ ], ['priority', 'value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'] ),
		("PUT_Minimum", "Minimum", [ ], ['bh.Count', 'bh.Capacity'] ),
		("PUT_RemoveMinimum", "RemoveMinimum",[ ], ['bh.Count', 'bh.Capacity'] ),
		("PUT_RemoveAt", "RemoveAt" ,[ ], ['index', 'bh.Count', 'bh.Capacity'] ),
		("PUT_IndexOf", "IndexOf" , [ ], ['value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'] ),
		("PUT_Update", "Update", [ ], ['priority', 'value', 'bh.Count', 'bh.Capacity', 'bh.IndexOf(value)'] )
	]

	runner(benchmark, methodParameters, "results/binaryheap_exception.csv")



def run_DSA():
	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll\eval-dsa\Dsa.sln',
		testFile = 'BenchmarksAll\eval-dsa\Dsa.PUTs\Algorithms\NumbersTest.cs',
		testDll ='BenchmarksAll/eval-dsa/Dsa.PUTs/bin/Debug/DsaPUTs.dll',
		classFile = "Benchmarks/eval-dsa/Dsa/Algorithms/Numbers.cs",
		testNamespace = 'Dsa.PUTs',
		testType = 'NumbersTest',
		pexReportFolder = 'BenchmarksAll/eval-dsa/Dsa.PUTs/bin'
	)
   

	methodParameters = [
		("PUT_ToBinary","ToBinary",[],['value']), 
		("PUT_ToOctal", "ToOctal", [], ['value']),
		("PUT_GreatestCommonDenominator","GreatestCommonDenominator",[],['first','second']),
		("PUT_Fibonacci", "Fibonacci", [], ['number'])
	]

	runner(benchmark, methodParameters, "results/dsa_exception.csv")



def run_Hola():
	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/HolaBenchmarks/HolaBenchmarks.sln',
		testFile = 'BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/HolaTest.cs',
		testDll ='BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/bin/Debug/HolaBenchmarksTest.dll',
		classFile='BenchmarksAll/HolaBenchmarks/HolaBenchmarks/Hola.cs',
		testNamespace = 'HolaBenchmarks.Test',
		testType = 'HolaTest',
		pexReportFolder = 'BenchmarksAll/HolaBenchmarks/HolaBenchmarksTest/bin/Debug'
	)
	
	methodParameters = [
		("PUT_dig01", "dig01", [], ['n'], 0),
		("PUT_dig07","dig07",[],['n','u1'],1),
		("PUT_dig14","dig14",[],['m','u4'],2),
		("PUT_dig15","dig15",[],['n','k'],3),
		("PUT_dig19","dig19",[],['m','n'],4),
		("PUT_dig21","dig21",[],['n','j','v','u4'],5),
		("PUT_dig31","dig31",[],['m','n','u1'],6),
		("PUT_dig39","dig39",[],['MAXPATHLEN','u'],7),
		("PUT_dig41","dig41",[],['n','kt','flag'],8),
		("PUT_dig43", "dig43", [], ['x', 'y', 'u1'], 9)
	]

	runner(benchmark, methodParameters, "results/hola_exception.csv")


def run_CodeContracts():
	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/CodeContractBenchmark/CodeContractBenchmark.sln',
		testFile = 'BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/CodeContractBenchmarkTest.cs',
		testDll ='BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/bin/Debug/CodeContractBenchmarkTest.dll',
		classFile='BenchmarksAll/CodeContractBenchmark/CodeContractBenchmark/CodeContractBenchmark.cs',
		testNamespace = 'CodeContractBenchmark.Test',
		testType = 'CodeContractBenchmarkTest',
		pexReportFolder = 'BenchmarksAll/CodeContractBenchmark/CodeContractBenchmarkTest/bin/Debug'
	)


	methodParameters =[
		("PUT_AfterWhileLoop_ConditionAlwaysTrue","AfterWhileLoop_ConditionAlwaysTrue",[],['x','z']),
		("PUT_AfterWhileLoop_Symbolic", "AfterWhileLoop_Symbolic", [], ['x']),
		("PUT_AssertGeqZero","AssertGeqZero",[],['x']),
		("PUT_AssertGTZero", "AssertGTZero", [], ['x']),
		("PUT_AssertInsideWhileLoop","AssertInsideWhileLoop",[],['x'] ),
		("PUT_AssertLTZero", "AssertLTZero", [], ['x']),
		("PUT_GTZero","GTZero",[],['x']),   
		("PUT_GTZeroAfterCondition", "GTZeroAfterCondition", ['b'], ['x']),
		("PUT_GTZeroInConditional","GTZeroInConditional",['b'],['x']), 
		("PUT_InsideWhileLoop", "InsideWhileLoop", [], ['x']),
		("PUT_Loop","Loop",[],['input']),
		("PUT_Loop2", "Loop2", [], ['x']),
		("PUT_Loop4","Loop4",[],['m1','f']),
		("PUT_RepeatedPreconditionInference","RepeatedPreconditionInference",[],['x','z','k'] ),
		("PUT_Shuvendu","Shuvendu",[],['x','t']),
		("PUT_Simplification1", "Simplification1", [], ['x']),
		("PUT_Simplification2","Simplification2",[],['x']),
		("PUT_Simplification3", "Simplification3", [], ['x']),
		("PUT_Simplification4","Simplification4",[],['x']),
		("PUT_SrivastavaGulwaniPLDI09", "SrivastavaGulwaniPLDI09", [], ['x', 'y'])
	] 

	runner(benchmark, methodParameters, "results/codecontract_exception.csv")


def run_PriorityQueueCommutativity():
	benchmark = Benchmark(
		solutionFile = 'BenchmarksAll/QuickGraph/QuickGraph.sln',
		testDll = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug/QuickGraphTest.dll',
		testFile = 'BenchmarksAll/QuickGraph/QuickGraphTest/PriorityQueueCommuteTest.cs',
		classFile = 'BenchmarksAll/QuickGraph/QuickGraph/PriorityQueue.cs',
		testNamespace = 'QuickGraphTest',
		testType = 'PriorityQueueCommuteTest',
		pexReportFolder = 'BenchmarksAll/QuickGraph/QuickGraphTest/bin/Debug'
	)
 

	methodParameters = [
		('PUT_CommutativityUpdateUpdateComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityUpdateCountComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityUpdateContainsComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityUpdateEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityUpdateDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityUpdatePeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityCountCountComm', [ ], ['pq1.Count'] ),
		('PUT_CommutativityCountContainsComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityCountEnqueueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityCountDequeueComm', [ ], ['pq1.Count'] ),
		('PUT_CommutativityCountPeekComm', [ ], ['pq1.Count'] ),
		('PUT_CommutativityContainsContainsComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityContainsEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityContainsDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityContainsPeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityEnqueueEnqueueComm', [ 'pq1.Contains(value1)', 'pq1.Contains(value2)'], ['pq1.Count', 'value1', 'value2'] ),
		('PUT_CommutativityEnqueueDequeueComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityEnqueuePeekComm', [ 'pq1.Contains(value)'], ['pq1.Count', 'value'] ),
		('PUT_CommutativityDequeueDequeueComm', [ ], ['pq1.Count'] ),
		('PUT_CommutativityDequeuePeekComm', [ ], ['pq1.Count'] ),
		('PUT_CommutativityPeekPeekComm', [], ['pq1.Count'])
	]

	runner(benchmark, methodParameters, "results/priorityqueue_comm.csv")



if __name__ == '__main__':
main()