// Exercise 8.5
// run (fromFile "MicroC/8.5/ternary.c") [];;
// compile "MicroC/8.5/ternary";;

// Result: 2
void main() {
    int i;
    i = (0 == 2 ? 1 : (1 == 1 ? 2 : 0));
    print i;
    println;
}