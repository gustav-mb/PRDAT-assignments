# Programs as Data - Assignment 1

Assignments are from Programming Language Concepts, by Peter Sestoft, Springer 2017.

</br>

## Exercise 1.1

### 1.1 (i)

File `Intro2.fs` contains a definition of the `expr` expression langauge and an evaluation function `eval`. Extend the `eval` function to handle three additional operators: "`max`", "`min`", and "`==`". Like the existing operators, they take two argument expressions. The eequals operator should return 1 when true and 0 when false.

</br>

### 1.1 (ii)

Write some example expressions in this extended language, using abstract syntax, and evaluate them using your new `eval` function.

</br>

### 1.1 (iii)

Rewrite one of the `eval` functions to evaluate the arguments of a primitive before branching out on the operator, in this style:

```fsharp
let rec eval e (env : (string * int) list) : int =
    match e with
    | ...
    | Prim(ope, e1, e2) ->
        let i1 = ...
        let i2 = ...
        match ope with
        | "+" -> i1 + i2
        | ...
```

</br>

### 1.1 (iv)

Extend the expression language with conditional expressions `If(e1, e2, e3)` corresponding to Java's expression `e1 ? e2 : e3` or F#'s conditional expression `if e1 then e2 else e3`.

You need to extend the `expr` datatype with a new constructor `If` that takes three `expr` arguments.

</br>

### 1.1 (v)

Extend interpreter function `eval` correspondingly. It should evaluate `e1`, and if `e1` is non-zero, then evaluate `e2`, else evaluate `e3`. You should be able to evaluate the expression `If(Var "a", CstI 11, CstI 22)` in an environment that binds variable `a`.

Note that various strange and non-standard interpretations might start by testing whether expressions `e2` and `e3` are syntactically identical, in which case there is no need to evaluate `e1`, only `e2` (or `e3`). Although possible, this shortcut is rarely useful.

</br>

---

</br>

## Exercise 1.2

### 1.2 (i)

Declare an alternative datatype `aexpr` for a representation of arithmetic expressions without let-bindings. The datatype should have constructors `CstI`, `Var`, `Add`, `Mul`, `Sub`, for constants, variables, addition, multiplication, and subtraction.

Then $x*(y+3)$ is represented as `Mul(Var "x", Add(Var "y", CstI 3))`, not as `Prim("*", Var "x", Prim("+", Var "y", CstI 3))`.

</br>

### 1.2 (ii)

Write the representation of the expressions:

* $v-(w+z)$
* $2*(v-(w+z))$
* $x+y+z+v$

</br>

### 1.2 (iii)

Write an F# function `fmt : aexpr -> string` to format expressions as strings. For instance, it may format `Sub(Var "x", CstI 34)` as the string `"(x - 34)"`. It has very much the same structure as an `eval` function, but takes no environment argument (because the *name* of the variable is independent if its *value*).

</br>

### 1.2 (iv)

Write an F# function `simplify : aexpr -> aexpr` to perform expression simplification. For instance, it should simplify $(x+0)$ to *x*, and simplify $(1+0)$ to 1. The more abitious student may want to simplify $(1+0)*(x+0)$ to $x$.

Hint: Pattern matching is your frind.

Hint: Don't forget the case where you cannot simplify anything.

You might consider the following simplifications, plus any others you find useful and correct:

|                     |
| :-----------------: |
| $0+e \rightarrow e$ |
| $e+0 \rightarrow e$ |
| $e-0 \rightarrow e$ |
| $1*e \rightarrow e$ |
| $e*1 \rightarrow e$ |
| $0*e \rightarrow 0$ |
| $e*0 \rightarrow 0$ |
| $e-e \rightarrow 0$ |

</br>

### 1.2 (v)

Write an F# function to perform symbolic differentiation of simple arithmetic expressions (such as `aexpr`) with respect to a single variable.

$${d \over dx}\alpha=0 \text{ (for konstante $\alpha$)}$$
$${d \over dx}x=1$$
$${d \over dx}y=0 \text{ når $y$ ikke er $x$}$$
$${d \over dx}(e_1+e_2)={d \over dx}e_1+{d \over dx}e_2$$
$${d \over dx}(e_1-e_2)={d \over dx}e_1-{d \over dx}e_2$$
$${d \over dx}(e_1*e_2)=({d \over dx}e_1)*e_2+e_1*({d \over dx}e_2)$$

