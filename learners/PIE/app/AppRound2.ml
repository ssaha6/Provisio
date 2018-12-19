     
open Base
open LoopInvGen
            
let precondition_job = Job.create

~f:(fun [@warning "-8"] [Int variableInt000 ; Int variableInt001 ; Int variableInt002 ; Int variableInt003 ; Bool variableBool000 ; Bool variableBool001 ; Bool variableBool002 ; Bool variableBool003 ; Bool variableBool004 ; Bool variableBool005] -> Bool (
match variableInt000, variableInt001, variableInt002, variableInt003, variableBool000, variableBool001, variableBool002, variableBool003, variableBool004, variableBool005  with
(2), (3), (5), (3), (false), (false), (false), (true), (false), (true) -> false 
| (2), (-2), (1), (7), (true), (false), (false), (false), (false), (false) -> true 
| (2), (0), (0), (7), (true), (true), (false), (true), (true), (false) -> false 
| (1), (0), (10), (10), (true), (false), (false), (true), (false), (false) -> true 
| (1), (5), (4), (1), (false), (false), (false), (false), (false), (false) -> false 
| (2), (7), (9), (2), (false), (false), (false), (false), (false), (false) -> false 
| (5), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (2), (-2), (3), (7), (true), (false), (false), (false), (false), (false) -> true 
| (2), (-8), (6), (4), (true), (false), (false), (true), (false), (false) -> true 
| (1), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (2), (0), (0), (0), (false), (false), (false), (true), (true), (true) -> false 
| (2), (0), (2), (2), (true), (false), (false), (true), (false), (false) -> true 
| (0), (0), (0), (0), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (1), (4), (4), (4), (true), (true), (true), (false), (false), (false) -> false 
| (1), (9), (2), (2), (false), (false), (false), (true), (false), (false) -> false 
| (1), (3), (10), (10), (false), (false), (false), (false), (false), (false) -> false 
|  _ -> false 
))

~args:([ ("variableInt000", Type.INT) ; ("variableInt001", Type.INT) ; ("variableInt002", Type.INT) ; ("variableInt003", Type.INT) ; ("variableBool000", Type.BOOL) ; ("variableBool001", Type.BOOL) ; ("variableBool002", Type.BOOL) ; ("variableBool003", Type.BOOL) ; ("variableBool004", Type.BOOL) ; ("variableBool005", Type.BOOL) ])

        ~features:[]

~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)


[ 
[ Int (2) ; Int (3) ; Int (5) ; Int (3) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (true) ]
 ; [ Int (2) ; Int (-2) ; Int (1) ; Int (7) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (7) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (10) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (5) ; Int (4) ; Int (1) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (7) ; Int (9) ; Int (2) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (5) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (-2) ; Int (3) ; Int (7) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (-8) ; Int (6) ; Int (4) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (0) ; Int (2) ; Int (2) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (0) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (4) ; Int (4) ; Int (4) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (9) ; Int (2) ; Int (2) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (3) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
]

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
