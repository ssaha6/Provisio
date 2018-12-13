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
import itertools


class Learner:
	# create neames file:  intvariables, high low, booleanvariables,
	# create data file: dataPoints = ()
	# runlearner: location, parameter

