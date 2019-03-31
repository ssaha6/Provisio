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

import reviewData
from dtlearner import DTLearner
import shell


class P2NLearner(DTLearner):


    def __init__(self, name, binary, parameters, tempLocation):
        DTLearner.__init__(self, name, binary, parameters, tempLocation)


    # def parse_tree(self, tree):
    #         print tree
            
    #         if (tree['children'] is None):
    #             return '  ' + str(tree['classification']).strip().lower()
            

    #         elif (len(tree['children']) == 2):
                
    #             node = []
    #             for condition in tree['conditions']:
                    
    #                 if 'partition' in condition:
                        
    #                     if condition['partition'] == 't':
    #                         partition = "true"
    #                     elif condition['partition'] == 'f':
    #                         partition = "false"
    #                     else :
    #                         partition = condition['partition']
                        
    #                     condition_str = ' ( = ( ' + condition['attribute'] + ' ) ' + partition + ' ) '
            
    #                 else:
    #                     condition_str = ' ( ' + condition['comparison'] + ' ' + condition['attribute'] + ' ' + str(condition['cut']) + ' ) '
                
    #                 node.append(condition_str)
                    
    #             node_joined =  '( and ' + ' '.join(node) + ')'
                
    #             left = self.parse_tree(tree['children'][0]).strip()
    #             right = self.parse_tree(tree['children'][1]).strip()
                
    #             return  '(or   ( and ' +   node_joined  + ' ' + left + ' )  ( and  ( not ' + node_joined + ') ' + right + ' ))'

    #             # return ' ((' + node_joined + ' && (' + left + ')) ||  ((!' + node_joined + ') && (' + right + '))) '

    #         else:
    #             shell.printExceptionAndExit(e, "Parsing JSON File")
    #             sys.exit(1)
