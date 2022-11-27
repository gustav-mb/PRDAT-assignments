# Programs as Data - Assignment 11

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

---

</br>

## PLC 12.1

The continuation-based micro-C compiler (file `Contcomp.fs`) still generates clumsy code in some cases. For instance, the statement (file `ex16.c`):

```c
if (n)
    {}
else
    print 1111;
print 2222;
```

is compiled to this machine code:

```txt
GETBP; LDI; IFZERO L3;
GOTO L2;
L3: CSTI 1111; PRINTI; INCSP -1;
L2: CSTI 2222; PRINTI; RET 1
```

which could be optimized to this by inverting the conditional jump and deleting the `GOTO L2` instruction:

```txt
GETBP; LDI; IFNZRO L2;
L3: CSTI 1111; PRINTI; INCSP -1;
L2: CSTI 2222; PRINTI; RET 1
```

Improve the compiler to recognize this situation. It must recognize that it is about to generate code of this form:

```txt
IFZERO L3; GOTO L2; Label L3; ....
```

where the conditional jump jumps over an unconditional jump. Instead it should generate code such as this:

```txt
IFNZRO L2; Label L3; ....
```

Define a new auxiliary function `addIFZERO lab3 C` which tests whether `C` has the structure shown above. In the code generation for `If(e,s1,s2)` in `cStmt`, instead of doing `IFZERO labelse:: code` you must call the auxiliary to do the consing, as in `addIFZERO labelse code`.

In fact, everywhere in the compiler where you would previously just cons `IFZERO lab` onto something, you should call `addIFZERO` instead to make sure the code gets optimized.

A similar optimization can be made for `IFNZRO L3; GOTO L2; Label L3`. This is done in much the same way.

> **Answer:** See file **Contcomp.fs** and output from `ex16.c` below

```fsharp
contCompileToFile (fromFile ".\MicroC\examples\ex16.c") "ex16.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; GETBP; LDI; IFNZRO "L2";
   Label "L3"; CSTI 1111; PRINTI; INCSP -1; Label "L2"; CSTI 2222; PRINTI;
   RET 1]
```

</br>

---

</br>

## PLC 12.2

Improve code generation in the continuation-based micro-C compiler so that a less-than comparison with *constant* arguments is compiled to its truth value.
For instance, `11 < 22` should compile to the same code as `true`, and `22 < 11` should compile to the same code as `false`. This can be done by a small extension of the `addCST` function in `Contcomp.fs`.

> **Answer:** See files **Contcomp.fs** and **12/12.2i.c** (for test)

```fsharp
// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2i.c") "12.2i.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 22;
   LT; STI; INCSP -1; GETBP; CSTI 11; CSTI 11; LT; STI; INCSP -1; GETBP;
   CSTI 11; CSTI 10; LT; STI; RET 1]

// OPTIMIZED
// True 11 < 22  -> CSTI 1
// False 11 < 11 -> CSTI 0
// False 11 < 10 -> CSTI 0
contCompileToFile (fromFile "12/12.2i.c") "12.2i.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 0; STI; INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

Further improve the code generation so that all comparisons with constant arguments are compiled to the same code as `true` (e.g. `11 <= 22` and `11 != 22` and `22 > 11` and `22 >= 11`) or `false`.

> **Answer:** See files **Contcomp.fs** and **12/12.2i(2).c**, **12/12.2ii.c**, **12/12.2ii(2).c**, **12/12.2iii.c**, **12/12.2iii(2).c** (for tests)

```fsharp
// x > y

// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2i(2).c") "12.2i(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 22; CSTI 11;
   SWAP; LT; STI; INCSP -1; GETBP; CSTI 22; CSTI 22; SWAP; LT; STI; INCSP -1;
   GETBP; CSTI 10; CSTI 11; SWAP; LT; STI; RET 1]

// OPTIMIZED
// 22 > 11  -> CSTI 1
// 22 > 22  -> CSTI 0
// 10 > 11 -> CSTI 0
contCompileToFile (fromFile "12/12.2i(2).c") "12.2i(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 0; STI; INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

```fsharp
// x <= y

// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2ii.c") "12.2ii.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 22;
   SWAP; LT; NOT; STI; INCSP -1; GETBP; CSTI 11; CSTI 11; SWAP; LT; NOT; STI;
   INCSP -1; GETBP; CSTI 11; CSTI 10; SWAP; LT; NOT; STI; RET 1]

// OPTIMIZED
// 11 <= 22  -> CSTI 1
// 11 <= 11  -> CSTI 1
// 11 <= 10 -> CSTI 0
contCompileToFile (fromFile "12/12.2ii.c") "12.2ii.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 1; STI; INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

```fsharp
// x >= y

// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2ii(2).c") "12.2ii(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 22; CSTI 11;
   LT; NOT; STI; INCSP -1; GETBP; CSTI 11; CSTI 11; LT; NOT; STI; INCSP -1;
   GETBP; CSTI 10; CSTI 11; LT; NOT; STI; RET 1]

