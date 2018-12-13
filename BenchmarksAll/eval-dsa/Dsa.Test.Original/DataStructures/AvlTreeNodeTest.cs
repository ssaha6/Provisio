using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for AvlTreeNode.
    /// </summary>
    [TestFixture]
    public sealed class AvlTreeNodeTest
    {
        /// <summary>
        /// Check to make sure height property is defaulted correctly.
        /// </summary>
        [Test]
        public void HeightTest()
        {
            AvlTreeNode<int> actual = new AvlTreeNode<int>(20);
            Assert.AreEqual(1, actual.Height);
        }
    }
}