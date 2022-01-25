using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Task7
{
    public class MyBinarySearchTree<T> where T : IComparable<T>
    {
        private bool _isCurrentEqualsRoot = false;
        private Node _root = null;
        private Node _current = null;

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(T value)
        {
            _root = new Node(value);
        }

        public void Add(T item)
        {
            if (_root == null)
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
            return false;
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
