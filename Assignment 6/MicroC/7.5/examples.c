// run (fromFile "MicroC/7.5/examples.c") [];;

void main(int n) {
    inc(n);
    dec(n);
    incArray(n);
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
