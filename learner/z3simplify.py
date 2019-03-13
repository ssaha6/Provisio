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
import logging
import shell
#from os import sys, path
#sys.path.append((path.dirname(path.abspath(__file__)+'\z3')  ))

# How to import z3
# 1. Add z3/z3-4.8.1-win/bin to path
# 2. Copy z3-4.8.1-win/bin/python/z3 folder to Python27/Lib
from z3 import *


def simplify(intVariables, boolVariables, precondition):
    set_option(max_args = 10000000, max_lines = 1000000, max_depth = 10000000, max_visited = 1000000)
    set_option(html_mode=False)
    set_fpa_pretty(flag=False)
    # print precondition
    
    intVars = [ Int(var) for var in intVariables]
    boolVars = [ Bool(var) for var in boolVariables]
    
    declareInts = "\n".join([ "(declare-const " + var + " Int)" for var in intVariables ])
    declareBools = "\n".join([ "(declare-const " + var + " Bool)" for var in boolVariables ])
    stringToParse = "\n".join([declareInts,  declareBools, "( assert " + precondition + ")"])
    
    logger = logging.getLogger("Framework.z3Simplify")
    
    logger.info("############ z3 program")
    logger.info("############ " + stringToParse)
    
    expr = parse_smt2_string(stringToParse)
    
    g  = Goal()
    g.add(expr)
    
    works = Repeat(Then( 
    Repeat(OrElse(Tactic('split-clause'),Tactic('skip'))),
    OrElse(Tactic('ctx-solver-simplify'),Tactic('skip')),
    OrElse(Tactic('unit-subsume-simplify'),Tactic('skip')),
    OrElse(Tactic('propagate-ineqs'),Tactic('skip')),
    OrElse(Tactic('purify-arith'),Tactic('skip')),
    OrElse(Tactic('ctx-simplify'),Tactic('skip')),
    OrElse(Tactic('dom-simplify'),Tactic('skip')),
    OrElse(Tactic('propagate-values'),Tactic('skip')),
    OrElse(Tactic('simplify'),Tactic('skip')),
    OrElse(Tactic('aig'),Tactic('skip')),
    OrElse(Tactic('degree-shift'),Tactic('skip')),
    OrElse(Tactic('factor'),Tactic('skip')),
    OrElse(Tactic('lia2pb'),Tactic('skip')),
    OrElse(Tactic('recover-01'),Tactic('skip')),
    OrElse(Tactic('elim-term-ite'),Tactic('skip')), #must to remove ite
    OrElse(Tactic('injectivity'),Tactic('skip')),
    OrElse(Tactic('snf'),Tactic('skip')),
    OrElse(Tactic('reduce-args'),Tactic('skip')),
    OrElse(Tactic('elim-and'),Tactic('skip')),
    OrElse(Tactic('symmetry-reduce'),Tactic('skip')),
    OrElse(Tactic('macro-finder'),Tactic('skip')),
    OrElse(Tactic('quasi-macros'),Tactic('skip')),
    ))

    result = works(g)

    # split_all = 

    # print str(result)
    # result = [[ "d1", "d2", "d3"], #= conjunct && conjunct
    #           [ "d4", "d5", "d6"]]
    
    #remove empty subgoals and check if resultant list is empty.
    result = filter(None, result)
    if not result:
        return "true" 
    
    
    completeConjunct = []
    for conjunct in result: 
        completeDisjunct = []
        for disjunct in conjunct:
                completeDisjunct.append("(" + str(disjunct) + ")")
                
        completeConjunct.append( "(" + " && ".join(completeDisjunct) + ")")
    
    simplifiedPrecondition = " || ".join(completeConjunct)
    
    simplifiedPrecondition = simplifiedPrecondition.replace("Not", " ! ")
    simplifiedPrecondition = simplifiedPrecondition.replace("False", " false ")
    simplifiedPrecondition = simplifiedPrecondition.replace("True", " true ")
    simplifiedPrecondition = simplifiedPrecondition.replace("\n", "  ")

    
    # assert ( ( "And" not in simplifiedPrecondition) and ( "Or" not in simplifiedPrecondition ) )
    
    # print simplifiedPrecondition
    return simplifiedPrecondition
    
    
    
    
    # print describe_tactics()
    # tactic human_simplify =  tactic(ctx, "ctx-simplify") & tactic(ctx, "purify-arith")
    # tactic dnf_human_simplify =   human_simplify & repeat( (tactic(ctx, "split-clause") | tactic(ctx, "skip")));



