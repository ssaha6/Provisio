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
import itertools
import random

# from utilityPython import utils
# from benchmarkSet import BenchmarkSet



# wslpath: only in wsl, not available in windows
# ex: wsl ls $(wsl wslpath -a 'D:\\done\\Sygus')
#
# Parameters
# -a    force result to absolute path format
# -u    translate from a Windows path to a WSL path (default)
# -w    translate from a WSL path to a Windows path
# -m    translate from a WSL path to a Windows path, with '/' instead of '\\'
#
# Windows -> Linux: -a
# Linux -> Windows: -a -w



# Detect OS
# import os
# os.name
# 'nt' => Windows
# 'posix' => WSL


# class Shell:

#     def __init__(self, osName):
#         self.osName = osName.lower()

#         if "win" in self.osName or self.osName == "nt":
#             self.osType = "windows"

# elif "posix" in self.osName or "unix" in self.osName or \
#     "linux" in self.osName or "wsl" in self.osName or \
#     "ubuntu" in self.osName:
# self.osType = "linux"


def sanitizePath(path, osType):
    try:
        absPath = os.path.abspath(path).strip()

        if osType == "windows" or osType == "win":
            return absPath
        elif osType == "linux" or osType == "wsl":
            return runCommand('wsl wslpath -a \'' + absPath + '\'')

    except ex:
        printExceptionAndExit(ex, "Error Converting Path")


def runCommand(args, directory = '.'):
    try:
        # #remove any starting with wsl
        # if self.osType == "windows":
        #     args = re.sub('\s*(wsl\s+)*(.*)', '\g<2>', args)
        # # add wsl if needed
        # elif self.osType == "linux":
        #     args = re.sub('\s*(wsl\s+)*(.*)', 'wsl \g<2>', args)

        print("Executing:", args)
        executionOutput = ""

        executionRun = subprocess.Popen(args, cwd = directory, stdout = subprocess.PIPE, stderr = subprocess.PIPE)
        for line in executionRun.stdout:
            executionOutput = executionOutput + os.linesep + str(line.rstrip())
        
        executionOutput = executionOutput.strip()
        executionRun.stdout.close()
        print("Output:", executionOutput)
        return executionOutput

    except Exception as e:
        print(executionOutput)
        printExceptionAndExit(e, "Execution Error")


#delete only in windows
def resetFilesByRegex( location, pattern):
    try:
        for f in os.listdir(os.path.abspath(location)):
            if re.search(pattern, f):
                os.remove(os.path.join(location, f))
    except:
        pass


def printExceptionAndExit(e, msg):
    print "*** ERROR:" + msg + " ****"
    print e
    sys.exit(1)


#writing only in windows
def writeFile( location, fileName, fileContents):
    absPath = os.path.abspath(location + '/' + fileName).strip()

    print absPath
    #wb to output LF, w outputs CRLF
    with open(absPath, 'wb') as outfile:
        outfile.write(fileContents)


#reading only in windows



def debug_print(text, flag):
    if flag:
        print text




#test
# if __name__ == '__main__':

# print Shell("win").runCommand('ls -la')
# print Shell("wsl").runCommand('ls -la')

# pwin = Shell("win")
# print pwin.runCommand('ls -la ' + pwin.sanitizePath('../../done/Sygus'))

# pwsl = Shell("wsl")
# print pwsl.runCommand('ls -la \'' + pwsl.sanitizePath('../../done/Sygus') + '\'')

# print Shell("winsome").sanitizePath('..\.\/\/||/\done\\Sygus')
# print Shell("wsl").sanitizePath('..\.\/\/||/\done\\Sygus')
