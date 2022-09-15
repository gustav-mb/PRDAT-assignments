module ex2_4Handout

open Expr
open Absyn
open Parse

//Assignment 2
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
  List.fold (fun acc x -> acc @ sinstrToInt x) [] instrs;;

(* Output the integers in list inss to the text file called fname: *)

let intsToFile (inss : int list) (fname : string) = 
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text);;

let e1 = Let("z", CstI 17, Prim("+",Var "z", Var "z"));;

let e1Compiled = scomp e1 [];; //val it : sinstr list = [SCstI 17; SVar 0; SVar 1; SAdd; SSwap; SPop]

let test1 = assemble (scomp e1 []);; //val it : int list = [0; 17; 1; 0; 1; 1; 2; 6; 5]
intsToFile test1 "test.txt";;

//Assignment 3
// Exercise 3.6

let compString s : list<sinstr> = scomp (fromString s) [];;

let testCompString = compString  "let z = 17 in z + z end";; 

//Assignment 3
// Exercise 3.7

let tif1 = seval (compString "let y = 10 in y ? 1 : 2 end") [];;
let tiffalse = seval (compString "0 ? 1 : 2") [];;
let tiftrue = seval (compString "1 ? 1 : 2") [];;
let tif2 = seval (compString "10 ? 1 : 2") [];;

