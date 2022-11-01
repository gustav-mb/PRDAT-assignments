// run (fromFile "MicroC/8.3/PreIncDecTests.c") [0];;
// compile "MicroC/8.3/PreIncDecTests";; 
// java Machine 8.3/PreIncDecTests.out 0

void main(int n) {
    inc(n);
    dec(n);
    incArray(n);
    doubleInc(n);
}

// Result with n = 0: 1
void inc(int n) {
    print ++n;
    println;
}

// Result with n = 0: -1
void dec(int n) {
    print --n;
    println;
}

// Result with n = 0: 1
void incArray(int n) {
    int arr[1];
    arr[0] = n;
    ++arr[0];
    print arr[0];
    println;
}

// Result with n = 0: 2
void doubleInc(int n) {
    int arr[2];
    arr[0] = 0;
    arr[1] = 1;
    print (++arr[++n]);
    println;
}
