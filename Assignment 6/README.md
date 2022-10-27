# Programs as Data - Assignment 6

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 7.1

Download `microc.zip` from the book homepage, unpack it to a folder `MicroC`, and build the micro-C interpreter as explained in `README.TXT` step (A).

Run the fromFile parser on the micro-C example in source file `ex1.c`. In your solution to the exercise, include the abstract syntax tree and indicate its parts: declarations, statements, types and expressions.

> Answer:

```fsharp
 Prog
    [Fundec
       (None, "main", [(TypI, "n")], // Declaration of function "main". It takes one argument, a TypI "n", and returns void, which is why it says "None" at the beginning
        Block   // Code block of statements and variable declarations related to main
          [Stmt // Statement for while loop
             (While // While of expr * stmt
                (Prim2 (">", Access (AccVar "n"), CstI 0), //Prim2 is a binary operator operation. Here it is "greater than" where we access the variable "n" and compare with 0
                 Block  // Code block of statements and variable declarations related to the while loop
                   [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));  // Prim1 is a Unary operator printi where we access the variable "n" of type int and prints it  
                    Stmt // A Stmt can be of type: If, While, Block, Return, or as in this case: Expr 
                      (Expr // Expr of expr
                         (Assign // Assigns the result of the expression "n - 1" to the variable "n", as follows:
                            (AccVar "n", // Variable access to the variable "n"
                             Prim2 ("-", Access (AccVar "n"), CstI 1))))])); // Prim2 is a Binary operator, where subtracts is the operand in the expression 'n - 1' 
           Stmt (Expr (Prim1 ("printc", CstI 10)))])] // Prim1 is a Unary operator printc where we print a constant "10" 

# Ask the TA about Printc and the CstI 10

```

Run the interpreter on some of the micro-C examples provided, such as those in source files `ex1.c` and `ex11.c`. Note that both take an integer `n` as input. The former program prints the numbers from `n` down to 1; the latter finds all solutions to the n-queens problem.

> Answer:

```fsharp
// ex1.c
run (fromFile "ex1.c") [5];;
5 4 3 2 1 
val it: Interp.store = map [(0, 0)]

// ex11.c
run (fromFile "ex11.c") [5];;
1 3 5 2 4 
1 4 2 5 3
2 4 1 3 5
2 5 3 1 4
3 1 4 2 5
3 5 2 4 1
4 1 3 5 2
4 2 5 3 1
5 2 4 1 3
5 3 1 4 2

val it: Interp.store =
  map
    [(0, 5); (1, 0); (2, 6); (3, -999); (4, 0); (5, 0); (6, 0); (7, 0); (8, 0);
     ...]
```

</br>

---

</br>

## PLC 7.2

