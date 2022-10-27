// run (fromFile "MicroC/7.3/7.3(iii).c") [7];;
// arr holding the seven numbers 1 2 1 1 1 2 0
// freq[0] is 1, freq[1] is 4, freq[2] is 2, and freq[3] is 0

void main(int n) {
    int freq[4];
    int arr[7];
    arr[0] = 1;
    arr[1] = 2;
    arr[2] = 1;
    arr[3] = 1;
    arr[4] = 1;
    arr[5] = 2;
    arr[6] = 0;

    // Initialize freq
    int i;
    for(i = 0; i < 4; i = i + 1){
        freq[i] = 0;
    }    

    // You can assume that all numbers in 
    // ns are between 0 and max, inclusive.

    histogram(n, arr, 3, freq);
    int j;
    for(j = 0; j <= 3; j = j + 1) {
        print freq[j];
    }
}

void histogram(int n, int ns[], int max, int freq[]) { 
    int i;
    
    for(i = 0; i < n; i = i + 1){
        freq[ns[i]] = freq[ns[i]] + 1; 
    }
}
