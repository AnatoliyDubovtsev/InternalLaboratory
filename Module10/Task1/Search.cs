using System;
using System.Collections.Generic;

namespace Module10.Task1
{
    public static class Search
    {
        public static int BinarySearch<T>(IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "The collection is a null");
            }
            else if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "The item is a null");
            }

            int left = 0;
            int right = collection.Count;
            int middle = (left + right) / 2;
            int count = -1;
            while(++count < collection.Count / 2)
            {
                if (item.CompareTo(collection[middle]) == 1)
                {
                    left = middle;
                }
                else if (item.CompareTo(collection[middle]) == -1)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }

                middle = (left + right) / 2;
            }

            return -1;
        }
    }
}
