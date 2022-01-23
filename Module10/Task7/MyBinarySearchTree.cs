using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Task7
{
    public class MyBinarySearchTree<T> where T : IComparable<T>
    {
        private Node Root { get; set; } = null;
        private Node Current { get; set; } = null;

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
                Current = Root;
                return;
            }

            if (item.CompareTo(Root.Value) > 0)
            {
                if (Root.RightChild == null)
                {
                    Root.RightChild = new Node(item);
                }
                else
                {
                    Current = Root.RightChild;
                    AddItem(item);
                }
            }
            else if (item.CompareTo(Root.Value) < 0)
            {
                if (Root.LeftChild == null)
                {
                    Root.LeftChild = new Node(item);
                }
                else
                {
                    Current = Root.LeftChild;
                    AddItem(item);
                }
            }
            else
            {
                Root.Quantity++;
            }

           // Root = Current;
        }

        private void AddItem(T item)
        {
            if (item.CompareTo(Current.Value) > 0)
            {
                if (Current.RightChild == null)
                {
                    Current.RightChild = new Node(item);
                }
                else
                {
                    Current = Current.RightChild;
                    AddItem(item);
                }
            }
            else if (item.CompareTo(Current.Value) < 0)
            {
                if (Current.LeftChild == null)
                {
                    Current.LeftChild = new Node(item);
                }
                else
                {
                    Current = Current.LeftChild;
                    AddItem(item);
                }                
            }
            else
            {
                Current.Quantity++;
            }
        }

        public bool Remove(T item)
        {
            return false;
        }


        private sealed class Node
        {
            public Node LeftChild { get; set; } = null;
            public Node RightChild { get; set; } = null;
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
