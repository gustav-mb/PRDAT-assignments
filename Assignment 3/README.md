# Programs as Data - Assignment 3

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 3.3

Write out the rightmost derivation of the string below from the expression grammar at the end of Sect. 3.6.5, corresponding to `ExprPar.fsy`. Take note of the sequence of grammar rules (A-I) used.

`let z = (17) in z + 2 * 3 end EOF`

![PLC 3.3](/appendix/PLC%203.3.png)

</br>

---

</br>

## PLC 3.4

Draw the above derivation as a tree.

![PLC 3.4](appendix/PLC%203.4.png)

</br>

---

</br>

## PLC 3.5

Get `expr.zip` from the book homepage and unpack it.

Using a command prompt, generate (1) the lexer and (2) the parser for expressions by running `fslex` and `fsyacc`; then (3) load the expression abstract syntax, the lexer and parser modules, and the expression interpreter and compilers, into an interactive F# session (`fsharpi`):

```fslex
fslex --unicode ExprLex.fslex
fsyacc --module ExprPar ExprPar.fsy
fsharpi -r Fsharp.PowerPack.dll Absyn.fs ExprPar.fs ExprLex.fs Parse.fs
```

Now try the parser on several example expressions, both well-formed and ill-formed ones, such as these, and some of your own invention:

```fsharp
open Parse;;
fromString "1+2* 3";;
fromString "1-2- 3";;
fromString "1 + -2";;
fromString "x++";;
fromString "1 + 1.2";;
fromString "1 + ";;
fromString "let z = (17) in z +2*3 end";;
fromString "let z = 17) inz+2*3 end";;
fromString "let in = (17) inz+2*3 end";;
fromString "1 + let x=5 in let y=7+x in y+y end + x end";;
```

Observations:

```fsharp
open Parse;;
fromString "1+2* 3";; // Parses: Prim ("+", CstI 1, Prim ("*", CstI 2, CstI 3))
fromString "1-2- 3";; // Parses: Prim ("-", Prim ("-", CstI 1, CstI 2), CstI 3)
fromString "1 + -2";; // Parses: Prim ("+", CstI 1, CstI -2)
fromString "x++";;  // Fails: Parse error near line 1, column 3
fromString "1 + 1.2";; // Fails: Lexer error: Illeagal symbol near line 1, column 4
fromString "1 + ";; // Fails: Parse error near line 1, column 2
fromString "let z = (17) in z +2*3 end";; // Parses: Let ("z", CstI 17, Prim ("+", Var "z", Prim ("*", CstI 2, CstI 3)))
fromString "let z = 17) inz+2*3 end";;  // Fails: Parse error near line 1, column 11
fromString "let in = (17) inz+2*3 end";; // Fails: Parse error near line 1, column 16
fromString "1 + let x=5 in let y=7+x in y+y end + x end";;
(* Parses:
    Prim
    ("+", CstI 1,
     Let
       ("x", CstI 5,
        Prim
          ("+",
           Let
             ("y", Prim ("+", CstI 7, Var "x"), Prim ("+", Var "y", Var "y")),
           Var "x")))
*)
```

</br>

---

</br>

## PLC 3.6

Use the expression parser from `Parse.fs` and the compiler `scomp` (from expressions to stack machine instructions)
and the associated datatypes from `Expr.fs`to defie a function `compString : string -> sinstr list`that parses a string
as an expression and compiles it to stack machine code.

Answer: See **ex2_4Handout.fs** 


</br>

---

</br>

## PLC 3.7

opg7

Answer: See **ex2_4Handout.fs** and **Expre.fs**


</br>

---

</br>