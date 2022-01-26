using System;
using System.Collections.Generic;

namespace Module10.Task7
{
    public class MyBinarySearchTree<T> : IComparer<T>
    {
        private bool _isCurrentEqualsRoot = false;
        private Node _root = null;
        private Node _current = null;
        private Node _temp = null;
        
        public bool UseInternalComparator { get; set; }

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(bool useInternalComparator)
        {
            UseInternalComparator = useInternalComparator;
        }

        public MyBinarySearchTree(T value, bool useInternalComparator = true)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value is a null");
            }

            _root = new Node(value);
            UseInternalComparator = useInternalComparator;
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is a null");
            }
            else if (_root == null)
            {
                _root = new Node(item);
                return;
            }

            if (!_isCurrentEqualsRoot)
            {
                _current = _root;
                _isCurrentEqualsRoot = true;
            }
            
            if (CompareElements(item, _current.Value) > 0)
            {
                if (_current.RightChild == null)
                {
                    _current.RightChild = new Node(item);
                    _current.RightChild.Parent = _current;
                }
                else
                {
                    _current = _current.RightChild;
                    Add(item);
                }
            }
            else if (CompareElements(item, _current.Value) < 0)
            {
                if (_current.LeftChild == null)
                {
                    _current.LeftChild = new Node(item);
                    _current.LeftChild.Parent = _current;
                }
                else
                {
                    _current = _current.LeftChild;
                    Add(item);
                }
            }
            else
            {
                _current.Quantity++;
            }

            _isCurrentEqualsRoot = false;
        }

        public IEnumerable<Node> Traversal(TraversalType traversalType)
        {
            var items = GetItems(_root, traversalType);
            foreach (var item in items)
            {
                yield return item;
            }
        }

        private IEnumerable<Node> GetItems(Node current, TraversalType traversalType)
        {
            if (current == null)
            {
                yield break;
            }

            if (traversalType == TraversalType.Preorder)
            {
                yield return current;
            }

            if (current.LeftChild != null)
            {
                foreach(var item in GetItems(current.LeftChild, traversalType))
                {
                    yield return item;
                }
            }

            if (traversalType == TraversalType.Inorder)
            {
                yield return current;
            }

            if (current.RightChild != null)
            {
                foreach (var item in GetItems(current.RightChild, traversalType))
                {
                    yield return item;
                }
            }

            if (traversalType == TraversalType.Postorder)
            {
                yield return current;
            }
        }

        public bool Remove(T item)
        {
            if (item == null)
            {
                return false;
            }

            bool isFound = false;
            if (!_isCurrentEqualsRoot)
            {
                _current = _root;
                _temp = _current;
                _isCurrentEqualsRoot = true;
            }

            if (CompareElements(item, _current.Value) > 0 && _current.RightChild != null)
            {
                _current = _current.RightChild;
                return Remove(item);
            }
            else if (CompareElements(item, _current.Value) < 0 && _current.LeftChild != null)
            {
                _current = _current.LeftChild;
                return Remove(item);
            }
            else if (CompareElements(item, _current.Value) == 0)
            {
                isFound = true;
                if (_current.LeftChild == null && _current.RightChild == null)
                {
                    if (_current.Parent.RightChild != null && CompareElements(item, _current.Parent.RightChild.Value) == 0)
                    {
                        _current.Parent.RightChild = null;
                    }
                    else
                    {
                        _current.Parent.LeftChild = null;
                    }
                }
                else if (_current.LeftChild == null)
                {
                    if (_current.Parent.RightChild != null && CompareElements(item, _current.Parent.RightChild.Value) == 0)
                    {
                        _current.Parent.RightChild = _current.RightChild;
                        _current.RightChild.Parent = _current.Parent;
                    }
                    else
                    {
                        _current.Parent.LeftChild = _current.RightChild;
                        _current.RightChild.Parent = _current.Parent;
                    }
                }
                else if (_current.RightChild == null)
                {
                    if (_current.Parent.LeftChild != null && CompareElements(item, _current.Parent.LeftChild.Value) == 0)
                    {
                        _current.Parent.LeftChild = _current.LeftChild;
                        _current.LeftChild.Parent = _current.Parent;
                    }
                    else
                    {
                        _current.Parent.RightChild = _current.LeftChild;
                        _current.LeftChild.Parent = _current.Parent;
                    }
                }
                else
                {
                    _temp = _current.LeftChild;
                    while (true)
                    {
                        if (_temp.RightChild == null)
                        {
                            _current.Value = _temp.Value;
                            _temp.Parent.RightChild = null;
                            break;
                        }
                        else
                        {
                            _temp = _temp.RightChild;
                        }
                    }
                }
            }

            _isCurrentEqualsRoot = false;
            return isFound;
        }

        public int Compare(T x, T y)
        {
            if (x.GetHashCode() > y.GetHashCode())
            {
                return 1;
            }
            else if (x.GetHashCode() < y.GetHashCode())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int CompareElements(T x, T y)
        {
            if (UseInternalComparator && x is IComparable<T> left)
            {
                return left.CompareTo(y);
            }
            else
            {
                return Compare(x, y);
            }
        }

        public sealed class Node
        {
            public Node LeftChild { get; set; } = null;
            public Node RightChild { get; set; } = null;
            public Node Parent { get; set; } = null;
            public T Value { get; set; }
            public int Quantity { get; set; } = 0;

            public Node(T value)
            {
                Value = value;
                Quantity++;
            }
        }
    }
}