</br>

---

</br>

## Exercise 1.4

This chapter has shown how to represent abstract syntax in functional langauges such as F# (using algebraic datatypes) and in object-oriented languages such as Java or C# (using a class hierarchy and composites).

</br>

### 1.4 (i)

Use Java or C# classes and methods to do what we have done using the F# datatype `aexpr` in the preceding exercises. Design a class hierarchy to represent arithmetic expressions: it could have an abstract class `Expr` with subclasses `CstI`, `Var`, and `Binop`, where the latter is itself abstract and has concrete subclasses `Add`, `Mul` and `Sub`. All classes should implement the `toString()` method to format an expression as a `String`.

The classes may be used to build an expression in abstract syntax, and then print it, as follows_

```java
Expr e = new Add(new CstI(17), new Var("z"));
System.out.println(e.toString());
```

</br>

### 1.4 (ii)

Create three more expressions in abstract syntax and print them.

</br>

### 1.4 (iii)

Extend your classes with facilities to evaluate the arithmetic expressions, that is, add a method `int eval(env)`.

</br>

### 1.4 (iv)

Add a method `Expr simplify()` that returns a new expression where algebraic simplifications have been performed, as in part (iv) of Exercise 1.2.

---

</br>

The goal of these exercises is to understand the compilation and evaluation of simple arithmetic expressions with variables and let-bindings.

</br>

## Exercise 2.1

Extend the expression langauge `expr` from Intcomp1.fs with multiple sequential let-bindings, such as this (in concrete syntax):

```let x1 = 5+7``` &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ```x2 = x1 * 2 in x1 + x2 end```

To evaluate this the right-hand side expression $5+7$ must be evaluated and bound to `x1`, and then `x1*2` must be evaluated and bound to `x2`, after which the let-body `x1+x2` is evaluated.

The new abstract syntax for `expr` might be:

```fsharp
type expr =
    | CstI of int
    | Var of string
    | Let of (string * expr) list * expr    (* CHANGED *)
    | Prim of string * expr * expr 
```

so that the `Let` constructor takes a list of binding, where a binding is a pair of a variable name and an expression. The example above would be represented as:

`Let ([("x1", ...); ("x2", ...)], Prim("+", Var "x1", Var "x2"))`

Revise the `eval` interpreter from `Intcomp1.fs` to work for the `expr` language extended with multiple sequential let-bindings.

</br>

## Exercise 2.2

Revise the function `freevars : expr -> string list` to work for the language as extended in Exercise 2.1. Note that the example expression in the beginning of Exercise 2.1 has no free variables, but `let x1 = x1+7 in x1+8 end` has the free variable `x1`, because the variable `x1` is bound only in the body `(x1+8)`, not in the right-hand side `(x1+7)`, of its own binding. There *are* programming languages where a bariable can be used in the right-hand side of its own binding, but ours is not such a language.

</br>

## Exercise 2.3

Revise the `expr`-to-`texpr` compiler `tcomp : expr -> texpr` from `Intcomp1.fs` to work for the extended `expr` langauge. There is no need to modify the ``texpr` language or the `teval` interpreter to accomodate multiple sequential let-bindings.

</br>

## Exercise 2.6 (optional)

Now modify the interpretation of te language from Exercise 2.1 so that multiple let-bindings are *simultaneous* rather than sequential. For instance,

`let x1 = 5+7` &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; `x2 = x1*2 in x1+x2 end`

should still have the abstract syntax

`Let ([("x1", ...); ("x2", ...)], Prim("+", Var "x1", Var "x2"))`

but now the interpretation is that all right-hand sides must be evaluated before any left-hand side variable gets bound to its right-hand side value.
That is, in the above expression, the occurrence of `x1` in the right-hand side of `x2` has nothing to do with the `x1` of the first binding; it is a free variable.

Revise the `eval` interpreter to work for this version of the `expr` language. The idea is that all the right-hand side expressions should be evaluated, after which all the variables are bound to those values simultaneously. Hence

`let x = 11 in let x = 22` &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; `y = x+1 in x+y end end`

should compute $12+22$ because *x* in $x+1$ is the outer *x* (and hence is 11), and *x* in $x+y$ is the inner *x* (and hence 22). In other words, in the let-binding

`let x1 = e1 ... xn = en in e end`

the scope of the variable `x1 ... xn` should be *e* not `e1 ... en`.

</br>

---
