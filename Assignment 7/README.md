# Programs as Data - Assignment 7

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

</br>

## PLC 8.1

Download `microc.zip` from the book homepage, unpack it to a folder `MicroC`, and build the micro-C compiler as explained in `README.TXT` step (B).

(i) As a warm-up, compile one of the micro-C examples provided, such as that in source file `ex11.c`, then run it using the abstract machine implemented in Java, as described also in step (B) of the README file. When run with command line argument 8, the program prints the 92 solutions to the eight queens problem: how to place eight queens on a chessboard so that none of them can attack any of the others.

> **Answer:** See file **ex11.out**
>
> Compilation of `ex11.c` and output from run via Machine.java can be seen below

```fsharp
compileToFile (fromFile "MicroC/examples/ex11.c") "ex11.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
   GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
   CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
   STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
   CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
   CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
   CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
   GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
   CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
   GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
   ADD; ...]
```

Run via Machine.java:

```txt
java Machine ex11.out 8       
1 5 8 6 3 7 2 4 
1 6 8 3 7 4 2 5
1 7 4 6 8 2 5 3
1 7 5 8 2 4 6 3 
2 4 6 8 3 1 7 5
2 5 7 1 3 8 6 4
2 5 7 4 1 8 6 3
2 6 1 7 4 8 3 5
2 6 8 3 1 4 7 5 
2 7 3 6 8 5 1 4
2 7 5 8 1 4 6 3
2 8 6 1 3 5 7 4
3 1 7 5 8 2 4 6 
3 5 2 8 1 7 4 6
3 5 2 8 6 4 7 1
3 5 7 1 4 2 8 6
3 5 8 4 1 7 2 6
3 6 2 5 8 1 7 4
3 6 2 7 1 4 8 5 
3 6 2 7 5 1 8 4
3 6 4 1 8 5 7 2
3 6 4 2 8 5 7 1
3 6 8 1 4 7 5 2
3 6 8 1 5 7 2 4
3 6 8 2 4 1 7 5
3 7 2 8 5 1 4 6
3 7 2 8 6 4 1 5
3 8 4 7 1 6 2 5
4 1 5 8 2 7 3 6
4 1 5 8 6 3 7 2
4 2 5 8 6 1 3 7
4 2 7 3 6 8 1 5
4 2 7 3 6 8 5 1 
4 2 7 5 1 8 6 3
4 2 8 5 7 1 3 6
4 2 8 6 1 3 5 7
4 6 1 5 2 8 3 7
4 6 8 2 7 1 3 5
4 6 8 3 1 7 5 2
4 7 1 8 5 2 6 3 
4 7 3 8 2 5 1 6
4 7 5 2 6 1 3 8
4 7 5 3 1 6 8 2
4 8 1 3 6 2 7 5
4 8 1 5 7 2 6 3
4 8 5 3 1 7 2 6
5 1 4 6 8 2 7 3
5 1 8 4 2 7 3 6
5 1 8 6 3 7 2 4
5 2 4 6 8 3 1 7
5 2 4 7 3 8 6 1
5 2 6 1 7 4 8 3
5 2 8 1 4 7 3 6
5 3 1 6 8 2 4 7
5 3 1 7 2 8 6 4 
5 3 8 4 7 1 6 2
5 7 1 3 8 6 4 2
5 7 1 4 2 8 6 3
5 7 2 4 8 1 3 6
5 7 2 6 3 1 4 8 
5 7 2 6 3 1 8 4
5 7 4 1 3 8 6 2
5 8 4 1 3 6 2 7
5 8 4 1 7 2 6 3
6 1 5 2 8 3 7 4
6 2 7 1 3 5 8 4
6 2 7 1 4 8 5 3
6 3 1 7 5 8 2 4
6 3 1 8 4 2 7 5
6 3 1 8 5 2 4 7
6 3 5 7 1 4 2 8 
6 3 5 8 1 4 2 7
6 3 7 2 4 8 1 5
6 3 7 2 8 5 1 4
6 3 7 4 1 8 2 5
6 4 1 5 8 2 7 3
6 4 2 8 5 7 1 3
6 4 7 1 3 5 2 8
6 4 7 1 8 2 5 3
6 8 2 4 1 7 5 3 
7 1 3 8 6 4 2 5
7 2 4 1 8 5 3 6
7 2 6 3 1 4 8 5
7 3 1 6 8 5 2 4
7 3 8 2 5 1 6 4
7 4 2 5 8 1 3 6
7 4 2 8 6 1 3 5
7 5 3 1 6 8 2 4
8 2 4 1 7 5 3 6 
8 2 5 3 1 7 4 6
8 3 1 6 2 5 7 4
8 4 1 3 6 2 7 5

Ran 0.251 seconds
```

