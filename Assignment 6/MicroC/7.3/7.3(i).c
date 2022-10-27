// run (fromFile "MicroC/7.3/7.3(i).c") [2];;

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
    int i;
    int sum;
    sum = 0;

    for(i = 0; i < n; i = i + 1) {
        sum = arr[i] + sum;
    }

    *sump = sum;
}
