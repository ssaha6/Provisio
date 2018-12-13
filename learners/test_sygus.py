from __future__ import print_function
#print is from this module.. so needs parenthesis
import unittest
import pprint
from sygus import Learner


class TestSygusClass(unittest.TestCase):

    def testLearnerInit(self):
        
        learner = Learner(
                            intVariables = ['inta', 'intb', 'intc'],
                            booleanVariables = ['b1', 'b2'],
                            learnerBinary = 'learner\C50exact\c5.0dbg.exe',
                            learnerParameter = '',
                            tempLocation = "tempLocation"
                        )

        # learner.renameVariables()
        # print(learner.symbolicBooleanVariables, learner.symbolicIntVariables)
        # learner.learn([])
        # self.assertTrue(True)



        dataPoints = [[1, 1, 0, "false", "true", "false"],
                    [2, 0, 0, "true", "true", "false"],
                    [1, 0, 0, "true", "true", "true"],
                    [0, 2, 2, "false", "false", "false"],
                    #[0, 2147483647, 0, "false", "false", "false"],
                    [0, 2, 0, "false", "false", "false"],
                    [3, 0, 0, "true", "true", "false"],
                    [0, 0, 0, "false", "false", "true"],
                    [2, 0, 1, "true", "false", "false"],
                    [0, 2, 2, "false", "false", "true"],
                    [2, 0, 0, "true", "true", "false"],
                    [5, 0, 0, "true", "true", "false"],
                    #[0, -2147483647, -2147483648, "false", "false", "false"]
                    ]
        # print(learner.formatProgram(learner.generateConstraints(dataPoints)))
		
        print(learner.learn(dataPoints))


if __name__ == '__main__':
    unittest.main()

