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
                    throw new ArgumentNullException(nameof(collection), "Item in the input collection is null");
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
                Resize();
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

            Resize(index);
            return true;
        }

        public void IntersectWith(IEnumerable<T> collection)
        {

        }

        public void UnionWith(IEnumerable<T> collection)
        {

        }
        public void ExceptWith(IEnumerable<T> collection)
        {

        }

        public void SymmetricExceptWith(IEnumerable<T> collection)
        {

        }

        public Dictionary<int, T> ToDictionary()
        {
            Dictionary<int, T> dictionary = new Dictionary<int, T>();
            for(int i = 0; i < _currentIndex; i++)
            {
                dictionary.Add(_keys[i], _values[i]);
            }

            return dictionary;
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

        private void Resize(int index = -1)
        {
            int length;
            if (index == -1 && _currentIndex > 0 && _keys.Length <= _currentIndex)
            {
                length = _keys.Length * 2;
            }
            else if (index != -1 && _currentIndex > 0 && _keys.Length / 2 >= _currentIndex)
            {
                length = _keys.Length / 2;
            }
            else
            {
                length = _keys.Length;
            }

            int[] newKeys = new int[length];
            T[] newValues = new T[length];
            int newArr = 0;
            for (int oldArr = 0; oldArr < _keys.Length && newArr < length; oldArr++)
            {
                if (oldArr != index)
                {
                    newKeys[newArr] = _keys[oldArr];
                    newValues[newArr] = _values[oldArr];
                    newArr++;
                }
            }

            _keys = newKeys;
            _values = newValues;
        }
    }
}