(ii) Now compile the example micro-C programs `ex3.c` and `ex5.c` using functions `compileToFile` and `fromFile` from `ParseAndComp.fs` as above.
Study the generated symbolic bytecode. Write up the bytecode in a more structured way with labels only at the beginning of the line (as in this chapter). Write the corresponding micro-C code to the right of the stack machine code. Note that `ex5.c` has a nested scope (a block ... inside a function body); how is that visible in the generated code?

> **Answer:** See files **ex3.out** and **ex5.out**
>
> The block is visible in the generated code for `ex5.c` in form of a new scope for the block variables (See bytecode instruction comments).

Compile output:

```fsharp
// ex3
compileToFile (fromFile "MicroC/examples/ex3.c") "ex3.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD;
   STI; INCSP -1; INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0;
   ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0]

// ex5
compileToFile (fromFile "MicroC/examples/ex5.c") "ex5.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   GETBP; CSTI 0; ADD; LDI; STI; INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI;
   GETBP; CSTI 2; ADD; CALL (2, "L2"); INCSP -1; GETBP; CSTI 2; ADD; LDI;
   PRINTI; INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   INCSP -1; RET 0; Label "L2"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD;
   LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1]
```

Bytecode instructions written in a structured way:

```txt
ex3

LDARGS          // Load commandline args "n"
CALL 1 "L1"     // Call main(n) with 1 argument "n"
STOP            // End of main()
L1:             // main(int n) function
  INCSP 1       // Declare variable "i"
  GETBP         // Get address of "i" at offset 1 
  CSTI 1        
  ADD
  CSTI 0        // Put 0 on the stack
  STI           // Store 0 in the address of variable "i"
  INCSP -1      // Remove result of assignment
  GOTO "L3"     // Goto conditional statement i < n in while loop
L2:             // While-loop body
  GETBP         // Get address of variable "i" at offset 1
  CSTI 1        
  ADD           // Compute and put address of "i" on the stack
  LDI           // Access variable on top of stack ("i")
  PRINTI        // Print value of "i"
  INCSP -1      // Shrink stack thus removing the value of "i" from the stack
  GETBP         // Get address of variable "i" at offset 1.
  CSTI 1        
  ADD           // Compute and put address of "i" on the stack
  GETBP         // Access variable "i" at offset 1.
  CSTI 1        
  ADD           // Compute and put address of "i" on the stack
  LDI           // Load "i" fra stack
  CSTI 1        
  ADD           // Compute new value i + 1
  STI           // Store the result of i + 1 in the address of variable "i"
  INCSP -1      // Remove result from stack
  INCSP 0       // Dead code generated for block
L3:             // While-loop
  GETBP         // Get address of "i" at offset 1
  CSTI 1
  ADD
  LDI           // Access "i", put value on stack
  GETBP         // Get address of "n" at offset 0
  CSTI 0
  ADD
  LDI           // Access "n", put value on stack
  LT            // "i" < "n"
  IFNZRO "L2"   // If result of "i" < "n" is non-zero goto while-loop body
  INCSP -1      // Else remove result of previous operation from stack
  RET 0         // Return value
   
```

```txt
ex5

LDARGS
CALL 1 "L1"     // Call main(n) with 1 argument "n"
STOP            // End of main()
L1:             // main(int n) function
  INCSP 1       // Declare variable r
  GETBP         // Get address of "r" at offset 1
  CSTI 1         
  ADD 
  GETBP         // Get address of "n" at offset 0
  CSTI 0        
  ADD            
  LDI           // Access value of "n" via computed address
  STI           // Store n in the address of variable "r". Assign r = n
  INCSP -1      // Shrink stack thus removing the value of "n" from stack
  INCSP 1       // Declare local variable "r" in block
  GETBP         // Compute address of local variable "r" with offset 0 (in the new block), because it declared in a block.
  CSTI 0
  ADD           // Put the result on the stack
  LDI           // Access value of local variable "r" and put on stack
  GETBP         // Accessvalue of global variable "r"
  CSTI 2
  ADD           // Put the address of global variable "r" on stack
  CALL 2 "L2"   // Call square() with two parameters
  INCSP -1      // Shrink stack thus removing the basepointer left after call
  GETBP         // access value of L2 computation "r" at offset 2
  CSTI 2        
  ADD
  LDI           // Access "r", put value on stack
  PRINTI        // print "r"
  INCSP -1      // Shrink stack thus removing the value of "r" from the stack for the print call
  INCSP -1      // Shrink stack thus removing the value of "r" which is the local variable "r", before ending the block (local scope)
  GETBP
  CSTI 1
  ADD
  LDI           // Access "r", put value on stack
  PRINTI        // print "r"
  INCSP -1      // Shrink stack thus removing the value of "r" from the stack
  INCSP -1      // Shrink stack thus removing the value of "r" which is the local variable "r", before ending the block (local scope)
  RET 0         // Return value
L2:             // square(int i, int *rp)
  GETBP         // Get address of "rp" at offset 1
  CSTI 1
  ADD
  LDI           // Access "rp", put value on stack
  GETBP         // Get address of "i" at offset 0
  CSTI 0
  ADD
  LDI           // Access "i", put value on stack
  GETBP         // Get address of "i" at offset 0
  CSTI 0
  ADD
  LDI           // Access "i", put value on stack
  MUL           // i * i 
  STI           // Store "i * i" at address of "rp"
  INCSP -1      // Remove result of assignment
  INCSP 0       // Dead code (generated for block)
  RET 1         // Return to main()
```

