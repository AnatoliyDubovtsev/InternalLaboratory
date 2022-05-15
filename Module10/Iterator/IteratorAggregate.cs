using System.Collections;
using System.Collections.Generic;

namespace Module10.Iterator
{
    public abstract class IteratorAggregate<T> : IEnumerable<T>
    {
        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
