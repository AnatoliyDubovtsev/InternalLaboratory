using Common;
using Module10.Iterator;
using System;
using System.Collections.Generic;

namespace Module10.Task5
{
    public class MyStack<T> : IteratorAggregate<T>
    {
        private T[] _items;
        private readonly int _defaultLength = 4;
        private int _headOfStack = -1;

        public int Count { get => _headOfStack; }
        public int InternalArraySize { get => _items.Length; }

        public MyStack() => _items = new T[_defaultLength];

        public MyStack(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be less then zero");
            }

            _items = new T[capacity];
        }

        public MyStack(IEnumerable<T> collection) : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection parameter in the constructor is a null");
            }

            foreach(var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is null");
                }
                this.Push(item);
            }
        }

        public T Pop()
        {
            T temp = Peek();
            _headOfStack--;
            if (_headOfStack < _items.Length / 2 && _headOfStack > 0 && _items.Length > _defaultLength)
            {
                T[] newArray = new T[_items.Length / 2];
                for (int i = 0; i < _headOfStack; i++)
                {
                    newArray[i] = _items[i];
                }

                _items = newArray;
            }
            return temp;
        }

        public T Peek()
        {
            if (_headOfStack < 0)
            {
                throw new InvalidOperationException("Collection is empty");
            }

            return _items[_headOfStack];
        }

        public void Push(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is a null");
            }
            else if (_headOfStack >= _items.Length - 1 && !OperationsWithElements.IsPowerOfTwo(_items.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(item), "Current item overflows default stack's size");
            }
            else if (_headOfStack >= _items.Length - 1)
            {
                Array.Resize<T>(ref _items, _items.Length * 2);
            }

            _items[++_headOfStack] = item;
        }

        public override IEnumerator<T> GetEnumerator() => new MyStackIterator<T>(this);

        public bool Contains(T item)
        {
            if (item == null)
            {
                return false;
            }

            for (int i = 0; i <= _headOfStack; i++)
            {
                if (object.Equals(_items[i], item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsEmpty() => Count == -1;

        public T[] ToArray()
        {
            T[] array = new T[_headOfStack + 1];
            for(int i = 0; i <= _headOfStack; i++)
            {
                array[i] = _items[i];
            }

            return array;
        }
    }
}
