(set-logic LIA)

(synth-inv inv_fun ((x Int)(y Bool)))

(declare-primed-var x Int)
(declare-primed-var y Bool)


(define-fun pre_fun ((x Int)(y Bool)) Bool
    (or 
        ( and ( > x 99 ) ( = y true))
        ( and ( > x -10 ) ( = y true))
        ( and ( > x 5 ) ( = y false))
        ( and ( > x 22 ) ( = y true))
    )
)



(define-fun trans_fun ((x Int)(y Bool) (x! Int)(y! Bool)) Bool
    (and  (= x x!) 
          ( = y y!)        
    )
)

(define-fun post_fun ((x Int)(y Bool)) Bool
    (and 
        (not ( and ( = x -3) ( = y false) ) )
    )
)

(inv-constraint inv_fun pre_fun trans_fun post_fun)

(check-synth)

