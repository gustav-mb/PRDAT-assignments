# Programs as Data - Assignment 13

Non-code answers to the exercises are answered in this document!

Exercises are from the written exam in Programs as Data from the 12.-13. of January 2017.

---

</br>

## **Opgave 3 (15%): Print i micro-ML**

Kapitel 5 i *Programming Language Concepts* (PLC) introducerer evaluering af et højereordens funktionssprog. Opgaven er at udvide funktionssproget med muligheden for at printe værdier på skærmen.

Udtrykket `print e` skal evaluere `e` til en værdi `v`, som henholdsvis printes på skærmen samt returneres som resultat af udtrykket. Eksempelvis vil udtrykket `print 2` udskrive `2` på skærmen og returnere værdien `2`.

1. I den abstrakte syntaks repræsenteres funktionen `print` med `Print e`, hvor `e` er et vilkårligt udtryk. Udvid typen `expr` i `Absyn.fs` med `Print` således at eksempelvis `Print (CstI 1)` repræsenterer udtrykket der printer konstanten 1 på skærmen og returnerer værdien 1.

    > **Answer:**

2. Udvid lexer og parser, således at print er understøttet med syntaksen `print e`, hvor `print` er et nyt nøgleord, se funktionen `keyword` i filen `FunLex.fsl`.

    Vis den abstrakte syntaks for følgende eksempler

    ```fsharp
    ex1: print 1
    ex2: print ((print 1) + 3)
    ex3: let f x = x + 1 in print f end
    ```

    Vis yderligere 3 eksempler der indeholder både konstanter og funktioner.

    > **Answer:**

3. Udvid funktionen `eval` i `HigherFun.fs`, med evaluering af `Print e`. Hvis `v` er værdien af at evaluere `e`, så er resultatet af `Print e` at udskrive `v` på skærmen samt returnere `v`.

    Hint: Du kan anvende F#’s indbyggede `printfn` funktion med format streng "`%A`" til at udskrive værdierne af type value i filen `HigherFun.fs`.

    Eksempelvis giver resultatet af at evaluere eksempel ex3 ovenfor

    ```fsharp
    run(fromString ex3);;
    Closure ("f","x",Prim ("+",Var "x",CstI 1),[])
    val it : HigherFun.value = Closure ("f","x",Prim ("+",Var "x",CstI 1),[])
    ```

    > **Answer:**

</br>

---

</br>

## **Opgave 4 (15%): Pipes i micro-ML**

Kapitel 5 i *Programming Language Concepts* (PLC) introducerer evaluering af et højereordens funktionssprog og kapitel 6 introducerer polymorf typeinferens.

Opgaven er at udvide funktionssproget med "pipes", `>>` og `|>`, kendt fra F#.

Hvis `x` er et argument og `f` en funktion, så er operatoren `|>` defineret ved `x |> f = f(x)`, dvs. argumentet `x` "pipes" ind i `f`. Målet er at vi i micro-ML f.eks. kan skrive

```fsharp
let f x = x + 1 in 2 |> f end
```

Operatoren `>>` svarer til funktionssammensætning, dvs. hvis `f` og `g` er to funktioner, så er `f >> g` den sammensatte funktion defineret ved `(f >> g)(x) = g(f(x))`. Eksempelvis vil

```fsharp
let f x = x + 1 in let g x = x + 2 in f >> g end end
```

returnere en ny funktion, som alt i alt lægger 3 til dens argument.

1. Udvid lexer og parser, således at operatorerne `|>` og `>>` er understøttet. Du kan eksempelvis introducere to nye tokens `PIPERIGHT` for `|>` og `COMPOSERIGHT` for `>>`.

    Begge operatorer er venstre associative og har en præcedens svarende til lighed (token `EQ` i filen `FunPar.fsy`). Det betyder bl.a. at +, -, * og / alle har højere præcedens end `|>` og `>>`.

    Du kan genanvende den abstrakte syntaks `Prim` til de to nye operatorer, hvor operanderne er henholdsvis "`|>`" og "`>>`".

    Parseren bør give følgende abstrakte syntaks for de to eksempler ovenfor:

    ```fsharp
    Letfun ("f","x",Prim ("+",Var "x",CstI 1), 
        Prim ("|>",CstI 2,Var "f"))

    Letfun ("f","x",Prim ("+",Var "x",CstI 1),
        Letfun ("g","x",Prim ("+",Var "x",CstI 2),
            Prim (">>",Var "f",Var "g")))
    ```

    > **Answer:**