Execute the compiled programs using `java Machine ex3.out 10` and similar. Note that these micro-C programs require a command line argument (an integer) when they are executed.

> **Answer:** See output below

```txt
ex3
java Machine examples/ex3.out 10
0 1 2 3 4 5 6 7 8 9 
Ran 0.033 seconds

ex5
java Machine examples/ex5.out 2
4 2 
Ran 0.002 seconds
```

Trace the execution using `java Machinetrace ex3.out 4`, and explain the stack contents and what goes on in each step of execution, and especially how the low-level bytecode instructions map to the higher-level features of MicroC. You can capture the standard output from a command prompt (in a file `ex3trace.txt`) using the Unix-style notation: `java Machinetrace ex3.out 4 > ex3trace.txt`

> **Answer:** See output below

```txt
java Machinetrace examples/ex3.out 4
[ ]{0: LDARGS}                    // Load commandline args, push 4 to stack
[ 4 ]{1: CALL 1 5}                // Call method main (5) with 1 argument, push return address (-999) and basepointer (4)
[ 4 -999 4 ]{5: INCSP 1}          // Declare i, grow stack by 1
[ 4 -999 4 0 ]{7: GETBP}          // Compute address of i; Push basepointer (2)
[ 4 -999 4 0 2 ]{8: CSTI 1}       // Push 1 to stack
[ 4 -999 4 0 2 1 ]{10: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 0 3 ]{11: CSTI 0}      // Push 0 to stack
[ 4 -999 4 0 3 0 ]{13: STI}       // Store 0 in address of i, pop address of i
[ 4 -999 4 0 0 ]{14: INCSP -1}    // Shrink stack by 1 thus removing the value of i from the stack
[ 4 -999 4 0 ]{16: GOTO 43}       // Go top step 43 (?)  
[ 4 -999 4 0 ]{43: GETBP}         // Get address of i; Push basepointer (2)
[ 4 -999 4 0 2 ]{44: CSTI 1}      // Push 1 to stack
[ 4 -999 4 0 2 1 ]{46: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 0 3 ]{47: LDI}         // Load value of i (0), pop address of i, push value to stack
[ 4 -999 4 0 0 ]{48: GETBP}       // Get the address of n; Push basepointer (2)
[ 4 -999 4 0 0 2 ]{49: CSTI 0}    // Push 0 to stack
[ 4 -999 4 0 0 2 0 ]{51: ADD}     // Add bp with 0, pop both values, push result (2 + 0 = 2)
[ 4 -999 4 0 0 2 ]{52: LDI}       // Acess the value of n (4), pop address of n, push value to stack
[ 4 -999 4 0 0 4 ]{53: LT}        // i < n (0 < 4), pop 0 and 4, push result to stack (1)
[ 4 -999 4 0 1 ]{54: IFNZRO 18}   // i < n == true goto 18, else continue
[ 4 -999 4 0 ]{18: GETBP}         // Get address of i; Push basepointer to stack
[ 4 -999 4 0 2 ]{19: CSTI 1}      // Push 1 to stack
[ 4 -999 4 0 2 1 ]{21: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 0 3 ]{22: LDI}         // Access value of i, pop address of i
[ 4 -999 4 0 0 ]{23: PRINTI}      // Print value of i (0)
[ 4 -999 4 0 0 ]{24: INCSP -1}    // Remove value of i from stack
[ 4 -999 4 0 ]{26: GETBP}         // Get the address of i; Push basepointer
[ 4 -999 4 0 2 ]{27: CSTI 1}      // Push 1 to stack
[ 4 -999 4 0 2 1 ]{29: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 0 3 ]{30: GETBP}       // Get the address of i; Push basepointer
[ 4 -999 4 0 3 2 ]{31: CSTI 1}    // Push 1 to stack
[ 4 -999 4 0 3 2 1 ]{33: ADD}     // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 0 3 3 ]{34: LDI}       // Load the value of i, pop address of i, push value of i
[ 4 -999 4 0 3 0 ]{35: CSTI 1}    // Push 1 to stack
[ 4 -999 4 0 3 0 1 ]{37: ADD}     // Add value of i with 1, pop both values, push result (0 + 1 = 1)
[ 4 -999 4 0 3 1 ]{38: STI}       // Store 1 at address of i, pop address of i
[ 4 -999 4 1 1 ]{39: INCSP -1}    // Shrink stack by 1 thus removing the value of i
[ 4 -999 4 1 ]{41: INCSP 0}       // Dead code; end of code block
[ 4 -999 4 1 ]{43: GETBP}         // Get address of i; Push basepointer
[ 4 -999 4 1 2 ]{44: CSTI 1}      // Push 1 to stack
[ 4 -999 4 1 2 1 ]{46: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 1 3 ]{47: LDI}         // Load value of i, pop address of i, push value of i (1)
[ 4 -999 4 1 1 ]{48: GETBP}       // Access address of n; Push basepointer
[ 4 -999 4 1 1 2 ]{49: CSTI 0}    // Push 0 to stack
[ 4 -999 4 1 1 2 0 ]{51: ADD}     // Add bp with 0, pop both values, push result (2 + 0 = 2)
[ 4 -999 4 1 1 2 ]{52: LDI}       // Load value of n, pop address of n, push value of n (4)
[ 4 -999 4 1 1 4 ]{53: LT}        // i < n (1 < 4), push result (1)
[ 4 -999 4 1 1 ]{54: IFNZRO 18}   // Check if not zero, goto 18
[ 4 -999 4 1 ]{18: GETBP}         // Access the address of i; Push basepointer (2)
[ 4 -999 4 1 2 ]{19: CSTI 1}      // Push 1 to stack
[ 4 -999 4 1 2 1 ]{21: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 1 3 ]{22: LDI}         // Load value of i, pop address, push value
[ 4 -999 4 1 1 ]{23: PRINTI}      // Print i
[ 4 -999 4 1 1 ]{24: INCSP -1}    // Shrink stack by 1, thus removing the value of i
[ 4 -999 4 1 ]{26: GETBP}         // Get address of i; Push basepointer (2)
[ 4 -999 4 1 2 ]{27: CSTI 1}      // Push 1 to stack
[ 4 -999 4 1 2 1 ]{29: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 1 3 ]{30: GETBP}       // Access address of i; Push basepointer
[ 4 -999 4 1 3 2 ]{31: CSTI 1}    // Push 1 to stack
[ 4 -999 4 1 3 2 1 ]{33: ADD}     // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 1 3 3 ]{34: LDI}       // Load value of i, pop address, push value
[ 4 -999 4 1 3 1 ]{35: CSTI 1}    // Push 1 to stack
[ 4 -999 4 1 3 1 1 ]{37: ADD}     // Increment i by 1, pop both values, push result (2)
[ 4 -999 4 1 3 2 ]{38: STI}       // Store new i by consuming, pop address
[ 4 -999 4 2 2 ]{39: INCSP -1}    // Shrink stack by 1, thus removing the value of i
[ 4 -999 4 2]{41: INCSP 0}        // Dead code, end of block
[ 4 -999 4 2 ]{43: GETBP}         // Accesss address of n; Push basepointer (2)
[ 4 -999 4 2 2 ]{44: CSTI 1}      // Push 1 to stack
[ 4 -999 4 2 2 1 ]{46: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 2 3 ]{47: LDI}         // Load value of i, pop address, push value
[ 4 -999 4 2 2 ]{48: GETBP}       // Access address of n; Push basepointer (2)
[ 4 -999 4 2 2 2 ]{49: CSTI 0}    // Push 0 to stack
[ 4 -999 4 2 2 2 0 ]{51: ADD}     // Add bp with 0, pop both values, push result (2 + 0 = 2)
[ 4 -999 4 2 2 2 ]{52: LDI}       // Load value of n, pop address, push value
[ 4 -999 4 2 2 4 ]{53: LT}        // i < n (2 < 4), pop both values, push result (1)
[ 4 -999 4 2 1 ]{54: IFNZRO 18}   // If not zero go to step 18, pop value
[ 4 -999 4 2 ]{18: GETBP}         // Get address of i; Push basepointer (2)
[ 4 -999 4 2 2 ]{19: CSTI 1}      // Push 1 to stack
[ 4 -999 4 2 2 1 ]{21: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 2 3 ]{22: LDI}         // Load value of i, pop address, push value (2)
[ 4 -999 4 2 2 ]{23: PRINTI}      // Print value of i (2)
2 [ 4 -999 4 2 2 ]{24: INCSP -1}  // Shrink stack by 1 thus removing the value of i
[ 4 -999 4 2 ]{26: GETBP}         // Get address of i; Push basepointer
[ 4 -999 4 2 2 ]{27: CSTI 1}      // Push 1 to stack
[ 4 -999 4 2 2 1 ]{29: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 2 3 ]{30: GETBP}       // Get address of i; Push basepointer
[ 4 -999 4 2 3 2 ]{31: CSTI 1}    // Push 1 to stack
[ 4 -999 4 2 3 2 1 ]{33: ADD}     // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 2 3 3 ]{34: LDI}       // Load value of i, pop address, push value (2)
[ 4 -999 4 2 3 2 ]{35: CSTI 1}    // Push 1 to stack
[ 4 -999 4 2 3 2 1 ]{37: ADD}     // Increment value of i by 1 (3)
[ 4 -999 4 2 3 3 ]{38: STI}       // Store new value of i, pop address
[ 4 -999 4 3 3 ]{39: INCSP -1}    // Shrink stack by, thus removing value of i
[ 4 -999 4 3 ]{41: INCSP 0}       // Dead code, end of block
[ 4 -999 4 3 ]{43: GETBP}         // Get address of i; Push basepointer (2)
[ 4 -999 4 3 2 ]{44: CSTI 1}      // Push 1 to stack
[ 4 -999 4 3 2 1 ]{46: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 3 3 ]{47: LDI}         // Load value of i, pop address, push value
[ 4 -999 4 3 3 ]{48: GETBP}       // Get address of n; Push basepointer
[ 4 -999 4 3 3 2 ]{49: CSTI 0}    // Push 0 to stack
[ 4 -999 4 3 3 2 0 ]{51: ADD}     // Add bp with 0, pop both values, push result (2 + 0 = 2)
[ 4 -999 4 3 3 2 ]{52: LDI}       // Load value of n, pop address, push value
[ 4 -999 4 3 3 4 ]{53: LT}        // i < n (3 < 4), pop both values, push result (1)
[ 4 -999 4 3 1 ]{54: IFNZRO 18}   // I not zero go to step 18, pop value
[ 4 -999 4 3 ]{18: GETBP}         // Get address of i; Push basepointer
[ 4 -999 4 3 2 ]{19: CSTI 1}      // Push 1 to stack
[ 4 -999 4 3 2 1 ]{21: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 3 3 ]{22: LDI}         // Load value of i, pop address, push value (3)
[ 4 -999 4 3 3 ]{23: PRINTI}      // Print value of i (3)
[ 4 -999 4 3 3 ]{24: INCSP -1}    // Shrink stack by 1, thus removing the value of i
[ 4 -999 4 3 ]{26: GETBP}         // Get the address of i; Push basepointer
[ 4 -999 4 3 2 ]{27: CSTI 1}      // Push 1 to stack
[ 4 -999 4 3 2 1 ]{29: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 3 3 ]{30: GETBP}       // Get the address of i; Push basepointer
[ 4 -999 4 3 3 2 ]{31: CSTI 1}    // Push 1 to stack
[ 4 -999 4 3 3 2 1 ]{33: ADD}     // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 3 3 3 ]{34: LDI}       // Load value of i, pop address, push value (3)
[ 4 -999 4 3 3 3 ]{35: CSTI 1}    // Push 1 to stack
[ 4 -999 4 3 3 3 1 ]{37: ADD}     // Increment value of i by 1, pop both values, push result (3 + 1 = 4)
[ 4 -999 4 3 3 4 ]{38: STI}       // Store new value of i, pop address
[ 4 -999 4 4 4 ]{39: INCSP -1}    // Shrink stack by 1 thus removing the value of i
[ 4 -999 4 4 ]{41: INCSP 0}       // Dead code, end of block
[ 4 -999 4 4 ]{43: GETBP}         // Get address of i; Push basepointer
[ 4 -999 4 4 2 ]{44: CSTI 1}      // Push 1 to stack
[ 4 -999 4 4 2 1 ]{46: ADD}       // Add bp with 1, pop both values, push result (2 + 1 = 3)
[ 4 -999 4 4 3 ]{47: LDI}         // Load value of i, pop address, push value
[ 4 -999 4 4 4 ]{48: GETBP}       // Get address of n; Push basepointer
[ 4 -999 4 4 4 2 ]{49: CSTI 0}    // Push 0 to stack
[ 4 -999 4 4 4 2 0 ]{51: ADD}     // Add bp with 0, pop both values, push result (2 + 0 = 2)
[ 4 -999 4 4 4 2 ]{52: LDI}       // Load value of n, pop address, push value
[ 4 -999 4 4 4 4 ]{53: LT}        // i < n (4 < 4), pop both values, push result (0)
[ 4 -999 4 4 0 ]{54: IFNZRO 18}   // If not zero, continue since value is 0, pop value
[ 4 -999 4 4 ]{56: INCSP -1}      // Shrink stack by 1
[ 4 -999 4 ]{58: RET 0}           // Pop program counter and base pointer
[ 4 ]{4: STOP}                    // Stop the machine

Ran 0.419 seconds
```

