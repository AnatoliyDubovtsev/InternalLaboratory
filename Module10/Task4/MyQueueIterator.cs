using Module10.Iterator;

namespace Module10.Task4
{
    public class MyQueueIterator<T> : Iterator<T>
    {
        private readonly MyQueue<T> _collection;
        private int _position = -1;

        public MyQueueIterator(MyQueue<T> collection)
        {
            _collection = collection;
        }

        public override T Current() => _collection.ItemByPosition(_position);

        public override void Dispose() => Reset();

        public override bool MoveNext()
        {
            if (_position < _collection.Count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public override void Reset() => _position = 0;
    }
}
