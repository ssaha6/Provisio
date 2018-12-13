using System.Collections.Generic;
using Dsa.DataStructures;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Dsa.Test.DataStructures
{
    /// <summary>
    /// Tests for Avl tree.
    /// </summary>
    [TestFixture]
    public class AvlTreeTest
    {
        /// <summary>
        /// Check to see wheter the correct balance factor is retrieved
        /// </summary>
        [Test]
        public void BalanceFactorTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 20 };
            AvlTreeNode<int> root = actual.FindNode(10);
            AvlTreeNode<int> leaf = actual.FindNode(20);
            AvlTreeNode<int> emptyNode = default(AvlTreeNode<int>);

            Assert.AreEqual(actual.GetBalanceFactor(root), -1);
            Assert.AreEqual(actual.GetBalanceFactor(leaf), 0);
            Assert.AreEqual(actual.GetBalanceFactor(emptyNode), 0);
        }
        
        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a right rebalancing.
        /// </summary>
        [Test]
        public void SingleLeftRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 20, 30 };

            Assert.AreEqual(20, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(30, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to see that the tree structure is correct after inserting nodes which will cause a left rebalancing.
        /// </summary>
        [Test]
        public void SingleRightRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 7, 4 };

            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(4, actual.Root.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to make sure tree is in the correct state after a double right rotation.
        /// </summary>
        [Test]
        public void DoubleRightLeftRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 20, 15 };

            Assert.AreEqual(15, actual.Root.Value);
            Assert.AreEqual(10, actual.Root.Left.Value);
            Assert.AreEqual(20, actual.Root.Right.Value);
        }

        /// <summary>
        /// Check to make sure tree is in the correct state after a double right rotation.
        /// </summary>
        [Test]
        public void DoubleLeftRightRotationTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 10, 5, 7 };

            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(5, actual.Root.Left.Value);
            Assert.AreEqual(10, actual.Root.Right.Value);
        }
        
        /// <summary>
        /// Check to see that a double rotation is applied for rebalancing a tree after
        /// a node insertion
        /// </summary>
        [Test]
        public void InsertionRotateRightLeftTest()
        { 
            AvlTree<int> avlTree = new AvlTree<int>(){6,5,15,7,16};
            avlTree.Add(14);
            Assert.AreEqual(7, avlTree.Root.Value);
            Assert.AreEqual(6, avlTree.Root.Left.Value);
            Assert.AreEqual(15, avlTree.Root.Right.Value);
            Assert.AreEqual(5, avlTree.Root.Left.Left.Value);
            Assert.AreEqual(14, avlTree.Root.Right.Left.Value);
            Assert.AreEqual(16, avlTree.Root.Right.Right.Value);
        }

        /// <summary>
        /// Massive insertion with multiple rotations and rebalancing
        /// </summary>
        [Test]
        public void InsertionMassiveTest()
        {
            AvlTree<int> actual = new AvlTree<int>() { 10, 7, 2, 5, 11, 3, 19 };
            Assert.AreEqual(7, actual.Root.Value);
            Assert.AreEqual(3, actual.Root.Left.Value);
            Assert.AreEqual(2, actual.Root.Left.Left.Value);
            Assert.AreEqual(11, actual.Root.Right.Value);
            Assert.AreEqual(10, actual.Root.Right.Left.Value);
            Assert.AreEqual(19, actual.Root.Right.Right.Value);
            Assert.AreEqual(5, actual.Root.Left.Right.Value);
        }
              
        /// <summary>
        /// Deletion test involving a two single left rotation cascading rebalancing 
        /// after the node has been removed from Avl tree
        /// </summary>
        [Test]
        public void RemoveCascadeBalancingTest()
        {
            AvlTree<int> avlTree = new AvlTree<int>() { 32,16,48,8,24,40,56,28,36,44,52,60,58,62 };            
            avlTree.Remove(8);
            Assert.AreEqual(48, avlTree.Root.Value);
            Assert.AreEqual(32, avlTree.Root.Left.Value);
            Assert.AreEqual(56, avlTree.Root.Right.Value);
            Assert.AreEqual(24, avlTree.Root.Left.Left.Value);
            Assert.AreEqual(16, avlTree.Root.Left.Left.Left.Value);
            Assert.AreEqual(40, avlTree.Root.Left.Right.Value);
            Assert.AreEqual(60, avlTree.Root.Right.Right.Value);
            Assert.AreEqual(52, avlTree.Root.Right.Left.Value);
            Assert.AreEqual(62, avlTree.Root.Right.Right.Right.Value);
        }

        /// <summary>
        /// Deletion test involving a single left rotation cascading rebalancing 
        /// after the node has been removed from Avl tree
        /// </summary>
        [Test]
        public void RemoveLeftRotationTest()
        {
            AvlTree<int> avlTree = new AvlTree<int>() { 32, 16, 48, 8, 24, 40, 56, 4, 36, 44, 52, 60, 58, 62 };
            avlTree.Remove(4);
            Assert.AreEqual(48, avlTree.Root.Value);
            Assert.AreEqual(32, avlTree.Root.Left.Value);
            Assert.AreEqual(56, avlTree.Root.Right.Value);
            Assert.AreEqual(16, avlTree.Root.Left.Left.Value);
            Assert.AreEqual(8, avlTree.Root.Left.Left.Left.Value);
            Assert.AreEqual(40, avlTree.Root.Left.Right.Value);
            Assert.AreEqual(60, avlTree.Root.Right.Right.Value);
            Assert.AreEqual(52, avlTree.Root.Right.Left.Value);
            Assert.AreEqual(62, avlTree.Root.Right.Right.Right.Value);
            Assert.AreEqual(58, avlTree.Root.Right.Right.Left.Value);
            Assert.AreEqual(13, avlTree.Count);
        }

        /// <summary>
        /// Simple Deletion of a node having only left subtree with no need of rebalancing
        /// </summary>
        [Test]
        public void RemoveNodeSingleLeftSubTreeTest()
        {
            AvlTree<int> avlTree = new AvlTree<int>() { 7, 6, 15, 5, 14, 16 };
            avlTree.Remove(6);
            Assert.AreEqual(7, avlTree.Root.Value);
            Assert.AreEqual(5, avlTree.Root.Left.Value);
            Assert.AreEqual(15, avlTree.Root.Right.Value);
            Assert.AreEqual(14, avlTree.Root.Right.Left.Value);
            Assert.AreEqual(16, avlTree.Root.Right.Right.Value);
        }

        /// <summary>
        /// Deletion test involving multiple rebalancing rotations
        /// after some nodes has been removed from Avl tree
        /// </summary>
        [Test]
        public void RemoveMassiveTest()
        {
            AvlTree<int> avlTree = new AvlTree<int>() { 32, 16, 48, 8, 24, 40, 56, 4, 36, 44, 52, 60, 58, 62 };
            avlTree.Remove(40);
            avlTree.Remove(36);
            avlTree.Remove(32);
            Assert.AreEqual(24, avlTree.Root.Value);
            Assert.AreEqual(8, avlTree.Root.Left.Value);
            Assert.AreEqual(56, avlTree.Root.Right.Value);
            Assert.AreEqual(4, avlTree.Root.Left.Left.Value);
            Assert.AreEqual(16, avlTree.Root.Left.Right.Value);
            Assert.AreEqual(60, avlTree.Root.Right.Right.Value);
            Assert.AreEqual(62, avlTree.Root.Right.Right.Right.Value);
            Assert.AreEqual(58, avlTree.Root.Right.Right.Left.Value);
            Assert.AreEqual(48, avlTree.Root.Right.Left.Value);
            Assert.AreEqual(44, avlTree.Root.Right.Left.Left.Value);
            Assert.AreEqual(52, avlTree.Root.Right.Left.Right.Value);
            Assert.AreEqual(11, avlTree.Count);
        }

        /// <summary>
        /// Check to see that after removing some nodes including one with both childs 
        /// the Avl tree has been correctly rebalanced
        /// </summary>
        [Test]
        public void RemoveNodeWithChildsTest()
        {
            AvlTree<int> avlTree = new AvlTree<int>() { 4, 8, 7, 2, 3, 1};                        
            avlTree.Remove(1);
            avlTree.Remove(2);
            avlTree.Remove(7);
            Assert.AreEqual(4, avlTree.Root.Value);            
        }

        /// <summary>
        /// Check to see that the correct behaviour is demonstrated when reomving an item from a tree with not items in.
        /// </summary>
        [Test]
        public void RemoveTreeHasNoItemsTest()
        {
            AvlTree<int> actual = new AvlTree<int>();            
            Assert.IsFalse(actual.Remove(6));
        }
        
        /// <summary>
        /// Check to simulate a composed use of an avl tree, so first we insert items and after 
        /// we delete some of them
        /// </summary>
        [Test]
        public void InsertionAndDeletionTest()
        {
            AvlTree<uint> avlTree = new AvlTree<uint>();
            avlTree.Add(28);
            avlTree.Add(22);
            avlTree.Add(3);
            avlTree.Add(7);
            avlTree.Add(14);
            avlTree.Add(9);
            avlTree.Add(19);
            avlTree.Add(55);
            avlTree.Add(23);
            avlTree.Add(4);
            avlTree.Add(1);
            avlTree.Add(6);
            avlTree.Add(15);
            Assert.AreEqual(avlTree.Root.Value, 14);
            Assert.AreEqual(avlTree.Root.Left.Value, 4);
            Assert.AreEqual(avlTree.Root.Right.Value, 22);
            avlTree.Remove(4);
            avlTree.Remove(3);
            avlTree.Remove(1);
            avlTree.Remove(9);
            avlTree.Remove(23);
            avlTree.Remove(14);
            Assert.AreEqual(7, avlTree.Count);
            Assert.AreEqual(22, avlTree.Root.Value);
            Assert.AreEqual(7, avlTree.Root.Left.Value);
            Assert.AreEqual(28, avlTree.Root.Right.Value);
            Assert.AreEqual(55, avlTree.Root.Right.Right.Value);
            Assert.AreEqual(6, avlTree.Root.Left.Left.Value);
            Assert.AreEqual(19, avlTree.Root.Left.Right.Value);
            Assert.AreEqual(15, avlTree.Root.Left.Right.Left.Value);
        }

        /// <summary>
        /// Check that count is correct after inserting some values.
        /// </summary>
        [Test]
        public void CountTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 12, 3, 4 };

            Assert.AreEqual(3, actual.Count);
        }

        /// <summary>
        /// Check that after invoking clear method all elements
        /// present in the tree will be removed
        /// </summary>
        [Test]
        public void ClearTest()
        {
            AvlTree<int> actual = new AvlTree<int> { 1,3,5,6,9,7 };
            Assert.AreEqual(6, actual.Count);
            actual.Clear();
            Assert.AreEqual(0, actual.Count);            
        }

        /// <summary>
        /// Check to see that traversal is correct.
        /// </summary>
        [Test]
        public void TraversalTest()
        {
            AvlTree<int> avlTree = new AvlTree<int> { 10, 20, 30 };
            List<int> expected = new List<int> { 10, 20, 30 };
            List<int> actual = new List<int>();

            foreach (int value in avlTree.GetInorderEnumerator())
            {
                actual.Add(value);
            }

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the AVLTree is in the correct state after invoking copy constructor.
        /// </summary>
        [Test]
        public void CopyConstructorTest()
        {
            List<int> values = new List<int> { 23, 45, 1, 19, 56 };
            AvlTree<int> avlTree = new AvlTree<int>(values);
            List<int> expected = new List<int> { 23, 1, 19, 45, 56 };
            List<int> actual = new List<int>();

            foreach(int i in avlTree)
            {
                actual.Add(i);
            }

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
