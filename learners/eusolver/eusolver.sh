#!/bin/bash

# LIBEUSOLVER_PYTHON_PATH=/mnt/d/Downloads/eu/thirdparty/libeusolver/build
# 
# Z3_PYTHON_PATH=/mnt/d/Downloads/eu/thirdparty/z3/bin/python 


# PYTHONPATH=$Z3_PYTHON_PATH:$LIBEUSOLVER_PYTHON_PATH:"'$PYTHONPATH'" 

cd /mnt/d/experimental3/learners/eusolver
timeout 1200s python3 src/benchmarks.py "$1"

# EOF
