#!/bin/bash

source ~/.profile  > /dev/null  2>&1

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null && pwd )"
cd $DIR

# cd /mnt/d/LearningContracts/tools/learner/PIE  > /dev/null  2>&1

# dune clean
dune build app/App.exe  > /dev/null  2>&1
timeout 1200s dune exec app/App.exe 
