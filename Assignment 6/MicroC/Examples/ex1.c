// run (fromFile "MicroC/Examples/ex1.c") [17];;

void main(int n) {
  while (n > 0) {
    print n;
    n = n - 1;
  }
  println;
}

// Exercise 7.3
// void main(int n) {
//   int i;
//   for(i = n; i > 0; i = i - 1) {
//     print i;
//   }
//   println;
// }
