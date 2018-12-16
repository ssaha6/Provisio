from __future__ import print_function
import unittest
# from onotherfile import class
# from analysis import Analysis
import pprint
from . import Teacher
from benchmarkSet import BenchmarkSet


class TestClass(unittest.TestCase):

	def testTeacherInit(self):


		benchmarkSet = BenchmarkSet(
		    benchmarkDir    = "..\\contractbenchmarks\\BenchmarksAll",
		    solutionFile    = 'DataStructures\\DataStructures.sln',
		    testDll         = 'DataStructures\\DataStructuresTest\\bin\Debug\\DataStructuresTest.dll',
		    reportFile      = 'DataStructures\\DataStructuresTest\\bin\\Debug\\myreport\\rep\\report.per',
		    testNamespace   = 'DataStructures.Comm.Test',
		    outputDir       = 'output',  #?????????
		    testFile        = 'DataStructures\\DataStructuresTest\\StackCommuteTest.cs',
		    testType        = 'StackCommuteTest',
		)
		
		compilerCommand = 'MSBuild.exe'
		pexBinary = 'C:\\install\\pex\\bin\\pex.exe'

		teacher = Teacher('PUT_CommutativityPeekPeekComm', benchmarkSet, compilerCommand, pexBinary)

		# teacher.run_compiler(teacher.set_compiler_args())
		# print(teacher.run_pex(teacher.set_pex_args()))
		print(teacher.runPTest("true"))

		self.assertTrue(True)

	# def test_reset_location(self):
	#     util.resetFile('StackEqualityAllNoBoundsExact.txt')
	#     self.assertTrue(True)

	# def test_reset_regex(self):
	#     util.resetFilesByRegex('.', 'pre\.*')
	#     self.assertTrue(True)

	# def test_skip_zer0(self):
	#     IntVariables = ['a', 'b','c']
	#     low = -2
	#     high = 2
	#     filename = "a.names"
	#     a = Analysis()
	#     a.create_names_file(IntVariables, low, high, filename)
	#     self.assertTrue(True)


if __name__ == '__main__':
	unittest.main()
