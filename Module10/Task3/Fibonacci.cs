using System.Collections;
using System.Collections.Generic;

namespace Module10.Task3
{
    public class Fibonacci : IEnumerable<int>
    {
        public int Quantity { get; set; }

        public Fibonacci(int quantity = 2)
        {
            Quantity = quantity;
        }
                
        public IEnumerator<int> GetEnumerator()
        {
            int temp;
            int previous = 0;
            int current = 1;
            for (int i = 0; i < Quantity; i++)
            {
                yield return current;
                temp = previous;
                previous = current;
                current += temp;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
