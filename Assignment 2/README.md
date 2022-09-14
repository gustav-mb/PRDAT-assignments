# Programs as Data - Assignment 1

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017 and Basic Compiler Design (BCD) by Torben Mogensen, DIKU 2010

</br>

## PLC 2.4

Write a bytecode assembler (in F#) that translates a list of bytecode instructions for the simple stack machine in `Intcomp1.fs` into a list of integers.

The integers should be the corresponding bytecodes for the interpreter in `Machine.java`. Thus you should write a function `assemble : sinstr list -> int list`.

Use this function together with scomp from `Intcomp1.fs` to make a compiler from the original expressions language `expr` to a list of bytecodes `int list`.

You may test the output of your compiler by typing in the numbers as an `int` array in the `Machine.java` interpreter. (Or you may solve Exercise 2.5 below to avoid this manual work).

**See file: Expr.fs**

</br>

---

</br>

## PLC 2.5

Modify the compiler from Exercise 2.4 to write the lists of integers to
a file. An F# list `inss` of integers may be output to the file called `fname` using this function (found in `Intcomp1.fs`):

```fsharp
let intsToFile (inss : int list) (fname : string) =
    let text = String.concat " " (List.map string inss)
    System.IO.File.WriteAllText(fname, text)
```

Then modify the stack machine interpreter in Machine.java to read the sequence of integers from a text file, and execute it as a stack machine program.

The name of the text file may be given as a command-line parameter to the Java program. Reading numbers from the text file may be done using the StringTokenizer class or StreamTokenizer class.

It is essential that the compiler (in F#) and the interpreter (in Java) agree on the intermediate language: what integer represents what instruction.

</br>

---

</br>

## PLC 3.2

Write a regular expression that recognizes all sequences consisting of *a* and *b* where two *a*’s are always separated by at least one b. For instance, these four strings are legal: *b*, *a*, *ba*, *ababbbaba*; but these two strings are illegal: *aa*, *babaa*.

Construct the corresponding NFA. Try to find a DFA corresponding to the NFA.

$ (a|b|ba)(b|ba)* $

See picture

</br>

---

</br>

## BCD 2.1

In the following, a *number-string* is a non-empty sequence of decimal digits, i.e., something in the language defined by the regular expression $[0-9]^+$. The value of a number-string is the usual interpretation of a number-string as an integer number.

Note that leading zeroes are allowed

Make for each of the following languages a regular expression that describes that language.

a) All number-strings that have the value 42.

Answer: 0*42

b) All number-strings that *do not* have the value 42

Answer: 0*(([0-9][0-13-9]*)|([0-35-9][0-9])|([0-9]*42[0-9]+))

c) All number-strings that have a value that is strictly greater than 42. (n > 42)

Answer: ^[1-9][0-9]{2,}|[4-9][3-9]|[5-9][0-9]$

</br>

---

</br>

## BCD 2.2

Given a regular expression a*(a|b)aa*:

a) Construct an equivalent NFA using the method in section 2.4.

See picture

b) Convert this NFA to a DFA using algorithm 2.3.

</br>

---
