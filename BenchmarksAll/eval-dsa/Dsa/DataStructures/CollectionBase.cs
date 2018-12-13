// <copyright file="CollectionBase.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Base class that all DSA collecitons derive from.
//   This is to make the implementing of several common interfaces easier for collection
//   designers.
// </summary>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Dsa.Properties;
using Dsa.Utility;
using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// Base class for all DSA collections.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="CollectionBase"/>.</typeparam>
    [Serializable]
    [DebuggerDisplay("Count={Count}")]
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [ExcludeFromCodeCoverage]
    public abstract class CollectionBase<T> : ICollection, ICollection<T>
    {
        [NonSerialized]
        private object m_syncRoot;

        /// <summary>
        /// Gets a value indicating whether the collection is thread safe.
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the number of items contained in the <see cref="ICollection{T}"/>.
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// Gets a value indicating whether the collection is read only.
        /// </summary>
        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the collection.
        /// </summary>
        /// <remarks>
        /// Use the object returned by this property for locks rather than this.
        /// </remarks>
        object ICollection.SyncRoot
        {
            get
            {
                if (m_syncRoot == null)
                {
                    Interlocked.CompareExchange(ref m_syncRoot, new object(), null);
                }

                return m_syncRoot;
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to add to collection.</param>
        public abstract void Add(T item);

        /// <summary>
        /// Clears all items from the <see cref="ICollection{T}"/>.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Determines whether an item is contained within the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to search the <see cref="ICollection{T}"/> for.</param>
        /// <returns>True if the item is in the <see cref="ICollection{T}"/>; otherwise false.</returns>
        public abstract bool Contains(T item);

        /// <summary>
        /// Copies all the <see cref="ICollection{T}"/> items to a compatible one-dimensional <see cref="Array"/>, 
        /// starting at the specified index of the target <see cref="Array"/>.
        /// </summary>
        /// <param name="array">A one-dimensional <see cref="Array"/> to copy the <see cref="ICollection{T}"/> items to.</param>
        /// <param name="arrayIndex">Index of target <see cref="Array"/> where copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(ToArray(), 0, array, arrayIndex, Count);
        }

        /// <summary>
        /// Removes an item from the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="item">Item to remove from collection.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        public abstract bool Remove(T item);

        /// <summary>
        /// An <see cref="IEnumerator{T}"/> that iterates through the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}" /> that can be used to iterate through the <see cref="ICollection{T}"/>.</returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the collection to a single dimension array.
        /// </summary>
        /// <returns>An array of the items in the collection.</returns>
        public abstract T[] ToArray();

        /// <summary>
        /// Not Supported in any DSA collection.
        /// </summary>
        /// <param name="array">Target array to copy items to.</param>
        /// <param name="index">Index to start copying items to.</param>
        public void CopyTo(Array array, int index)
        {
            throw new NotSupportedException(Resources.ICollectionCopyToNotSupported);
        }

        /// <summary>
        /// An <see cref="IEnumerator"/> that iterates through the <see cref="ICollection"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator" /> that can be used to iterate through the <see cref="ICollection"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Creates an array representation for a datastructure.
        /// </summary>
        /// <param name="size">Size of the destintation array.</param>
        /// <param name="enumerator">Enumerator to use to denote traversal order.</param>
        /// <returns>Array of the data structure.</returns>
        internal static T[] ToArray(int size, IEnumerable<T> enumerator)
        {
            T[] local = new T[size];
            int i = 0;
            foreach (T item in enumerator)
            {
                local[i++] = item;
            }

            return local;
        }

        /// <summary>
        /// Copies the items in an <see cref="IEnumerable{T}"/> to the <see cref="CollectionBase{T}"/>.
        /// </summary>
        /// <param name="collection">Items to copy.</param>
        /// <exception cref="ArgumentNullException"><strong>collection</strong> is <strong>null</strong>.</exception>
        protected void CopyCollection(IEnumerable<T> collection)
        {
            Guard.ArgumentNull(collection, "collection");

            foreach (T item in collection)
            {
                Add(item);
            }
        }
    }
}