if __name__ == '__main__':
    # precondition = "(or   ( and ( <= ( + ( * -1 variableInt000)  (* -1 variableInt001)) -2 ) false )  ( and  ( not ( <= ( + (* -1 variableInt000) (* -1 variableInt001)) -2 )) true ))"
    # synbolicIntVariables = ["variableInt000", "variableInt001", "variableInt002"]
    # synbolicBoolVariables = ["variableBool000", "variableBool001"]
    
    
    # precondition = "(and (<= 0 variableInt002) (not (<= variableInt000 variableInt002)))"
    # precondition =  '(or (and variableBool000 (not (<= variableInt001 0)))  variableBool001 )'
    # precondition =  '(not (and variableBool000 (<= variableInt001 0)))' 
    # precondition =  '(<= (ite variableBool000 0 1) variableInt002)'

    # precondition = "(<= (ite variableBool001 1 (- (- variableInt000 1) 1)) (ite variableBool000 variableInt001 1))"
    # precondition = "(not (and (= variableInt002 variableInt001) (< variableInt006 0)))"

    # precondition = "(or (or (<= 0 variableInt006) (<= 0 variableInt005)) (or (= variableInt006 0) (< variableInt002 variableInt001))) "
    # precondition = "(or variableBool000 (not ( <= ( + ( * (-1) variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ) 0 )))"
    precondition = "(not ( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ( * -1 variableInt004 ) ) 0 ))"


    synbolicIntVariables = ["variableInt001", "variableInt000", "variableInt002", "variableInt003", "variableInt004"]
    synbolicBoolVariables = ["variableBool000"]
    simplify(synbolicIntVariables, synbolicBoolVariables, precondition)
    
    
    intVariables = ['Old_s1Count', 'New_s1Count', 'Old_s1Peek', 'New_s1Peek', 'Old_x', 'New_x']
    boolVariables = ["s1Containsx"]
    
    intExpression = "( = New_x (+ Old_s1Count 1) )"
    simplify(intVariables, boolVariables, intExpression)

    
# LOOK FOR SIMPLIFY PROPAGATE
   
