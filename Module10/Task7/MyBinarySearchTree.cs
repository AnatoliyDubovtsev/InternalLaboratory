using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Task7
{
    public class MyBinarySearchTree<T> where T : IComparable<T>
    {
        private bool isCurrentEqualRoot = false;
        private List<T> itemsForUser = new();
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

            if (!isCurrentEqualRoot)
            {
                Current = Root;
                isCurrentEqualRoot = true;
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

            isCurrentEqualRoot = false;
        }

        public List<T> InorderTraversal()
        {
            itemsForUser.Clear();
            Node current = Root;
            Inorder(current);
            return itemsForUser;
        }

        public List<T> PreorderTraversal()
        {
            itemsForUser.Clear();
            Node current = Root;
            Preorder(current);
            return itemsForUser;
        }

        public List<T> PostorderTraversal()
        {
            itemsForUser.Clear();
            Node current = Root;
            Postorder(current);
            return itemsForUser;
        }

        private void Postorder(Node current)
        {
            if (current.LeftChild != null)
            {
                Postorder(current.LeftChild);
            }

            if (current.RightChild != null)
            {
                Postorder(current.RightChild);
            }

            itemsForUser.Add(current.Value);
        }

        private void Preorder(Node current)
        {
            itemsForUser.Add(current.Value);

            if (current.LeftChild != null)
            {
                Preorder(current.LeftChild);
            }

            if (current.RightChild != null)
            {
                Preorder(current.RightChild);
            }
        }

        private void Inorder(Node current)
        {
            if (current.LeftChild != null)
            {
                Inorder(current.LeftChild);
            }

            itemsForUser.Add(current.Value);

            if (current.RightChild != null)
            {
                Inorder(current.RightChild);
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
