// Exercise 9.2 (iii)
using System.Collections.Generic;
using System;
using System.Threading;

class LinkedList
{
    public static void Main(string[] args)
    {
        LinkedList<string> list = new LinkedList<string>();
        list.AddFirst("din far");
        Console.WriteLine("Press return to start...");
        Console.In.Read();

        for(int i = 0; i < 100000; i++) 
        {
            list.AddFirst("er rigtig flot" + i);
        }

        for(int i = 0; i < 100000; i++)
            list.RemoveFirst();

        list = new LinkedList<string>();

        for(int i = 0; i < 100; i++) 
        {
            list.AddFirst("Hej");
        }

        Thread.Sleep(5000);
    }
}
