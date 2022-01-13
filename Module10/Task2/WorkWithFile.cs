using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Module10.Task2
{
    public static class WorkWithFile
    {
        private const string _path = @"..\..\..\..\Module10\Task2\Text.txt";

        public static Dictionary<string, int> CountWordsInText(string path = _path)
        {
            var quantityOfWords = new Dictionary<string, int>();
            string[] words = File.ReadAllText(path)
                .ToLower(new CultureInfo("en-US"))
                .Split(new char[] { ',', '.', '?', '!', '(', ')', '{', '}', '[', ']', '\"', '\'', ' ' });
            foreach(var word in words)
            {
                if (quantityOfWords.TryGetValue(word, out _))
                {
                    quantityOfWords[word]++;
                }
                else if (!string.IsNullOrEmpty(word))
                {
                    quantityOfWords.Add(word, 1);
                }
            }

            return quantityOfWords;
        }
    }
}
