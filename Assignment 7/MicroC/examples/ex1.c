// run (fromFile "MicroC/Examples/ex1.c") [17];;

void main(int n) {
  while (n > 0) {
    print n;
    n = n - 1;
  }
  println;
}
