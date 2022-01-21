using Common;
using Module10.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Task6
{
    public class MySet<T> : IteratorAggregate<T>
    {
        private int _currentIndex = 0;
        private const int _defaultLength = 4;
        private int[] _keys;
        private T[] _values;

        public int Count { get => _currentIndex; }

        public MySet() : this(Array.Empty<T>()) { }

        public MySet(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            _keys = new int[_defaultLength];
            _values = new T[_defaultLength];
            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is a null");
                }

                Add(item);
            }
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is a null");
            }
            else if (Contains(item))
            {
                return;
            }
            else if (_currentIndex >= _keys.Length)
            {
                Array.Resize<int>(ref _keys, _keys.Length * 2);
                Array.Resize<T>(ref _values, _values.Length * 2);
            }

            int hashCode = item.GetHashCode();
            _keys[_currentIndex] = hashCode;
            _values[_currentIndex] = item;
            _currentIndex++;
        }

        public void Clear()
        {
            _keys = new int[_defaultLength];
            _values = new T[_defaultLength];
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is a null");
            }

            return GetItemsId(item) != -1;
        }

        public override IEnumerator<T> GetEnumerator() => new MySetIterator<T>(this);

        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is a null");
            }

            int index = GetItemsId(item);
            if (index == -1)
            {
                return false;
            }

            while (index < _currentIndex - 1 && index < _keys.Length - 1)
            {
                OperationsWithElements.SwapElements<int>(ref _keys[index], ref _keys[index + 1]);
                OperationsWithElements.SwapElements<T>(ref _values[index], ref _values[index + 1]);
                index++;
            }

            _currentIndex--;
            if (_currentIndex <= _keys.Length / 2 && _currentIndex > 0 && _keys.Length > _defaultLength)
            {
                int length = _keys.Length / 2;
                int[] newKeys = new int[length];
                T[] newValues = new T[length];
                for (int i = 0; i < length; i++)
                {
                    newKeys[i] = _keys[i];
                    newValues[i] = _values[i];
                }

                _keys = newKeys;
                _values = newValues;
            }

            return true;
        }

        //Удаляет элементы, которые не находятся сразу в двух наборах
        public void IntersectWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            int[] newKeys = new int[_defaultLength];
            T[] newValues = new T[_defaultLength];
            int index = 0;
            foreach(var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is a null");
                }
                else if (Contains(item))
                {
                    newKeys[index] = item.GetHashCode();
                    newValues[index] = item;
                    index++;
                }

                if (index == newKeys.Length)
                {
                    Array.Resize<int>(ref newKeys, newKeys.Length * 2);
                    Array.Resize<T>(ref newValues, newValues.Length * 2);
                }
            }

            _keys = newKeys;
            _values = newValues;
            _currentIndex = index;
        }

        //Добавляет все элементы из второго набора в исходный набор (исключая дубликаты)
        public void UnionWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is a null");
                }

                if (!Contains(item))
                {
                    Add(item);
                }
            }
        }

        //Удаляет указанные элементы из исходного набора
        public void ExceptWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is a null");
                }

                if (Contains(item))
                {
                    Remove(item);
                }
            }
        }

        //Удаляет все элементы, кроме тех, которые являются уникальными в одном или другом наборе
        public void SymmetricExceptWith(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection), "Collection is a null");
            }

            foreach (var item in collection)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is a null");
                }

                if (Contains(item))
                {
                    Remove(item);
                }
                else
                {
                    Add(item);
                }
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[_currentIndex];
            Array.Copy(_values, array, _currentIndex);
            return array;
        }

        private int GetItemsId(T item)
        {
            int hashCode = item.GetHashCode();
            int index = -1;
            for (int i = 0; i < _currentIndex; i++)
            {
                if (_keys[i] == hashCode)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
