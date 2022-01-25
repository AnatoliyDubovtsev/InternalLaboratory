using System;
using System.Collections.Generic;

namespace Module10.Task7
{
    public class MyBinarySearchTree<T> where T : IComparable<T>
    {
        private bool _isCurrentEqualsRoot = false;
        private Node _root = null;
        private Node _current = null;
        private Node _temp = null;

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), "Value is a null");
            }

            _root = new Node(value);
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

            if (item.CompareTo(_current.Value) > 0)
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
            else if (item.CompareTo(_current.Value) < 0)
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

            if (item.CompareTo(_current.Value) > 0 && _current.RightChild != null)
            {
                _current = _current.RightChild;
                return Remove(item);
            }
            else if (item.CompareTo(_current.Value) < 0 && _current.LeftChild != null)
            {
                _current = _current.LeftChild;
                return Remove(item);
            }
            else if (item.CompareTo(_current.Value) == 0)
            {
                isFound = true;
                if (_current.LeftChild == null && _current.RightChild == null)
                {
                    if (_current.Parent.RightChild != null && item.CompareTo(_current.Parent.RightChild.Value) == 0)
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
                    if (_current.Parent.RightChild != null && item.CompareTo(_current.Parent.RightChild.Value) == 0)
                    {
                        _current.Parent.RightChild = _current.RightChild;
                    }
                    else
                    {
                        _current.Parent.LeftChild = _current.RightChild;
                    }
                }
                else if (_current.RightChild == null)
                {
                    if (_current.Parent.LeftChild != null && item.CompareTo(_current.Parent.LeftChild.Value) == 0)
                    {
                        _current.Parent.LeftChild = _current.LeftChild;
                    }
                    else
                    {
                        _current.Parent.RightChild = _current.LeftChild;
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
