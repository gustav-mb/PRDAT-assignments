// run (fromFile "MicroC/7.2/7.2(i).c") [2];;

void main(int n){
    int *sump;
    int arr[4];
    arr[0] = 7;
    arr[1] = 13;
    arr[2] = 9;
    arr[3] = 8;
    arrsum(n, arr, sump);
    print *sump;
    println;
}

void arrsum(int n, int arr[], int *sump) {
    int sum;
    int i;
    i = 0;
    sum = 0;
    while(i < n){
        sum = arr[i] + sum;
        i = i + 1;
    }

    *sump = sum;
}

