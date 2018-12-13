// <copyright file="OrderedSet.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Set whose items are ordered. 
//   Uses a binary search tree.
// </summary>
using System;
using System.Collections.Generic;

using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// An set where the items are ordered. 
    /// </summary>
    /// <remarks>
    /// In order to check for equality for non-primitve types you must make sure the type implements <see cref="IComparable{T}"/> otherwise
    /// the <see cref="OrderedSet{T}"/> cannot guarantee the set contains only unique objects.
    /// </remarks>
    /// <typeparam name="T">Type of OrderedSet.</typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class OrderedSet<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        private readonly BinarySearchTree<T> m_set;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedSet{T}"/> class.
        /// </summary>
        public OrderedSet()
        {
            m_set = new BinarySearchTree<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedSet{T}"/> class populating the <see cref="OrderedSet{T}"/> 
        /// with the items withing the provided <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Call this constructor if assigning a collection to the <see cref="OrderedSet{T}"/>.
        /// </para>
        /// <para>
        /// This method is an O(n) operation where n is the number of items in the <see cref="IEnumerable{T}"/>.
        /// </para>
        /// </remarks>
        /// <param name="collection">Collection of items to populate the set.</param>
        public OrderedSet(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Adds an item to the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the <see cref="OrderedSet{T}"/>.</param>
        public override void Add(T item)
        {
            if (m_set.Contains(item))
            {
                return; // item already in set
            }

            m_set.Add(item);
            Count++;
        }

        /// <summary>
        /// Clears all the items from the <see cref="OrderedSet{T}"/>.
        /// </summary>
        public override void Clear()
        {
            m_set.Clear();
            Count = 0;
        }

        /// <summary>
        /// Determines whether or not an item is contained within the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to search the <see cref="OrderedSet{T}"/> for.</param>
        /// <returns>True if the item is contained within the <see cref="OrderedSet{T}"/>; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return m_set.Contains(item);
        }

        /// <summary>
        /// Removes an item from the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the <see cref="OrderedSet{T}"/>.</param>
        /// <returns>True if the item was removed; false otherwise.</returns>
        public override bool Remove(T item)
        {
            int count = Count;
            if (m_set.Remove(item))
            {
                Count--;
            }

            return Count < count ? true : false;
        }

        /// <summary>
        /// Returns the items in the <see cref="OrderedSet{T}"/> as a one-dimensional <see cref="Array"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="OrderedSet{T}"/>.
        /// </remarks>
        /// <returns>A one dimensional <see cref="Array"/> populated with the items from the <see cref="OrderedSet{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        /// <summary>
        /// Returns an <see cref="IEnumerator{T}"/> to provide a simple traversal through the items in the <see cref="OrderedSet{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> to traverse the <see cref="OrderedSet{T}"/>.</returns>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="OrderedSet{T}"/>.
        /// </remarks>
        public override IEnumerator<T> GetEnumerator()
        {
            return m_set.GetInorderEnumerator().GetEnumerator();
        }
    }
}
