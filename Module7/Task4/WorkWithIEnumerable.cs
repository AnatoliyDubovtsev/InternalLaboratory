using System.Collections.Generic;
using System.Linq;

namespace Module7.Task4
{
    public static class WorkWithIEnumerable
    {
        public static List<T> UniqueInOrder<T>(IEnumerable<T> collection)
        {
            List<T> inputCollection = collection.ToList();
            for (int i = 0; i < inputCollection.Count; i++)
            {
                for (int j = i + 1; j < inputCollection.Count; j++)
                {
                    if (inputCollection[i].Equals(inputCollection[j]))
                    {
                        inputCollection.RemoveAt(i--);
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return inputCollection;
        }
    }
}
