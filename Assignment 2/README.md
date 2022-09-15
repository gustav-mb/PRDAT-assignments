# Programs as Data - Assignment 1

Non-code answers to the exercises are given in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017 and Basic Compiler Design (BCD) by Torben Mogensen, DIKU 2010

</br>

## PLC 2.4

Write a bytecode assembler (in F#) that translates a list of bytecode instructions for the simple stack machine in `Intcomp1.fs` into a list of integers.

The integers should be the corresponding bytecodes for the interpreter in `Machine.java`. Thus you should write a function `assemble : sinstr list -> int list`.

Use this function together with scomp from `Intcomp1.fs` to make a compiler from the original expressions language `expr` to a list of bytecodes `int list`.

You may test the output of your compiler by typing in the numbers as an `int` array in the `Machine.java` interpreter. (Or you may solve Exercise 2.5 below to avoid this manual work).

See file **ex2_4Handout.fs**

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

See file **ex2_4Handout.fs** and **Machine.java**

</br>

---

</br>

## PLC 3.2

Write a regular expression that recognizes all sequences consisting of *a* and *b* where two *a*’s are always separated by at least one b. For instance, these four strings are legal: *b*, *a*, *ba*, *ababbbaba*; but these two strings are illegal: *aa*, *babaa*.

Construct the corresponding NFA. Try to find a DFA corresponding to the NFA.

Regex: `(a|b|ba)(b|ba)*`

NFA:

![3.2 NFA](/appendix/PLC%203.2%20NFA.png)

DFA:

![3.2 DFA](/appendix/PLC%203.2%20DFA.png)

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

Answer: `0*(([0-9][0-13-9]*)|([0-35-9][0-9])|([0-9]*42[0-9]+))`

c) All number-strings that have a value that is strictly greater than 42. (n > 42)

Answer: `^[1-9][0-9]{2,}|[4-9][3-9]|[5-9][0-9]$`

</br>

---

</br>

## BCD 2.2

Given a regular expression a*(a|b)aa:

a) Construct an equivalent NFA using the method in section 2.4.

![BCD 2.2 NFA](/appendix/BCD%202.2%20NFA.png)

b) Convert this NFA to a DFA using algorithm 2.3.

![BCD 2.2 DFA](/appendix/BCD%202.2%20DFA.png)

</br>

---

</br>

## HelloLex Question 1

Read the specification `hello.fsl`

What are the regular expressions involved, and which semantic values are they associated with?

The involved regex is the range [0-9].

The semantic values associated with is a single char representing an integer from 0 to 9.

</br>

---

</br>

## HelloLex Question 2

Generate the lexer out of the specification using a command prompt. Which additional file is generated during the process?

Answer: `hello.fs`

How many states are there by the automaton of the lexer?
Hint: Depending on setup, you can generate the lexer with the command `fslex --unicode hello.fsl`

You can get the number of the states of the automaton by reading the report output when the lexer is generated.

Answer: There are 3 states by the automaton of the lexer.

</br>

---

</br>

## HelloLex Question 3

Compile and run the generated program `hello.fs` from question 2.
Hint: This depends on your setup. A possible approach is to have `FsLexYacc.Runtime.dll` accessible from your working directory and do the following:

```fsharppc
% fsharpc -r FsLexYacc.Runtime.dll hello.fs
Microsoft (R) F# Compiler version 10.2.3 for F# 4.5
Copyright (c) Microsoft Corporation. All Rights Reserved.

% mono hello.exe
Hello World from FsLex!

Please pass a digit:
3

The lexer recognizes 3
%
```

</br>

---

</br>

## HelloLex Question 4

Extend the lexer specification `hello.fsl` to recognize numbers of more than one digit. New lexer specification is `hello2.fsl`.
Generate `hello.fs`, compile and run the generated program.

</br>

---

</br>

## HelloLex Question 5

Extend the lexer specification `hello2.fsl` to recognize floating numbers. New lexer specification is `hello3.fsl`. Generate `hello3.fs`, compile and run the generated program.

Hint: You can use the regular expression `[+-]?([0-9]*[.])?[0-9]+` to recognize floats.

</br>

---
