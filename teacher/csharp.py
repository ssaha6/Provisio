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
##from utilityPython import utils
##from benchmarkSet import BenchmarkSet
from lxml import etree
import modifycode
import reportparser
import executecommand


def set_compiler_args(compilerCommand, solutionFile):
	compilerOption = '/t:rebuild'
	build_mode = 'debug'
	ignoreWarning = '/property:WarningLevel=2'
	solutionPath = solutionFile
	cmd_exec = [compilerCommand, solutionPath, compilerOption, ignoreWarning]
	# print(cmd_exec)
	return cmd_exec


def run_compiler(args):
	try:
		compilerOutput = executecommand.runCommand(args)
		if re.match('0 Error\(s\)', compilerOutput):
			return
		else:
			raise ValueError('Compilation has errors')
	except Exception as e:
		utils.debug_print("Compilation Exception", True)
		utils.printExceptionAndExit(e, "Compilation error")