</br>

---

</br>

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

> **Answer:** See file **Comp.fs** and (for PLC 7.4) **Absyn.fs**, **Interp.fs**, **CLex.fsl** and **CPar.fsy**

Write a program to check that this works. If you are brave, try it on expressions of the form `++arr[++i]` and check that `i` and the elements of `arr` have the correct values afterwards.

> **Answer:** See files **8.3/PreIncDecTests.c** and **8.3/PreIncDecTests.out** plus below output

Run **PreIncDecTests.c**:

```fsharp
// Run with n = 0
open ParseAndRun;;
run (fromFile "8.3/PreIncDecTests.c") [0];;

1  // inc (n++)
-1 // dec (n--)
1  // incArray (++arr[0]) 
2  // doubleInc (++arr[++n])
val it: Interp.store = map [(0, 0); (1, 1); (2, 0); (3, 2); (4, 2)]
```

Compile **PreIncDecTests.c**:

```fsharp
// Compile PreIncDecTests.c
open ParseAndComp;;

compile "8.3/PreIncDecTests";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; GETBP; CSTI 0; ADD; LDI;
   CALL (1, "L2"); INCSP -1; GETBP; CSTI 0; ADD; LDI; CALL (1, "L3"); INCSP -1;
   GETBP; CSTI 0; ADD; LDI; CALL (1, "L4"); INCSP -1; GETBP; CSTI 0; ADD; LDI;
   CALL (1, "L5"); INCSP -1; INCSP 0; RET 0; Label "L2"; GETBP; CSTI 0; ADD;
   DUP; LDI; CSTI 1; ADD; STI; PRINTI; INCSP -1; CSTI 10; PRINTC; INCSP -1;
   INCSP 0; RET 0; Label "L3"; GETBP; CSTI 0; ADD; DUP; LDI; CSTI 1; SUB; STI;
   PRINTI; INCSP -1; CSTI 10; PRINTC; INCSP -1; INCSP 0; RET 0; Label "L4";
   INCSP 1; GETSP; CSTI 0; SUB; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; GETBP;
   CSTI 0; ADD; LDI; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; DUP;
   LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 0; ADD; LDI;
   PRINTI; INCSP -1; ...]
```

