# Programs as Data - Assignment 7

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 8.1

Download `microc.zip` from the book homepage, unpack it to a folder `MicroC`, and build the micro-C compiler as explained in `README.TXT` step (B).

(i) As a warm-up, compile one of the micro-C examples provided, such as that in source file `ex11.c`, then run it using the abstract machine implemented in Java, as described also in step (B) of the README file. When run with command line argument 8, the program prints the 92 solutions to the eight queens problem: how to place eight queens on a chessboard so that none of them can attack any of the others.

> Answer:

(ii) Now compile the example micro-C programs `ex3.c` and `ex5.c` using functions `compileToFile` and `fromFile` from `ParseAndComp.fs` as above.
Study the generated symbolic bytecode. Write up the bytecode in a more structured way with labels only at the beginning of the line (as in this chapter). Write the corresponding micro-C code to the right of the stack machine code. Note that `ex5.c` has a nested scope (a block ... inside a function body); how is that visible in the generated code?

> Answer:

Execute the compiled programs using `java Machine ex3.out 10` and similar. Note that these micro-C programs require a command line argument (an integer) when they are executed.

> Answer:

Trace the execution using `java Machinetrace ex3.out 4`, and explain the stack contents and what goes on in each step of execution, and especially how the low-level bytecode instructions map to the higher-level features of MicroC. You can capture the standard output from a command prompt (in a file `ex3trace.txt`) using the Unix-style notation: `java Machinetrace ex3.out 4 > ex3trace.txt`

> Answer:

</br>

---

## PLC 8.3

This abstract syntax for preincrement `++e` and predecrement `--e` was introduced in Exercise 7.4:

```fsharp
type expr =
    ...
  | PreInc of access  (* C/C++/Java/C# ++i or ++a[e] *)
  | PreDec of access  (* C/C++/Java/C# --i or --a[e] *)
```

Modify the compiler (function `cExpr`) to generate code for `PreInc(acc)` and `PreDec(acc)`. To parse micro-C source programs containing these expressions, you also need to modify the lexer and parser.

It is tempting to expand `++e` to the assignment expression `e = e+1`, but that would evaluate `e` twice, which is wrong. Namely, `e` may itself have a side effect, as in `++arr[++i]`.

Hence `e` should be computed only once. For instance, `++i` should compile to something like this: `<code to compute address of i>`, `DUP`, `LDI`, `CSTI 1`, `ADD`, `STI`, where the address of `i` is computed once and then duplicated.

> Answer:

Write a program to check that this works. If you are brave, try it on expressions of the form `++arr[++i]` and check that `i` and the elements of `arr` have the correct values afterwards.

> Answer:

</br>

---

## PLC 8.4

Compile `ex8.c` and study the symbolic bytecode to see why it is so much slower than the handwritten 20 million iterations loop in `prog1`.

> Answer:

Compile `ex13.c` and study the symbolic bytecode to see how loops and conditionals interact; describe what you see.

> Answer:

In a later chapter we shall see an improved micro-C compiler that generates fewer extraneous labels and jumps.

</br>

---

## PLC 8.5

Extend the micro-C language, the abstract syntax, the lexer, the parser,
and the compiler to implement conditional expressions of the form `(e1 ? e2 : e3)`.

The compilation of `e1 ? e2 : e3` should produce code that evaluates `e2` only if `e1` is true and evaluates `e3` only if `e1` is false. The compilation scheme should be the same as for the conditional statement `if (e) stmt1 else stmt2`, but expression `e2` or expression `e3` must leave its value on the stack top if evaluated, so that the entire expression `e1 ? e2 : e3` leaves its value on the stack top.

> Answer:

</br>

---

## PLC 8.6

Extend the lexer, parser, abstract syntax and compiler to implement switch statements such as this one:

```c
switch (month) {
  case 1:
    { days = 31; }
  case 2:
    { days = 28; if (y%4==0) days = 29; }
  case 3:
    { days = 31; }
}
```

Unlike in C, there should be no fall-through from one `case` to the next: after the last statement of a `case`, the code should jump to the end of the `switch` statement. The parenthesis after `switch` must contain an expression.
The value after a `case` must be an integer constant, and a case must be followed by a statement block. A `switch` with `n` cases can be compiled using `n` labels, the last of which is at the very end of the switch. For simplicity, do not implement the `break` statement or the `default` branch.

> Answer:

</br>

---
