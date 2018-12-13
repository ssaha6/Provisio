using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;
using System;
//using NUnit.Framework.Extensions;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Deque.
    /// </summary>
    [TestFixture]
    public class DequeTest
    {
        /// <summary>
        /// Check to make sure the deque is in the correct state after adding an item to the deque.
        /// </summary>
        [Test]
        public void EnqueueFrontTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.EnqueueFront(10);

            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the deque is in the correct state when using implicitly the Add method
        /// of the deque.
        /// The Add method implicity uses EnqueueBack by default.
        /// </summary>
        [Test]
        public void AddTest()
        {
            Deque<int> actual = new Deque<int> { 12, 34, 23 };

            Assert.AreEqual(3, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the deque is in the correct state when adding an item to the back of the
        /// deque.
        /// </summary>
        [Test]
        public void EnqueueBackTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.EnqueueBack(120);

            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when dequeuing an item from the front on an empty
        /// deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), 
            ExpectedMessage = "Cannot dequeue an item from an empty Deque.")]
        public void DequeueFrontEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.DequeueFront();
        }

        /// <summary>
        /// Check to see that the state of the deque is correct when dequeuing the item from the front of the deque.
        /// </summary>
        [Test]
        public void DequeueFrontNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            Assert.AreEqual(10, actual.DequeueFront());
            Assert.AreEqual(12, actual.DequeueFront());
            Assert.AreEqual(13, actual.DequeueFront());
        }

        /// <summary>
        /// Check to make sure that the Count property is correct when mutating the state of the Deque.
        /// </summary>
        [Test]
        public void DequeueFrontCountNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            actual.DequeueFront();

            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the correct exception is thrown when trying to dequeue an item from the back of an
        /// empty Deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), 
            ExpectedMessage = "Cannot dequeue an item from an empty Deque.")]
        public void DequeueBackEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.DequeueBack();
        }

        /// <summary>
        /// Check to see that the correct values are returned when dequeuing the item at the back of the deque.
        /// </summary>
        [Test]
        public void DequeueBackNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            Assert.AreEqual(13, actual.DequeueBack());
            Assert.AreEqual(12, actual.DequeueBack());
            Assert.AreEqual(10, actual.DequeueBack());
        }

        /// <summary>
        /// Check to make sure that the Count property is correct when mutating the state of Deque.
        /// </summary>
        [Test]
        public void DequeueBackCountNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 12, 13 };

            actual.DequeueBack();

            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        /// Check to make sure that the correct exception is thrown when trying to peek at the item at the front
        /// of an empty Deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException),
            ExpectedMessage = "Cannot peek an item from an empty Deque.")]
        public void PeekFrontDequeEmptyTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.PeekFront();
        }

        /// <summary>
        /// Check to see that the correct value is returned when peeking at the item at the front of the Deque.
        /// </summary>
        [Test]
        public void PeekFrontNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 10, 23, 19 };

            Assert.AreEqual(10, actual.PeekFront());
        }

        /// <summary>
        /// Check to make sure that the correct exception is thrown when peeking at the item at the back of an
        /// empty Deque.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException), 
            ExpectedMessage = "Cannot peek an item from an empty Deque.")]
        public void PeekBackDequeEmptyTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.PeekBack();
        }

        /// <summary>
        /// Check to make sure that the correct value is returned when peeking at the item at the back of the 
        /// deque.
        /// </summary>
        [Test]
        public void PeekBackNonEmptyDequeTest()
        {
            Deque<int> actual = new Deque<int> { 12, 123, 89 };

            Assert.AreEqual(89, actual.PeekBack());
        }

        /// <summary>
        /// Check to make sure that calling Remove throws the correct exception. In queues Remove is not supported
        /// as it goes agains the grain of only having access to the front or back item in the queue, for Deque anyway.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NotSupportedException), ExpectedMessage = "Remove is not supported on queues.")]
        public void RemoveTest()
        {
            Deque<int> actual = new Deque<int>();

            actual.Remove(10);
        }

        /// <summary>
        /// Check to make sure contains returns the correct value. No need for extensive testing as we are calling
        /// the doubly linked lists contains method.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            Deque<int> actual = new Deque<int> { 12, 4325, 89 };

            Assert.AreEqual(true, actual.Contains(4325));
        }

        /// <summary>
        /// Check to make sure that the correct array is returned when converting the data structure to an array.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            Deque<int> actual = new Deque<int> { 123, 324, 12, 90, 23 };
            int[] expected = { 123, 324, 12, 90, 23 };

            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        /// <summary>
        /// Check to make sure the data structure is cleared after calling clear.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            Deque<int> actual = new Deque<int> { 12, 45, 321 };

            actual.Clear();

            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        /// Check to see that the Deque is in the correct state after copying the items from another collection.
        /// </summary>
        [Test]
        public void CopyConstructorTest()
        {
            List<int> original = new List<int> { 12, 123, 1, 90 };
            Deque<int> actual = new Deque<int>(original);
            Deque<int> expected = new Deque<int> { 12, 123, 1, 90 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
