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
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' > e2' then e1' else e2'
    | Prim("min", e1, e2) ->
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' > e2' then e2' else e1'
    | Prim("==", e1, e2) ->
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' = e2' then 1 else 0
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
        let i1 = eval2 e1 env
        let i2 = eval2 e2 env
        match ope with
        | "+"   -> i1 + i2
        | "-"   -> i1 - i2
        | "*"   -> i1 * i2
        | "max" -> if i1 > i2 then i1 else i2
        | "min" -> if i1 > i2 then i2 else i1
        | "=="  -> if i1 = i2 then 1 else 0
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
let test1 = Sub(Var "v", Add(Var "w", Var"z"));;               // v ??? (w + z)
let test2 = Mul(CstI 2, test1);;                               // 2 ??? (v ??? (w + z))
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
let rec simplify a : aexpr = 
    match a with
    | Add(a1, a2) ->
        let a1' = simplify a1
        let a2' = simplify a2
        match a1', a2' with
        | CstI 0, CstI 0 -> CstI 0
        | CstI 0, a2     -> simplify a2
        | a1, CstI 0     -> simplify a1
        | a1, a2         -> Add(a1, a2)
    | Sub(a1, a2) ->
        let a1' = simplify a1
        let a2' = simplify a2
        match a1', a2' with
        | a1, CstI 0          -> simplify a1
        | a1, a2 when a1 = a2 -> CstI 0
        | CstI 0, CstI i      -> CstI -i
        | a1, a2              -> Sub(a1, a2)
    | Mul(a1, a2) ->
        let a1' = simplify a1
        let a2' = simplify a2
        match a1', a2' with
        | CstI 0, _ -> CstI 0
        | _, CstI 0 -> CstI 0
        | CstI 1, a2 -> simplify a2
        | a1, CstI 1 -> simplify a1
        | a1, a2     -> Mul(a1, a2)
    | _                        -> a;;

// Add
let addSimplifyTest1 = simplify (Add(CstI 17, CstI 0)) |> fmt       // 17
let addSimplifyTest2 = simplify (Add(CstI 0, CstI 10)) |> fmt       // 10
let addSimplifyTest3 = simplify (Add(CstI 0, CstI 0)) |> fmt        // 0
let addSimplifyTest4 = simplify (Add(CstI 2, CstI 10)) |> fmt       // (2 + 10)
let addSimplifyTest5 = simplify (Add(CstI 0, Add(CstI 2, CstI 10))) |> fmt // (2 + 10)
let addSimplifyTest6 = simplify (Add(Var "x", Add(Var "y", CstI 0))) |> fmt // (x + y)
let addSimplifyTest7 = simplify (Add(Var "x", Add(Var "y", Add(CstI 10, CstI 0)))) |> fmt // (x + (y + 10))

// Sub
let subSimplifyTest1 = simplify (Sub(CstI 0, CstI 0)) |> fmt // 0
let subSimplifyTest2 = simplify (Sub(Var "x", CstI 0)) |> fmt // x
let subSimplifyTest3 = simplify (Sub(Add(CstI 1, CstI 1), Add(CstI 1, CstI 1))) |> fmt // 0
let subSimplifyTest4 = simplify (Sub(Add(CstI 0, CstI 0), CstI -1)) |> fmt // 1
let subSimplifyTest5 = simplify (Sub(Var "x", Sub(CstI 10, Add(Var "y", CstI 0)))) |> fmt // x - (10 -  y)
let subSimplifyTest6 = simplify (Sub(Add(Mul(CstI 0, CstI 1), CstI 10), Add(CstI 10, CstI 10))) |> fmt // 10 - (10 + 10)

// Mul
let mulSimplifyTest1 = simplify (Mul(CstI 0, Add(CstI 10, CstI 9))) |> fmt // 0
let mulSimplifyTest2 = simplify (Mul(Add(CstI 10, CstI 9), CstI 0)) |> fmt // 0
let mulSimplifyTest3 = simplify (Mul(Sub(CstI 1, CstI 0), Add(CstI 0, CstI 33))) |> fmt // 33
let mulSimplifyTest4 = simplify (Mul(Add(CstI 0, CstI 33), (Sub(CstI 1, CstI 0)))) |> fmt // 33
let mulSimplifyTest5 = simplify (Mul(CstI -2, Sub(CstI 10, CstI 0))) |> fmt // (-2 * 10)
let mulSimplifyTest6 = simplify (Mul(CstI -2, Sub(CstI 10, CstI 10))) |> fmt // 0

// Var
let varSimplifyTest1 = simplify (Add(Var "x", Var "y")) |> fmt // (x + y)
let varSimplifyTest2 = simplify (Var "x") |> fmt // x

// Exercise 1.2 (v)
let rec diff a x : aexpr =
    match a with
    | CstI _ -> CstI 0
    | Var y when y <> x -> CstI 0
    | Var _ -> CstI 1
    | Add(a1, a2) -> Add(diff a1 x, diff a2 x)
    | Sub(a1, a2) -> Sub(diff a1 x, diff a2 x)
    | Mul(a1, a2) -> Add(Mul(diff a1 x, a2), Mul(a1, diff a2 x))

let diffTest1 = diff (Var "x") "x"
let diffTest2 = diff (Var "x") "y"
let diffTest3 = diff (Add(Var "x", Add(Var "y", CstI 10))) "x"
let diffTest4 = diff (Add(Var "x", Sub(Var "y", CstI 10))) "x"
let diffTest5 = diff (Mul(Var "x", Add(Var "y", Var "x"))) "x"
let diffTest6 = diff (Add(CstI 4, CstI 5)) "ligegyldigt"
let diffTest7 = diff (Mul(CstI 5, CstI 4)) "Stadig ligegyldigt"