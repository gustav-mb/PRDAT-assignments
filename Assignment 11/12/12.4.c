// contCompileToFile (fromFile "12/12.4.c") "12.4.out";;

// WITHOUT COND
// contCompileToFile (fromFile "12/12.4.c") "12.4.out";;
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; Label "L2"; RET -1]

// WITH COND
// val it: Machine.instr list =
//   [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 0; GOTO "L3"; Label "L4";
//    CSTI 0; Label "L3"; IFZERO "L2"; CSTI 0; PRINTI; RET 0; Label "L2"; RET -1]

void main()
{
    if (1 && 0)
    {
        print 00;
    }
}