// contCompileToFile (fromFile "12/12.3.c") "12.3.out";;

// contCompileToFile (fromFile "12/12.3.c") "12.3.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 1; Label "L4"; CSTI 1111;
//    GOTO "L3"; Label "L4"; CSTI 2222; Label "L3"; INCSP -1; CSTI 0; Label "L2";
//    CSTI 1111; RET 0; Label "L2"; CSTI 2222; RET 0]

// contCompileToFile (fromFile "12/12.3.c") "12.3.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 1111; GOTO "L3"; Label "L4";
//    CSTI 2222; Label "L3"; INCSP -1; Label "L2"; CSTI 2222; RET 0]

void main()
{
    true ? 1111 : 2222;
    false ? 1111: 2222;
}