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


# ????????? Exauhtive list of cases of failire and passing..
def parseReport(reportPath):
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