2. Anvend parseren på nedenstående 3 eksempler og forklar den genererede abstrakte syntaks udfra reglerne om præcedens og associativitet af `|>` og `>>`. Forklar yderligere, for hvert eksempel, hvorvidt du mener, at den genererede syntaks bør repræsentere et validt micro-ML program.

    ```fsharp
    (a)
    let f x = x+1 in
        let g x = x+2 in
            2 |> f >> g
        end
    end

    (b)
    let f x = x+1 in
        let g x = x+2 in
            2 |> (f >> g)
        end
    end

    (c)
    let f x = x in
        let g x = x in
            2=2 |> (f >> g)
        end
    end
    ```

    > **Answer:**

    ![fig 6.1](/appendix/fig_6.1.png)

3. Figur 6.1 på side 98 i PLC viser typeinferensregler for funktionssproget vi har udvidet med `|>` og `>>`. Vi definerer følgende to typeregler for de nye operatorer:

    ![type rules](/appendix/type_rules.png)

    Angiv et typeinferenstræ for udtrykket

    ```fsharp
    let f x = x + 1 in 3 |> f end
    ```

    Du finder to eksempler på typeinferenstræer i figur 4.8 og 4.9 på side 70 i PLC.

    ![fig 4.8-9](/appendix/fig_4.8-9.png)

    > **Answer:**

</br>

---

</br>

## **Opgave 5 (25%): Tupler i List-C**

I denne opgave udvider vi sproget List-C, som beskrevet i afsnit 10.7 i PLC, med tupler allokeret på hoben (eng. heap). Filerne der anvendes findes i `listc.zip` fra lektion 9. Spildopsamling (eng. Garbage collection) behøver ikke at fungere for at løse denne opgave.

Tupler kan have 1, 2 eller flere elementer. Figuren nedenfor angiver hvordan et tupel med *N* elementer, $v_1, ... , v_N$, repræsenteres på hoben.

![5.1(1)](/appendix/5.1(1).png)

Afsnit 10.7.3 og 10.7.4 i PLC beskriver indholdet af header, der bl.a. indeholder et tag og størrelsen af blokken som antal ord (eng. words). Et tupel fylder hermed $N + 1$ ord på hoben. Som eksempel er tuplen med elementerne `31`, `32` og `33` repræsenteret nedenfor.

![5.1(2)](/appendix/5.1(2).png)

Opgaven er at udvide List-C således at vi kan oprette (funktion tup), opdatere (funktion `upd`) og læse fra (funktion `nth`) tupler. For at simplificere implementationen mest muligt genbruger vi typen dynamic, se eksempel nedenfor.

```c
void main() 
{
    dynamic t1;
    t1 = tup(32, 33, 34);
    printTuple(t1, 3); // 32 33 34
    upd(t1, 0, 42);
    printTuple(t1, 3); // 42 33 34
    dynamic t2;
    t2 = tup(10, 11, 12, 13, 14, 15);
    upd(t2, 5, 42);
    printTuple(t2, 6); // 10 11 12 13 14 42
}

void printTuple(dynamic t, int n)
{
    int i;
    i = 0;
    while (i < n) {
        print nth(t, i);
        i = i + 1;
    }
}
```

De tre funktioner er defineret således:

* $tup(e_1, ..., e_N)$ allokerer et tupel i hoben med resultaterne af at evaluere $e_1, ..., e_N$.
* $udp(t, i, e)$ opdaterer element `i` i tuplen `t` med værdien af at evaluere `e`. Første element har indeks 0.
* $nth(t, i)$ returnerer værdien af elementet med indeks `i` i tuplen `t`.

Der er ikke noget check af at indekset `i` går ud over tuplen eller ej. Således kan der nemt laves programmer med uforudsigelig effekt. Opgaven er at implementere tupler, således at ovenstående program kan køres. Nedenfor følger en opskrift på en mulig implementation, som du kan tage udgangspunkt i:

