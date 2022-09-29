# Programs as Data - Assignment 4

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 4.1

Get archive `fun.zip` from the homepage and unpack to directory `Fun`.

It contains lexer and parser specifications and interpreter for a small firstorder language. Generate and compile the lexer and parser as described in `README.TXT`; parse and run some example programs with `ParseAndRun.fs`.

> Answer:

```fsharp
run (fromString "5+7");; 
val it: int = 12

run (fromString "let y = 7 in y + 2 end");;
val it: int = 9

run (fromString "let f x = x + 7 in f 2 end");;
val it: int = 9
```

</br>

---

</br>

## PLC 4.2

Write more example programs in the functional language, and test them in the same way as in Exercise 4.1:

- Compute the sum of the numbers from 1000 down to 1. Do this by defining a function `sum n` that computes the sum $n+(n-1)+...+2+1$. (Use straightforward summation, no clever tricks).

> Answer: See **\<ParseAndRun.fs\>**

- Compute the number $3^8$, that is, 3 raised to the power of 8. Again, use a recursive function.

> Answer: See **\<ParseAndRun.fs\>**

- Compute $3^0+3^1+...+3^{10}+3^{11}$, using a recursive function (or two, if you prefer).

> Answer: See **\<ParseAndRun.fs\>**

- Compute $1^8+2^8+...+10^8$, again using a recursive function (or two).

> Answer: See **\<ParseAndRun.fs\>**

</br>

---

</br>

## PLC 4.3

For simplicity, the current implementation of the functional language requires all functions to take exactly one argument. This seriously limits the programs that can be written in the language (at least it limits what that can be written without excessive cleverness and complications).

Modify the language to allow functions to take one or more arguments. Start by modifying the abstrac syntax in `Absyn.fs` to permit a list of parameter names in `Letfun` and a list of argument expressions in `Call`.

Then modify the `eval` interpreter in file `Fun.fs` to work for the new abstract syntax. You must modify the closure representation to accommodate a list of parameters.

Also, modify the `Letfun` and `Call` clauses of the interpreter. You will need  a way to zip together a list of vairable names and a list of variable values, to get an environment in the form of an assoication list; so function `List.zip` might be useful.

> Answer: See **See Fun.fs**

</br>

---

</br>

## PLC 4.4

In continuation of Exercise [4.3](#plc-43), modify the parser specification to accept a language where functions may take any (non-zero) number of arguments.

The resulting parser should permit function declarations such as these:

```fsharp
let pow x n = if n=0 then 1 else x * pow x (n-1) in pow 3 8 end

let max2 a b = if a<b then b else a 
in let max3 a b c = max2 a (max2 b c) 
  in max3 25 6 62 end 
end
```

You may want to define non-empty parameter lists and argument lists in analogy with the `Names1` nonterminal from `Usql/UsqlPar.fsy`, except that the parameters should not be separated by commas.

Note that multi-argument applications such as `f a b` are already permitted by the existing grammar, but they would produce abstract syntax of the form `Call(Call(Var "f", Var "a"), Var "b")` which the `Fun.eval` function does not understand. You need to modify the AppExpr nonterminal and its semantic action to produce `Call(Var "f", [Var "a"; Var "b"])` instead.

> Answer: See **FunPar.fsy** and **ParseAndRun** (for tests)

```fsharp
> test44;;  
val it: Absyn.expr =
  Letfun
    ("pow", ["x"; "n"],
     If
       (Prim ("=", Var "n", CstI 0), CstI 1,
        Prim
          ("*", Var "x",
           Call (Var "pow", [Var "x"; Prim ("-", Var "n", CstI 1)]))),
     Call (Var "pow", [CstI 3; CstI 8]))
```

</br>

---

</br>

## PLC 4.5

Extend the (untyped) functional language with infix operator "`&&`" meaning sequential logical "and" and infix operator "`||`" meaning sequentical logical "or", as in C, C++, Java, C#, or F#.

Note that `e1 && e2` can be encoded as `if e1 then e2 else false` and that `e1 || e2` can be encoded as `if e1 then true else e2`.

 Hence you need only change the lexer and parser specifications, and make the new rules in the parser specification generate the appropriate abstract syntax. You need not change `Absyn.fs` or `Fun.fs`.

> Answer: See **FunPar.fsy** and **ParseAndRun.fs** (for tests)

</br>

---
