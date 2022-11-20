# Programs as Data - Assignment 12

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

---

</br>

## PLC 13.1

Download `microsml.zip` from the book homepage, unpack it to a folder `Sml`, and build the micro-SML compiler as explained in `README.TXT` step A to C.

Compile the micro-SML exampleex09.smlwith all options, `-opt`, `-verbose` and `-eval`, enabled. This provides the following result:

* A file `ex09.out` being the byte code for file `ex09.sml`
* A lot of output on the console, including abstract syntax with tail call and type information, the result of evaluating the program and the assembly byte code

Now execute `ex09.out` with the bytecode machine, by running `msmlmachine ex09.out`. The result will be written to the console.

> **Answer:** See output of running `msmlmachine ex09.out` below

```txt
<output goes here>
```

Using the information above, answer the following:

1. What is the result value of running `ex09.out`?
2. What type does the result value have? (Look at the result produced by the interpreter).
3. What application calls have been annotated as tail calls? Explain how this matches the intuition behind a tail call.
4. What type has been annotated for the call sites to the functions `f` and `g`? Function `f` is called in two places, and `g` in one place.
5. What is the running time for executing the example using the evaluator, and what is the running time using the byte code `ex09.out` using `msmlmachine`?
6. Now compile the example `ex09.sml` without optimizations. How many byte code instructions did the optimization save for this small example?

> **Answer:**
>
> 1.
>
> 2.
>
> 3.
>
> 4.
>
> 5.
>
> 6.
>

```txt
<output from point 6. goes here>
```

</br>

---

</br>

## PLC 13.2

In this exercise we extend micro-SML with a pair expression `(e1, e2)`. We can create a pair, and we can access the first and second components of a pair `p` by `fst(p)` and `snd(p)`.

The example program `pair.sml` shows a use of pairs where the pair's first and second components are accessed.

```sml
val p = (1, 43)
fun f p = if fst(p) < 0 then g p else f (fst(p)-1, snd(p)) and g p = (fst(p), snd(p)-1)

begin
    print (f p)
end
```

The goal of this exercise is to implement lexing, parsing, type inference, interpretation and compilation of pairs, and then to run the program. For instance, the type annotated abstract syntax should be as follows:

```sml
Program with types:
val p = (1:int,43:int):(int * int)
fun f p =
    if (fst(p:(int * int)):int < 0:int):bool
        then g:((int * int) -> (int * int))_tail p:(int * int):(int * int)
        else f:((int * int) -> (int * int))_tail
                ((fst(p:(int * int)):int - 1:int):int,
                    snd(p:(int * int)):int):(int * int):(int * int)
and g p = (fst(p:(int * int)):int,
            (snd(p:(int * int)):int - 1:int):int):(int * int)
begin
    print(f:((int * int) -> (int * int)) p:(int * int):(int * int)):(int * int)
end
Result type: (int * int)
```

The type of `p` is `int * int`. The type of `f` is `int * int −> int * int`. The final result type is also a pair `int * int`.

Interpreting the program you get

`Result value: Result (PairV (Int -1, Int 42))`

You can use the following steps to implement support for pairs:

1. Write type rules for the primitives `fst` and `snd`, see Fig. 13.6
2. Write evaluation rules for the primitives `fst` and `snd`, see Fig. 13.7.
3. **FunLex.fsl**: Extend with token `COMMA` and unary primitives `snd` and `fst`.
4. **FunPar.fsy**: Extend with token `COMMA` and a rule for creating a pair. The concrete syntax is `(e1, e2)`.
5. **Absyn.fs**: Extend the abstract syntax with a pair expression:

    ```fsharp
    type expr<'a> =
        ...
        | Pair of expr<'a> * expr<'a> * 'a option
        ...
    ```

    Some compiler functions must also be extended to handle pair expressions: `ppProg`, `getOptExpr`, `tailcalls` and `freevars`.

6. **TypeInference.fs**: Extend the `typ` type with the new pair type:

    ```fsharp
    type typ =
        ...
        | TypP of typ * typ
    ```

    Some compiler functions must be extended: `resolveType`, `freeTypeVars`, `typeToString`, `unify`, `copyType`, `showType`, `typExpr`. Type function `typExpr` must be extended with type inference for unary primitives `fst`, `snd` and then the pair construction `Pair(e1, e2, _)` expression.

7. **HigherFun.fs**: The interpreter must be able to handle pair values:

    ```fsharp
    type value =
        ...
        | PairV of value * value
    ```

    Thus the following interpreter functions must be extended: `ppValue`, `evalExpr` and `check`.

8. **msmlmachine.c**: Two new byte code instructions are needed. One for creating a pair, `PAIR` and one for printing a pair, `PRINTP`. To simplify matters you can implement `PRINTP` assuming that pairs will always contain scalar values. This is of course not always the case.

    | Instruction     | Stack before      |               | Stack after | Effect                              |
    | --------------- | ----------------- | ------------- |------------ | ----------------------------------- |
    | **42** `Pair`   | *s*, $v_1$, $v_2$ | $\Rightarrow$ | *s*, *p*    | Create pair cell `(v1, v2)` on heap |
    | **44** `PRINTP` | *s*, *p*          | $\Rightarrow$ | *s*, *p*    | Print pair value pointed at by *p*  |

9. **ContComp.fs**: The compiler must be extended to generate code for creating a pair in the heap and for accessing the first and second component with `fst` and `snd` respectively.

    The primitives `fst` and `snd` are easily done using `CAR` and `CDR` in the bytecode. A pair is created using the new byte code instruction `PAIR`. The compiler function `cExpr` must be extended.

10. **Machine.fs**: The byte code instructions `PRINTP` and `PAIR` must be added. You have to assign unique instruction codes to `PRINTP` and `PAIR` that match with same instructions in `msmlmachine.c`.

> **Answer:**

</br>

---

</br>

## PLC 13.3

> **Answer:**

</br>

---
