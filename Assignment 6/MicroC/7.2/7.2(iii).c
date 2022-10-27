// run (fromFile "MicroC/7.2/7.2(iii).c") [7];;
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
    i = 0;
    while(i < 4) {
        freq[i] = 0;
        i = i + 1;
    }

    // You can assume that all numbers in 
    // ns are between 0 and max, inclusive.

    histogram(n, arr, 3, freq);
    int j;
    j = 0;
    while(j <= 3) {
        print freq[j];
        j = j + 1;
    }
}

void histogram(int n, int ns[], int max, int freq[]) { 
    int i;
    i = 0;
    while(i < n){
        freq[ns[i]] = freq[ns[i]] + 1; 
        i = i + 1;
    }
}