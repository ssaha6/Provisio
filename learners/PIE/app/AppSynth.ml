     
open Base
open LoopInvGen
            
let precondition_job = Job.create

~f:(fun [@warning "-8"] [Int variableInt000 ; Int variableInt001 ; Int variableInt002 ; Int variableInt003 ; Bool variableBool000 ; Bool variableBool001 ; Bool variableBool002 ; Bool variableBool003 ; Bool variableBool004 ; Bool variableBool005] -> Bool (
match variableInt000, variableInt001, variableInt002, variableInt003, variableBool000, variableBool001, variableBool002, variableBool003, variableBool004, variableBool005  with
(1), (4), (4), (4), (true), (true), (true), (false), (false), (false) -> false 
| (0), (0), (0), (0), (false), (false), (false), (false), (false), (false) -> false 
| (2), (0), (0), (0), (false), (false), (false), (true), (true), (true) -> false 
| (5), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (1), (0), (0), (0), (true), (true), (true), (true), (true), (true) -> false 
| (1), (3), (10), (10), (false), (false), (false), (false), (false), (false) -> false 
| (1), (0), (10), (10), (true), (false), (false), (true), (false), (false) -> true 
| (2), (3), (4), (10), (false), (false), (false), (false), (false), (false) -> false 
|  _ -> false 
))

~args:([ ("variableInt000", Type.INT) ; ("variableInt001", Type.INT) ; ("variableInt002", Type.INT) ; ("variableInt003", Type.INT) ; ("variableBool000", Type.BOOL) ; ("variableBool001", Type.BOOL) ; ("variableBool002", Type.BOOL) ; ("variableBool003", Type.BOOL) ; ("variableBool004", Type.BOOL) ; ("variableBool005", Type.BOOL) ])

        ~features:[]

~post:(fun inp res ->
        match inp, res with
        | _ ,  Ok (Bool ret_val) -> ret_val
        | _ -> false)


[ 
[ Int (1) ; Int (4) ; Int (4) ; Int (4) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (0) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (0) ; Int (0) ; Int (0) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (5) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (0) ; Int (0) ; Int (0) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ; Bool (true) ]
 ; [ Int (1) ; Int (3) ; Int (10) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
 ; [ Int (1) ; Int (0) ; Int (10) ; Int (10) ; Bool (true) ; Bool (false) ; Bool (false) ; Bool (true) ; Bool (false) ; Bool (false) ]
 ; [ Int (2) ; Int (3) ; Int (4) ; Int (10) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ; Bool (false) ]
]

let () = Stdio.print_endline(
  Log.enable ~msg:"RECORD" (Some "synthLog.txt");
  PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job)
)