`Absyn.fs`: En mulighed er at implementere de tre funktioner `tup`, `nth` og `upd` med et nyt primitiv `PrimN(opr, es)`, som tager en streng `opr` og en liste af udtryk `es`. Bemærk at `tup` kan have et vilkårligt antal elementer. Ligeledes kræver `upd` tre argumenter, hvilket der ikke er support for med `Prim1` eller `Prim2`.

`CPar.fsy`: Tilføj tre nye tokens således at de tre funktioner `tup`, `nth` og `upd` let genkendes. Tilføj tre grammatikregler således der genereres en knude i den abstrakte syntaks med `PrimN` for hver af de tre funktioner. Den abstrakte syntaks for `t1 = tup(32, 33, 34);` kunne f.eks. være

```fsharp
Stmt(Expr(Assign(AccVar "t1", PrimN ("tup", [CstI 32; CstI 33; CstI 34]))));
```

`CLex.fsl`: Udvid f.eks. funktionen keyword til at returnere de tre nye tokens fra `CPar.fsy` når henholdsvis `tup`, `upd` og `nth` genkendes.

`Machine.fs`: Tilføj tre nye bytekode instruktioner `TUP`, `UPD` og `NTH` til at allokere og manipulere med tuplerne:

| Instruction     | Stack before            |               | Stack after | Effect                                                            |
| --------------- | ----------------------- | ------------- |------------ | ----------------------------------------------------------------- |
| **0** `CSTI i`  | *s*                     | $\Rightarrow$ | *s*, *i*    | Push constant *i*                                                 |
| ...             |                         |               |             |                                                                   |
| **32** `TUP n`  | *s*, $v_1, ..., v_n$    | $\Rightarrow$ | *s*, *p*    | Where *n* is number of elements and *p* is pointer to tuple.      |
| **33** `UPD`    | *s*, *p*, *i*, *v*      | $\Rightarrow$ | *s*, *p*    | Element at index *i* is updated with value *v*. The pointer *p* to the tuple is left on the stack |
| **34** `NTH`    | *s*, *p*, *i*           | $\Rightarrow$ | *s*, *v*    | The value *v* at index *i* in the tuple *p* is left on the stack. |

I tabellen ovenfor er den eksisterende bytekode instruktion 0 `CSTI` medtaget til sammenligning.

`Comp.fs`: I funktionen `cExpr` oversættes de tre tilfælde af `PrimN` svarende til de tre grammatikregler der er oprettet i `CPar.fsy`. De tre bytekode instruktioner `TUP`, `UPD` og `NTH` anvendes. Bemærk funktionen `cExprs`, som bruges til at oversætte en liste af udtryk.

`listmachine.c`: Giv en tuple tagget 1. Du skal implementere de tre bytekode instruktioner `TUP`, `UPD` og `NTH`. Ved `TUP` skal du anvende allocate til at allokere tuplen i hoben samt lave kode som kopierer værdierne fra stakken til hoben. For `UPD` og `NTH` skal du huske at indekset `i` er tagget, dvs. anvende `Untag` for at få indekset ind i tuplen.

1. Vis (i udklip) de modifikationer du har lavet til filerne `Absyn.fs`, `CLex.fsl`, `CPar.fsy`, `Comp.fs`, `Machine.fs` og `listmachine.c` for at implementere tupler. Giv en skriftlig forklaring på modifikationerne.

    > **Answer:**

2. Dokumenter ved at køre ovenstående eksempelprogram, at du får følgende uddata: `32 33 34 42 33 34 10 11 12 13 14 42`.

    > **Answer:**

3. Antag at vi ønsker at implementere et primitiv `printTuple(t)`, som kan udskrive indholdet af en tupel `t` på skærmen. Resultatet af `printTuple(t)` er tuplen selv. Giv en opskrift, på niveau med ovenstående opskrift, der forklarer hvorledes du vil gøre dette. Det er tilladt at ændre repræsentationen af tupler på hoben. Det er ikke et krav, at du implementerer `printTuple`.

    > **Answer:**

</br>

---
