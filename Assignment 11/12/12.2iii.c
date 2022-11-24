// contCompileToFile (fromFile "12/12.2iii.c") "12.2iii.out";;

// NOT OPTIMIZED
//contCompileToFile (fromFile "12/12.2iii.c") "12.2iii.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 11; CSTI 22;
//    EQ; NOT; STI; INCSP -1; GETBP; CSTI 11; CSTI 11; EQ; STI; RET 1]

// OPTIMIZED
// True 11 != 22  -> CSTI 1
// False 11 != 11  -> CSTI 0
// contCompileToFile (fromFile "12/12.2iii.c") "12.2iii.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; STI;
//    INCSP -1; GETBP; CSTI 0; STI; RET 1]

void main()
{
    int x;
    x = 11 != 22;
    x = 11 != 11;
}