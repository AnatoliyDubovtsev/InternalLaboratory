using Module10.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Task4
{
    public class MyQueueIterator<T> : Iterator<T>
    {
        private MyQueue<T> _collection;

        public MyQueueIterator(MyQueue<T> collection)
        {
            _collection = collection;
        }

        public override T Current() => _collection.Peek();

        public override bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
