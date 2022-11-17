# Programs as Data - Assignment 9

Non-code answers to the exercises are answered in this document!

Assignments are from Programming Language Concepts (PLC), by Peter Sestoft, Springer 2017.

---

</br>

## PLC 10.1

To understand how the abstract machine and the garbage collector work and how they collaborate, answer these questions:

(i) Write 3–10 line descriptions of how the abstract machine executes each of the following instructions:

* `ADD`, which adds two integers.
* `CSTI i`, which pushes integer constant `i`
* `NIL`, which pushes a `nil` reference. What is the difference between `NIL` and `CSTI 0`?
* `IFZERO`, which tests whether an integer is zero, or a reference is `nil`.
* `CONS`
* `CAR`
* `SETCAR`

> **Answer:**
>
> **`ADD`:**
>
> To execute `ADD`, the two values at the top of the stack are popped, untagged and added together. The result is then tagged and pushed to the stack.
>
> **`CSTI i`:**
>
> To execute `CST i`, the abstract machine looks up the CSTI instruction in the program array `p` with the index of the program counter `pc` (which is post incremented afterwards by 1). The integer found is then tagged and pushed to the stack at the stack pointer plus 1.
>
> **`NIL`:**
>
> To execute `NIL`, the value at the stack pointer is set to 0 (thereby signifying a reference, since LSB is 0). Afterwards the stackpointer is incremented to prepare for the next command.
>
> **`IFZERO`:**
>
> To execute `IFZERO`, the word at the stackpointer is saved in local variable v. Then the stackpointer is decremented. First we check whether or not v is an integer. If true, we untag v and check if it is 0, If that is the case, then the next instruction will the one after the current instruction. If not, it will jump to the instruction after that (by incrementing `pc`).
>
> **`CONS`:**
>
> To execute `CONS`, the abstract machine first allocates a word pointer of size 2. It then adds the two top values from the stack to the cons cell and adds the pointer to the cons cell to the stack.
>
> **`CAR`:**
>
> To execute `CAR`, the word saved at the stackpointers location is saved. If the reference is 0, then the reference is `nil` and the program returns. If it is a valid reference, then the value at the stackpointer location will be set to the first block of the word (`p[1]`).
>
> **`SETCAR`:**
>
> To execute `SETCAR` the abstract machine first pops a value `v` from the stack. It then pops the reference to a cons cell and sets the first component to `v`.
>

(ii) Describe the result of applying each C macro `Length`, `Color` and `Paint` from Sect. 10.7.4 to a block header `ttttttttnnnn...nnnngg`, that is, a 64-bit word, as described in the source code comments.

> **Answer:**
>
> **`Length`:**
>
> The result of applying the macro Length returns the length part of the block header. We know that a block has all 0s for type (t), and by bit shifting right by 2, we remove the color bits. The bitwise AND enforces that we only obtain the block length (the ns) because of the bitmask.
>
> `tttttttt nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnngg >> 2` ->
>
> `tttttttt ttnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn` &
>
> `00000000 00111111 11111111 11111111 11111111 11111111 11111111 11111111` ->
>
> `00000000 00nnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn`
>
> **`Color`:**
>
> The result of applying the macro Color returns the color part of the block header. The bit mask 3 has the last two bits set to 1 and all others 0, which when applying bitwise AND to the header, returns the last 2 bits.
>
> `tttttttt nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnngg` &
>
> `00000000 00000000 00000000 00000000 00000000 00000000 00000000 00000011` ->
>
> `00000000 00000000 00000000 00000000 00000000 00000000 00000000 000000gg`
>
> **`Paint`:**
>
> As result of applying the mask we mantain the tag and length and ignore the last two color bits from the header. We then take the bitwise OR of the color and the "colorless header" which adds the color bits to the header.
>
> (`tttttttt nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnngg` &
>
> `11111111 11111111 11111111 11111111 11111111 11111111 11111111 11111100`) |
>
> `tttttttt nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnnn nnnnnnGG`

(iii) When does the abstract machine, or more precisely, its instruction interpretation loop, call the `allocate(…)` function? Is there any other interaction between the abstract machine (also called the mutator) and the garbage collector?

