// Exercise 9.2 (iii)
using System;

class Fib
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Press return to start Fib...");
        Console.In.Read();
        Fibonacci(1000000);
    }

    private static void Fibonacci(int len)
    {
        FibonacciTemp(0, 1, 1, len);
    }

    private static void FibonacciTemp(int a, int b, int counter, int len)
    {
        if (counter <= len)
        {
            Console.Write("{0} ", a);
            FibonacciTemp(b, a + b, counter + 1, len);
        }
    }
}
