// run (fromFile "MicroC/7.3/7.3(ii).c") [2];;

void main(int n) {
    int arr[20];
    int i; 

    for(i = 0; i < n; i = i + 1) {
        arr[i] = 0;
    }
    
    squares(n, arr);
    int *sump;
    arrsum(n, arr, sump);
    print *sump;
    println;
}

void squares(int n, int arr[]) {
    int i;
    for(i = n; i >= 0; i = i - 1) {
        arr[i] = i * i;
    }
}

// From 7.3(i)
void arrsum(int n, int arr[], int *sump) {
    int sum;
    sum = 0;
    int i;
    for(i = 0; i < n; i = i + 1){
        sum = arr[i] + sum;
    }
    *sump = sum;
}
