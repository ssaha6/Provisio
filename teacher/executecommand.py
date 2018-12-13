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
from utilityPython import utils
from benchmarkSet import BenchmarkSet
from lxml import etree


def runCommand(args):
	try:
		print(args)
		executionOutput = ""

		executionRun = subprocess.Popen(args, stdout = subprocess.PIPE, stderr = subprocess.PIPE)
		for line in executionRun.stdout:
			executionOutput = executionOutput + os.linesep + str(line.rstrip())

		executionRun.stdout.close()
		print(executionOutput)
		return executionOutput
	except Exception as e:
		print(executionOutput)
		shell.printExceptionAndExit(e, "Execution Error")
