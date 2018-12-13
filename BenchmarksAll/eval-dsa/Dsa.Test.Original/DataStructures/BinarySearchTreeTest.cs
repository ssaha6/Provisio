using System;
using System.Collections;
using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for BinarySearchTree.
    /// </summary>
    [TestFixture]
    public sealed class BinarySearchTreeTest
    {
        /// <summary>
        /// Check to see that the fields are initialized correctly.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            Assert.IsNull(bst.Root);
        }

        /// <summary>
        /// Check to see that the insert asserts the correct state changes.
        /// </summary>
        [Test]
        public void InsertRootNullTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10};

            Assert.AreEqual(10, bst.Root.Value);
        }

        /// <summary>
        /// Check to see that the state of the BinarySearchTree is updated correctly when inserting more than one node into the tree.
        /// </summary>
        [Test]
        public void InsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 20, 30, 5, 7, 3};

            Assert.AreEqual(20, bst.Root.Right.Value);
            Assert.AreEqual(30, bst.Root.Right.Right.Value);
            Assert.AreEqual(5, bst.Root.Left.Value);
            Assert.AreEqual(7, bst.Root.Left.Right.Value);
            Assert.AreEqual(3, bst.Root.Left.Left.Value);
        }

        /// <summary>
        /// Check to make sure that a non-null IEnumerator object is returned when calling GetEnumerator on a bst object.
        /// </summary>
        [Test]
        public void GetEnumeratorGenericTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 3, 8, 12, 11};

            Assert.IsNotNull(bst.GetEnumerator());
        }

        /// <summary>
        /// Check to make sure that a non-null IEnumerator object is returned when calling the GetPostorderEnumerator on a bst object.
        /// </summary>
        [Test]
        public void GetPostorderEnumeratorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 3, 20, 17, 30};

            Assert.IsNotNull(bst.GetPostorderEnumerator());
        }

        /// <summary>
        /// Check to see that a non-null IEnumerator object is returned when calling the GetInorderEnumerator on a bst object.
        /// </summary>
        [Test]
        public void GetInorderEnumeratorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 3, 20, 17, 30};

            Assert.IsNotNull(bst.GetInorderEnumerator());
        }

        /// <summary>
        /// Check to see that count returns the correct value.
        /// </summary>
        [Test]
        public void CountTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 4, 67};

            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Check to see that IsReadOnly property returns the correct value.
        /// </summary>
        [Test]
        public void ReadOnlyTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            ICollection<int> actual = bst;

            Assert.IsFalse(actual.IsReadOnly);
        }

        /// <summary>
        /// Check to see that IsSynchronized property returns the correct value.
        /// </summary>
        [Test]
        public void IsSynchronizedTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            ICollection actual = bst;

            Assert.IsFalse(actual.IsSynchronized);
        }

        /// <summary>
        /// Check to see that a non null enumerator object is returned.
        /// </summary>
        [Test]
        public void ICollectionGetEnumeratorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.GetEnumerator());
        }

        /// <summary>
        /// Check to see that SyncRoot returns a non null object.
        /// </summary>
        [Test]
        public void SyncRootTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            ICollection actual = bst;

            Assert.IsNotNull(actual.SyncRoot);
        }

        /// <summary>
        /// Check to see that calling Clear resets the collection to its default state.
        /// </summary>
        [Test]
        public void ClearTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 15};

            bst.Clear();

            Assert.IsNull(bst.Root);
            Assert.AreEqual(0, bst.Count);
        }

        /// <summary>
        /// Check to see that the FindMin method returns the correct value.
        /// </summary>
        [Test]
        public void FindMinTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {12, 8, 42, 6, 11};

            Assert.AreEqual(6, bst.FindMin());
        }

        /// <summary>
        /// Check to see the correct exception is thrown when calling FindMin on an empty tree.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindMinTreeEmptyTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.FindMin();
        }

        /// <summary>
        /// Check to see that FindMax returns the largest value in the bst.
        /// </summary>
        [Test]
        public void FindMaxTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {12, 8, 42, 6, 11};

            Assert.AreEqual(42, bst.FindMax());
        }


        /// <summary>
        /// Check to see that the correct exception is thrown when calling FindMax on an empty tree.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FindMaxTreeEmptyTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            bst.FindMax();
        }

        /// <summary>
        /// Check to see that Contains returns the correct value.
        /// </summary>
        [Test]
        public void ContainsTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {12, 5, 3, 8, 42};

            Assert.IsTrue(bst.Contains(12));
            Assert.IsTrue(bst.Contains(3));
            Assert.IsTrue(bst.Contains(42));
        }

        /// <summary>
        /// Check to see that the correct value is returned when the item is not contained within the bst.
        /// </summary>
        [Test]
        public void ContainsItemNotPresentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {12, 5, 3, 8, 42};

            Assert.IsFalse(bst.Contains(99));
            Assert.IsFalse(bst.Contains(1));
        }

        /// <summary>
        /// Check to see that calling GetBreadthFirstEnumerator returns a non null enumerator.
        /// </summary>
        [Test]
        public void GetBreadthFirstEnumeratorTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            Assert.IsNotNull(bst.GetBreadthFirstEnumerator());
        }

        /// <summary>
        /// Check to see that calling ToArray returns the correct array.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {12, 8, 6, 11, 42};

            int[] actual = bst.ToArray();
            int[] expected = {12, 8, 42, 6, 11};

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that the correct (empty) array is returned.
        /// </summary>
        [Test]
        public void ToArrayNoItemsInBstTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            int[] actual = bst.ToArray();

            Assert.AreEqual(0, actual.Length);
        }

        /// <summary>
        /// Check to see that calling CopyTo results in the target array being updated correctly.
        /// </summary>
        [Test]
        public void CopyToTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> { 12, 8, 6, 11, 42 };
            int[] expected = { 12, 8, 42, 6, 11 };
            int[] actual = new int[bst.Count];

            bst.CopyTo(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that calling CopyTo starting at specified index results in the target array being updated correctly.
        /// </summary>
        [Test]
        public void CopyToStartingSpecifiedIndexTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> { 12, 8, 6, 11, 42 };
            int[] expected = { 0, 0, 0, 12, 8, 42, 6, 11 };
            int[] actual = new int[bst.Count + 3];

            bst.CopyTo(actual, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check to see that calling ICollection.CopyTo throws the correct exception.
        /// </summary>
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ICollectionCopyToTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            ICollection actual = bst;
            int[] array = new int[5];

            actual.CopyTo(array, 0);
        }

        /// <summary>
        /// Check to see if a non-null reference is returned for a node that is in the bst with the specified value that is located in the left subtree.
        /// </summary>
        [Test]
        public void FindNodeValidLeftChildTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 14};

            Assert.IsNotNull(bst.FindNode(5));
            Assert.AreEqual(5, bst.FindNode(5).Value);
        }

        /// <summary>
        /// Check to see if a non-null reference is returned for a node that is in the bst with the specified value that is located in the right subtree.
        /// </summary>
        [Test]
        public void FindNodeValidRightChildTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 14};

            Assert.IsNotNull(bst.FindNode(14));
            Assert.AreEqual(14, bst.FindNode(14).Value);
        }

        /// <summary>
        /// Check to see that FindNode returns null when a value that isn't in the bst is specified.
        /// </summary>
        [Test]
        public void FindNodeNotInBstTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 5, 15};

            Assert.IsNull(bst.FindNode(34));
        }

        /// <summary>
        /// Check to see that the correct node is returned when finding the parent of a node with the specified value located in the left subtree.
        /// </summary>
        [Test]
        public void FindParentLeftSubTreeTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 9, 23, 17, 4};

            Assert.AreEqual(10, bst.FindParent(9).Value);
            Assert.AreEqual(9, bst.FindParent(4).Value);
        }

        /// <summary>
        /// Check to see that the correct node is returned when finding the parent of a node with
        /// the specified value located in the right subtree.
        /// </summary>
        [Test]
        public void FindParentRightSubTreeTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 17, 4, 9, 23};

            Assert.AreEqual(17, bst.FindParent(23).Value);
            Assert.AreEqual(10, bst.FindParent(17).Value);
        }

        /// <summary>
        /// Check to see that null is returned when looking for a value that should be located in the right subtree.
        /// </summary>
        [Test]
        public void FindParentRightSubTreeNodeNotPresentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {9, 23, 17, 10};

            Assert.IsNull(bst.FindParent(32));
        }

        /// <summary>
        /// Check to see that null is returned when looking for a value that should be located in the left subtree.
        /// </summary>
        [Test]
        public void FindParentLeftSubTreeNodeNotPresentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 9, 23, 17};

            Assert.IsNull(bst.FindParent(4));
        }

        /// <summary>
        /// Check to see that calling FindParent using the value of the root node returns null as the root node has no parent node.
        /// </summary>
        [Test]
        public void FindParentRootNodeTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 10, 23, 9};

            Assert.IsNull(bst.FindParent(10));
        }

        /// <summary>
        /// Check to see that null is returned when trying to find the parent of a tree with 0 items.
        /// </summary>
        [Test]
        public void FindParentNoItemsInBstTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();

            Assert.IsNull(bst.FindParent(45));
        }

        /// <summary>
        /// Check to see that trying to remove a node that is not in the bst returns the correct value.
        /// </summary>
        [Test]
        public void RemoveNodeNotFoundTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 7, 12};

            Assert.IsFalse(bst.Remove(4));
        }

        /// <summary>
        /// Check to see that removing a leaf node with a value less than its parent leaves the bst in the correct state.
        /// </summary>
        [Test]
        public void RemoveLeafValueLessThanParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 7, 12, 11};

            Assert.IsTrue(bst.Remove(7));
            Assert.IsNull(bst.Root.Left);
            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Check to see taht removing a leaf node with a value greater than or equal to its parent leaves the bst in the correct state.
        /// </summary>
        [Test]
        public void RemoveLeafValueGreaterThanOrEqualToParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 7, 12};

            Assert.IsTrue(bst.Remove(12));
            Assert.IsNull(bst.Root.Right);
            Assert.AreEqual(2, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a right subtree leaves the bst in the correct state when the value of the 
        /// nodeToRemove is greater than or equal to the parent.
        /// </summary>
        [Test]
        public void RemoveNodeWithRightSubtreeOnlyChildGreaterThanOrEqualToParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 7, 12, 13};

            Assert.IsTrue(bst.Remove(12));
            Assert.AreEqual(13, bst.Root.Right.Value);
            Assert.AreEqual(3, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a right subtree leaves the bst in the correct state when the value of the 
        /// nodeToRemove is less than the parent.
        /// </summary>
        [Test]
        public void RemoveNodeWithRightSubtreeOnlyChildLessThanParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {10, 7, 12, 13, 8};

            Assert.IsTrue(bst.Remove(7));
            Assert.AreEqual(8, bst.Root.Left.Value);
            Assert.AreEqual(4, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a left subtree leaves the bst in the correct state when the value of the 
        /// nodeToRemove is less than the parent. 
        /// </summary>
        [Test]
        public void RemoveNodeWithLeftSubtreeOnlyChildLessThanParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {35, 21, 43, 17, 26, 59, 13, 15};

            Assert.IsTrue(bst.Remove(17));
            Assert.AreEqual(13, bst.Root.Left.Left.Value);
            Assert.AreEqual(7, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node that has only a left subtree leaves the bst in the correct state when the value of the nodeToRemove 
        /// is greater than or equal to the parent. 
        /// </summary>
        [Test]
        public void RemoveNodeWithLeftSubtreeOnlyChildGreaterThanOrEqualToParentTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {35, 21, 43, 17, 26, 59, 13, 15, 65, 61};

            Assert.IsTrue(bst.Remove(65));
            Assert.AreEqual(61, bst.Root.Right.Right.Right.Value);
            Assert.AreEqual(9, bst.Count);
        }

        /// <summary>
        /// Check to see that removing a node with a left and right subtree leaves the bst in the correct state.
        /// </summary>
        [Test]
        public void RemoveNodeWithBothSubtreesTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {33, 21, 17, 24, 19, 14, 50, 49};

            Assert.IsTrue(bst.Remove(21));
            Assert.IsNull(bst.FindNode(21));
            Assert.AreEqual(19, bst.Root.Left.Value);
            Assert.AreEqual(7, bst.Count);
        }

        /// <summary>
        /// Check to see that removing the root node when root is the only node in the bst leaves the bst in the correct state.
        /// </summary>
        [Test]
        public void RemoveRootNoSubtreesTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int> {33};

            Assert.IsTrue(bst.Remove(33));
            Assert.IsNull(bst.Root);
            Assert.AreEqual(0, bst.Count);
        }

        /// <summary>
        /// Check to see that the correct behaviour is demonstrated when reomving an item from a tree with not items in.
        /// </summary>
        [Test]
        public void RemoveTreeHasNoItemsTest()
        {
            BinarySearchTree<int> actual = new BinarySearchTree<int>();

            actual.Remove(10);
        }

        /// <summary>
        /// Check to make sure the bst is left in the correct state when copying the items from an IEnumerable to it.
        /// </summary>
        [Test]
        public void CopyContructorTest()
        {
            List<string> collection = new List<string> { "Granville", "Barnett", "Luca", "Del", "Tongo" };
            BinarySearchTree<string> actual = new BinarySearchTree<string>(collection);

            Assert.AreEqual(5, actual.Count);
        }
    }
}