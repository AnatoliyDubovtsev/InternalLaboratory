using System;
using System.Collections.Generic;
using System.Linq;

namespace Module7.Task4
{
    public static class WorkWithIEnumerable
    {
        public static List<T> UniqueInOrder<T>(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is null or empty");
            }

            List<T> inputCollection = collection.ToList();
            for (int i = 0; i < inputCollection.Count - 1; i++)
            {
                if (inputCollection[i].Equals(inputCollection[i + 1]))
                {
                    inputCollection.RemoveAt(i--);
                }
            }

            return inputCollection;
        }
    }
}
