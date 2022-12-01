// micro-C example 13 -- optimization of andalso and orelse

// contCompileToFile (fromFile "MicroC/examples/ex13.c") "ex13.out";;

// contCompileToFile (fromFile "MicroC/examples/ex13.c") "ex13.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
//    CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
//    CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
//    CSTI 4; MOD; IFNZRO "L3"; GETBP; CSTI 1; ADD; LDI; CSTI 100; MOD;
//    IFNZRO "L4"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD; IFNZRO "L3";
//    Label "L4"; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1; Label "L3"; GETBP;
//    CSTI 1; ADD; LDI; GETBP; LDI; LT; IFNZRO "L2"; RET 1]

// contCompileToFile (fromFile "MicroC/examples/ex13.c") "ex13.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
//    CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
//    CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
//    CSTI 4; MOD; IFNZRO "L5"; GETBP; CSTI 1; ADD; LDI; CSTI 100; MOD;
//    IFZERO "L6"; CSTI 1; GOTO "L4"; Label "L6"; GETBP; CSTI 1; ADD; LDI;
//    CSTI 400; MOD; NOT; GOTO "L4"; Label "L5"; CSTI 0; Label "L4"; IFZERO "L3";
//    GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1; Label "L3"; GETBP; CSTI 1; ADD;
//    LDI; GETBP; LDI; LT; IFNZRO "L2"; RET 1]

void main(int n) {
  int y;
  y = 1889;
  while (y < n) {
    y = y + 1;
    if (y % 4 == 0 && (y % 100 != 0 || y % 400 == 0)) 
      print y;
  }
}
