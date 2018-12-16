(set-logic LIA)

		( synth-fun precondition ( (variableInt000 Int) (variableInt001 Int) (variableInt002 Int) (variableBool000 Bool) (variableBool001 Bool) ) Bool (
			( Start Bool (StartBool) )
				( StartBool Bool (
					true false
					variableBool000 variableBool001
						(and StartBool StartBool)
						(and StartBool StartBool)
						(not StartBool)
						(<=  StartInt StartInt)
						(= StartInt StartInt)
						(>=  StartInt StartInt)
				) )
				( StartInt Int (
					0 1
					variableInt000 variableInt001 variableInt002
						(+ StartInt StartInt)
						(- StartInt StartInt)
						(ite StartBool StartInt StartInt)
				) )
		) )

(declare-var x0 Int)
(declare-var x1 Int)
(declare-var x2 Int)
(declare-var x3 Bool)
(declare-var x4 Bool)

(constraint (implies ( and ( = x0 3) (= x1 0)(= x2 0)(= x3 false)(= x4 false)) (not (precondition x0 x1 x2 x3 x4)  )))
(constraint (implies ( and ( = x0 9) (= x1 1)(= x2 3)(= x3 false)(= x4 false))  (precondition x0 x1 x2 x3 x4)  ))
; ( constraint ( not ( precondition 2 0 0 true true ) ) )
; ( constraint ( precondition 3 0 0 false false ) )
; ( constraint ( precondition 2 0 -8 true false ) )
; ( constraint ( precondition 2 6 10 true false ) )
; ( constraint ( precondition 2 7 -9 true false ) )
; ( constraint ( precondition 1 0 0 false false ) )
; ( constraint ( precondition 1 -3 8 false true ) )
; ( constraint ( precondition 0 0 0 false false ) )
; ( constraint ( not ( precondition 1 0 0 true true ) ) )
; ( constraint ( precondition 1 7 2 false true ) )
; ( constraint ( precondition 2 0 1 true false ) )
; ( constraint ( precondition 2 -9 2 false true ) )
; ( constraint ( precondition 2 0 8 false true ) )
; ( constraint ( not ( precondition 4 0 0 false false ) ) )
; ( constraint ( precondition 1 10 10 false false ) )
; ( constraint ( not ( precondition 4 0 0 true true ) ) )
; ( constraint ( precondition 2 0 0 false false ) )
; ( constraint ( precondition 6 1 -1 true true ) )
; ( constraint ( precondition 2 1 0 true true ) )
(check-synth)