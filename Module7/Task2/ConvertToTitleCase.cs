using System;
using System.Linq;
using System.Text;

namespace Module7.Task2
{
    public static class ConvertToTitleCase
    {
        public static string ConvertStringToTitleCase(string inputString, string minorWords = null)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentNullException(nameof(inputString), "Input string is null or empty");
            }

            StringBuilder result = new StringBuilder(inputString.Length);
            string[] inputStringWords = inputString.ToLower().Split(' ');
            string[] minorWordsArray = string.IsNullOrEmpty(minorWords) ? Array.Empty<string>() : minorWords.ToLower().Split(' ');
            bool isAppended;
            for (int i = 0; i < inputStringWords.Length; i++)
            {
                isAppended = false;
                for (int j = 0; j < minorWordsArray.Length; j++)
                {
                    if (minorWordsArray.Contains(inputStringWords[i]) && i != 0)
                    {
                        result.Append(inputStringWords[i]);
                        isAppended = true;
                        break;
                    }
                }

                if (!isAppended && !char.IsUpper(inputStringWords[i][0]))
                {
                    char firstSymbol = char.ToUpper(inputStringWords[i][0]);
                    string newWord = inputStringWords[i].Remove(0, 1);
                    result.Append(newWord.Insert(0, firstSymbol.ToString()));
                }
                else if (!isAppended)
                {
                    result.Append(inputStringWords[i]);
                }

                if (i != inputStringWords.Length - 1)
                {
                    result.Append(" ");
                }
            }

            return result.ToString();
        }
    }
}
