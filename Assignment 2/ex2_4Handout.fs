open Expr
open Absyn 

(* Ex 2.4 - assemble to integers *)
(* SCST = 0, SVAR = 1, SADD = 2, SSUB = 3, SMUL = 4, SPOP = 5, SSWAP = 6; *)

let sinstrToInt = function
  | SCstI i -> [0;i]
  | SVar i  -> [1;i]
  | SAdd    -> [2]
  | SSub    -> [3]
  | SMul    -> [4]
  | SPop    -> [5]
  | SSwap   -> [6];;

let assemble instrs = 
  List.fold (fun acc x -> sinstrToInt x @ acc ) [] instrs;;

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

let e1 = Let("z", CstI 17, Prim("+",Var "z", Var "z"));;

scomp e1 [];; //val it : sinstr list = [SCstI 17; SVar 0; SVar 1; SAdd; SSwap; SPop]

assemble (scomp e1 []);; //val it : int list = [0; 17; 1; 0; 1; 1; 2; 6; 5]