using System.Collections;
using System.Collections.Generic;

namespace Module10.Iterator
{
    public abstract class Iterator<T> : IEnumerator<T>
    {
        T IEnumerator<T>.Current => Current();

        object IEnumerator.Current 
        { 
            get
            {
                IEnumerator<T> enumerator = this;
                return enumerator.Current;
            }
        }

        public abstract T Current();

        public abstract void Dispose();

        public abstract bool MoveNext();

        public abstract void Reset();
    }
}
