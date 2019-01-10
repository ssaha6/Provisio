     
open Base
open LoopInvGen
            
let precondition_job = Job.create

~f:(fun [@warning "-8"] [Int variableInt000 ; Int variableInt001 ; Int variableInt002 ; Int variableInt003 ; Bool variableBool000 ; Bool variableBool001 ; Bool variableBool002 ; Bool variableBool003 ; Bool variableBool004 ; Bool variableBool005] -> Bool (
match variableInt000, variableInt001, variableInt002, variableInt003, variableBool000, variableBool001, variableBool002, variableBool003, variableBool004, variableBool005  with
(1), (-2), (10), (10), (false), (false), (false), (false), (false), (false) -> false 
| (1), (5), (6), (0), (false), (false), (false), (true), (false), (false) -> false 
| (1), (0), (8), (0), (true), (true), (false), (false), (false), (true) -> true 
| (1), (5), (3), (0), (false), (false), (false), (false), (true), (false) -> false 
| (1), (0), (4), (0), (false), (false), (true), (true), (true), (false) -> false 
| (1), (1), (5), (0), (false), (true), (false), (false), (true), (false) -> true 
| (0), (8), (9), (10), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (0), (4), (true), (true), (true), (false), (false), (false) -> true 
| (0), (0), (0), (0), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (0), (2), (2), (-1), (false), (false), (false), (false), (false), (false) -> false 
| (1), (0), (4), (2), (false), (true), (false), (false), (false), (false) -> true 
| (1), (0), (10), (2), (false), (true), (false), (true), (false), (false) -> true 
| (1), (9), (10), (10), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (1), (0), (true), (true), (false), (false), (false), (true) -> false 
| (0), (0), (0), (9), (false), (false), (false), (false), (false), (false) -> false 
| (1), (8), (8), (8), (true), (true), (true), (true), (true), (true) -> true 
| (2), (1), (1), (1), (false), (false), (false), (true), (true), (true) -> false 
| (0), (1), (3), (6), (false), (false), (false), (false), (false), (false) -> false 
| (3), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> true 
| (2), (-2), (-2), (-2), (true), (true), (true), (true), (true), (true) -> true 
| (2), (1), (0), (1), (true), (true), (true), (true), (true), (true) -> false 
| (1), (4), (2), (-8), (false), (false), (false), (false), (false), (true) -> false 
| (1), (1), (-7), (4), (true), (false), (false), (true), (false), (false) -> false 
| (2), (0), (0), (8), (true), (true), (true), (true), (false), (true) -> true 
| (1), (6), (10), (10), (false), (false), (false), (false), (false), (false) -> false 
| (1), (0), (10), (9), (true), (false), (false), (true), (false), (false) -> false 
| (2), (1), (0), (0), (true), (false), (false), (true), (false), (false) -> false 
| (3), (-6), (-6), (-6), (true), (true), (true), (false), (false), (false) -> false 
| (1), (4), (0), (6), (false), (false), (false), (false), (false), (false) -> false 
| (1), (0), (0), (0), (false), (false), (false), (false), (false), (false) -> false 
| (1), (1), (1), (1), (true), (true), (true), (true), (true), (true) -> true 
| (0), (8), (6), (2), (false), (false), (false), (false), (false), (false) -> false 
| (2), (4), (4), (-8), (false), (false), (false), (false), (false), (false) -> false 
| (1), (0), (10), (10), (true), (false), (false), (true), (false), (false) -> false 
| (2), (7), (1), (-8), (false), (false), (false), (false), (false), (false) -> false 
| (1), (3), (10), (0), (false), (false), (false), (false), (true), (false) -> false 
| (2), (1), (1), (1), (true), (true), (true), (true), (true), (true) -> false 
| (2), (3), (10), (5), (true), (true), (false), (false), (false), (false) -> true 
| (0), (1), (0), (4), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (4), (0), (true), (true), (false), (true), (true), (false) -> false 
| (1), (2), (10), (0), (false), (false), (false), (false), (true), (false) -> false 
| (1), (-10), (-10), (-10), (true), (true), (true), (false), (false), (false) -> false 
| (1), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> true 
| (1), (2), (10), (0), (true), (false), (false), (false), (true), (false) -> false 
| (2), (0), (0), (0), (false), (false), (false), (true), (true), (true) -> false 
| (1), (7), (10), (1), (true), (false), (false), (false), (false), (false) -> false 
| (4), (2), (2), (2), (false), (false), (false), (true), (true), (true) -> false 
| (1), (3), (3), (3), (true), (true), (true), (false), (false), (false) -> false 
|  _ -> false 
))

~args:([ ("variableInt000", Type.INT) ; ("variableInt001", Type.INT) ; ("variableInt002", Type.INT) ; ("variableInt003", Type.INT) ; ("variableBool000", Type.BOOL) ; ("variableBool001", Type.BOOL) ; ("variableBool002", Type.BOOL) ; ("variableBool003", Type.BOOL) ; ("variableBool004", Type.BOOL) ; ("variableBool005", Type.BOOL) ])

~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)

~features:[]

[ 
[ Int (1) ; Int (-2) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (5) ; Int (6) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (8) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ]
 ; [ Int (1) ; Int (5) ; Int (3) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (4) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (1) ; Int (5) ; Int (0) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ]
 ; [ Int (0) ; Int (8) ; Int (9) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (4) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (0) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (0) ; Int (2) ; Int (2) ; Int (-1) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (4) ; Int (2) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (2) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (9) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (1) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ]
 ; [ Int (0) ; Int (0) ; Int (0) ; Int (9) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (8) ; Int (8) ; Int (8) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (1) ; Int (1) ; Int (1) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (0) ; Int (1) ; Int (3) ; Int (6) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (3) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (-2) ; Int (-2) ; Int (-2) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (1) ; Int (0) ; Int (1) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (4) ; Int (2) ; Int (-8) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ]
 ; [ Int (1) ; Int (1) ; Int (-7) ; Int (4) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (8) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (true) ]
 ; [ Int (1) ; Int (6) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (9) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (1) ; Int (0) ; Int (0) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (3) ; Int (-6) ; Int (-6) ; Int (-6) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (4) ; Int (0) ; Int (6) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (1) ; Int (1) ; Int (1) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (0) ; Int (8) ; Int (6) ; Int (2) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (4) ; Int (4) ; Int (-8) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (10) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (7) ; Int (1) ; Int (-8) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (3) ; Int (10) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ]
 ; [ Int (2) ; Int (1) ; Int (1) ; Int (1) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (2) ; Int (3) ; Int (10) ; Int (5) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (0) ; Int (1) ; Int (0) ; Int (4) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (4) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (2) ; Int (10) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ]
 ; [ Int (1) ; Int (-10) ; Int (-10) ; Int (-10) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (2) ; Int (10) ; Int (0) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (7) ; Int (10) ; Int (1) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (4) ; Int (2) ; Int (2) ; Int (2) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (3) ; Int (3) ; Int (3) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
]

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
