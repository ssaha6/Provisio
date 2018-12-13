import re
import sys
import os
import time
import subprocess
import argparse
import collections
import pprint
import csv

from bs4 import BeautifulSoup


def getTestNumber(tag):
	testNumTag = tag.find('span', class_="hint")
	testNum = testNumTag.text.strip("(").strip(")")
	return testNum

path = str(sys.argv[1])
f = open(path  , 'r')
html = f.read()
f.close()  

setTestNum = set()
soup = BeautifulSoup(html, 'html.parser')

# iterate through a list of test
tab = soup.find('table',id="testtableID0EC")
divTestTable = tab.find('div', id="logID0EU")

testTable = divTestTable.find('table')



# iterate through a list of passing test
for tag in testTable.find_all('div', class_="test"):
	#print tag.strings
	for s in tag.strings:
		if s.find("pathboundsexceeded") != -1:
			setTestNum.add(getTestNumber(tag))

# iterate through a list of failing test
for tag in testTable.find_all('div', class_="testfailure"):
	#print tag.text
	for s in tag.strings:
		if s.find("pathboundsexceeded") != -1:
			setTestNum.add(getTestNumber(tag))

for num in setTestNum:
	print "test: "+num