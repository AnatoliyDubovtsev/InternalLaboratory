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

        public bool Remove(T item)
        {
            return false;
        }


        public sealed class Node
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
