(set-logic LIA)
		( synth-fun Precondition ( (Old_x Int) (Old_s1Count Int) (Old_s1Peek Int) ) Int (
			( Start Int (StartInt) )
				( StartInt Int (
					0 1
					Old_x Old_s1Count Old_s1Peek
						(+ StartInt StartInt)
						(- StartInt StartInt)
				) )
		) )
		( constraint ( =  ( Precondition 0 1 0 ) 0 ) )
		( constraint ( =  ( Precondition 0 2 10 ) 0 ) )
		( constraint ( =  ( Precondition 0 1 2 ) 0 ) )
		( constraint ( =  ( Precondition 0 1 1 ) 0 ) )
		( constraint ( =  ( Precondition 1 1 0 ) 1 ) )
		( constraint ( =  ( Precondition 0 1 10 ) 0 ) )
		( constraint ( =  ( Precondition 2 1 -5 ) 2 ) )
(check-synth)