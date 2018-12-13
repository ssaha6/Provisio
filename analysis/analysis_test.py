from __future__ import print_function
import unittest
# from onotherfile import class
from Analysis import Analysis
import pprint

class TestClass(unittest.TestCase):

    def test_fn(self):
        # create object of the class
        a = Analysis()
        print(a.make_linear_combination(3,-2, 2))
        self.assertTrue(True)

    def test_create_names_file(self):
        IntVariables = ['a', 'b', 'c']
        low = 1
        high = 2
        filename = "a.txt"
        a = Analysis()
        a.create_names_file(IntVariables, low, high, filename)
        self.assertTrue(True)

    def test_skip_zer0(self):
        IntVariables = ['a', 'b','c']
        low = -2
        high = 2
        filename = "a.names"
        a = Analysis()
        a.create_names_file(IntVariables, low, high, filename)
        self.assertTrue(True)

if __name__ == '__main__':
    unittest.main()
