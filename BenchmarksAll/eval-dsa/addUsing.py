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

l = list()
f = open(sys.argv[1],'r')
file = f.read().decode("utf-8").splitlines()
l[0:] = file
f.close()

outf = open(sys.argv[1],'w')
outf.write("using Microsoft.Pex.Framework;\n")
outf.write("using DySy.Framework;\n")
for line in l:
    outf.write(line+"\n")

outf.close()
