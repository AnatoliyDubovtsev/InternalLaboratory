using Module3.Task2;
using Module4.Task2;
using Module6.Task2;
using Module6.Task2.Implementations;
using System;
using System.Collections.Generic;

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
        }
    }
}