(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

open Microsoft.FSharp.Core

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

(* --- EXERCISE 1.1 --- *)
type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr;;  // Exercise 1.1 (iv)

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    // Exercise 1.1 (i)
    | Prim("max", e1, e2) ->
        let first = eval e1 env
        let second = eval e2 env
        if first > second then first else second
    | Prim("min", e1, e2) ->
        let first = eval e1 env
        let second = eval e2 env
        if first > second then second else first
    | Prim("==", e1, e2) ->
        let first = eval e1 env
        let second = eval e2 env
        if first = second then 1 else 0
    | Prim _            -> failwith "unknown primitive"
    // Excercise 1.1 (v)
    | If(e1, e2, e3) -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env);;

// Exercise 1.1 (ii)
let testMax = eval (Prim("max", Prim("*", CstI 2, CstI 9), CstI 19)) env;;
let testMin = eval (Prim("min", Prim("*", CstI 2, CstI 9), CstI 10)) env;;
let testEqualTrue = eval (Prim("==", Prim("*", CstI 2, CstI 5), CstI 10)) env;;
let testEqualFalse = eval (Prim("==", Prim("*", CstI 2, CstI 9), CstI 10)) env;;

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

// Exercise 1.1 (iii)
let rec eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(ope, e1, e2) ->
        let il1 = eval2 e1 env
        let il2 = eval2 e2 env
        match ope with
        | "+"   -> il1 + il2
        | "-"   -> il1 - il2
        | "*"   -> il1 * il2
        | "max" -> if il1 > il2 then il1 else il2
        | "min" -> if il1 > il2 then il2 else il1
        | "=="  -> if il1 = il2 then 1 else 0
        | _     -> failwith "unknown primitive"
    // Excercise 1.1 (v)
    | If(e1, e2, e3) ->
        if (eval2 e1 env) <> 0 then (eval2 e2 env) else (eval2 e3 env);;

let testIf = eval2 (If(Var "a", CstI 11, CstI 22)) env;;

(* --- EXERCISE 1.2 --- *)
// Exercise 1.2 (i)
type aexpr = 
  | CstI of int
  | Var of string
  | Add of aexpr * aexpr
  | Mul of aexpr * aexpr
  | Sub of aexpr * aexpr;;

// Exercise 1.2 (ii)
let test1 = Sub(Var "v", Add(Var "w", Var"z"));;               // v − (w + z)
let test2 = Mul(CstI 2, test1);;                               // 2 ∗ (v − (w + z))
let test3 = Add(Var "x", Add(Var "y", Add(Var "z", Var"v")));; // x + y + z + v

// Exercise 1.2 (iii)
let rec fmt a : string =
    match a with
    | CstI i      -> i.ToString()
    | Var x       -> x
    | Add(a1, a2) -> $"({fmt a1} + {fmt a2})"
    | Sub(a1, a2) -> $"({fmt a1} - {fmt a2})"
    | Mul(a1, a2) -> $"({fmt a1} * {fmt a2})";;

let converted = fmt test3;;

// Exercise 1.2 (iv)
(*
    EXPRESSION SIMPLIFICATIONS
    0 + e −→ e
    e + 0 −→ e
    e − 0 −→ e
    e − e −→ 0
    1 ∗ e −→ e
    e ∗ 1 −→ e
    0 ∗ e −→ 0
    e ∗ 0 −→ 0
*)

// TODO FIX
let rec simplify a : aexpr = 
    match a with
    | Add(CstI 0, a2)          -> simplify a2
    | Add(a1, CstI 0)          -> simplify a1
    // | Add(a1, a2)              -> Add(simplify a1, simplify a2)
    | Sub(a1, CstI 0)          -> simplify a1
    | Sub(a1, a2) when a1 = a2 -> CstI 0
    // | Sub(a1, a2)              -> Sub(simplify a1, simplify a2)
    | Mul(CstI 1, a2)          -> simplify a2
    | Mul(a1, CstI 1)          -> simplify a1
    | Mul(CstI 0, _)           -> CstI 0
    | Mul(_, CstI 0)           -> CstI 0
    // | Mul(a1, a2)              -> Mul(simplify a1, simplify a2)
    | _                        -> a;;

let testSubSimplify1 = fmt (simplify (Add(CstI 0, CstI 2)));;
let testSubSimplify2 = fmt (simplify (Sub(CstI 1, Add(CstI 0, CstI 2))));; //DOESNT WORK
let testSubSimplify3 = simplify (Sub(Add(Mul(CstI 0, CstI 1), CstI 10), Add(CstI 10, CstI 10))) |> fmt

//   ((0 * 1) + 10) - (10 + 10)

// Exercise 1.2 (iv)

let diff a str : aexpr = failwith "Not implemented"
