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
        private readonly List<T> _itemsForUser = new();
        public Node Root { get; set; } = null;
        public Node Current { get; set; } = null;

        public MyBinarySearchTree() { }

        public MyBinarySearchTree(T value)
        {
            Root = new Node(value);
        }

        public void Add(T item)
        {
            if (Root == null)
            {
                Root = new Node(item);
                return;
            }

            if (!_isCurrentEqualsRoot)
            {
                Current = Root;
                _isCurrentEqualsRoot = true;
            }

            if (item.CompareTo(Current.Value) > 0)
            {
                if (Current.RightChild == null)
                {
                    Current.RightChild = new Node(item);
                    Current.RightChild.Parent = Current;
                }
                else
                {
                    Current = Current.RightChild;
                    Add(item);
                }
            }
            else if (item.CompareTo(Current.Value) < 0)
            {
                if (Current.LeftChild == null)
                {
                    Current.LeftChild = new Node(item);
                    Current.LeftChild.Parent = Current;
                }
                else
                {
                    Current = Current.LeftChild;
                    Add(item);
                }
            }
            else
            {
                Current.Quantity++;
            }

            _isCurrentEqualsRoot = false;
        }

        public IEnumerable<T> Traversal(TraversalType traversalType)
        {
            Node current = Root;
            _itemsForUser.Clear();
            GetItems(current, traversalType);
            foreach (var item in _itemsForUser)
            {
                yield return item;
            }
        }

        private void GetItems(Node current, TraversalType traversalType)
        {
            if (traversalType == TraversalType.Preorder)
            {
                _itemsForUser.Add(current.Value);
            }

            if (current.LeftChild != null)
            {
                GetItems(current.LeftChild, traversalType);
            }

            if (traversalType == TraversalType.Inorder)
            {
                _itemsForUser.Add(current.Value);
            }

            if (current.RightChild != null)
            {
                GetItems(current.RightChild, traversalType);
            }

            if (traversalType == TraversalType.Postorder)
            {
                _itemsForUser.Add(current.Value);
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
