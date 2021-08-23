using System;
using data_structures.interfaces;
using System.Collections.Generic;

namespace data_structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < 5; i++)
                stack.Push(i);

            // foreach(var element in stack)
            // {
            //     Console.WriteLine(element);sdsd
            // }

            // for(int i = 0; i < 5; i++)
            // {
            //     Console.WriteLine(stack.Pop());
            // }

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
        }
    }
}
