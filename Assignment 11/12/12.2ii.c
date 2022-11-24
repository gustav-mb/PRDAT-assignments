// contCompileToFile (fromFile "12/12.2ii.c") "12.2ii.out"

// NOT OPTIMIZED
// contCompileToFile (fromFile "12/12.2ii.c") "12.2ii.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 22;
//    SWAP; LT; NOT; STI; RET 1]

// OPTIMIZED
// contCompileToFile (fromFile "12/12.2ii.c") "12.2ii.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
//    RET 1]

void main()
{
    int x;
    x = 11 <= 22;
}