> **Answer:** It calls the `allocate(…)` function when the Abstract Machine encounters a `CONS` instruction (i.e., we need to find a free block for the block to be allocated to).

(iv) In what situation will the garbage collector's `collect(…)` function be called?

> **Answer:** The Garbage Collector only calls `colllect(…)` when failing to find a fitting free block during allocation.

</br>

---

</br>

## PLC 10.2

Add a simple mark-sweep garbage collector to `listmachine.c`, like this:

```c
void collect(int s[], int sp) {
    markPhase(s, sp);
    sweepPhase();
}
```

Your `markPhase` function should scan the abstract machine stack `s[0..sp]` and call an auxiliary function `mark(word* block)` on each non-nil heap reference in the stack, to mark live blocks in the heap. Function `mark(word* block)` should recursively mark everything reachable from the block.

The `sweepPhase` function should scan the entire heap, put white blocks on the freelist, and paint black blocks white. It should ignore blue blocks; they are either already on the freelist or they are orphan blocks which are neither used for data nor on the freelist, because they consist only of a block header, so there is no way to link them into the freelist.

This may sound complicated, but the complete solution takes less than 30 lines of C code.

Running `listmachine ex30.out 1000` should now work, also for arguments that are much larger than 1000.

Remember that the listmachine has a tracing mode `listmachine -trace ex30.out 4` so you can see the stack state just before your garbage collector crashes.

Also, calling the `heapStatistics()` function in `listmachine.c` performs some checking of the heap's consistency and reports some statistics on the number of used and free blocks and so on. It may be informative to call it before and after garbage collection, and between the mark and sweep phases.

When your garbage collector works, use it to run the list-C programs `ex35.lc` and `ex36.lc` and check that they produce the expected output (described in their source files). These programs build shared and cyclic data structures in the heap, and this may reveal flaws in your garbage collector.

> **Answer:** See file **listmachine.c** (and function `sweepPhase` below)

```c
void sweepPhase()
{
  printf("sweeping ...\n");

  word *block = heap;

  // Go through entire heap
  // Paint black blocks white, and white blocks blue
  while (inHeap(block))
  {
    if (Color(block[0]) == Black)
    {
      block[0] = Paint(block[0], White); // Set color to white
    }

    if (Color(block[0]) == White)
    {
      block[0] = Paint(block[0], Blue); // Set color to blue

      block[1] = (word)freelist; // Set next element to point at the free list
      freelist = block;          // Set the free list to point to the current free block
    }

    block += Length(block[0]) + 1; // Go to next block
  }
}
```

```txt
.\listmachine.exe .\examples\ex35.out
33 33 
marking ...
Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
sweeping ...
Heap: 168 blocks (831 words); of which 168 free (831 words, largest 5 words); 1 orphans
44 44
Used 0 cpu milli-seconds
```

```txt
1 
marking ...
Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
sweeping ...
Heap: 167 blocks (832 words); of which 167 free (832 words, largest 5 words); 1 orphans
1 
Used 0 cpu milli-seconds
```

</br>

---

</br>

## PLC 10.3

Improve the sweep phase so that it joins adjacent dead blocks into a single dead block. More precisely, when sweep finds a white (dead) block of length *`n`* at address *`p`*, it checks whether there is also a white block at address $p + 1 + n$, and if so join them into one block.

Don't forget to run the list-C programs `ex35.lc` and `ex36.lc` as in Exercise [10.2](#plc-102).

> **Answer:** See file **listmachine.c**

```txt
.\listmachine.exe .\examples\ex35.out
33 33 
marking ...
Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
sweeping ...
Heap: 168 blocks (831 words); of which 168 free (831 words, largest 5 words); 1 orphans
44 44
Used 0 cpu milli-seconds
```

```txt
.\listmachine.exe .\examples\ex36.out
1 
marking ...
Heap: 333 blocks (666 words); of which 0 free (0 words, largest 0 words); 1 orphans
sweeping ...
Heap: 167 blocks (832 words); of which 167 free (832 words, largest 5 words); 1 orphans
1
Used 0 cpu milli-seconds
```

</br>

---
