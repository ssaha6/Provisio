from __future__ import print_function
#print is from this module.. so needs parenthesis
import unittest
import pprint
from . import Learner


class TestClass(unittest.TestCase):
    
    
    def testLearnerInit(self):
        learner = Learner(  ['inta', 'intb', 'intc'],
                             ['b1', 'b2'],
                             'learner\C50exact\c5.0dbg.exe',
                             '',
                             "tempLocation"
                        )
        
        learner.setIntLowHigh(-3, 3)
        print ("datapoint size" + str(learner.getDataPointSize()))
        
        dataPoints = [[1, 1, 0, "false", "true", "false"],
                      [2, 0, 0, "true", "true", "false"],
                      [1, 0, 0, "true", "true", "true"],
                      [0, 2, 2, "false", "false", "false"],
                      [0, 2147483647, 0, "false", "false", "false"],
                      [0, 2, 0, "false", "false", "false"],
                      [3, 0, 0, "true", "true", "false"],
                      [0, 0, 0, "false", "false", "true"],
                      [2, 0, 1, "true", "false", "false"],
                      [0, 2, 2, "false", "false", "true"],
                      [2, 0, 0, "true", "true", "false"],
                      [],
                      [5, 0, 0, "true", "true", "false"],
                      [0, -2147483647, -2147483648, "false", "false", "false"]
                    ]
        
        # learner.setDataPoints(dataPoints)
        # print("datapoint size" + str(learner.getDataPointSize()))
        # print(learner.dataPoints)
        
        print(learner.learn(dataPoints))
        
        self.assertTrue(True)






if __name__ == '__main__':
    unittest.main()

