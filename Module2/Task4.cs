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
                int symbolCode = (int)resultStringBuilder[i];
                if ((symbolCode < 65 || (symbolCode > 90 && symbolCode < 97) || symbolCode > 122))
                {
                    throw new ArgumentException("Input strings cannot contain symbols which are not Latin alphabet");
                }

                isFoundNewLetter = true;
                for (int j = 0; j < uniqueLetters.Length; j++)
                {
                    if (resultStringBuilder[i] == uniqueLetters[j])
                    {
                        isFoundNewLetter = false;
                        break;
                    }
                }

                if (isFoundNewLetter)
                {
                    uniqueLetters.Append(resultStringBuilder[i]);
                }
            }

            return uniqueLetters.ToString();
        }
    }
}
