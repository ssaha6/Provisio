     
open Base
open LoopInvGen
            
let precondition_job = Job.create

~f:(fun [@warning "-8"] [Int variableInt000 ; Int variableInt001 ; Int variableInt002 ; Bool variableBool000 ; Bool variableBool001] -> Bool (
match variableInt000, variableInt001, variableInt002, variableBool000, variableBool001  with
(1), (0), (10), (false), (false) -> true 
| (2), (6), (10), (true), (false) -> true 
| (5), (1), (-6), (true), (false) -> true 
| (0), (0), (3), (false), (false) -> true 
| (2), (0), (0), (true), (true) -> false 
| (3), (0), (0), (false), (false) -> true 
| (2), (0), (1), (true), (false) -> true 
| (1), (1), (-1), (true), (false) -> true 
| (1), (7), (2), (false), (true) -> true 
| (5), (-8), (0), (true), (true) -> true 
| (5), (6), (-6), (false), (false) -> true 
| (1), (0), (0), (true), (true) -> false 
| (2), (0), (-1), (true), (false) -> true 
| (4), (0), (0), (true), (true) -> false 
| (2), (0), (0), (false), (false) -> true 
| (2), (1), (0), (true), (true) -> true 
| (1), (10), (10), (false), (false) -> true 
| (2), (7), (-9), (true), (false) -> true 
| (2), (7), (10), (false), (false) -> true 
| (0), (0), (0), (false), (false) -> true 
| (2), (-2), (10), (false), (false) -> true 
|  -> false 
| (1), (0), (0), (false), (false) -> true 
|  _ -> false 
))

~args:([ ("variableInt000", Type.INT) ; ("variableInt001", Type.INT) ; ("variableInt002", Type.INT) ; ("variableBool000", Type.BOOL) ; ("variableBool001", Type.BOOL) ])

~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)

~features:[]

[ 
[ Int (1) ; Int (0) ; Int (10) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (6) ; Int (10) ; Bool (true) ; Bool (false) ]
 ; [ Int (5) ; Int (1) ; Int (-6) ; Bool (true) ; Bool (false) ]
 ; [ Int (0) ; Int (0) ; Int (3) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ]
 ; [ Int (3) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (1) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (1) ; Int (-1) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (7) ; Int (2) ; Bool (false) ; Bool (true) ]
 ; [ Int (5) ; Int (-8) ; Int (0) ; Bool (true) ; Bool (true) ]
 ; [ Int (5) ; Int (6) ; Int (-6) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (0) ; Int (-1) ; Bool (true) ; Bool (false) ]
 ; [ Int (4) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (1) ; Int (0) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (7) ; Int (-9) ; Bool (true) ; Bool (false) ]
 ; [ Int (2) ; Int (7) ; Int (10) ; Bool (false) ; Bool (false) ]
 ; [ Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (-2) ; Int (10) ; Bool (false) ; Bool (false) ]
 ; [  ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ]
]

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
