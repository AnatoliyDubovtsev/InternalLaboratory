using Common;
using Module10.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module10.Task4
{
    public class MyQueue<T> : IteratorAggregate<T>
    {
        private T[] _items;
        private int _currentIndex = 0;
        private int _headOfQueue = 0;
        private const int _defaultLength = 4;

        public int Count { get => _currentIndex; }
        public int InternalArraySize { get => _items.Length; }

        public MyQueue() => _items = new T[_defaultLength];

        public MyQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be less then zero");
            }

            _items = new T[capacity];
        }

        public MyQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection parameter in the constructor is a null");
            }

            _items = collection.ToArray();
            _currentIndex = _items.Length;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach(var element in _items)
            {
                yield return element;
            }
        }

        public void Enqueue(T item)
        {
            if (_items.Length < _defaultLength || _currentIndex >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(item), "Current item overflows default queue's size");
            }

            _items[_currentIndex++] = item;

            if (_currentIndex == _items.Length && _items.Length >= _defaultLength && OperationsWithElements.IsPowerOfTwo(_items.Length))
            {
                Array.Resize<T>(ref _items, _items.Length * 2);
            }
        }

        public T Dequeue()
        {
            T temp = Peek();
            _headOfQueue++;
            if (_headOfQueue > 0 && _items.Length > _defaultLength && _currentIndex - _headOfQueue <= _items.Length / 2)
            {
                T[] newArray = new T[_items.Length / 2];
                for(int oldIndex = _headOfQueue, newIndex = 0; oldIndex < _currentIndex; oldIndex++, newIndex++)
                {
                    newArray[newIndex] = _items[oldIndex];
                }

                _items = newArray;
                _currentIndex -= _headOfQueue;
                _headOfQueue = 0;
            }

            return temp;
        }

        public T Peek()
        {
            if (_items.Length == 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }
            else if (_items[_headOfQueue] == null)
            {
                throw new InvalidOperationException("Collection is empty");
            }

            return _items[_headOfQueue];
        }

        public bool Contains(T item)
        {
            for (int i = _headOfQueue; i < _currentIndex; i++)
            {
                if (object.Equals(_items[i], item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
