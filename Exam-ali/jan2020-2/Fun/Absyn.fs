(* Fun/Absyn.fs * Abstract syntax for micro-ML, a functional language *)

module Absyn

type expr = 
  | CstI of int
  | CstB of bool
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
  | If of expr * expr * expr
  | Letfun of string * string * expr * expr    (* (f, x, fBody, letBody) *)
  | Call of expr * expr
  | InCheck of expr * expr * expr   // Opgave 2.1

// open Absyn;;
// InCheck(Var "x", Prim("+",CstI 2, CstI 3), CstI 40);;
// val it: expr = InCheck (Var "x", Prim ("+", CstI 2, CstI 3), CstI 40)
