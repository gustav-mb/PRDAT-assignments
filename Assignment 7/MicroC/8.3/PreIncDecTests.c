// run (fromFile "MicroC/8.3/PreIncDecTests.c") [1];;
// compile "MicroC/8.3/PreIncDecTests";; 
// java Machine 8.3/PreIncDecTests.out 1

void main(int n) {
    inc(n);
    dec(n);
    incArray(n);
    doubleInc(n);
}

void inc(int n) {
    print ++n;
    println;
}

void dec(int n) {
    print --n;
    println;
}

void incArray(int n) {
    int arr[1];
    arr[0] = n;
    ++arr[0];
    print arr[0];
    println;
}

void doubleInc(int n) {
    int arr[2];
    arr[0] = 0;
    arr[1] = 1;
    print (++arr[++n]);
    println;
}
