(* File Fun/ParseAndRun.fs *)

module ParseAndRun

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

// Exercise 4.2
let sum1000To1 = "let sum n = if n then (n + sum(n - 1)) else n in sum 1000 end";;  // 4.2 a)
let threePower8 = "let tPe n = if n then 3 * tPe(n - 1) else 1 in tPe 8 end";;      // 4.2 b)
let sum3Power11 = "let sum n = if n then ((let tPe x = if x then 3 * tPe(x - 1) else 1 in tPe n end) + sum(n - 1)) else n + 1 in sum 11 end";;     // 4.2 c)
let sum10Power8 = "let sum n = if n then ((let tPe x = if x then n * tPe(x - 1) else 1 in tPe 8 end) + sum(n - 1)) else n in sum 10 end";;         // 4.2 d)

let testSum1000To1 = run (fromString sum1000To1);;
let testThreePower8 = run (fromString threePower8);;
let testSum3Power11 = run (fromString sum3Power11);; // 265.720
let testSum10Power8 = run (fromString sum10Power8);; // 167731333


//Exercise 4.4 tests
let test44a = "let pow x n = if n=0 then 1 else x * pow x (n-1) in pow 3 8 end";;

let test44b = "let max2 a b = if a<b then b else a 
               in let max3 a b c = max2 a (max2 b c) 
               in max3 25 6 62 end 
               end";;

let test44 = fromString test44a;;
let test44aa = run (fromString test44a);; //6.561
let test44bb = run (fromString test44b);; // 62

            