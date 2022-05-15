using Module10.Iterator;

namespace Module10.Task6
{
    public class MySetIterator<T> : Iterator<T>
    {
        private readonly T[] _values;
        private int _position = -1;

        public MySetIterator(MySet<T> collection)
        {
            _values = collection.ToArray();
        }

        public override T Current() => _values[_position];

        public override void Dispose() => Reset();

        public override bool MoveNext() => _position++ < _values.Length - 1;

        public override void Reset() => _position = 0;
    }
}
