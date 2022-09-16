(* File Fun/ParseAndRun.fs *)

module ParseAndRun

open Parse
open Absyn

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;
