// <copyright file="BinaryTreeNode.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Generic implementation of a BST node.
// </summary>
using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// Node used by <see cref="BinarySearchTree{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of the node.</typeparam>
    [ExcludeFromCodeCoverage]
    public class BinaryTreeNode<T> : ICommonBinaryTreeNode<BinaryTreeNode<T>, T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTreeNode{T}"/> class.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets or sets the left node reference.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// Gets or sets the right node reference.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        public T Value { get; set; }
    }
}
