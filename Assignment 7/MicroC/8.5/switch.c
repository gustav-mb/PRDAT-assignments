// Exercise 8.6
// run (fromFile "MicroC/8.5/switch.c") [];;

void main(int month) {
    int days;
    int year;
    year = 2000;

    switch (month) {
        case 1: 
            { days = 31; }
        case 2: 
            { days = 28; if (year%4==0) days = 29; }
        case 3:
            { days = 31; }
    }

    print days;
    println;
}