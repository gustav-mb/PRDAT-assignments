// contCompileToFile (fromFile "12/12.2iii(2).c") "12.2iii(2).out";;

// NOT OPTIMIZED
// contCompileToFile (fromFile "12/12.2iii(2).c") "12.2iii(2).out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 11;
//    EQ; STI; INCSP -1; GETBP; CSTI 12; CSTI 11; EQ; STI; RET 1]

// OPTIMIZED
// contCompileToFile (fromFile "12/12.2iii(2).c") "12.2iii(2).out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
//    INCSP -1; GETBP; CSTI 0; STI; RET 1]

void main()
{
    int x;
    x = 11 == 11;
    x = 12 == 11;
}