Run with Machine.java:

```txt
java Machine 8.3/examples.out 1
1   // inc (n++)
-1  // dec (n--)
1   // incArray (++arr[0]) 
2   // doubleInc (++arr[++n])

Ran 0.003 seconds
```

</br>

---

</br>

## PLC 8.4

Compile `ex8.c` and study the symbolic bytecode to see why it is so much slower than the handwritten 20 million iterations loop in `prog1`.

> **Answer:** See file **prog1.out** and below comments
>
> The slow version has a lot of redundant operations which are not required to compute the actual result of the while-loop.
>
> This could for instance be the different labels, computing addresses for the same variables, handling new scopes, setup functions.

```fsharp
compile "MicroC/examples/ex8";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 20000000; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 0; ADD;
   GETBP; CSTI 0; ADD; LDI; CSTI 1; SUB; STI; INCSP -1; INCSP 0; Label "L3";
   GETBP; CSTI 0; ADD; LDI; IFNZRO "L2"; INCSP -1; RET -1]

LDARGS
CALL 0 L1 // main()
STOP
L1: // main function
  INCSP 1 
  GETBP 
  CSI 0 
  ADD 
  CSTI 20000000
  STI // i=20000000
  INCSP -1
  GOTO "L3"
L2: // while
  GETBP    // Redundant operations
  CSTI 0   //
  ADD      //
  GETBP    //
  CSTI 0   //
  ADD      //
  LDI 
  CSTI 1
  SUB
  STI 
  INCSP -1
  INCSP 0
L3: // while conditional i
  GETBP
  CSTI 0
  ADD
  LDI
  IFNZRO "L2"
  INCSP -1
  RET -1
```

