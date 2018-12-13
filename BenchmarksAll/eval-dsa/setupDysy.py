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
import sys


#print sys.argv[1]
mut = sys.argv[2]
unitTest = list()
f = open(sys.argv[1],'r')
file = f.read().decode("utf-8").splitlines()
for line in file:
	r = mut + '[0-9]*\(\)$'
	match = re.search(r, line)
	if match:
		unitTest.append(match.group())

f.close()

print "[PexMethod]"
print "[DySyAnalysis]"
print "public void Entry(){"
for l in unitTest:
	print l+";"
print "}"


f.close()
