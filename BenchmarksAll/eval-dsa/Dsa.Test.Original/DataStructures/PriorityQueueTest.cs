using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for PriorityQueue.
    /// </summary>
    [TestFixture]
    public sealed class PriorityQueueTest
    {
        /// <summary>
        /// Check to see that the queue is in the correct state.
        /// </summary>
        [Test]
        public void AddTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int> { 12, 6, 3, 1, 0, 8 };

            Assert.AreEqual(6, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct value is returned.
        /// </summary>
        [Test]
        public void PeekTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int> { 12, 6, 3, 1, 0, 8 };

            Assert.AreEqual(0, actual.Peek());
        }

        /// <summary>
        /// Check to see that the correct exception is raised when peeking from an empty queue.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage="There are no items in the queue.")]
        public void PeekNoItemsInTheQueueTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>();

            actual.Peek();
        }

        /// <summary>
        /// Removes the item at the front of the queue.
        /// </summary>
        [Test]
        public void DequeueTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int> { 12, 6, 3, 1, 0, 8 };

            Assert.AreEqual(0, actual.Dequeue());
            Assert.AreEqual(1, actual.Peek());
            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when calling dequeue on an empty queue.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), ExpectedMessage="There are no items in the queue.")]
        public void DequeueEmptyQueueTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>();

            actual.Dequeue();
        }

        /// <summary>
        /// Check to see that the correct value is returned when checking for an item that is within the queue.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int> { 45, 12, 1, 0 };

            Assert.IsTrue(actual.Contains(12));
        }

        /// <summary>
        /// Check to see that the correct array is returned.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            PriorityQueue<int> queue = new PriorityQueue<int> { 12, 6, 3, 1, 0, 8 };
            int[] expected = { 0, 1, 6, 12, 3, 8 };

            int[] actual = queue.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct exception is raised as this is not supported on the queue, you must go through
        /// dequeueing etc.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void RemoveTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>();

            actual.Remove(120);
        }

        /// <summary>
        /// Check to see that the queue is in the correct state after clearing it.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>();

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that the queue is correct when using a strategy that makes the higher valued
        /// values take priority.
        /// </summary>
        [Test]
        public void MaxValuesHavePriorityTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>(Strategy.Max) { 6, 1, 8, 9, 2, 3, 7 };

            Assert.AreEqual(9, actual.Peek());
        }

        /// <summary>
        /// Check to see that the correct values are returned on enumeration.
        /// </summary>
        [Test]
        public void GetEnumeratorTest()
        {
            PriorityQueue<int> actual = new PriorityQueue<int>(Strategy.Max) { 6, 1, 8, 9, 2, 3, 7 };
            List<int> expected = new List<int> { 9, 8, 7, 1, 2, 3, 6 };

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that copying an existing collection to a priority queue results in the correct state.
        /// </summary>
        [Test]
        public void CopyConstructorTest()
        {
            List<string> collection = new List<string> { "Granville", "Barnett", "Luca", "Del", "Tongo" };
            PriorityQueue<string> actual = new PriorityQueue<string>(collection);

            Assert.AreEqual(5, actual.Count);
        }

        /// <summary>
        /// Check to see that the collection is left in the correct state when using a custom strategy and the items from an existing
        /// collection to populate the queue.
        /// </summary>
        [Test]
        public void CopyConstructorCustomStrategyTest()
        {
            List<string> collection = new List<string> { "Granville", "Barnett", "Luca", "Del", "Tongo" };
            PriorityQueue<string> actual = new PriorityQueue<string>(collection, Strategy.Max);

            Assert.AreEqual(5, actual.Count);
        }
    }
}