```txt
prog1

java Machine ./prog1         
Ran 0.297 seconds

java Machine examples/ex8.out
Ran 1.18 seconds    
```

Compile `ex13.c` and study the symbolic bytecode to see how loops and conditionals interact; describe what you see.

In a later chapter we shall see an improved micro-C compiler that generates fewer extraneous labels and jumps.

> **Answer:** See commented structured bytecode instructions and below:
>
> **Loops**
>
> The conditional is encoded as two labels; the body and the conditional expression (in that order).
> If the conditional is evaluated to true, it jumps to the body label, else the loop has finished.
> Once the body label has been evaluated, we reach the conditional label again.
>
> **|| (or)**
>
> e1 || e2 evaluates the first expression (e1), if it is true it jumps over the bytecode for the second expression (e2) (thereby skipping the evaluation of it). If e1 is false, we must evaluate e2.
>
> **&& (and)**
>
> e1 && e2 evaluates the first expression (e1), if it is false, it jumps to a label skipping the second expresion (e2). e2 is then never evaluated. If e1 is true, it must also evaluate e2

```c
// micro-C example 13 -- optimization of andalso and orelse

void main(int n) {
  int y;
  y = 1889;
  while (y < n) {
    y = y + 1;
    if (y % 4 == 0 && (y % 100 != 0 || y % 400 == 0)) 
      print y;
  }
}
```

