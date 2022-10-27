// run (fromFile "MicroC/8.5/ternary.c") [];;

void main() {
    int i;
    i = 1;

    // i = (1 ? 1 : 2); // Doesn't work
    (1 ? 1 : 2); // works

    // (i ? print 1 : print 2);
    println;
}