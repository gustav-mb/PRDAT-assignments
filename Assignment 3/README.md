# Programs as Data - Assignment 3

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 3.3

Write out the rightmost derivation of the string below from the expression grammar at the end of Sect. 3.6.5, corresponding to `ExprPar.fsy`. Take note of the sequence of grammar rules (A-I) used.

`let z = (17) in z + 2 * 3 end EOF`

> $\text{Main}\overset{A}\rightarrow$
>
> $\text{\textbf{\textit{Expr}} EOF}\overset{F}\rightarrow$
>
> $\text{LET NAME EQ \textit{Expr} IN \textbf{\textit{Expr}} END EOF}\overset{G}\rightarrow$
>
>$\text{LET NAME EQ \textit{Expr} IN \textit{Expr} TIMES \textbf{\textit{Expr}} END EOF}\overset{C}\rightarrow$
>
>$\text{LET NAME EQ \textit{Expr} IN \textbf{\textit{Expr}} TIMES CSTINT END EOF}\overset{H}\rightarrow$
>
>$\text{LET NAME EQ \textit{Expr} IN \textit{Expr} PLUS \textbf{\textit{Expr}} TIMES CSTINT END EOF}\overset{C}\rightarrow$
>
>$\text{LET NAME EQ \textit{Expr} IN \textbf{\textit{Expr}} PLUS CSTINT TIMES CSTINT END EOF}\overset{B}\rightarrow$
>
>$\text{LET NAME EQ \textbf{\textit{Expr}} IN NAME PLUS CSTINT TIMES CSTINT END EOF}\overset{E}\rightarrow$
>
>$\text{LET NAME EQ LPAR \textbf{\textit{Expr}} RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF}\overset{C}\rightarrow$
>
>$\text{LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF}$

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

Observations for the above expressions:

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
fromString "let x = 10 in x - x end";; // Parses: Let ("x", CstI 10, Prim ("-", Var "x", Var "x"))
```

</br>

---

</br>

## PLC 3.6

Use the expression parser from `Parse.fs` and the compiler `scomp` (from expressions to stack machine instructions)
and the associated datatypes from `Expr.fs` to define a function `compString : string -> sinstr list` that parses a string
as an expression and compiles it to stack machine code.

Answer: See **ex2_4Handout.fs**

</br>

---

</br>

## PLC 3.7

Extend the expression language abstract syntax and the lexer and parser specifications with conditional expressions. The abstract syntax should be `If(e1, e2, e3)`, so modify file `Absyn.fs` as well as `ExprLex.fsl` and file `ExprPar.fsy`. The concrete syntax may be the keyword-laden F#/ML-style:

> `If e1 then e2 else e3`

Or the more light-weight C/C++/Java/C#-style:

> `e1 ? e2 : e3`

Some documentation for `fslex` and `fsyacc` is found in this chapter and in `Expert F#`.

Answer: Both implemented; see **Absyn.fs**, **ExprLex.fsl** and **ExprPar.fsy**

</br>

---
