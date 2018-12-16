open Base
open LoopInvGen


let precondition_job = Job.create
    ~f:(fun [@warning "-8"] [ Int x ; Bool y ] -> Bool ( 
            match x, y  with 
                     0 , true  -> false
                | (10), false  -> false
                |     9, true  -> true
                | _ ->   false
            ))
                                   
    ~args:([ ("x", Type.INT) ; ("y",Type.BOOL)])
    
    
    ~post:(fun inp res ->
            match inp, res with
            | _ ,  Ok (Bool ret_val) -> ret_val 
            | _ -> false)
            
    ~features:[]

        [ [Int 0    ; Bool true ]
        ; [Int (10); Bool false]
        ; [Int 9    ; Bool true ] 
        ]
  
let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job))



(* 
let disablesynth_config : PIE.config = 
{   for_BFL = BFL.default_config ;  
    synth_logic = Logic.of_string "LIA" ;  
    disable_synth = true ;  
    max_conflict_group_size = PIE.base_max_conflict_group_size ; 
}

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond  ~conf:(disablesynth_config) precondition_job))

 *)




(* Ocaml Refresher: https://www2.lib.uchicago.edu/keith/ocaml-class/class-01.html *)
(* Repo: https://github.com/SaswatPadhi/LoopInvGen *)



(*modified working template*)
(* let precondition_job = Job.create
    ~f:(fun [@warning "-8"] [ Value.Int x;  Value.Int y] -> Value.Bool (
                        if x = 0 &&  y = 1 then true
                        else if x = 10 && y = 0 then false
                        else if x = 0  && y = 10 then true
                        else if x = 1 && y =1 then false
                        else if x = 223 && y = 910 then true
                        else false ))
                        
    ~args:([ ("x", Type.INT) ; ("y",Type.INT)])
    
    
    ~post:(fun inp res ->
            match inp, res with
            | _ ,  Ok (Value.Bool ret_val) -> ret_val 
            | _  -> false)
            
    ~features:[]

    (List.map ~f:(List.map ~f:(fun i -> Value.Int i))
                [ [0;  1]
                ; [10; 0]
                ; [0; 10]
                ; [1;  1]
                ; [223; 910]])

let () = Stdio.print_endline(PIE.cnf_opt_to_desc (PIE.learnPreCond precondition_job)) *)






(*original template*)
(* let abs_job = Job.create
  ~f:(fun [@warning "-8"] [ Value.Int x ] -> Value.Int (if x > 0 then x else -x))
  ~args:([ "x", Type.INT ])
  ~post:(fun inp res ->
           match inp , res with
           | [ Value.Int x ], Ok (Value.Int y) -> x = y
           | _ -> false)
  ~features:[
    ((fun [@warning "-8"] [Value.Int x] -> x > 0), "(> x 0)")
  ]
(List.map [(-1) ; 3 ; 0 ; (-2) ; 6] ~f:(fun i -> [Value.Int i]))                

let () =
  Stdio.print_endline (
      "The precondition is: "
    ^ PIE.cnf_opt_to_desc (PIE.learnPreCond abs_job)
  ) *)



