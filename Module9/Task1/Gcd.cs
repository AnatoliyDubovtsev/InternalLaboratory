using Module4.Task2;
using System;
using System.Text;

namespace Module9.Task1
{
    public delegate int GcdHandle(out double elapsedMilliseconds, params int[] numbers);

    public static class Gcd
    {
        private static readonly IGcdAlgorithm[] _gcdAlgorithms = { new BinaryEuclideanAlgorithm(), new EuclideanAlgorithm() };

        public static string FindGcd()
        {
            Console.WriteLine("Please, input numbers using whitespace");
            string[] input = Console.ReadLine().Trim().Split(' ');
            int[] numbers = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                _ = int.TryParse(input[i], out numbers[i]);
            }

            GcdHandle gcdHandler = null;
            foreach (var gcdAlgorithm in _gcdAlgorithms)
            {
                gcdHandler += gcdAlgorithm.FindGcd;
            }

            Delegate[] invocationList = gcdHandler?.GetInvocationList();
            StringBuilder results = new StringBuilder();
            int[] numbersForMethod = new int[numbers.Length];
            for(int i = 0; i < invocationList?.Length; i++)
            {
                var localGcdHandler = invocationList[i] as GcdHandle;
                Array.Copy(numbers, numbersForMethod, numbers.Length);
                int gcd = localGcdHandler.Invoke(out double elapsedMilliseconds, numbersForMethod);
                Array.Clear(numbersForMethod, 0, numbersForMethod.Length);
                results.Append($"Algorithm: {invocationList[i].Method.DeclaringType.Name}; GCD: {gcd}; Time: {elapsedMilliseconds} {Environment.NewLine}");
            }

            return results.ToString();
        }
    }
}