# ackermannize_bv : A tactic for performing full Ackermannization on bv instances.
# subpaving : tactic for testing subpaving module.
# horn : apply tactic for horn clauses.
# horn-simplify : simplify horn clauses.
# nlsat : (try to) solve goal using a nonlinear arithmetic solver.
# qfnra-nlsat : builtin strategy for solving QF_NRA problems using only nlsat.
# nlqsat : apply a NL-QSAT solver.
# qe-light : apply light-weight quantifier elimination.
# qe-sat : check satisfiability of quantified formulas using quantifier elimination.
# qe : apply quantifier elimination.
# qsat : apply a QSAT solver.
# qe2 : apply a QSAT based quantifier elimination.
# qe_rec : apply a QSAT based quantifier elimination recursively.
# psat : (try to) solve goal using a parallel SAT solver.
# sat : (try to) solve goal using a SAT solver.
# sat-preprocess : Apply SAT solver preprocessing procedures (bounded resolution, Boolean constant propagation, 2-SAT, subsumption, subsumption resolution).
# ctx-solver-simplify : apply solver-based contextual simplification rules.
# smt : apply a SAT based SMT solver.
# psmt : builtin strategy for SMT tactic in parallel.
# unit-subsume-simplify : unit subsumption simplification.
# aig : simplify Boolean structure using AIGs.
# add-bounds : add bounds to unbounded variables (under approximation).
# card2bv : convert pseudo-boolean constraints to bit-vectors.
# degree-shift : try to reduce degree of polynomials (remark: :mul2power simplification is automatically applied).
# diff-neq : specialized solver for integer arithmetic problems that contain only atoms of the form (<= k x) (<= x k) and (not (= (- x y) k)), where x and y are constants and k is a numeral, and all constants are bounded.
# eq2bv : convert integer variables used as finite domain elements to bit-vectors.
# factor : polynomial factorization.
# fix-dl-var : if goal is in the difference logic fragment, then fix the variable with the most number of occurrences at 0.
# fm : eliminate variables using fourier-motzkin elimination.
# lia2card : introduce cardinality constraints from 0-1 integer.
# lia2pb : convert bounded integer variables into a sequence of 0-1 variables.
# nla2bv : convert a nonlinear arithmetic problem into a bit-vector problem, in most cases the resultant goal is an under approximation and is useul for finding models.
# normalize-bounds : replace a variable x with lower bound k <= x with x' = x - k.
# pb2bv : convert pseudo-boolean constraints to bit-vectors.
# propagate-ineqs : propagate ineqs/bounds, remove subsumed inequalities.
# purify-arith : eliminate unnecessary operators: -, /, div, mod, rem, is-int, to-int, ^, root-objects.
# recover-01 : recover 0-1 variables hidden as Boolean variables.
# bit-blast : reduce bit-vector expressions into SAT.
# bv1-blast : reduce bit-vector expressions into bit-vectors of size 1 (notes: only equality, extract and concat are supported).
# bv_bound_chk : attempts to detect inconsistencies of bounds on bv expressions.
# propagate-bv-bounds : propagate bit-vector bounds by simplifying implied or contradictory bounds.
# propagate-bv-bounds-new : propagate bit-vector bounds by simplifying implied or contradictory bounds.
# reduce-bv-size : try to reduce bit-vector sizes using inequalities.
# bvarray2uf : Rewrite bit-vector arrays into bit-vector (uninterpreted) functions.
# dt2bv : eliminate finite domain data-types. Replace by bit-vectors.
# elim-small-bv : eliminate small, quantified bit-vectors by expansion.
# max-bv-sharing : use heuristics to maximize the sharing of bit-vector expressions such as adders and multipliers.
# blast-term-ite : blast term if-then-else by hoisting them.
# cofactor-term-ite : eliminate term if-the-else using cofactors.
# collect-statistics : Collects various statistics.
# ctx-simplify : apply contextual simplification rules.
# der : destructive equality resolution.
# distribute-forall : distribute forall over conjunctions.
# dom-simplify : apply dominator simplification rules.
# elim-term-ite : eliminate term if-then-else by adding fresh auxiliary declarations.
# elim-uncnstr : eliminate application containing unconstrained variables.
# injectivity : Identifies and applies injectivity axioms.
# snf : put goal in skolem normal form.
# nnf : put goal in negation normal form.
# occf : put goal in one constraint per clause normal form (notes: fails if proof generation is enabled; only clauses are considered).
# pb-preprocess : pre-process pseudo-Boolean constraints a la Davis Putnam.
# propagate-values : propagate constants.
# reduce-args : reduce the number of arguments of function applications, when for all occurrences of a function f the i-th is a value.
# reduce-invertible : reduce invertible variable occurrences.
# simplify : apply simplification rules.
# elim-and : convert (and a b) into (not (or (not a) (not b))).
# solve-eqs : eliminate variables by solving equations.
# split-clause : split a clause in many subgoals.
# symmetry-reduce : apply symmetry reduction.
# tseitin-cnf : convert goal into CNF using tseitin-like encoding (note: quantifiers are ignored).
# tseitin-cnf-core : convert goal into CNF using tseitin-like encoding (note: quantifiers are ignored). This tactic does not apply required simplifications to the input goal like the tseitin-cnf tactic.

