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
import csharp
##from utilityPython import utils
##from benchmarkSet import BenchmarkSet
from lxml import etree


def insert_p_in_put(CSharpFile, methodname, precondition ):
    fullPathCsharpFile= os.path.abspath(CSharpFile)
    file = list()
    with io.open(fullPathCsharpFile, 'r',encoding='utf-8-sig') as f:
        file = f.read().splitlines()
        
    begin = False
    index = -1
    once = True
    newContents = []

    for line in file:
        if line.find(methodname) != -1 and once:
            begin = True
            once = False
        elif begin and line.find("AssumePrecondition.IsTrue(") != -1:
            index = line.find("AssumePrecondition.IsTrue(")
            line = line[:index+26]+ precondition+ ");"
            begin = False
            #print line.encode.encode("utf-8")("utf-8")
        newContents.append(line)
    
    with io.open(fullPathCsharpFile, 'w', encoding='utf-8-sig') as fWrite:
        fWrite.write("\n".join(newContents))


def insert_assumes(ClassFilePath, methodUnderTest):
    fullPathCsharpFile= os.path.abspath(ClassFilePath)

    contentsLines = list()
    with io.open(fullPathCsharpFile, 'r',encoding='utf-8-sig') as f:
        contentsLines = f.read().splitlines()
    
    begin = False
    index = -1
    once =True
    nextLine = False
    newContents = []
    
    for line in contentsLines:
        if line.find(methodUnderTest) != -1 and once:
            #this.debug_print("method under test: " + methodUnderTest, False)
            begin = True
            once = False
        elif begin and line.find('//NotpAssume.IsTrue') != -1:
            #print "********before: "+line
            line = line.replace('//',"")
            nextLine = True
        elif nextLine and  line.find('//try{PexAssert.IsTrue') != -1:
            line = line.replace('//',"")
            nextLine = False
            #print "********uncommented: "+line

        elif begin and re.search(r"(?:(?:public)|(?:private)|(?:static)|(?:protected)\s+).*",line,re.DOTALL):# if we see the signature for next method, stop collecting assumes
            begin = False

        newContents.append(line)
    
    
    with io.open(fullPathCsharpFile, 'w',encoding='utf-8-sig') as fWrite:
        fWrite.write("\n".join(newContents))
    


def remove_assumes(ClassFilePath, methodUnderTest):
    fullPathCsharpFile = os.path.abspath(ClassFilePath)

    file = list()
    with io.open(fullPathCsharpFile  , 'r',encoding='utf-8-sig') as f:
        file = f.read().splitlines()

    begin = False
    index = -1
    once =True
    nextLine = False
    newContents = []
   
    for line in file:
        if line.find(methodUnderTest) != -1 and once:
            begin = True
            once = False
        #elif begin and line.find("/*Change*/PexAssume.IsTrue(") != -1:
        elif begin and line.find('NotpAssume.IsTrue') != -1 and line.find('//NotpAssume.IsTrue') == -1:
            #print "********before: "+line
            line = line.replace('Notp',"//Notp")
            nextLine = True

        elif nextLine and  line.find('try{PexAssert.IsTrue') != -1 and line.find('//try{PexAssert.IsTrue') == -1:
            line = line.replace('try{PexAssert',"//try{PexAssert")
            nextLine = False
            #print "********commenting: "+line

        elif begin and re.search(r"(?:(?:public)|(?:private)|(?:static)|(?:protected)\s+).*",line,re.DOTALL):# if we see the signature for next method, stop collecting assumes
            begin = False
                    
        newContents.append(line)
                
        
    with io.open(fullPathCsharpFile, 'w',encoding='utf-8-sig') as fWrite:
        fWrite.write("\n".join(newContents))



def insertPostConditionInPexAssert(CSharpFile, postcondition, methodname):
    fullPathCsharpFile = os.path.abspath(CSharpFile)
    file = list()
    with io.open(fullPathCsharpFile, 'r', encoding = 'utf-8-sig') as f:
        file = f.read().splitlines()

    begin = False
    indexPexAssert = -1
    once = True
    lineToChange = "PexAssert.IsTrue("
    newContents = []
    
    for line in file:
        if line.find(methodname) != -1 and once:
            begin = True
            once = False
        elif begin and line.find(lineToChange) != -1:
            indexPexAssert = line.find(lineToChange)
            line = line[:indexPexAssert + 17] + postcondition + ");"
            begin = False
            #print line.encode.encode("utf-8")("utf-8")
        newContents.append(line)
    
    with io.open(fullPathCsharpFile, 'w', encoding='utf-8-sig') as fWrite:
        fWrite.write("\n".join(newContents))
    

def runCompiler(compilerCommand, solutionFile):
    csharp.run_compiler(csharp.set_compiler_args(compilerCommand, solutionFile))


