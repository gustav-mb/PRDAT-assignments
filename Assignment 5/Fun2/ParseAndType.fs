(* File Fun/ParseAndType.fs *)

module ParseAndType

let fromString = Parse.fromString;;

let inferType = TypeInference.inferType;;

// Exercise 6.5 (i)
let a1 = inferType (fromString "let f x = 1 in f f end")
// val it: string = "int"

// let a2 = inferType (fromString "let f g = g g in f end")
// type error: circularity 
(*
  The function g calls itself, so the type inference
  system never stops infering the type.
*) 

let a3 = inferType (fromString "let f x = let g y = y in g false end in f 42 end")
// val it: string = "bool"

//let a4 = inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end")
// type error: bool and int 
(*
  By the Type Rule p7 about if-then-else expressions
  the types following then and else must be of the same type.

  In this case x = 42 because f(42) and y = false because g(false) meaning that they cannot be compared!
*)

let a5 = inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end")
// val it: string = "bool"

// Exercise 6.5 (ii)
// bool -> bool
let i1 = inferType (fromString "let f x = x = false in f end");;
// val i1: string = "(bool -> bool)"

// int -> int
let i2 = inferType (fromString "let f x = x + 1 in f end");;
// val i2: string = "(int -> int)"

// int -> int -> int
let i3 = inferType (fromString "let f x = (let g y = x + y in g end) in f end");;
// val i3: string = "(int -> (int -> int))"

// 'a -> 'b -> 'a
let i4 = inferType (fromString "let f x = (let g y = x in g end) in f end");;
// val i4: string = "('h -> ('g -> 'h))"

// 'a -> 'b -> 'b
let i5 = inferType (fromString "let f x = (let g y = y in g end) in f end");;
// val i5: string = "('g -> ('h -> 'h))"

// ('a -> 'b) -> ('b -> 'c) -> ('a -> 'c)
let i6 = inferType (fromString "let f x = (let g y = (let h z = y (x z) in h end) in g end) in f end");;
// val i6: string = "(('l -> 'k) -> (('k -> 'm) -> ('l -> 'm)))"

// 'a -> 'b
let i7 = inferType (fromString "let f x = f x in f end");;
// val i7: string = "('e -> 'f)"

// 'a
let i8 = inferType (fromString "let f x = f 0 in f 0 end");;
// val i8: string = "'e"

(* Well-typed examples ---------------------------------------- *)

(* In the let-body, f is polymorphic *)

let tex1 = 
    inferType(fromString "let f x = 1 in f 7 + f false end");;

(* In the let-body, g is polymorphic because f is *)

let tex2 = 
    inferType(fromString "let g = let f x = 1 in f end in g 7 + g false end");;

(* f is not polymorphic but used consistently *)

let tex3 = 
    inferType(fromString "let g y = let f x = (x=y) in f 1 = f 3 end in g 7 end");;

(* The twice function *)

let tex4 = 
    inferType(fromString 
                @"let tw g = let app x = g (g x) in app end 
                 in let triple y = 3 * y in (tw triple) 11 end 
                 end");;

let tex5 = 
    inferType(fromString 
               @"let tw g = let app x = g (g x) in app end 
                 in tw end");;

(* Declaring a polymorphic function and rebinding it *)

let tex6 =
    inferType(fromString                 
               @"let id x = x 
                 in let i1 = id 
                 in let i2 = id 
                 in let k x = let k2 y = x in k2 end 
                 in (k 2) (i1 false) = (k 4) (i1 i2) end end end end ");;

(* A large type *)

let tex7 =
    inferType(fromString 
               @"let pair x = let p1 y = let p2 p = p x y in p2 end in p1 end 
                 in let id x = x 
                 in let p1 = pair id id 
                 in let p2 = pair p1 p1 
                 in let p3 = pair p2 p2 
                 in let p4 = pair p3 p3 
                 in p4 end end end end end end");;

(* F# will not infer the same type as above (the variables in p1, p2, p3, p4
   will not be generalized) because of the so-called value restriction 
   on polymorphism, which ensures type system soundness in the presence of 
   destructive update.  An F# example similar to the above can be obtained by 
   eta-expansion: turning  let f = e  into  let f p = e p  which is valid
   when f is a function.  The type of p5 below involves 64 different type variables:

   let id x = x
   let pair x y p = p x y
   let p1 p = pair id id p
   let p2 p = pair p1 p1 p
   let p3 p = pair p2 p2 p
   let p4 p = pair p3 p3 p
   let p5 p = pair p4 p4 p
   in p5;;
*)

(* A polymorphic function may be applied to itself *)

let tex8 = 
    inferType(fromString "let f x = x in f f end");;


(* Ill-typed examples ----------------------------------------- *)

(* A function f is not polymorphic in its own right-hand side,  *)

let teex1 () = 
    inferType(fromString "let f x = f 7 + f false in 4 end");;

(* f is not polymorphic in x because y is bound further out *)

let teex2 () = 
    inferType(fromString "let g y = let f x = (x=y) in f 1 = f false end in g end");;

(* circularity: function parameter h cannot be applied to itself *)

let teex3 () = 
    inferType(fromString "let g h = h h in let f x = x in g f end end");;
