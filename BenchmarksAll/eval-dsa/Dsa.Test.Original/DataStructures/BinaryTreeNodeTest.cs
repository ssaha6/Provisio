using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// BinaryTreeNode(Of T) tests.
    /// </summary>
    [TestFixture]
    public sealed class BinaryTreeNodeTest
    {
        /// <summary>
        /// Check to see that a BinaryTreeNode is initialized to the correct values.
        /// </summary>
        [Test]
        public void BinaryTreeNodeConstructorTest()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(10);
            
            Assert.AreEqual(10, node.Value);
            Assert.IsNull(node.Left);
            Assert.IsNull(node.Right);
        }

        /// <summary>
        /// Check to see that child nodes are appended properly.
        /// </summary>
        [Test]
        public void AssignNodeTest()
        {
            BinaryTreeNode<int> node = new BinaryTreeNode<int>(5) {Right = new BinaryTreeNode<int>(10)};

            Assert.AreEqual(10, node.Right.Value);
        }
    }
}