```fsharp
compile "MicroC/examples/ex13";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
   CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
   CSTI 4; MOD; CSTI 0; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; LDI; CSTI 100;
   MOD; CSTI 0; EQ; NOT; IFNZRO "L9"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD;
   CSTI 0; EQ; GOTO "L8"; Label "L9"; CSTI 1; Label "L8"; GOTO "L6";
   Label "L7"; CSTI 0; Label "L6"; IFZERO "L4"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GOTO "L5"; Label "L4"; INCSP 0; Label "L5"; INCSP 0;
   Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
   IFNZRO "L2"; INCSP -1; RET 0]
```

```txt
LDARGS            // Load commandline arguments
CALL (1, "L1")    // Call main with 1 argument
STOP              // Halt the machine
L1:               // main(int n)
  INCSP 1         // Declare y
  GETBP           // Compute address of y and put on stack
  CSTI 1
  ADD
  CSTI 1889       // Push 1889 to stack
  STI             // Store 1889 in address of y, pop address of y
  INCSP -1        // Remove value of y from stack
  GOTO "L3"       // Jump to while condition
L2:               // While-loop body
  GETBP           // Push address of y on stack
  CSTI 1
  ADD
  GETBP           // Push address of y on stack
  CSTI 1
  ADD
  LDI             // Load value of y, pop address, push value
  CSTI 1          // Push 1 to stack
  ADD             // y + 1
  STI             // Store result of y + 1 at address of y, pop address
  INCSP -1        // Remove result of y + 1 from stack
  GETBP           // Push address of y on stack
  CSTI 1
  ADD
  LDI             // Load value of y, pop address, push value
  CSTI 4          // Push 4 on stack
  MOD             // y % 4, pop value of y and 4, push result
  CSTI 0          // Push 0 to stack
  EQ              // (y % 4) == 0, push result
  IFZERO "L7"     // If ((y % 4) == 0) = false jump to L7 (out of If-statement)
  GETBP           // Push address of y on stack
  CSTI 1 
  ADD
  LDI             // Load value of y, pop address, push value
  CSTI 100        // Push 100 to stack
  MOD             // y % 100, pop y and 100, push result
  CSTI 0          // Push 0 to stack
  EQ              // (y % 100) == 0, pop (y % 100) and 0, push result
  NOT             // !((y % 100) == 0), pop ((y % 100) == 0), push result
  IFNZRO "L9"     // If !((y % 100) == 0) is non zero jump to L9 (false or)
  GETBP           // Push address of y
  CSTI 1
  ADD
  LDI             // Load value of y, pop address, push value
  CSTI 400        // Push 400 to stack
  MOD;            // y % 400, pop y and 400, push result
  CSTI 0          // Push 0 to stack
  EQ              // (y % 400) == 0, pop (y % 400) and 0, push result
  GOTO "L8"       // Jump to L8 (true or)
L9: 
  CSTI 1          // Push 1 to stack
L8:
  GOTO "L6"       // Jump to L6 (If-body)
L7:               // Ensure out of if statement
  CSTI 0          // Push 0 to stack
L6:               // If-body
  IFZERO "L4"     // If top of stack is 0 goto L4
  GETBP           // Push address of y
  CSTI 1
  ADD
  LDI             // Load value of y, pop address, push value
  PRINTI          // Print value of y
  INCSP -1        // Remove value of y from stack
  GOTO "L5"       // Jump to L5 (out of if-block)
L4: 
  INCSP 0;        // Dead code, out of block
L5: 
  INCSP 0         // Dead code, out of block
L3:               // y < n
  GETBP           // Push address of y
  CSTI 1 
  ADD 
  LDI             // Load value stored at the address of y, pop address, push value
  GETBP           // Get address of n
  CSTI 0 
  ADD 
  LDI             // Load value stored at the address of n, pop address, push value
  LT              // y < n, pop both values for y and n, push result on stack
  IFNZRO "L2"     // If y < n != 0 goto While body (L2), pop result of LT
  INCSP -1        // Remove result of y < n from stack
  RET 0           // End of block return
```

