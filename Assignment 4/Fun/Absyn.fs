(* Fun/Absyn.fs * Abstract syntax for micro-ML, a functional language *)

module Absyn

// Exercise 4.3 Function with one or more arguments
type expr = 
  | CstI of int
  | CstB of bool
  | Var of string
  | Let of string * expr * expr
  | Prim of string * expr * expr
  | If of expr * expr * expr
  | Letfun of string * list<string> * expr * expr    (* (f, (x, y, ...), fBody, letBody) *)
  | Call of expr * list<expr> // Call(Var "f", [CstI 1, CstI 2])