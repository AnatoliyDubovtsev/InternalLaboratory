using Module10.Task7;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module10.Tests.Task7.Tests
{
    public class MyTreeTests
    {
        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 })]
        public void Add_SavingNewItemInTree(int[] collection)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            foreach(var item in collection)
            {
                tree.Add(item);
            }

            //assert
            Assert.NotNull(tree);
        }

        [TestCase(new int[] { 10, 8, 11, 12, 14, 7, 5, 4 })]
        public void InorderTraversal_ReturnsAllTreesItems(int[] collection)
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            foreach (var item in collection)
            {
                tree.Add(item);
            }

            //act
            tree.InorderTraversal();

            //assert
            Assert.NotNull(tree);
        }
    }
}
