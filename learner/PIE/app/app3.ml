     
open Base
open LoopInvGen
            
let precondition_job = Job.create

~f:(fun [@warning "-8"] [Int variableInt000 ; Int variableInt001 ; Int variableInt002 ; Int variableInt003 ; Int variableInt004 ; Int variableInt005 ; Int variableInt006 ; Int variableInt007 ; Int variableInt008] -> Bool (
match variableInt000, variableInt001, variableInt002, variableInt003, variableInt004, variableInt005, variableInt006, variableInt007, variableInt008  with
(0), (0), (0), (0), (0), (1), (-1), (-1), (-12) -> false 
| (0), (0), (1), (0), (0), (1), (-1), (-1), (-20) -> true 
| (1), (1), (0), (1), (1), (1), (0), (0), (0) -> false 
| (10), (10), (10), (10), (0), (2), (-1), (-1), (-15) -> true 
| (10), (0), (7), (0), (1), (3), (0), (0), (10) -> true 
| (10), (0), (8), (8), (2), (3), (0), (-1), (1) -> false 
| (-8), (0), (9), (0), (1), (3), (0), (0), (0) -> false 
| (6), (0), (2), (1), (2), (2), (0), (-1), (5) -> false 
| (2), (0), (2), (0), (1), (1), (0), (0), (0) -> true 
| (9), (-6), (0), (-6), (1), (1), (0), (0), (2) -> false 
| (4), (0), (10), (0), (1), (3), (0), (0), (9) -> false 
| (2), (0), (0), (0), (1), (1), (0), (0), (3) -> true 
| (1), (0), (10), (1), (1), (3), (0), (-1), (0) -> false 
| (7), (0), (7), (0), (1), (3), (0), (0), (0) -> true 
| (0), (0), (1), (0), (1), (3), (0), (0), (0) -> false 
| (10), (0), (0), (0), (1), (1), (0), (0), (2) -> false 
| (5), (0), (10), (0), (1), (3), (0), (0), (10) -> true 
|  _ -> false 
))

~args:([ ("variableInt000", Type.INT) ; ("variableInt001", Type.INT) ; ("variableInt002", Type.INT) ; ("variableInt003", Type.INT) ; ("variableInt004", Type.INT) ; ("variableInt005", Type.INT) ; ("variableInt006", Type.INT) ; ("variableInt007", Type.INT) ; ("variableInt008", Type.INT) ])

~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)

~features:[]

[ 
[ Int (0) ; Int (0) ; Int (0) ; Int (0) ; Int (0) ; Int (1) ; Int (-1) ; Int (-1) ; Int (-12) ]
 ; [ Int (0) ; Int (0) ; Int (1) ; Int (0) ; Int (0) ; Int (1) ; Int (-1) ; Int (-1) ; Int (-20) ]
 ; [ Int (1) ; Int (1) ; Int (0) ; Int (1) ; Int (1) ; Int (1) ; Int (0) ; Int (0) ; Int (0) ]
 ; [ Int (10) ; Int (10) ; Int (10) ; Int (10) ; Int (0) ; Int (2) ; Int (-1) ; Int (-1) ; Int (-15) ]
 ; [ Int (10) ; Int (0) ; Int (7) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (10) ]
 ; [ Int (10) ; Int (0) ; Int (8) ; Int (8) ; Int (2) ; Int (3) ; Int (0) ; Int (-1) ; Int (1) ]
 ; [ Int (-8) ; Int (0) ; Int (9) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (0) ]
 ; [ Int (6) ; Int (0) ; Int (2) ; Int (1) ; Int (2) ; Int (2) ; Int (0) ; Int (-1) ; Int (5) ]
 ; [ Int (2) ; Int (0) ; Int (2) ; Int (0) ; Int (1) ; Int (1) ; Int (0) ; Int (0) ; Int (0) ]
 ; [ Int (9) ; Int (-6) ; Int (0) ; Int (-6) ; Int (1) ; Int (1) ; Int (0) ; Int (0) ; Int (2) ]
 ; [ Int (4) ; Int (0) ; Int (10) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (9) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Int (1) ; Int (1) ; Int (0) ; Int (0) ; Int (3) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (1) ; Int (1) ; Int (3) ; Int (0) ; Int (-1) ; Int (0) ]
 ; [ Int (7) ; Int (0) ; Int (7) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (0) ]
 ; [ Int (0) ; Int (0) ; Int (1) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (0) ]
 ; [ Int (10) ; Int (0) ; Int (0) ; Int (0) ; Int (1) ; Int (1) ; Int (0) ; Int (0) ; Int (2) ]
 ; [ Int (5) ; Int (0) ; Int (10) ; Int (0) ; Int (1) ; Int (3) ; Int (0) ; Int (0) ; Int (10) ]
]

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))


