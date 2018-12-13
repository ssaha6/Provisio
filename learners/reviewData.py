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

import shell


# just removes empty points
def removeEmptyPoints(dataPoints):
    return filter(lambda x: len(x) > 0, dataPoints)


#also roves empty points and sort
def uniqueDataPoints(dataPoints):
    # filter empty lists
    dataPoints = removeEmptyPoints(dataPoints)
    #find unique: need sort to call itertools
    dataPoints.sort()
    return list(k for k, _ in itertools.groupby(dataPoints))


# also removes empty points and duplicates
def filterDataPointConflicts(dataPoints):
    try:
        inputm = removeEmptyPoints(dataPoints)
        finalset = set()
        for row in inputm:
            row_backup = list(row)
            if row[-1] == 'true':
                row_backup[-1] = 'false'
                if row_backup in inputm:
                    shell.debug_print("****found conflict****", False)
                else:
                    finalset.add(tuple(row))
            else:
                finalset.add(tuple(row))

        return list(finalset)

    except Exception as e:
        shell.printExceptionAndExit(e, "Error Filtering Data Points For Conflicts")

# region: old sort_and_unique_preds
# def sort_and_unique_preds(this, data_file, log, round, methodName):
#     inputm = []
#     dataToPrint = list()
#     with open(data_file) as f_in:
#         reader = csv.reader(f_in)
#         for row in reader:
#             if len(row) > 0:
#                 inputm.append(row)
#
#         finalset = set()
#         for row in inputm:
#             row_backup = list(row)
#             if row[-1] == 'true':
#                 row_backup[-1] = 'false'
#                 if row_backup in inputm:
#                     this.debug_print("****found conflict****", False)
#                 else:
#                     finalset.add(tuple(row))
#             else:
#                 finalset.add(tuple(row))
#         #loggin code
#         if log:
#             for item in finalset:
#                 if not (item in this.allDataSet):
#                     dataToPrint.append(item)
#
#             this.allDataSet = this.allDataSet.union(finalset)
#             with open(methodName+"_round_"+str(round)+".txt", 'w') as f_out:
#                 csv_out = csv.writer(f_out)
#                 for item in this.allDataSet:
#                     csv_out.writerow(item)
#         # end of logging code
#     finalset = sorted(finalset)
#     with open(data_file, 'wb') as f_out:
#         csv_out = csv.writer(f_out)
#         for item in finalset:
#             csv_out.writerow(item)
#     return len(finalset)
# endregion