# qffd : builtin strategy for solving QF_FD problems.
# pqffd : builtin strategy for solving QF_FD problems in parallel.
# fpa2bv : convert floating point numbers to bit-vectors.
# qffp : (try to) solve goal using the tactic for QF_FP.
# qffpbv : (try to) solve goal using the tactic for QF_FPBV (floats+bit-vectors).
# qffplra : (try to) solve goal using the tactic for QF_FPLRA.
# default : default strategy used when no logic is specified.
# sine-filter : eliminate premises using Sine Qua Non
# qfbv-sls : (try to) solve using stochastic local search for QF_BV.
# nra : builtin strategy for solving NRA problems.
# qfaufbv : builtin strategy for solving QF_AUFBV problems.
# qfauflia : builtin strategy for solving QF_AUFLIA problems.
# qfbv : builtin strategy for solving QF_BV problems.
# qfidl : builtin strategy for solving QF_IDL problems.
# qflia : builtin strategy for solving QF_LIA problems.
# qflra : builtin strategy for solving QF_LRA problems.
# qfnia : builtin strategy for solving QF_NIA problems.
# qfnra : builtin strategy for solving QF_NRA problems.
# qfuf : builtin strategy for solving QF_UF problems.
# qfufbv : builtin strategy for solving QF_UFBV problems.
# qfufbv_ackr : A tactic for solving QF_UFBV based on Ackermannization.
# ufnia : builtin strategy for solving UFNIA problems.
# uflra : builtin strategy for solving UFLRA problems.
# auflia : builtin strategy for solving AUFLIA problems.
# auflira : builtin strategy for solving AUFLIRA problems.
# aufnira : builtin strategy for solving AUFNIRA problems.
# lra : builtin strategy for solving LRA problems.
# lia : builtin strategy for solving LIA problems.
# lira : builtin strategy for solving LIRA problems.
# skip : do nothing tactic.
# fail : always fail tactic.
# fail-if-undecided : fail if goal is undecided.
# macro-finder : Identifies and applies macros.
# quasi-macros : Identifies and applies quasi-macros.
# ufbv-rewriter : Applies UFBV-specific rewriting rules, mainly demodulation.
# bv : builtin strategy for solving BV problems (with quantifiers).
# ufbv : builtin strategy for solving UFBV problems (with quantifiers).




#     tacticList = ['ackermannize_bv',
# 'subpaving',
# 'horn',
# 'horn-simplify',
# 'nlsat',
# 'qfnra-nlsat',
# 'nlqsat',
# 'qe-light',
# 'qe-sat',
# 'qe',
# 'qsat',
# 'qe2',
# 'qe_rec',
# 'psat',
# 'sat',
# 'sat-preprocess',
# 'ctx-solver-simplify',
# 'smt',
# 'psmt',
# 'unit-subsume-simplify',
# 'aig',
# 'add-bounds',
# 'card2bv',
# 'degree-shift',
# 'diff-neq',
# 'eq2bv',
# 'factor',
# 'fix-dl-var',
# 'fm',
# 'lia2card',
# 'lia2pb',
# 'nla2bv',
# 'normalize-bounds',
# 'pb2bv',
# 'propagate-ineqs',
# 'purify-arith',
# 'recover-01',
# 'bit-blast',
# 'bv1-blast',
# 'bv_bound_chk',
# 'propagate-bv-bounds',
# 'propagate-bv-bounds-new',
# 'reduce-bv-size',
# 'bvarray2uf',
# 'dt2bv',
# 'elim-small-bv',
# 'max-bv-sharing',
# 'blast-term-ite',
# 'cofactor-term-ite',
# 'collect-statistics',
# 'ctx-simplify',
# 'der',
# 'distribute-forall',
# 'dom-simplify',
# 'elim-term-ite',
# 'elim-uncnstr',
# 'injectivity',
# 'snf',
# 'nnf',
# 'occf',
# 'pb-preprocess',
# 'propagate-values',
# 'reduce-args',
# 'reduce-invertible',
# 'simplify',
# 'elim-and',
# 'solve-eqs',
# 'split-clause',
# 'symmetry-reduce',
# 'tseitin-cnf',
# 'tseitin-cnf-core',
# 'qffd',
# 'pqffd',
# 'fpa2bv',
# 'qffp',
# 'qffpbv',
# 'qffplra',
# 'default',
# 'sine-filter',
# 'qfbv-sls',
# 'nra',
# 'qfaufbv',
# 'qfauflia',
# 'qfbv',
# 'qfidl',
# 'qflia',
# 'qflra',
# 'qfnia',
# 'qfnra',
# 'qfuf',
# 'qfufbv',
# 'qfufbv_ackr',
# 'ufnia',
# 'uflra',
# 'auflia',
# 'auflira',
# 'aufnira',
# 'lra',
# 'lia',
# 'lira',
# 'skip',
# 'fail',
# 'fail-if-undecided',
# 'macro-finder',
# 'quasi-macros',
# 'ufbv-rewriter',
# 'bv',
# 'ufbv'
#     ]
    
#     works = []
#     for tactic in tacticList:
#         try:
#             t = Tactic(tactic)
#             t(g)
#             works.append(tactic)
#         except :
#             pass