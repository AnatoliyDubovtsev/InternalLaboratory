using Module10.Iterator;

namespace Module10.Task5
{
    public class MyStackIterator<T> : Iterator<T>
    {
        private readonly MyStack<T> _collection;
        private readonly T[] _array;
        private int _position = -1;

        public MyStackIterator(MyStack<T> collection)
        {
            _collection = collection;
            _array = collection.ToArray();
        }

        public override T Current() => _array[_position];

        public override void Dispose() => Reset();

        public override bool MoveNext()
        {
            if (_position < _array.Length - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            _position = 0;
        }
    }
}
