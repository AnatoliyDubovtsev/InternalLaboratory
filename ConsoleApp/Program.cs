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
            int[,] matrix = new int[,]
            {
                { 1, 2, 3 },
                { 3, 4, 5 },
                { 4, 0, 6 }
            };

            var sortMatrix = new Module3.Task2.SortMatrix();
            sortMatrix.Sorting(matrix);
        }
    }
}