using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for DoublyLinkedList.
    /// </summary>
    [TestFixture]
    public sealed class DoublyLinkedListTest
    {
        /// <summary>
        /// Check to see if CollectionAssert.AreEqual passes for twocollection containing the same values.
        /// </summary>
        [Test]
        public void ItemsAreEqualTest()
        {
            DoublyLinkedList<int> actual = new DoublyLinkedList<int> {10, 20};
            DoublyLinkedList<int> expected = new DoublyLinkedList<int> {10, 20};

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that AddLast adds a node onto the tail of the list.
        /// </summary>
        [Test]
        public void AddLastTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            Assert.AreEqual(10, dll.Head.Value);
            Assert.AreEqual(20, dll.Head.Next.Value);
            Assert.AreEqual(10, dll.Head.Next.Previous.Value);
            Assert.AreEqual(30, dll.Tail.Value);
            Assert.AreEqual(20, dll.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that AddFirst adds a node to the head of the linked list.
        /// </summary>
        [Test]
        public void AddFirstTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            dll.AddFirst(10);
            dll.AddFirst(20);

            Assert.AreEqual(20, dll.Head.Value);
        }

        /// <summary>
        /// Check to see that a call to AddAfter raises the correct exception when there are no nodes to add after.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddAfterNoNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            dll.AddAfter(dll.Head, 10);
        }

        /// <summary>
        /// Check to see that the correct exception is raised when adding after a null node.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfterNullNodeTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.AddAfter(null, 10);
        }

        /// <summary>
        /// Check to see that calling AddAfter passing in the tail node updates the internal tail node pointer.
        /// </summary>
        [Test]
        public void AddAfterTailTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.AddAfter(dll.Head, 20);

            Assert.AreEqual(20, dll.Tail.Value);
            Assert.AreEqual(10, dll.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that calling AddAfter passing in a node that isn't the tail results in the expected state.
        /// </summary>
        [Test]
        public void AddAfterTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.AddAfter(dll.Head.Next, 25);

            Assert.AreEqual(25, dll.Head.Next.Next.Value);
            Assert.AreEqual(20, dll.Head.Next.Next.Previous.Value);
            Assert.AreEqual(30, dll.Head.Next.Next.Next.Value);
            Assert.AreEqual(25, dll.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that calling AddBefore results in the node being placed in the correct position in the DoublyLinkedList when
        /// adding before the head node.
        /// </summary>
        [Test]
        public void AddBeforeHeadTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.AddBefore(dll.Head, 5);

            Assert.AreEqual(5, dll.Head.Value);
            Assert.AreEqual(10, dll.Head.Next.Value);
            Assert.AreEqual(5, dll.Head.Next.Previous.Value);
        }

        /// <summary>
        /// Check to see that when calling AddBefore the node is placed in the correct position within the linked list.
        /// </summary>
        [Test]
        public void AddBeforeTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 30};

            dll.AddBefore(dll.Head.Next, 20);

            Assert.AreEqual(20, dll.Head.Next.Value);
            Assert.AreEqual(10, dll.Head.Next.Previous.Value);
            Assert.AreEqual(30, dll.Head.Next.Next.Value);
            Assert.AreEqual(20, dll.Tail.Previous.Value);
        }

        /// <summary>
        /// Check to see that calling AddBefore when the list is empty results in the correct exception being raised.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddBeforeEmptyListTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            dll.AddBefore(dll.Head, 10);
        }

        /// <summary>
        /// Check to see that a call to AddBefore when passing in a null node raises the correct exception.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddBeforeNullNode()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.AddBefore(dll.Head.Next, 20);
        }

        /// <summary>
        /// Check to see that the IsEmpty method returns the correct value.
        /// </summary>
        [Test]
        public void IsEmptyTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            Assert.IsTrue(dll.IsEmpty());
        }

        /// <summary>
        /// Check to see that a call to RemoveLast on a non empty list results in the expected behaviour.
        /// </summary>
        [Test]
        public void RemoveLastTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.RemoveLast();

            Assert.IsTrue(dll.IsEmpty());
            Assert.IsFalse(dll.RemoveLast());
            Assert.IsNull(dll.Tail);
        }

        /// <summary>
        /// Check to see that a call to RemoveLast when there are two nodes in the linked list reassigns the tail node.
        /// </summary>
        [Test]
        public void RemoveLastTwoNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20};

            Assert.IsTrue(dll.RemoveLast());
            Assert.AreEqual(10, dll.Head.Value);
            Assert.AreEqual(10, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
            Assert.IsNull(dll.Head.Next);
        }

        /// <summary>
        /// Check to see that calling RemoveLast when there are more than two nodes results in the expected behaviour.
        /// </summary>
        [Test]
        public void RemoveLastTestMultipleNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.RemoveLast();

            Assert.AreEqual(20, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
        }

        /// <summary>
        /// Check to see that calling RemoveLast on an empty list throws the correct exception.
        /// </summary>
        [Test]
        public void RemoveLastEmptyListTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            dll.RemoveLast();
        }

        /// <summary>
        /// Check to see that a call to RemoveFirst when there is only a single node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [Test]
        public void RemoveFirstSingleNodeTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.RemoveFirst();

            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
        }

        /// <summary>
        /// Check to see that a call to RemoveFirst when there are two node in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [Test]
        public void RemoveFirstTwoNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20};

            dll.RemoveFirst();

            Assert.AreEqual(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Previous);
        }

        /// <summary>
        /// Check to see that calling RemoveFirst when there are more than two nodes in the linked list
        /// results in the expected behaviour.
        /// </summary>
        [Test]
        public void RemoveFirstMoreThanTwoNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            Assert.IsTrue(dll.RemoveFirst());
            Assert.AreEqual(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Previous);
        }

        /// <summary>
        /// Check to see that calling RemoveFirst on a linked list with no nodes returns false.
        /// </summary>
        [Test]
        public void RemoveFirstEmptyListTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            Assert.IsFalse(dll.RemoveFirst());
        }

        /// <summary>
        /// Check to see that calling ICollection(Of T).Add results in the expected behaviour.
        /// </summary>
        [Test]
        public void AddTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();
            ICollection<int> actual = dll;

            actual.Add(10);
            actual.Add(20);

            Assert.AreEqual(10, dll.Head.Value);
            Assert.AreEqual(20, dll.Tail.Value);
            Assert.IsNull(dll.Head.Previous);
            Assert.IsNull(dll.Tail.Next);
        }

        /// <summary>
        /// Check to see that calling Clear results in the DoublyLinkedListCollection(Of T) being reset to its
        /// default state.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.Clear();

            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
            Assert.AreEqual(0, dll.Count);
        }

        /// <summary>
        /// Check to see that the Count property returns the expected value.
        /// </summary>
        [Test]
        public void CountTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 5};

            dll.RemoveFirst();
            dll.RemoveLast();
            dll.Add(10);
            dll.AddAfter(dll.Head, 30);
            dll.AddBefore(dll.Head.Next, 20);

            Assert.AreEqual(3, dll.Count);
        }

        /// <summary>
        /// Check to see that Contains returns the correct value.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            Assert.IsTrue(dll.Contains(20));
            Assert.IsFalse(dll.Contains(40));
        }

        /// <summary>
        /// Check to see that calling ToArray on the linked list results in the expected array.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            DoublyLinkedList<string> dll = new DoublyLinkedList<string> {"London", "Paris", "Berlin"};

            string[] expected = { "London", "Paris", "Berlin" };

            CollectionAssert.AreEqual(expected, dll.ToArray());
        }

        /// <summary>
        /// Check to see that calling ToArray on a DoublyLinkedListCollection(Of T) that contains no nodes throws the 
        /// correct exception.
        /// </summary>
        [Test]
        public void ToArrayEmptyListTest()
        {
            DoublyLinkedList<int> actual = new DoublyLinkedList<int>();

            Assert.AreEqual(0, actual.ToArray().Length);
        }

        /// <summary>
        /// Check to see that calling Remove on a DoublyLinkedListCollection(Of T) that contains no nodes results in the
        /// correct raised exception.
        /// </summary>
        [Test]
        public void RemoveEmptyListTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int>();

            Assert.IsFalse(dll.Remove(10));
        }

        /// <summary>
        /// Check to see that removing a single node from the DoublyLinkedListCollection(Of T) results in the list being
        /// declared as empty.
        /// </summary>
        [Test]
        public void RemoveSingleNodeTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            dll.Remove(10);

            Assert.IsTrue(dll.IsEmpty());
            Assert.IsNull(dll.Head);
            Assert.IsNull(dll.Tail);
            Assert.AreEqual(0, dll.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing head value from 
        /// a list with two nodes.
        /// </summary>
        [Test]
        public void RemoveHeadTwoNodes()
        {
            DoublyLinkedList<string> dll = new DoublyLinkedList<string> {"London", "Paris"};

            dll.Remove("London");

            Assert.AreEqual("Paris", dll.Head.Value);
            Assert.AreEqual("Paris", dll.Tail.Value);
            Assert.AreEqual(1, dll.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state after removing tail value from 
        /// a list with two nodes.
        /// </summary>
        [Test]
        public void RemoveTailTwoNodes()
        {
            DoublyLinkedList<string> dll = new DoublyLinkedList<string> {"London", "Paris"};

            dll.Remove("Paris");

            Assert.AreEqual("London", dll.Head.Value);
            Assert.AreEqual("London", dll.Tail.Value);
            Assert.AreEqual(1, dll.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [Test]
        public void RemoveMiddleMultipleNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.Remove(20);

            Assert.AreEqual(30, dll.Head.Next.Value);
            Assert.AreEqual(10, dll.Tail.Previous.Value);
            Assert.AreEqual(2, dll.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// head node value from a list of 3 or more nodes.
        /// </summary>
        [Test]
        public void RemoveHeadMultipleNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.Remove(10);

            Assert.AreEqual(20, dll.Head.Value);
            Assert.IsNull(dll.Head.Previous);
            Assert.AreEqual(2, dll.Count);
        }

        /// <summary>
        /// Check to see that the DoublyLinkedListCollection(Of T) is left in the correct state when removing
        /// middle node value from a list of 3 or more nodes.
        /// </summary>
        [Test]
        public void RemoveTailMultipleNodesTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            dll.Remove(30);

            Assert.AreEqual(20, dll.Tail.Value);
            Assert.IsNull(dll.Tail.Next);
            Assert.AreEqual(2, dll.Count);
        }

        /// <summary>
        /// Check to see that the correct value is returned when the value to be removed is not in the
        /// DoublyLinkedListCollection(Of T).
        /// </summary>
        [Test]
        public void RemoveNoMatchTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10};

            Assert.IsFalse(dll.Remove(20));
        }

        /// <summary>
        /// Check to see that an non null IEnumerator object is returned.
        /// </summary>
        [Test]
        public void GetEnumeratorTest()
        {
            DoublyLinkedList<int> dll = new DoublyLinkedList<int> {10, 20, 30};

            foreach (int i in dll) Console.WriteLine(i);

            Assert.IsNotNull(dll.GetEnumerator());
        }

        /// <summary>
        /// Check to make sure that the linked list is left in the correct state after copying the items from an IEnumerable to it.
        /// </summary>
        [Test]
        public void CopyConstructorTest()
        {
            List<string> collection = new List<string> { "Granville", "Barnett", "Luca", "Del", "Tongo" };
            DoublyLinkedList<string> actual = new DoublyLinkedList<string>(collection);

            Assert.AreEqual(5, actual.Count);
        }
    }
}