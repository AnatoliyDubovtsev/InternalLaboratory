using System;
using System.Text;

namespace Module2
{
    public static class Task4
    {
        public static string StringsConcatenation(string leftString, string rightString)
        {
            if (string.IsNullOrEmpty(leftString))
            {
                throw new ArgumentNullException(nameof(leftString), "Left string is null or empty");
            }
            else if (string.IsNullOrEmpty(rightString))
            {
                throw new ArgumentNullException(nameof(rightString), "Right string is null or empty");
            }

            StringBuilder resultStringBuilder = new StringBuilder(leftString + rightString);
            StringBuilder uniqueLetters = new StringBuilder();
            bool isFoundNewLetter;
            for (int i = 0; i < resultStringBuilder.Length; i++)
            {
                isFoundNewLetter = true;
                for (int j = 0; j < uniqueLetters.Length; j++)
                {
                    if (resultStringBuilder[i] == uniqueLetters[j])
                    {
                        resultStringBuilder.Remove(i--, 1);
                        isFoundNewLetter = false;
                        break;
                    }
                }

                if (isFoundNewLetter)
                {
                    uniqueLetters.Append(resultStringBuilder[i]);
                }
            }

            return resultStringBuilder.ToString();
        }
    }
}
