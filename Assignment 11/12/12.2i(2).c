// contCompileToFile (fromFile "12/12.2i(2).c") "12.2i(2).out";;

// NOT OPTIMIZED
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 22; CSTI 11;
//    SWAP; LT; STI; INCSP -1; GETBP; CSTI 22; CSTI 22; SWAP; LT; STI; INCSP -1;
//    GETBP; CSTI 10; CSTI 11; SWAP; LT; STI; RET 1]

// OPTIMIZED
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
//    INCSP -1; GETBP; CSTI 0; STI; INCSP -1; GETBP; CSTI 0; STI; RET 1]

void main()
{
    int x;
    x = 22 > 11;
    x = 22 > 22;
    x = 10 > 11;
}