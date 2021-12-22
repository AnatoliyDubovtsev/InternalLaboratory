using System;
using System.Text;

namespace Common
{
    public static class CollectionsCommonMethods
    {
        public static void ShowCollectionItems<T>(T[] collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            int i = 0;
            foreach (var item in collection)
            {
                Console.WriteLine($"{i++} {item}");
            }
        }

        public static int FindIndexOfElement(string numberString, char element)
        {
            for(int i = 0; i < numberString.Length; i++)
            {
                if (numberString[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
