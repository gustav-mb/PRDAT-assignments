// run (fromFile "MicroC/7.2/7.2(ii).c") [2];;

void main(int n) {
    int arr[20];
    int i; 
    i = 0;

    while(i < n) {
        arr[i] = 0;
        i = i + 1;
    }
    
    squares(n, arr);
    int *sump;
    arrsum(n, arr, sump);
    print *sump;
    println;
}

void squares(int n, int arr[]) {
    while(n >= 0){
        arr[n] = n*n;
        n = n - 1;
    }
}

// From 7.2(i)
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