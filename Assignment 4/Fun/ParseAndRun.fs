(* File Fun/ParseAndRun.fs *)

module ParseAndRun

open Parse
open Absyn

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

// Exercise 4.2
let sum1000To1 = "let sum n = if n then (n + sum(n - 1)) else n in sum 1000 end";;  // 4.2 a)
let threePower8 = "let tPe n = if n then 3 * tPe(n - 1) else 1 in tPe 8 end";;      // 4.2 b)
let sum3Power11 = "let sum n = if n then (n + sum(n - 1)) else n in (let sPx n = if n then 3 + sPx(n - 1) else 1 in sum 11 end) end";;     // 4.2 c) 265720
let sum10Power8 = "";;  // 4.2 d)

run (fromString "let tPe n = if n then tPe(n - 1) * tPe(n - 1) else 1 in tPe 11 end");;

let testSum1000To1 = run (fromString sum1000To1);;
let testThreePower8 = run (fromString threePower8);;