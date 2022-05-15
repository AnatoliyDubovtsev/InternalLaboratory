using System;
using System.Text;

namespace Module7.Task5
{
    public static class WorkWithStrings
    {
        public static string ReverseWords(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "String is null or empty");
            }

            if (input.StartsWith(' ') || input.EndsWith(' '))
            {
                input = input.Trim();
            }

            StringBuilder result = new(input.Length);
            string[] words = input.Split(' ');
            for (int i = words.Length - 1; i >= 0; i--)
            {
                result.Append(words[i]);
                if (i != 0)
                {
                    result.Append(' ');
                }
            }

            return result.ToString();
        }
    }
}
