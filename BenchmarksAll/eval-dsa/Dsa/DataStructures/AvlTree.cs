// <copyright file="AvlTree.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of an AVL tree.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Utility;
using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    
    /// <summary>
    /// AVL balanced tree.
    /// </summary>
    /// <remarks>
    /// AVL tree is a tree that is self balancing.
    /// </remarks>
    /// <typeparam name="T">Concrete type of AVL Tree</typeparam>
   [ExcludeFromCodeCoverage]
    public class AvlTree<T> : CommonBinaryTree<AvlTreeNode<T>,T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvlTree{T}"/> class.
        /// </summary>
        public AvlTree()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AvlTree{T}"/> class, populating it with the items from the
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="AvlTree{T}"/>.</param>
        public AvlTree(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Retrieves the height of the specified node.
        /// </summary>
        /// <param name="node">Node to obtain depth.</param>
        /// <returns>If the node is null 0; otherwise its proper height.</returns>
        public int Height(AvlTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Height;
            }
        }

        /// <summary>
        /// Get the balance factor for the node
        /// Balance factor is defined as the height difference 
        /// between left and right subtree if subtrees exist otherwise 
        /// for a null node as 0
        /// </summary>
        public int GetBalanceFactor(AvlTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Height(node.Left) - Height(node.Right);
            }
        }

        /// <summary>
        /// Inserts a new node with the specified value at the appropriate location in the <see cref="AvlTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation plus constant time due to rebalancing.
        /// </remarks>
        /// <param name="item">Value to insert.</param>
        public override void Add(T item)
        {
            if (Root == null)
            {
                Root = new AvlTreeNode<T>(item);
            }
            else
            {
                var root = Root;
                InsertNode(ref root, item);
                Root = root;
            }
            Count++;
        }

        /// <summary>
        /// Called by the Add method. Finds the location where to put the node in the <see cref="AvlTree{T}"/> and if 
        /// necessary rebalance.
        /// </summary>
        /// <param name="avlNode">Node to start searching from.</param>
        /// <param name="value">Value to insert into the Avl.</param>        
        private void InsertNode(ref AvlTreeNode<T> avlNode, T value)
        {
            var left  = avlNode.Left;
            var right = avlNode.Right;
            if (Compare.IsLessThan(value, avlNode.Value, Comparer))
            {
                if (avlNode.Left == null)
                {
                    avlNode.Left = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(ref left , value);
                    avlNode.Left = left;
                }
            }
            else
            {
                if (avlNode.Right == null)
                {
                    avlNode.Right = new AvlTreeNode<T>(value);
                }
                else
                {
                    InsertNode(ref right, value);                    
                    avlNode.Right = right;
                }
            }
            if ((GetBalanceFactor(avlNode) == 2) || (GetBalanceFactor(avlNode) == - 2))
            {
                Balance(ref avlNode);
            }
            else
            {
                AdjustHeight(avlNode);
            }            
        }
       
        /// <summary>
        /// Set the proper height of a node
        /// </summary>
        /// <param name="avlNode">the node needing a height fix </param>
        private void AdjustHeight(AvlTreeNode<T> avlNode)
        {
            avlNode.Height = Math.Max(Height(avlNode.Left), Height(avlNode.Right)) + 1;
        }

        /// <summary>
        /// Function that balance the tree after having updated its height
        /// </summary>
        /// <param name="node">the root of the tree to balance </param>        
        private void Balance(ref AvlTreeNode<T> node)
        {                       
            // Left Heavy Tree
            if (GetBalanceFactor(node) == 2)
            {
                if (GetBalanceFactor(node.Left) > -1) // Left Heavy Left Subtree or zero balance factor
                {
                    SingleRightRotation(ref node);                    
                }
                else // Right Heavy Left Subtree
                {
                    DoubleLeftRightRotation(ref node);
                }
            }// Right Heavy Tree
            else if (GetBalanceFactor(node) == -2)
            {
                if (GetBalanceFactor(node.Right) < 1) // Right Heavy Right Subtree or zero balance factor
                {
                    SingleLeftRotation(ref node);
                }
                else // Left Heavy Right SubTree
                {
                    DoubleRightLeftRotation(ref node);
                }
            }            
        }
        
        /// <summary>
        /// Removes a node with the specified value from the <see cref="AvlTree{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation plus if necessary a rebalancing.
        /// </remarks>
        /// <param name="item">Item to remove from the the <see cref="AvlTree{T}"/>.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            try
            {
                Root = RemoveNode(Root, item);
                Count--;
                return true;
            }
            catch (Exception)
            {
                return false;
            }                             
        }
        
        /// <summary>
        /// Called by remove public method. This removal helper method find the item to 
        /// remove and if present remove it rebalancing in case the avl tree
        /// </summary>
        /// <param name="avlNode">root subtree node to start deleting </param>
        /// <param name="item">value to delete</param>
        /// <returns>the root of the tree with value removed</returns>
        private AvlTreeNode<T> RemoveNode(AvlTreeNode<T> avlNode, T item)
        {
            if (avlNode ==  null)
            {
                throw new Exception("item not found");
            }
            else if (Compare.IsLessThan(item, avlNode.Value, Comparer))
            {
                avlNode.Left = RemoveNode(avlNode.Left, item);                
            }
            else if (Compare.IsGreaterThan(item, avlNode.Value, Comparer))
            {
                avlNode.Right =  RemoveNode(avlNode.Right, item);                
            }
            else if (Compare.AreEqual(item, avlNode.Value, Comparer))
            {                                                  
                    if (avlNode.Right == null && avlNode.Left == null)
                    {
                        // node to remove is a leaf, we simply delete node
                        return null;
                    }
                    else if (avlNode.Right != null && avlNode.Left == null)
                    {
                        // node to remove has only a right subtree, we link it with its parent
                        return avlNode.Right;
                    }
                    else if (avlNode.Left != null && avlNode.Right == null )
                    {
                        // node to remove has only a left subtree, we link it with its parent
                        return avlNode.Left;
                    }
                    else // node to remove has both childs
                    {
                        T newValue = FindMaxValue(avlNode.Left);                        
                        avlNode.Value = newValue;
                        avlNode.Left = RemoveNode(avlNode.Left, newValue);
                    }                                                                            
            }
            // Checking for unbalance, if detected, balance (include also height update)
            // otherwise only Adjust height
            if ((GetBalanceFactor(avlNode) == 2) || (GetBalanceFactor(avlNode) == -2))
            {
                Balance(ref avlNode);
            }
            else
            {
                AdjustHeight(avlNode);
            }
                 
            return avlNode;
        }        
                
        /// <summary>
        /// Get the maximum value of a tree
        /// </summary>
        /// <param name="avlTreeNode">the root of the tree</param>
        /// <returns>the maximum value of the tree</returns>
        private T FindMaxValue(AvlTreeNode<T> avlTreeNode)
        {
            while (avlTreeNode.Right!= null)
            {
                avlTreeNode = avlTreeNode.Right;
            }

            T max = avlTreeNode.Value;
            return max;
        }
        /// <summary>
        /// A Double rotation composed of a left rotation and a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>        
        private void DoubleLeftRightRotation(ref AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Left.Right;
            node.Left.Right = node1.Left;
            node1.Left = node.Left;
            AdjustHeight(node.Left);
            AdjustHeight(node);

            node.Left = node1.Right;
            node1.Right = node;
            AdjustHeight(node);
            AdjustHeight(node1);
            node = node1;
        }

        /// <summary>
        /// A single right rotation composed of a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>       
        private void SingleLeftRotation(ref AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Right;
            node.Right = node1.Left;
            node1.Left = node;
            AdjustHeight(node);
            AdjustHeight(node1);
            node = node1;
        }

        /// <summary>
        /// A Double rotation composed of a right rotation and a left rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>        
        private void DoubleRightLeftRotation(ref AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Right.Left;
            node.Right.Left = node1.Right;
            node1.Right = node.Right;
            AdjustHeight(node.Right);
            AdjustHeight(node1);

            node.Right = node1.Left;
            node1.Left = node;
            AdjustHeight(node);
            AdjustHeight(node1);
            node = node1;
        }

        /// <summary>
        /// A Single rotation composed of a left rotation and a right rotation.
        /// </summary>
        /// <param name="node">The pivoting node involved in rotations.</param>        
        private void SingleRightRotation(ref AvlTreeNode<T> node)
        {
            AvlTreeNode<T> node1 = node.Left;
            node.Left = node1.Right;
            node1.Right = node;
            AdjustHeight(node);
            AdjustHeight(node1);
            node = node1;
        }

    }
}