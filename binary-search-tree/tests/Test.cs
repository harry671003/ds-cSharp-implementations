using System;
using binary_search_tree;
using Xunit;

namespace tests
{
    public class Test
    {
        [Fact]
        public void InsertionTest()
        {
            var tree = BuildTreeOfFive();

            Assert.Equal(5, tree.Root.Key);

            Assert.Null(tree.Root.Parent);

            var nodeTwo = tree.Root.LeftChild;
            Assert.Equal(2, nodeTwo.Key);

            var nodeSeven = tree.Root.RightChild;
            Assert.Equal(7, nodeSeven.Key);

            Assert.True(nodeSeven.Parent == tree.Root);
            Assert.True(nodeTwo.Parent == tree.Root);

            var nodeNine = nodeSeven.RightChild;
            Assert.Equal(9, nodeNine.Key);

            var nodeThree = nodeTwo.RightChild;
            Assert.Equal(3, nodeThree.Key);
        }

        [Fact]
        public void GetNextTest()
        {
            var tree = BuildTreeOfFive();

            var nodeTwo = tree.Find(2, tree.Root);

            var next = tree.GetNext(nodeTwo);
            Assert.Equal(3, next.Key);

            next = tree.GetNext(next);
            Assert.Equal(5, next.Key);

            next = tree.GetNext(next);
            Assert.Equal(7, next.Key);

            next = tree.GetNext(next);
            Assert.Equal(9, next.Key);
        }

        [Fact]
        public void RangeSearchTest()
        {
            var tree = BuildTreeOfFive();

            var result = tree.RangeSearch(1, 7);

            Assert.Equal(4, result.Count);

            Assert.Equal(2, result[0].Key);
            Assert.Equal(3, result[1].Key);
            Assert.Equal(5, result[2].Key);
            Assert.Equal(7, result[3].Key);
        }

        private BinarySearchTree<int, string> BuildTreeOfFive() 
        {
            var tree = new BinarySearchTree<int, string>();

            tree.Insert(5, "five");
            tree.Insert(2, "two");
            tree.Insert(3, "three");
            tree.Insert(7, "seven");
            tree.Insert(9, "nine");

            return tree;
        }
    }
}
