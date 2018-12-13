using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for DoublyLinkedListNode.
    /// </summary>
    [TestFixture]
    public sealed class DoublyLinkedListNodeTest
    {
        /// <summary>
        /// Check to see that a node is created and its state initialized correctly.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            DoublyLinkedListNode<int> n = new DoublyLinkedListNode<int>(10);

            Assert.AreEqual(10, n.Value);
            Assert.IsNull(n.Previous);
            Assert.IsNull(n.Next);
        }
    }
}