</br>

---

</br>

## PLC 8.5

Extend the micro-C language, the abstract syntax, the lexer, the parser,
and the compiler to implement conditional expressions of the form `(e1 ? e2 : e3)`.

The compilation of `e1 ? e2 : e3` should produce code that evaluates `e2` only if `e1` is true and evaluates `e3` only if `e1` is false. The compilation scheme should be the same as for the conditional statement `if (e) stmt1 else stmt2`, but expression `e2` or expression `e3` must leave its value on the stack top if evaluated, so that the entire expression `e1 ? e2 : e3` leaves its value on the stack top.

> **Answer:** See files **Absyn**, **Interp.fs**, **CLex.fsl**, **CPar.fsy**, **Comp.fs**, and **8.5/ternary.c**, **8.5/ternary.out** (for tests)

Compilation output:

```fsharp
compile "MicroC/8.5/ternary";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 0; CSTI 2; EQ; IFZERO "L2"; CSTI 1; GOTO "L3"; Label "L2"; CSTI 1;
   CSTI 1; EQ; IFZERO "L4"; CSTI 2; GOTO "L5"; Label "L4"; CSTI 0; Label "L5";
   Label "L3"; STI; INCSP -1; GETBP; CSTI 0; ADD; LDI; PRINTI; INCSP -1;
   CSTI 10; PRINTC; INCSP -1; INCSP -1; RET -1]
```

Output of Machine.java when running `ternary.out`:

```txt
java .\MicroC\Machine.java .\MicroC\8.5\ternary.out
2 

Ran 0.002 seconds
```

</br>

---

</br>

## PLC 8.6

Extend the lexer, parser, abstract syntax and compiler to implement switch statements such as this one:

```c
switch (month) {
  case 1:
    { days = 31; }
  case 2:
    { days = 28; if (y % 4 == 0) days = 29; }
  case 3:
    { days = 31; }
}
```

Unlike in C, there should be no fall-through from one `case` to the next: after the last statement of a `case`, the code should jump to the end of the `switch` statement. The parenthesis after `switch` must contain an expression.
The value after a `case` must be an integer constant, and a case must be followed by a statement block. A `switch` with `n` cases can be compiled using `n` labels, the last of which is at the very end of the switch. For simplicity, do not implement the `break` statement or the `default` branch.

> **Answer:** See files **Absyn**, **Interp.fs**, **CLex.fsl**, **CPar.fsy**, **Comp.fs**, and **8.6/switch.c**, **8.6/switch.out** (for tests)

```fsharp
compile "MicroC/8.6/switch";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; GETBP; CSTI 2;
   ADD; CSTI 2000; STI; INCSP -1; GETBP; CSTI 0; ADD; LDI; CSTI 1; EQ;
   IFZERO "L3"; GETBP; CSTI 1; ADD; CSTI 31; STI; INCSP -1; INCSP 0; GOTO "L2";
   Label "L3"; GETBP; CSTI 0; ADD; LDI; CSTI 2; EQ; IFZERO "L4"; GETBP; CSTI 1;
   ADD; CSTI 28; STI; INCSP -1; GETBP; CSTI 2; ADD; LDI; CSTI 4; MOD; CSTI 0;
   EQ; IFZERO "L5"; GETBP; CSTI 1; ADD; CSTI 29; STI; INCSP -1; GOTO "L6";
   Label "L5"; INCSP 0; Label "L6"; INCSP 0; GOTO "L2"; Label "L4"; GETBP;
   CSTI 0; ADD; LDI; CSTI 3; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; CSTI 31; STI;
   INCSP -1; INCSP 0; GOTO "L2"; Label "L7"; Label "L2"; GETBP; CSTI 1; ADD;
   LDI; PRINTI; INCSP -1; CSTI 10; PRINTC; INCSP -1; INCSP -2; RET 0]
```

Output of Machine.java when running `switch.out`:

```txt
java .\MicroC\Machine.java .\MicroC\8.6\switch.out 2
29

Ran 0.003 seconds
```

</br>

---
