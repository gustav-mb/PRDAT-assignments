// Exercise 8.6
// run (fromFile "MicroC/8.6/switch.c") [2];;
// compile "MicroC/8.6/switch"
// java .\MicroC\Machine.java .\MicroC\8.6\switch.out 2

void main(int month) {
    int days;
    int year;
    year = 2000;

    switch (month) {
        case 1: 
            { days = 31; }
        case 2: 
            { days = 28; if (year % 4 == 0) days = 29; }
        case 3:
            { days = 31; }
    }

    print days;
    println;
}