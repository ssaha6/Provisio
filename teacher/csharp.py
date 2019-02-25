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
import executecommand


def set_compiler_args(compilerCommand, solutionFile):
    compilerOption = '/t:rebuild'
    build_mode = 'debug'
    ignoreWarning = '/property:WarningLevel=2'
    solutionPath = solutionFile
    cmd_exec = [compilerCommand, solutionPath, compilerOption, ignoreWarning]

    return cmd_exec


def run_compiler(args):
    
    compilerOutput = executecommand.runCommand(args)
    parsedOutput =  (compilerOutput.split(os.linesep))[-4:-2]

    # assert MSBuild.exe output near the  end  [0 Warning(s), 0 Error(s)]
    assert len(parsedOutput) == 2

    if parsedOutput[1].find("0 Error(s)") != -1:
        return
    else:
        raise ValueError('The input solution did not compile Errors')