Write and run a few more micro-C programs to understand the use of arrays, pointer arithmetics, and parameter passing. Use the micro-C implementation Imperative Languages in `Interp.fs` and the associated lexer and parser to run your programs, as in Exercise [7.1](#plc-71).

Be careful: there is no type checking in the micro-C interpreter and nothing prevents you from overwriting arbitrary store locations by mistake, causing your program to produce unexpected results. (The type system of real C would catch *some* of those mistakes at compile time).

(i) Write a micro-C program containing a function `void arrsum(int n, int arr[], int *sump)` that computes and returns the sum of the first `n` elements of the given array `arr`. The result must be returned through the `sump` pointer. The program's main function must create an array holding the four numbers 7, 13, 9, 8, call function `arrsum` on that array, and print the result using micro-C's non-standard print statement.

Remember that MicroC is very limited compared to actual C: You cannot use initializers in variable declarations like "`int i=0;`" but must use a declaration followed by a statement, as in "`int i; i=0;`" instead; there is nofor-loop (unless you implement one, see Exercise [7.3](#plc-73)); and so on.
Also remember to initialize all variables and array elements; this doesn't happen automatically in micro-C or C

> Answer: See file **./7.2/7.2(i).c**

``` fsharp
run (fromFile "MicroC/7.2/7.2(i).c") [2];;
20 val it: Interp.store =
  map
    [(-1, 20); (0, 2); (1, -1); (2, 7); (3, 13); (4, 9); (5, 8); (6, 2);
     (7, -1); ...]
```

(ii) Write a micro-C program containing a function `void squares(int n, int arr[])` that, given `n` and an array `arr` of length `n` or more fills `arr[i]` with `i*i` for `i = 0, ..., n − 1`.

Your `main` function should allocate an array holding up to 20 integers, call function `squares` to fill the array with `n` square numbers (where $n \leq 20$ is given as a parameter to the `main` function), then call function `arrsum` above to compute the sum of the `n` squares, and print the sum.

> Answer: See file **./7.2/7.2(ii).c**

```fsharp
run (fromFile "MicroC/7.2/7.2(ii).c") [4];;
14 val it: Interp.store =
  map
    [(-1, 14); (0, 4); (1, 0); (2, 1); (3, 4); (4, 9); (5, 16); (6, -999);
     (7, -999); ...]
```

(iii) Write a micro-C program containing a function `void histogram(int n, int ns[], int max, int freq[])` which fills array `freq` the frequencies of the numbers in array `ns`. More precisely, when the function returns, element `freq[c]` must equal the number of times that value `c` appears among the first `n` elements of `arr`, for $0\leq c\leq max$. You can assume that all numbers in `ns` are between 0 and `max`, inclusive.

For example, if your `main` function creates an array `arr` holding the seven numbers 1 2 1 1 1 2 0 and calls `histogram(7, arr, 3, freq)`, then afterwards `freq[0]` is 1, `freq[1]` is 4, `freq[2]` is 2, and `freq[3]` is 0. Of course, `freq` must be an array with at least four elements. What happens if it is not? The array `freq` should be declared and allocated in the `main` function, and passed to histogram function. It does not work correctly (in micro-C or C) to stack-allocate the array in histogram and somehow return it to the `main` function. Your `main` function should print the contents of array `freq` after the call.

> Answer: See file **./7.2/7.2(iii).c**

```fsharp
run (fromFile "MicroC/7.2/7.2(iii).c") [7];;
1 4 2 0 val it: Interp.store =
  map
    [(0, 7); (1, 1); (2, 4); (3, 2); (4, 0); (5, 1); (6, 1); (7, 2); (8, 1);
     ...]
```

</br>

---

</br>

## PLC 7.3

Extend MicroC with a for-loop, permitting for instance:

```c
for (i=0; i<100; i=i+1)
  sum = sum+i
```

To do this, you must modify the lexer and parser specifications in `CLex.fsl` and `CPar.fsy`. You may also extend the micro-C abstract syntax in `Absyn.fs` by defining a new statement constructor `Forloop` in the `stmt` type, and add a suitable case to the `exec` function in the interpreter.

But actually, with a modest amount of cleverness (highly recommended), you do not need to introduce special abstract syntax for for-loops, and need not modify the interpreter at all. Namely, a for-loop of the general form:

```c
for (e1; e2; e3)
  stmt
```

is equivalent to a block:

```c
{
  e1; 
  while (e2) {
    stmt
    e3;
  }
}
```

Hence it suffices to let the semantic action `...` in the parser construct abstract syntax using the existing `Block`, `While`, and `Expr` constructors from the `stmt` type.

Rewrite your programs from Exercise [7.2](#plc-72) to use for-loops instead of while-loops.

> Answer: See files **CLex.fsl**, **CPar.fsy**, and Folder **7.3**

```fsharp
run (fromFile "MicroC/Examples/ex1.c") [17];;
17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 
val it: Interp.store = map [(0, 17); (1, 0)]
```

</br>

---

</br>

## PLC 7.4

Extend the micro-C abstract syntax in `Absyn.fs` with the preincrement and predecrement operators known from C, C++, Java, and C#:

```fsharp
type expr =
    ...
  | PreInc of access  (* C/C++/Java/C# i++ or ++a[e] *)
  | PreDec of access  (* C/C++/Java/C# --i or --a[e] *)
```

Note that the predecrement and preincrement operators work on lvalues, that is, variables and array elements, and more generally on any expression that evaluates to a location.

Modify the micro-C interpreter in `Interp.fs` to handle `PreInc` and `PreDec`. You will need to modify the `eval` function, and use the `getSto` and `setSto` store operations (Sect. 7.3).

> Answer: See files **Absyn.fs** and **Interp.fs**

</br>

---

</br>

## PLC 7.5

Extend the micro-C lexer and parser to accept `++e` and `-–e` also, and to build the corresponding abstract syntax.

> Answer: See files **CLex.fsl**, **CPar.fsy** and Folder **7.5**

```fsharp
run (fromFile "MicroC/7.5/examples.c") [12] ;;
13 val it: Interp.store = map [(0, 13)]

#Ask TA about precedence print and Inc
```

</br>

---
