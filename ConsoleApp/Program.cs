using Module10.Task2;
using Module3.Task2;
using Module4.Task2;
using Module6.Task2;
using Module6.Task2.Implementations;
using Module6.Task3;
using Module9.Task1;
using Module9.Task3;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Module 2, Task 5
            /*Console.Write("Enter the number -> ");
            int number = int.Parse(Console.ReadLine());
            int newNumber = Task5.FindNextBiggerNumber(number, out double elapsedMilliseconds);
            Console.WriteLine($"New number: {newNumber}, Elapsed time: {elapsedMilliseconds} ms");*/

            // Module 3, Task 2
            /*int[,] matrix = new int[,]
            {
                { 1, 2, 3 },
                { 3, 4, 5 },
                { 4, 0, 6 }
            };

            ISortingStrategy sortingStrategy = SortingConfiguration.ChooseSortingStrategy();
            SortMatrix sortMatrix = new(sortingStrategy);
            SortingConfiguration.ChooseTypeOfSorting(out bool isAscendingSorting);
            sortMatrix.Sorting(matrix, isAscendingSorting);*/

            // Module 4, Task 2
            /*Console.WriteLine("Euclidean algorithm");
            IGcdAlgorithm gcdAlgorithm = new EuclideanAlgorithm();
            int gcdEuclideanAlgorithm = gcdAlgorithm.FindGcd(out double elapsedMillisecondsEuclideanAlgorithm, new int[]
                { 1375800, 9876090, 3859650, 456000, 756890, 957000 });
            Console.WriteLine($"GCD: {gcdEuclideanAlgorithm}, Time: {elapsedMillisecondsEuclideanAlgorithm}");

            gcdAlgorithm = new BinaryEuclideanAlgorithm();
            int gcdBinaryEuclideanAlgorithm = gcdAlgorithm.FindGcd(out double elapsedMillisecondsBinaryEuclideanAlgorithm, new int[]
                { 1375800, 9876090, 3859650, 456000, 756890, 957000 });
            Console.WriteLine($"GCD: {gcdBinaryEuclideanAlgorithm}, Time: {elapsedMillisecondsBinaryEuclideanAlgorithm}");*/

            // Module 6, Task 2

            /*List<Shape> shapes = new List<Shape>
            {
                new Circle("Circle", 5),
                new Square("Square", 5),
                new Triangle("Triangle", 10, 5),
                new Rectangle("Rectangle", 10, 5)
            };
            IVisitor visitor = new ShapesAreaVisitor();
            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.Area(visitor));
            }*/

            // Module 6, Task 3
            /*Console.WriteLine("Input polynomial. Use whitespace to divide coefficients. " + Environment.NewLine + "Example: a * x^0 + b * x^1 + c * x^2 + ... + d * x^n");
            //string input1 = Console.ReadLine();
            string input1 = "1 2 3 4 5 6 7 8";
            int[] array1 = Polynomial.ConvertToArray(input1);
            //string input2 = Console.ReadLine();
            string input2 = "1 -2 3 4 5 6";
            int[] array2 = Polynomial.ConvertToArray(input2);
            Polynomial polynomial1 = new Polynomial(array1);
            Polynomial polynomial2 = new Polynomial(array2);
            Polynomial plus = polynomial1 + polynomial2;
            Console.WriteLine("1: " + polynomial1.ToString());
            Console.WriteLine("2: " + polynomial2.ToString());
            Console.WriteLine("1 + 2: " + plus.ToString());*/

            // Module 9, Task 1
            //Console.WriteLine(Gcd.FindGcd());

            // Module 9, Task 2
            //Console.WriteLine(Module9.Task2.SortingMatrix.Sort(new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 5, 6 } }, false));
            //Console.WriteLine(Module9.Task2.SortingMatrix.Sort(new int[,] { { 1, 2, 3 }, { 4, 0, 8 }, { 6, 15, 6 } }, true));

            //Module 9, Task 3
            //ExampleRun.Task3Run();

            //Module 10, Task 2
            //WorkWithFile.CountWordsInText();

            //Module 2, Task 6
            /*int[] arr1 = new int[1_000_000_000];
            int[] arr2 = new int[arr1.Length];
            Random rand = new Random();
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(0, arr1.Length);
                arr2[i] = arr1[i];
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _ = Module2.Task6.FilterDigitUsingList(arr1, 7);
            stopwatch.Stop();
            Console.WriteLine($"With list: {stopwatch.ElapsedMilliseconds}");
            
            stopwatch.Reset();
            
            stopwatch.Start();
            _ = Module2.Task6.FilterDigit(arr1, 7);
            stopwatch.Stop();
            Console.WriteLine($"With array: {stopwatch.ElapsedMilliseconds}");
            
            Console.ReadLine();*/
        }
    }
}