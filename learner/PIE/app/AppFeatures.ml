     
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

~features:[ 

     ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ; Value.Bool variableBool000 ; _ ; _ ; _ ; _ ; _ ] -> (  variableBool000 ) ) , " variableBool000 " ) 


 ; ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ; _ ; _ ; _ ; Value.Bool variableBool003 ;  _ ; _ ] -> (  variableBool003 ) ) , " variableBool003 " )  

 ;  ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ;  _ ; _ ; _ ; _ ; Value.Bool variableBool004 ; _ ] -> (  variableBool004 ) ) , " variableBool004 " ) 


;  ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ; _ ; _ ; _ ; _ ; _ ; Value.Bool variableBool005  ] -> (  variableBool005 ) ) , " variableBool005 " ) 

  
; ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ; _ ; Value.Bool variableBool001 ; _ ; _ ; _ ; _ ] -> (  variableBool001 ) ) , " variableBool001 " ) 

;  ( ( fun [@warning "-8"] [ _ ; _ ; _ ; _ ;  _ ; _ ; Value.Bool variableBool002 ; _ ; _ ; _ ] -> (  variableBool002 ) ) , " variableBool002 " )  



 ; ( ( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; _ ; _ ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt000 = variableInt001 ) ) , " ( = variableInt000 variableInt001 ) " ) 
 
; ( ( fun [@warning "-8"] [ Value.Int variableInt000 ; _ ; Value.Int variableInt002 ; _ ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt000 = variableInt002 ) ) , " ( = variableInt000 variableInt002 ) " ) 
 
; ( ( fun [@warning "-8"] [ Value.Int variableInt000 ; _ ; _ ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt000 = variableInt003 ) ) , " ( = variableInt000 variableInt003 ) " ) 
 
; ( ( fun [@warning "-8"] [ _ ; Value.Int variableInt001 ; Value.Int variableInt002 ; _ ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt001 = variableInt002 ) ) , " ( = variableInt001 variableInt002 ) " ) 
 
; ( ( fun [@warning "-8"] [ _ ; Value.Int variableInt001 ; _ ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt001 = variableInt003 ) ) , " ( = variableInt001 variableInt003 ) " ) 
 
; ( ( fun [@warning "-8"] [ _ ; _ ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] -> ( variableInt002 = variableInt003 ) ) , " ( = variableInt002 variableInt003 ) " ) 
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
  ; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( (-1) * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * -1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 0 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 0 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( (-1) * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * -1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 0 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 0 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( (-1) * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * -1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 0 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 0 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( (-1) * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * -1 variableInt003 ) ) 0 )")


 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 0 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 0 variableInt003 ) ) 0 )")
 
; (( fun [@warning "-8"] [ Value.Int variableInt000 ; Value.Int variableInt001 ; Value.Int variableInt002 ; Value.Int variableInt003 ; _ ; _ ; _ ; _ ; _ ; _ ] ->(( 1 * variableInt000 ) + ( 1 * variableInt001 ) + ( 1 * variableInt002 ) + ( 1 * variableInt003 ) <= 0)),"( <= ( + ( * 1 variableInt000 ) ( * 1 variableInt001 ) ( * 1 variableInt002 ) ( * 1 variableInt003 ) ) 0 )")
 ] 

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





 let disablesynth_config : PIE.config = 
 {   for_BFL = BFL.default_config ;  
     synth_logic = Logic.of_string "LIA" ;  
     disable_synth = true ;  
     max_conflict_group_size = PIE.base_max_conflict_group_size ; 
 }

 let () = Stdio.print_endline(
  Log.enable ~msg:"RECORD" (Some "FeatureLogNoSynth.txt");
 PIE.cnf_opt_to_desc (PIE.learnPreCond ~conf:(disablesynth_config) precondition_job))
 
 
 (* let () = Stdio.print_endline(
  Log.enable ~msg:"RECORD" (Some "FeatureLogSynth.txt");  
 PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))
  *)