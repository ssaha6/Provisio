using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for SinglyLinkedListNode.
    /// </summary>
    [TestFixture]
    public sealed class SinglyLinkedListNodeTest
    {
        /// <summary>
        /// Check to see that the expected Int32 value of a node is returned.
        /// </summary>
        [Test]
        public void ValueIntTest()
        {
            SinglyLinkedListNode<int> n = new SinglyLinkedListNode<int>(10);

            Assert.AreEqual(10, n.Value);
        }

        /// <summary>
        /// Check to see that the expected string reference type value of a node is returned.
        /// </summary>
        [Test]
        public void ValueStringTest()
        {
            SinglyLinkedListNode<string> n = new SinglyLinkedListNode<string>("Granville");

            Assert.AreEqual("Granville", n.Value);
        }

        /// <summary>
        /// Check to see that the next node of a node is correct.
        /// </summary>
        [Test]
        public void NextTest()
        {
            SinglyLinkedListNode<int> n2 = new SinglyLinkedListNode<int>(20);
            SinglyLinkedListNode<int> n1 = new SinglyLinkedListNode<int>(10) {Next = n2};

            Assert.AreEqual(20, n1.Next.Value);
        }
    }
}