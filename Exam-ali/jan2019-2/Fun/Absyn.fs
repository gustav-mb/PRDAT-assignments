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
  | Field of expr * string // Opgave 2.1
  | Record of (string * expr) list // Opgave 2.1

  // Opgave 2.1
  // let x = { } in x end (* ex1 *)
  // Let ("x",Record [],Var "x");
  
  // let x = {field1 = 32} in x.field1 end (* ex2 *)
  // Let ("x",Record [("field1", CstI 32)],Field (Var "x","field1"))

  // let x = {field1 = 32; field2 = 33} in x end (* ex3 *)
  // Let ("x",Record [("field1", CstI 32);("field2", CstI 33)],Var "x");

  // let x = {field1 = 32; field2 = 33} in x.field1 end (* ex4 *)
  // Let ("x",Record [("field1", CstI 32);("field2", CstI 33)],Field (Var "x","field1"));

  // let x = {field1 = 32; field2 = 33} in x.field1+x.field2 end (* ex5 *)
  // Let ("x",Record [("field1", CstI 32);("field2", CstI 33)],Prim ("+",Field (Var "x","field1"),Field (Var "x","field2")));