// OPTIMIZED
// 22 >= 11 -> CSTI 1
// 11 >= 11 -> CSTI 1
// 10 >= 11 -> CSTI 0
contCompileToFile (fromFile "12/12.2ii(2).c") "12.2ii(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 1; STI; INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

```fsharp
// x != y

// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2iii.c") "12.2iii.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 22;
   EQ; NOT; STI; INCSP -1; GETBP; CSTI 11; CSTI 11; EQ; STI; RET 1]

// OPTIMIZED
// 11 != 22 -> CSTI 1
// 11 != 11 -> CSTI 0
contCompileToFile (fromFile "12/12.2iii.c") "12.2iii.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

```fsharp
// x == y

// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2iii(2).c") "12.2iii(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 11;
   EQ; STI; INCSP -1; GETBP; CSTI 12; CSTI 11; EQ; STI; RET 1]

// OPTIMIZED
// 11 == 11 -> CSTI 1
// 12 == 11 -> CSTI 0
contCompileToFile (fromFile "12/12.2iii(2).c") "12.2iii(2).out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
   INCSP -1; GETBP; CSTI 0; STI; RET 1]
```

Check that `if (11 <= 22) print 33;` compiles to code that unconditionally executes `print 33` without performing any test or jump.

> **Answer:** See files **Contcomp.fs** and **12/12.2iv.c** (for test)

```fsharp
// NOT OPTIMIZED
contCompileToFile (fromFile "12/12.2iv.c") "12.2iv.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 11; CSTI 22; SWAP; LT;
   IFNZRO "L2"; IFZERO "L2"; CSTI 33; PRINTI; RET 0; Label "L2"; RET -1]

// OPTIMIZED
contCompileToFile (fromFile "12/12.2iv.c") "12.2iv.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 33; PRINTI; RET 0;
   Label "L2"; RET -1]
```

</br>

---

</br>

## PLC 12.3

Extend the micro-C abstract syntax (file `Absyn.fs`) with conditional expressions `Cond(e1, e2, e3)`, corresponding to this concrete syntax (known from C, C++, Java and C#):

`e1 ? e2 : e3`

The expression `Cond(e1, e2, e3)` must evaluate `e1`, and if the result is nonzero, must evaluate `e2`, otherwise `e3`. (If you want to extend also the lexer and parser to accept this new syntax, then note that `?` and `:` are right associative; but implementing them in the lexer and parser is not strictly necessary for this exercise).

> **Answer:** See files **Absyn**, **CLex.fsl** and **CPar.fsy**

Schematically, the conditional expression should be compiled to the code shown below:

```txt
    <e1>
    IFZERO L1
    <e2>
    GOTO L2
L1: <e3>
L2:
```

Extend the continuation-based micro-C compiler (file `Contcomp.fs`) to compile conditional expressions to stack machine code. Your compiler should optimize code while generating it. Check that your compiler compiles the following two examples to code that works properly:

```c
true ? 1111 : 2222          false ? 1111: 2222
```

The first one has abstract syntax `Cond(CstI 1, CstI 1111, CstI 2222)`. Unless you have implemented conditional expressions `(e1 ? e2 : e3)` in the lexer and parser, the simplest way to experiment with this is to invoke the `cExpr` expression compilation function directly, like this, where the two first `[]` represent empty environments, and the last one is an empty list of instructions:

```fsharp
cExpr (Cond(CstI 1, CstI 1111, CstI 2222)) ([], 0) [] [];
```

Do not waste too much effort trying to get your compiler to optimize away everything that is not needed. This seems impossible without traversing and modifying already generated code.

> **Answer:** See file **Contcomp.fs** and **12/12.3.c** (for test)

```fsharp
contCompileToFile (fromFile "12/12.3.c") "12.3.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 1111; GOTO "L3"; Label "L4";
   CSTI 2222; Label "L3"; INCSP -1; Label "L2"; CSTI 2222; RET 0]
```

</br>

---

</br>

## PLC 12.4

The compilation of the short-cut logical operators (`&&`) and (`||`) in `Contcomp.fs` is rather complicated. After Exercise [12.3](#plc-123) one can implement them in a somewhat simpler way, using these equivalences:

$$\text{\texttt{e1 \&\& e2} is equivalent to \texttt{(e1 ? e2 : 0)}}$$
$$\text{\texttt{e1 || e2} is equivalent to \texttt{(e1 ? 1 : e2)}}$$

Implement the sequential logical operators (`&&` and `||`) this way in your extended compiler from Exercise [12.3](#plc-123). You should change the parser specification in `CPar.fsy` to build `Cond(...)` expressions instead of `Andalso(...)` or `Orelse(...)`.

> **Answer:**

Test this approach on file `ex13.c` and possibly other examples. How does the code quality compare to the existing complicated compilation of `&&` and `||`?

> **Answer:**

</br>

---
