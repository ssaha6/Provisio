// <copyright file="CommonBinaryTree.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Base type for all tree's that conform to a basic binary tree standard. Ex: AVL, BST.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;
using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// Base type for common binary tree's. 
    /// </summary>
    /// <remarks>
    /// <para>
    /// Exmaples of common binary trees: <see cref="BinarySearchTree{T}"/>, <see cref="AvlTree{T}"/>.
    /// </para>
    /// <para>
    /// The nodes that make up what is deemed a <see cref="CommonBinaryTree{TNode,TValue}"/> must adhere by the contract
    /// defined in <see cref="ICommonBinaryTreeNode{TNode,TValue}"/>.
    /// </para>
    /// </remarks>
    /// <typeparam name="TNode">Type of the tree node.</typeparam>
    /// <typeparam name="TValue">Type of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</typeparam>
    [ExcludeFromCodeCoverage]
    public abstract class CommonBinaryTree<TNode, TValue> : CollectionBase<TValue>
        where TNode : class, ICommonBinaryTreeNode<TNode, TValue> 
        where TValue : IComparable<TValue>
    {
        [NonSerialized]
        private TNode m_root;
        [NonSerialized]
        private IComparer<TValue> m_comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonBinaryTree{TNode,TValue}"/> class.
        /// </summary>
        public CommonBinaryTree()
        {
            m_comparer = Comparer<TValue>.Default;
        }

        /// <summary>
        /// Gets the root of the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        public TNode Root
        {
            get { return m_root; }
            protected set { m_root = value; }
        }

        /// <summary>
        /// Gets the <see cref="IComparer{T}"/> to use for comparisons.
        /// </summary>
        protected IComparer<TValue> Comparer
        {
            get { return m_comparer; }
        }
        
        /// <summary>
        /// Clears all items from the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        public override void Clear()
        {
            m_root = null;
            Count = 0;
        }

        /// <summary>
        /// Traverses the items in the <see cref="CommonBinaryTree{TNode,TValue}"/> in breadth first order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/> .
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </returns>
        public IEnumerable<TValue> GetBreadthFirstEnumerator()
        {
            return BreadthFirstTraversal(m_root);
        }

        /// <summary>
        /// Traverses the <see cref="CommonBinaryTree{TNode,TValue}"/> in an in order traversal.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </returns>
        public IEnumerable<TValue> GetInorderEnumerator()
        {
            List<TValue> arrayListCollection = new List<TValue>();
            return InorderTraversal(m_root, arrayListCollection);
        }

        /// <summary>
        /// Traverses the <see cref="CommonBinaryTree{TNode,TValue}"/> in a postorder fashion.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of nodes in the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/> .
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </returns>
        public IEnumerable<TValue> GetPostorderEnumerator()
        {
            List<TValue> arrayListCollection = new List<TValue>();
            return PostorderTraversal(m_root, arrayListCollection);
        }

        /// <summary>
        /// <para>
        /// An <see cref="IEnumerator{T}"/> that iterates through the <see cref="CommonBinaryTree{TNode,TValue}"/>.  
        /// </para>
        /// <para>
        /// The default is preorder traversal of the items in the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerator{T}" /> that can be used to iterate through the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </returns>
        public override IEnumerator<TValue> GetEnumerator()
        {
            List<TValue> arrayListCollection = new List<TValue>();
            return PreorderTraveral(m_root, arrayListCollection).GetEnumerator();
        }

        /// <summary>
        /// Finds the largest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <returns>Largest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="CommonBinaryTree{TNode,TValue}"/> contains <strong>0</strong> items.
        /// </exception>
        public TValue FindMax()
        {
            //Guard.InvalidOperation(m_root == null, Resources.BinarySearchTreeEmpty);

            return FindMax(m_root);
        }

        /// <summary>
        /// Finds smallest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <returns>Smallest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.</returns>
        /// <exception cref="InvalidOperationException">
        /// The <see cref="CommonBinaryTree{TNode,TValue}"/> contains <strong>0</strong> items.
        /// </exception>
        public TValue FindMin()
        {
            //Guard.InvalidOperation(m_root == null, Resources.BinarySearchTreeEmpty);

            return FindMin(m_root);
        }

        /// <summary>
        /// Finds a node in the <see cref="CommonBinaryTree{TNode,TValue}"/> with the specified value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <returns>
        /// An instance of the correct node used for the respective tree if the node was found with the value provided; 
        /// otherwise null.
        /// </returns>
        public TNode FindNode(TValue value)
        {
            return FindNode(value, m_root);
        }

        /// <summary>
        /// Finds the parent node of a node with the specified value.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <returns>
        /// An instance of the correct node used for the respective tree if the node was found with the value provided; 
        /// otherwise null.
        /// </returns>
        public TNode FindParent(TValue value)
        {
            if (m_root == null)
            {
                return null;
            }

            return Compare.AreEqual(value, m_root.Value, Comparer) ? null : FindParent(value, m_root);
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="CommonBinaryTree{TNode,TValue}"/> for.</param>
        /// <returns>
        /// True if the item is contained within the <see cref="CommonBinaryTree{TNode,TValue}"/>; otherwise false.
        /// </returns>
        public override bool Contains(TValue item)
        {
            return Contains(m_root, item);
        }

        
        /// <summary>
        /// Returns the items in the <see cref="CommonBinaryTree{TNode,TValue}"/> as an <see cref="Array"/> 
        /// using <see cref="CommonBinaryTree{TNode,TValue}.GetBreadthFirstEnumerator"/> traversal.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n) operation where n is the number of nodes in the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </para>
        /// </remarks>
        /// <returns>
        /// A one-dimensional <see cref="Array"/> containing the items of the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </returns>
        public override TValue[] ToArray()
        {
            return ToArray(Count, GetBreadthFirstEnumerator());
        }

        /// <summary>
        /// Traverse the <see cref="CommonBinaryTree{TNode,TValue}"/> in breadth first order, i.e. each node is visited on 
        /// the same depth to depth n, where n is the depth of the tree.
        /// </summary>
        /// <param name="root">The root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <returns>
        /// <see cref="List{T}"/> populated with the items from the traversal.
        /// </returns>
        private static List<TValue> BreadthFirstTraversal(TNode root)
        {
            Queue<TNode> unvisited = new Queue<TNode>();
            List<TValue> visited = new List<TValue>();

            while (root != null)
            {
                visited.Add(root.Value);
                if (root.Left != null)
                {
                    unvisited.Enqueue(root.Left);
                }

                if (root.Right != null)
                {
                    unvisited.Enqueue(root.Right);
                }

                root = unvisited.Count > 0 ? unvisited.Dequeue() : null;
            }

            return visited;
        }

        /// <summary>
        /// Traverses the <see cref="CommonBinaryTree{TNode,TValue}"/> in an in order fashion, i.e. returning the 
        /// values of the nodes when a node is passed underneath.
        /// </summary>
        /// <param name="root">The root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <param name="arrayList"><see cref="List{T}"/> to store the traversed node values.</param>
        /// <returns><see cref="List{T}"/> populated with the items from the traversal.</returns>
        private static List<TValue> InorderTraversal(TNode root, List<TValue> arrayList)
        {
            if (root != null)
            {
                InorderTraversal(root.Left, arrayList);
                arrayList.Add(root.Value);
                InorderTraversal(root.Right, arrayList);
            }

            return arrayList;
        }

        /// <summary>
        /// Traverses the tree in postorder, i.e. returning the values of the nodes passed on the right.
        /// </summary>
        /// <param name="root">The root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <param name="arrayList"><see cref="List{T}"/> to store the traversed node values.</param>
        /// <returns><see cref="List{T}"/> populated with the items from the traversal.</returns>
        private static List<TValue> PostorderTraversal(TNode root, List<TValue> arrayList)
        {
            if (root != null)
            {
                PostorderTraversal(root.Left, arrayList);
                PostorderTraversal(root.Right, arrayList);
                arrayList.Add(root.Value);
            }

            return arrayList;
        }

        /// <summary>
        /// Traverses the tree in preorder, i.e. returning the values of the nodes passed on the left.
        /// </summary>
        /// <param name="root">The root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <param name="arrayList"><see cref="List{T}"/> to store the traversed node values.</param>
        /// <returns><see cref="List{T}"/> populated with the items from the traversal.</returns>
        private static List<TValue> PreorderTraveral(TNode root, List<TValue> arrayList)
        {
            if (root != null)
            {
                arrayList.Add(root.Value);
                PreorderTraveral(root.Left, arrayList);
                PreorderTraveral(root.Right, arrayList);
            }

            return arrayList;
        }

        /// <summary>
        /// Finds the largest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <param name="root">Root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <returns>Largest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.</returns>
        private static TValue FindMax(TNode root)
        {
            return root.Right == null ? root.Value : FindMax(root.Right);
        }

        /// <summary>
        /// Finds the smallest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <param name="root">Root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <returns>Smallest value in the <see cref="CommonBinaryTree{TNode,TValue}"/>.</returns>
        private static TValue FindMin(TNode root)
        {
            return root.Left == null ? root.Value : FindMin(root.Left);
        }

        /// <summary>
        /// Finds a node in the <see cref="CommonBinaryTree{TNode,TValue}"/> with the specified value.
        /// </summary>
        /// <param name="value">Value to find.</param>
        /// <param name="root">Node to start the search from.</param>
        /// <returns>
        /// An instance of the correct node used for the respective tree if the node was found with the value provided; 
        /// otherwise null.
        /// </returns>
        private TNode FindNode(TValue value, TNode root)
        {
            if (root == null)
            {
                return null;
            }

            return Compare.IsLessThan(value, root.Value, Comparer)
                       ? FindNode(value, root.Left)
                       : (Compare.IsGreaterThan(value, root.Value, Comparer) ? FindNode(value, root.Right) : root);
        }

        /// <summary>
        /// Finds the parent of a node with the specified value, starting the search from a specified node in the 
        /// <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <param name="value">Value of node to find parent of.</param>
        /// <param name="root">Node to start the search at.</param>
        /// <returns>
        /// An instance of the correct node used for the respective tree if the node was found with the value provided; 
        /// otherwise null.
        /// </returns>
        private TNode FindParent(TValue value, TNode root)
        {
            if (Compare.IsLessThan(value, root.Value, Comparer))
            {
                // check to see if the left child of root is null, if it is then the value is not in the bst
                if (root.Left == null)
                {
                    return null;
                }

                return Compare.AreEqual(value, root.Left.Value, Comparer) ? root : FindParent(value, root.Left);
            }

            if (root.Right == null)
            {
                return null;
            }

            return Compare.AreEqual(value, root.Right.Value, Comparer) ? root : FindParent(value, root.Right);
        }

        /// <summary>
        /// Determines whether an item is contained within the <see cref="CommonBinaryTree{TNode,TValue}"/>.
        /// </summary>
        /// <param name="root">The root node of the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <param name="item">The item to be located in the <see cref="CommonBinaryTree{TNode,TValue}"/>.</param>
        /// <returns>
        /// True if the item is contained within the <see cref="CommonBinaryTree{TNode,TValue}"/>; otherwise false.
        /// </returns>
        private bool Contains(TNode root, TValue item)
        {
            if (root == null)
            {
                // if the root is null then we have exhausted all the nodes in the tree, thus the item isn't in the bst
                return false; 
            }

            if (Compare.AreEqual(root.Value, item, m_comparer))
            {
                return true;
            }

            return Compare.IsLessThan(item, root.Value, m_comparer) ? Contains(root.Left, item) : Contains(root.Right, item);
        }
    }
}
