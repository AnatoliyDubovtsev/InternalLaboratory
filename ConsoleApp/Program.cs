using System;
using Module2;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Module 2, Task 5
            Console.Write("Enter the number -> ");
            int number = int.Parse(Console.ReadLine());
            int newNumber = Task5.FindNextBiggerNumber(number, out double elapsedMilliseconds);
            Console.WriteLine($"New number: {newNumber}, Elapsed time: {elapsedMilliseconds} ms");
        }
    }
}
