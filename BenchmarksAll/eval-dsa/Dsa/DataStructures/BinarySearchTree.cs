// <copyright file="BinarySearchTree.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of a BST. The BST is NOT balanced - see the AVL tree for that.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Utility;

using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// A binary search tree (BST).
    /// </summary>
    /// <typeparam name="T">Type of <see cref="BinarySearchTree{T}"/>.</typeparam>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class BinarySearchTree<T> : CommonBinaryTree<BinaryTreeNode<T>, T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class, populating it with the items from the
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="BinarySearchTree{T}"/>.</param>
        public BinarySearchTree(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Copies all the <see cref="BinarySearchTree{T}"/> items to a compatible one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <param name="array">A one-dimensional <see cref="Array"/> to copy the <see cref="BinarySearchTree{T}"/> items to.</param>
        public void CopyTo(T[] array)
        {
            Array.Copy(ToArray(), array, Count);
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode<T>(item);
            }
            else
            {
                InsertNode(item);
            }

            Count++;
        }

        /// <summary>
        /// Removes a node with the specified value from the <see cref="BinarySearchTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the the <see cref="BinarySearchTree{T}"/>.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            BinaryTreeNode<T> nodeToRemove = Root;
            BinaryTreeNode<T> parent = null;

            while ((nodeToRemove != null) && (!Compare.AreEqual(item, nodeToRemove.Value, Comparer)))
            {
                parent = nodeToRemove;
                if (Compare.IsLessThan(item, nodeToRemove.Value, Comparer))
                {
                    nodeToRemove = nodeToRemove.Left;
                }
                else
                {
                    nodeToRemove = nodeToRemove.Right;
                }
            }
            if (nodeToRemove == null)
            {
                return false;
            }            
            if (Count == 1)
            {
                Root = null;
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right == null)
            {
                // nodeToRemove is a leaf
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, Comparer))
                {
                    parent.Left = null;
                }
                else
                {
                    parent.Right = null;
                }
            }
            else if (nodeToRemove.Left == null && nodeToRemove.Right != null)
            {
                // nodeToRemove has only a right subtree
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, Comparer))
                {
                    parent.Left = nodeToRemove.Right;
                }
                else
                {
                    parent.Right = nodeToRemove.Right;
                }
            }
            else if (nodeToRemove.Left != null && nodeToRemove.Right == null)
            {
                // nodeToRemove has only a left subtree
                if (Compare.IsLessThan(nodeToRemove.Value, parent.Value, Comparer))
                {
                    parent.Left = nodeToRemove.Left;
                }
                else
                {
                    parent.Right = nodeToRemove.Left;
                }
            }
            else
            {
                // nodeToRemove has both a left and right subtree
                BinaryTreeNode<T> largestValue = nodeToRemove.Left;

                // find the largest value in the left subtree of nodeToRemove
                while (largestValue.Right != null)
                {
                    largestValue = largestValue.Right;
                }

                // find the parent of the largest value in the left subtree of nodeToDelete and sets its right property to null.
                FindParent(largestValue.Value).Right = null;

                // set value of nodeToRemove to the value of largestValue
                nodeToRemove.Value = largestValue.Value;
            }

            Count--;
            return true;
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the <see cref="BinarySearchTree{T}"/>.
        /// </summary>        
        /// <param name="value">Value to insert into the Bst.</param>
        private void InsertNode(T value)
        {
            BinaryTreeNode<T> current = Root;
            while (true)
            {                
                if (Compare.IsLessThan(value, current.Value, Comparer))
                {
                    //We go left and if arrived at a leaf insert the node and return
                    if (current.Left!=null)
                    {	
                        current = current.Left;
                    }
	
                    else
                    {	
                        current.Left = new BinaryTreeNode<T>(value);
                        return;
                    }
                }                
                else if (Compare.IsGreaterThan(value, current.Value, Comparer))
                {
                    //We go right and if arrived at a leaf insert the node and return
                    if (current.Right!=null)
                    {	
                        current = current.Right;
                    }
	
                    else
                    {	
                        current.Right = new BinaryTreeNode<T>(value);
                        return;
                    }
                }
                // The value to insert is already present, we simply return
                else
                {
                    return;
                }
            }            
        }

    }
}