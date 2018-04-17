using System;
using binary_search_tree;
using Xunit;

namespace tests
{
    public class Test
    {
        [Fact]
        public void InsertionOrderTest()
        {
            // Arrange.
            var bs = new BinarySearchTree<int, string>();

            // Act.
            bs.Insert(5, "one");
            bs.Insert(2, "two");
            bs.Insert(3, "three");
            bs.Insert(7, "seven");
            bs.Insert(9, "nine");

            // Assert.
            Assert.Equal(5, bs.Root.Key);

            Assert.Null(bs.Root.Parent);

            var nodeTwo = bs.Root.LeftChild;
            Assert.Equal(2, nodeTwo.Key);

            var nodeSeven = bs.Root.RightChild;
            Assert.Equal(7, nodeSeven.Key);

            Assert.True(nodeSeven.Parent == bs.Root);
            Assert.True(nodeTwo.Parent == bs.Root);

            var nodeNine = nodeSeven.RightChild;
            Assert.Equal(9, nodeNine.Key);

            var nodeThree = nodeTwo.RightChild;
            Assert.Equal(3, nodeThree.Key);
        }


    }
}
