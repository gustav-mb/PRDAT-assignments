// contCompileToFile (fromFile "12/12.2iv.c") "12.2iv.out";;

// NOT OPTIMIZED
// contCompileToFile (fromFile "12/12.2iv.c") "12.2iv.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 11; CSTI 22; SWAP; LT;
//    IFNZRO "L2"; IFZERO "L2"; CSTI 33; PRINTI; RET 0; Label "L2"; RET -1]

// OPTIMIZED
// contCompileToFile (fromFile "12/12.2iv.c") "12.2iv.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 11; CSTI 22; SWAP; LT;
//    IFNZRO "L2"; IFZERO "L2"; CSTI 33; PRINTI; RET 0; Label "L2"; RET -1]

// [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 2; GOTO "L2";
//    Label "L3"; CSTI 0; Label "L2"; STI; RET 1]

void main()
{
    if (11 <=22) print 33;
}