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
		('PUT_CommutativityAddVertexRemoveVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexContainsEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexAdjacentEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexIsVerticesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexVertexCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexContainsVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexAddEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexRemoveEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexIsEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexEdgeCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexAdjacentDegreeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityAddVertexIsAdjacentEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexRemoveVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexAdjacentEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'index', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexIsVerticesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexVertexCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexContainsVertexComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexAddEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexRemoveEdgeComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)', 'g1.ContainsVertex(e.Source)', 'g1.ContainsVertex(e.Target)', 'g1.ContainsEdge(e.Source, e.Target)'], ['node', 'e.Source', 'e.Target', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexIsEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount']),
		('PUT_CommutativityRemoveVertexEdgeCountComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node)'], ['node', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node)']),
		('PUT_CommutativityRemoveVertexAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityRemoveVertexIsAdjacentEdgesEmptyComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
		('PUT_CommutativityClearAdjacentEdgesClearAdjacentEdgesComm', ['g1.IsVerticesEmpty', 'g1.IsEdgesEmpty', 'g1.AllowParallelEdges', 'g1.ContainsVertex(node1)', 'g1.ContainsVertex(node2)'], ['node1', 'node2', 'g1.VertexCount', 'g1.EdgeCount', 'g1.AdjacentDegree(node1)', 'g1.AdjacentDegree(node2)']),
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
		('PUT_CommutativityCapacityCapacityComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityCountComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityAddComm', [], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityRemoveMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityRemoveAtComm', [], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityIndexOfComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCapacityUpdateComm', [], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountCountComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountAddComm', [], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountRemoveMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountRemoveAtComm', [], ['index', 'bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountIndexOfComm', [], ['value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityCountUpdateComm', [], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityAddAddComm', [], ['priority1', 'value1', 'priority2', 'value2', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value1)', 'bh1.IndexOf(value2)', 'bh1.Minimum().Key']),
		('PUT_CommutativityAddMinimumComm', [], ['priority', 'value', 'bh1.Count', 'bh1.Capacity', 'bh1.IndexOf(value)', 'bh1.Minimum().Key']),
		('PUT_CommutativityMinimumMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key']),
		('PUT_CommutativityMinimumRemoveMinimumComm', [], ['bh1.Count', 'bh1.Capacity', 'bh1.Minimum().Key'])
	]

	runner(benchmark, methodParameters, "results/binaryheap_comm.csv")



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
		("PUT_dig01", "dig01", [], ['n']),
		("PUT_dig07","dig07",[],['n','u1']),
		("PUT_dig14","dig14",[],['m','u4']),
		("PUT_dig15","dig15",[],['n','k']),
		("PUT_dig19","dig19",[],['m','n']),
		("PUT_dig21","dig21",[],['n','j','v','u4']),
		("PUT_dig31","dig31",[],['m','n','u1']),
		("PUT_dig39","dig39",[],['MAXPATHLEN','u']),
		("PUT_dig41","dig41",[],['n','kt','flag']),
		("PUT_dig43", "dig43", [], ['x', 'y', 'u1'])
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

def run_LidgrenNetworkNetBigInteger(learner, pex, typeLearner, thres, file):
    SolutionFile = 'BenchmarksAll/Lidgren.Network/Lidgren.Network.Windows.sln'
    TestDll = 'BenchmarksAll/Lidgren.Network/Lidgren.NetworkTests/bin/Debug/Lidgren.Network.Tests.dll'
    TestFile = 'BenchmarksAll/Lidgren.Network/Lidgren.NetworkTests/NetBigIntegerTest.cs'
    ClassFile = 'BenchmarksAll/Lidgren.Network/NetBigInteger.cs'
    TestNamespace = 'Lidgren.Network'
    TestType = 'NetBigIntegerTest'
    learnerOutputDir = 'BenchmarksAll'

    print "***** Beginning BigNetInteger Analysis *****"
    print "***** starting Exact *****"

    listOfInputs = [('PUT_Abs','Abs', [ ], ['targetIntValue', 'targetSignValue'], 0),
 ('PUT_Add','Add', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 1),
 ('PUT_And','And', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 2),
 ('PUT_BitLengthGet','BitLengthGet', [ ], ['targetIntValue', 'targetSignValue'], 3),
 ('PUT_CompareTo','CompareTo', ['NetBigIntegerTest.IsNull(obj)', 'typeEqualTestClass'], ['targetIntValue', 'targetSignValue'], 4),
 ('PUT_CompareTo01','CompareTo01', ['NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 5),
 ('PUT_Constructor','Constructor', ['string.IsNullOrEmpty(value)', 'string.IsNullOrWhiteSpace(value)', 'ulong.TryParse(value.out.temp)', 'nullAtEnd', 'isNotBegZero', 'startWithSign'], [], 6),
 ('PUT_Constructor01','Constructor01', ['string.IsNullOrEmpty(str)', 'string.IsNullOrWhiteSpace(str)', 'ulong.TryParse(str.out.temp)', 'nullAtEnd', 'isNotBegZero', 'startWithSign'], ['radix'], 7),
 ('PUT_Constructor02','Constructor02', ['NetBigIntegerTest.IsNull(bytes)'], ['bytesLength'], 8),
 ('PUT_Constructor03','Constructor03', ['NetBigIntegerTest.IsNull(bytes)'], ['bytesLength', 'offset', 'length'], 9),
 ('PUT_Constructor04','Constructor04', ['NetBigIntegerTest.IsNull(bytes)'], ['bytesLength', 'sign'], 10),
 ('PUT_Constructor05','Constructor05', ['NetBigIntegerTest.IsNull(bytes)'], ['bytesLength', 'sign', 'offset', 'length'], 11),
 ('PUT_Divide','Divide', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 12),
 ('PUT_DivideAndRemainder','DivideAndRemainder', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 13),
 ('PUT_Equals01','Equals01',['NetBigIntegerTest.IsNull(obj)', 'typeEqualTestClass'], ['targetIntValue', 'targetSignValue'], 14),
 ('PUT_Gcd','Gcd', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 15),
 ('PUT_GetHashCode01','GetHashCode01', [ ], ['targetIntValue', 'targetSignValue'], 16),
 ('PUT_GetLowestSetBit','GetLowestSetBit', [ ], ['targetIntValue', 'targetSignValue'], 17),
 ('PUT_IntValueGet','IntValueGet', [ ], ['targetIntValue', 'targetSignValue'], 18),
 ('PUT_Max','Max', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 19),
 ('PUT_Min','Min', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 20),
 ('PUT_Mod','Mod', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 21),
 ('PUT_ModInverse','ModInverse', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue', 'intGcd'], 22),
 ('PUT_ModPow','ModPow', [ 'NetBigIntegerTest.IsNull(exponent)', 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'exponentIntValue', 'exponentSignValue', 'valueIntValue', 'valueSignValue'], 23),
 ('PUT_Modulus','Modulus', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 24),
 ('PUT_Multiply','Multiply', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 25),
 ('PUT_Negate','Negate', [ ], ['targetIntValue', 'targetSignValue'], 26),
 ('PUT_Not','Not', [ ], ['targetIntValue', 'targetSignValue'], 27),
 ('PUT_Pow','Pow', [ ], ['targetIntValue', 'targetSignValue', 'exp'], 28),
 ('PUT_Remainder','Remainder', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 29),
 ('PUT_ShiftLeft','ShiftLeft', [ ], ['targetIntValue', 'targetSignValue', 'n'], 30),
 ('PUT_ShiftRight','ShiftRight', [ ], ['targetIntValue', 'targetSignValue', 'n'], 31),
 ('PUT_SignValueGet','SignValueGet', [ ], ['targetIntValue', 'targetSignValue'], 32),
 ('PUT_Subtract','Subtract', [ 'NetBigIntegerTest.IsNull(value)'], ['targetIntValue', 'targetSignValue', 'valueIntValue', 'valueSignValue'], 33),
 ('PUT_TestBit','TestBit', [ ], ['targetIntValue', 'targetSignValue', 'n'], 34),
 ('PUT_ToByteArray','ToByteArray', [ ], ['targetIntValue', 'targetSignValue'], 35),
 ('PUT_ToByteArrayUnsigned','ToByteArrayUnsigned', [ ], ['targetIntValue', 'targetSignValue'], 36),
 ('PUT_ToString01','ToString01', [ ], ['targetIntValue', 'targetSignValue'], 37),
 ('PUT_ToString02','ToString02', [ ], ['targetIntValue', 'targetSignValue', 'radix'], 38),
 ('PUT_ValueOf','ValueOf', [ ], ['value'], 39)]
    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    # need to reevaluate cases before PUT_Modulus

    for i in [11]:
        if len(listOfInputs[i][2])== 0 and len(listOfInputs[i][3]) == 0:
            printToFile(listOfInputs[i][0], "","","still need to evaluate","",file,"",True)
            continue

        if os.path.exists(lidgrenNetworkReportLocation):
            shutil.rmtree(lidgrenNetworkReportLocation)
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3], SolutionFile, TestFile,
            ClassFile, TestDll, pex, TestNamespace, TestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e
            traceback.print_exc()

def run_LidgrenNetworkNetOutgoingMessage(learner, pex, typeLearner, thres, file):
    SolutionFile = 'BenchmarksAll/Lidgren.Network/Lidgren.Network.Windows.sln'
    TestDll = 'BenchmarksAll/Lidgren.Network/Lidgren.NetworkTests/bin/Debug/Lidgren.Network.Tests.dll'
    TestFile = 'BenchmarksAll/Lidgren.Network/Lidgren.NetworkTests/NetOutgoingMessageTest.cs'
    ClassFile = 'BenchmarksAll/Lidgren.Network/NetOutgoingMessage.cs'
    TestNamespace = 'Lidgren.Network'
    TestType = 'NetOutgoingMessageTest'
    learnerOutputDir = 'BenchmarksAll'

    print "***** Beginning NetOutgoingMessage Analysis *****"
    print "***** starting Exact *****"

    listOfInputs =[('PUT_Encrypt','Encrypt', ['NetOutgoingMessageTest.IsNull(encryption)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'encryptionBytesLength'], 0),
 ('PUT_EnsureBufferSize','EnsureBufferSize', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'numberOfBits'], 1),
 ('PUT_InternalEnsureBufferSize','InternalEnsureBufferSize', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'numberOfBits'], 2),
 ('PUT_LengthBitsGet','LengthBitsGet', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 3),
 ('PUT_LengthBitsSet','LengthBitsSet', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 4),
 ('PUT_LengthBytesGet','LengthBytesGet', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 5),
 ('PUT_LengthBytesSet','LengthBytesSet', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 6),
 ('PUT_PeekDataBuffer','PeekDataBuffer', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 7),
 ('PUT_ToString01','ToString01', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 8),
 ('PUT_Write','Write', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 9),
 ('PUT_Write01','Write01', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 10),
 ('PUT_Write02','Write02', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 11),
 ('PUT_Write03','Write03', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'numberOfBits'], 12),
 ('PUT_Write04','Write04', ['NetOutgoingMessageTest.IsNull(source)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'sourceLength'], 13),
 ('PUT_Write05','Write05', ['NetOutgoingMessageTest.IsNull(source)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'sourceLength', 'offsetInBytes', 'numberOfBytes'], 14),
 ('PUT_Write06','Write06', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 15),
 ('PUT_Write07','Write07', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source', 'numberOfBits'], 16),
 ('PUT_Write08','Write08', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 17),
 ('PUT_Write09','Write09', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 18),
 ('PUT_Write10','Write10', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 19),
 ('PUT_Write11','Write11', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source', 'numberOfBits'], 20),
 ('PUT_Write12','Write12', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source', 'numberOfBits'], 21),
 ('PUT_Write13','Write13', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 22),
 ('PUT_Write14','Write14', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source', 'numberOfBits'], 23),
 ('PUT_Write15','Write15', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 24),
 ('PUT_Write16','Write16', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source', 'numberOfBits'], 25),
 ('PUT_Write17','Write17', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 26),
 ('PUT_Write18','Write18', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source'], 27),
 ('PUT_Write19','Write19', ['string.IsNullOrEmpty(source)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'source.Length'], 28),
 ('PUT_Write20','Write20', ['IsNull(endPoint)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'endPointPort'], 29),
 ('PUT_Write21','Write21', ['IsNull(message)'], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'messageLengthBits', 'messageLengthBytes', 'messageBufferLength'], 30),
 ('PUT_Write22','Write22', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'messageLengthBits', 'messageLengthBytes', 'messageBufferLength'], 31),
 ('PUT_WriteAllFields','WriteAllFields', [], ['target.LengthBits', 'target.LengthBytes'], 32),
 ('PUT_WriteAllFields01','WriteAllFields01', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 33),
 ('PUT_WriteAllProperties','WriteAllProperties', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 34),
 ('PUT_WriteAllProperties01','WriteAllProperties01', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 35),
 ('PUT_WritePadBits','WritePadBits', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length'], 36),
 ('PUT_WritePadBits01','WritePadBits01', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'numberOfBits'], 37),
 ('PUT_WriteRangedInteger','WriteRangedInteger', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'min', 'max', 'value'], 38),
 ('PUT_WriteRangedSingle','WriteRangedSingle', [], ['value', 'min', 'max', 'numberOfBits'], 39),
 ('PUT_WriteSignedSingle','WriteSignedSingle', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value', 'numberOfBits'], 40),
 ('PUT_WriteTime','WriteTime', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'localTime', 'highPrecision'], 41),
 ('PUT_WriteUnitSingle','WriteUnitSingle', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value', 'numberOfBits'], 42),
 ('PUT_WriteVariableInt32','WriteVariableInt32', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 43),
 ('PUT_WriteVariableInt64','WriteVariableInt64', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 44),
 ('PUT_WriteVariableUInt32','WriteVariableUInt32', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 45),
 ('PUT_WriteVariableUInt64','WriteVariableUInt64', [], ['target.LengthBits', 'target.LengthBytes', 'target.PeekDataBuffer().Length', 'value'], 46)]
    name =""
    p = ""
    rounds  = ""
    data = ""
    t0 = 0.0
    t1 = 0.0
    pexTime = 0.0

    #for i in xrange(40, 41):
    for i in [14]:
        if len(listOfInputs[i][2])== 0 and len(listOfInputs[i][3]) == 0:
            printToFile(listOfInputs[i][0], "","","still need to evaluate","",file,"",True)
            continue

        if os.path.exists(lidgrenNetworkReportLocation):
            shutil.rmtree(lidgrenNetworkReportLocation)
        print "Evaluation for method: " + listOfInputs[i][0]
        try:        
            t0 = time.time()
            myAnalysis = Analysis()
            name,p,rounds,data,pexTime = myAnalysis.learnPreconditionForException(listOfInputs[i][0],listOfInputs[i][1],listOfInputs[i][2],listOfInputs[i][3], SolutionFile, TestFile,
            ClassFile, TestDll, pex, TestNamespace, TestType, learner, typeLearner,thres, learnerOutputDir)  
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),True)
        except Exception as e:
            t1 = time.time()
            printToFile(name,p,rounds,str(t1-t0),data,file,str(pexTime),False)
            print "***************"
            print e
            traceback.print_exc()

if __name__ == '__main__':
    main()