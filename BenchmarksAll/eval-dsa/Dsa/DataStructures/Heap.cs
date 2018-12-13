// <copyright file="Heap.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Array based implementation of a Heap.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Dsa.Properties;
using Dsa.Utility;

using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// Heap data structure.
    /// </summary>
    /// <remarks>
    /// Min heap by default.
    /// </remarks>
    /// <typeparam name="T">Type of heap.</typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class Heap<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        [NonSerialized]
        private readonly Comparer<T> m_comparer;
        [NonSerialized]
        private readonly Strategy m_strategy;
        [NonSerialized]
        private T[] m_heap;

        /// <summary>
        /// Initializes a new instance of the <see cref="Heap{T}"/> class.
        /// </summary>
        public Heap()
        {
            m_heap = new T[4];
            m_comparer = Comparer<T>.Default;
            m_strategy = Strategy.Min;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Heap{T}"/> class, populating it with the items from the 
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="Heap{T}"/> with.</param>
        public Heap(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Heap{T}"/> class using a specified <see cref="Strategy"/>.
        /// </summary>
        /// <param name="strategy">Strategy of Heap.</param>
        public Heap(Strategy strategy)
            : this()
        {
            m_strategy = strategy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Heap{T}"/> class, populating it with the items from the 
        /// <see cref="IEnumerable{T}"/>, and using a specified <see cref="Strategy"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="Heap{T}"/> with.</param>
        /// <param name="strategy">Strategy of heap.</param>
        public Heap(IEnumerable<T> collection, Strategy strategy)
            : this(strategy)
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Used for the first predicate of the <see cref="Heap{T}.Contains"/> method.
        /// </summary>
        /// <param name="index">Index of an item.</param>
        /// <param name="comparer">Comparer to use.</param>
        /// <returns>True if the predicate is satisfied; otherwise false.</returns>
        private delegate bool ParentHandler(int index, Comparer<T> comparer);

        /// <summary>
        /// Used for the second predicate of the <see cref="Heap{T}.Contains"/> method. Determines whether the item
        /// is less than or greater than some other item. The behaviour depends on the type of the <see cref="Heap{T}"/>
        /// being used.
        /// </summary>
        /// <param name="x">First item.</param>
        /// <param name="y">Second item.</param>
        /// <param name="comparer">Comparer to use.</param>
        /// <returns>True if the predicate is satisfied; otherwise false.</returns>
        private delegate bool ComparerHandler(T x, T y, Comparer<T> comparer);

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <returns>Item at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                //Guard.OutOfRange(index < 0 || index > Count - 1, "index", Resources.IndexNotWithinBoundsOfHeap);
                return m_heap[index];
            }
        }

        /// <summary>
        /// Adds an item to the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the heap.</param>
        public override void Add(T item)
        {
            if (Count == m_heap.Length)
            {
                Array.Resize(ref m_heap, 2 * m_heap.Length);
            }

            m_heap[Count++] = item;
            if (m_strategy == Strategy.Min)
            {
                MinHeapify();
            }
            else
            {
                MaxHeapify();
            }
        }

        /// <summary>
        /// Clears the <see cref="Heap{T}"/> of its items.
        /// </summary>
        /// <remarks>
        /// Calling this method returns the internal <see cref="Array"/> to it's original capacity of 4.
        /// </remarks>
        public override void Clear()
        {
            Count = 0;
            m_heap = new T[4];
        }

        /// <summary>
        /// Determines whether or not the <see cref="Heap{T}"/> contains a specific item.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </para>
        /// <para>
        /// Algorithm is optimised to categorically rule out a value being in the heap if the value we are looking
        /// for is > than the parent of each node at the current level, but less than each node at the current level.
        /// The opposite strategy is used when searching a max-heap. Worse case is still linear, but now in some scenarios
        /// we can give a definitive answer without traversing all the values in the heap.
        /// </para>
        /// </remarks>
        /// <param name="item">Item to see if the Heap contains.</param>
        /// <returns>True is the item if in the Heap; otherwise false.</returns>
        public override bool Contains(T item)
        {
            int start = 0;
            int maxNodesAtCurrentLevel = 1;
            int count = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            ParentHandler p1;
            ComparerHandler p2;

            // figure out which methods to use for this type of heap
            if (m_strategy == Strategy.Min)
            {
                p1 = GreaterThanParent;
                p2 = Compare.IsLessThan;
            }
            else
            {
                p1 = LessThanParent;
                p2 = Compare.IsGreaterThan;
            }
            
            while (start < Count)
            {
                start = maxNodesAtCurrentLevel - 1; // start index of current level of nodes in the heap
                int end = maxNodesAtCurrentLevel + start; // end index of the current level of nodes in the heap

                while (start < Count && start < end)
                {
                    if (Compare.AreEqual(item, m_heap[start], comparer))
                    {
                        return true;
                    }
                    else if (p1(start, comparer) && p2(item, m_heap[start], comparer))
                    {
                        count++;
                    }

                    start++;
                }

                // item < all nodes at this level in the heap AND item > the parent of each respective node at this level
                // so we can safely say that this item is not in the heap without looking at the rest of the items in the
                // heap. The opposite cases are used for a max-heap.
                if (count == maxNodesAtCurrentLevel)
                {
                    return false;
                }

                maxNodesAtCurrentLevel *= 2; // goto the next level in the heap
            }

            return false;
        }

        /// <summary>
        /// Removes an item from the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <param name="item">Item to remove from the Heap.</param>
        /// <returns>True if the item was found and removed; otherwise false.</returns>
        public override bool Remove(T item)
        {
            ComparerHandler p1;
            ComparerHandler p2;

            if (m_strategy == Strategy.Min)
            {
                p1 = Compare.IsGreaterThan;
                p2 = Compare.IsLessThan;
            }
            else
            {
                p1 = Compare.IsLessThan;
                p2 = Compare.IsGreaterThan;
            }

            int index = Array.IndexOf(m_heap, item);
            if (index < 0)
            {
                return false;
            }

            m_heap[index] = m_heap[--Count];

            while ((2 * index) + 1 < Count && (p1(m_heap[index], m_heap[(2 * index) + 1], m_comparer) ||
                                             p1(m_heap[index], m_heap[(2 * index) + 2], m_comparer)))
            {
                if (p2(m_heap[(2 * index) + 1], m_heap[(2 * index) + 2], m_comparer))
                {
                    Sorting.Exchange(m_heap, index, (2 * index) + 1);
                    index = (2 * index) + 1;
                }
                else
                {
                    Sorting.Exchange(m_heap, index, (2 * index) + 2);
                    index = (2 * index) + 2;
                }
            }

            m_heap[Count] = default(T); // fix to release obj handles

            return true;
        }

        /// <summary>
        /// Converts the <see cref="Heap{T}"/> to a one-dimensional array.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the values of the nodes contained in the 
        /// <see cref="Heap{T}"/>.</returns>
        public override T[] ToArray()
        {
            return ToArray(Count, this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="Heap{T}"/> in breadth first order.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="Heap{T}"/>.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}"/> for the <see cref="Heap{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return m_heap[i];
            }
        }

        /// <summary>
        /// Determines whether or not an item at the given index is greater than its parent.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <param name="comparer">Comparer to use.</param>
        /// <returns>True if the item at the provided index is greater than its parent; otherwise false.</returns>
        private bool GreaterThanParent(int index, Comparer<T> comparer)
        {
            if (index < 1)
            {
                return true;
            }

            return Compare.IsGreaterThan(m_heap[index], m_heap[(index - 1) / 2], comparer);
        }

        /// <summary>
        /// Determines whether or not an item at the given index is less than its parent.
        /// </summary>
        /// <param name="index">Index of item.</param>
        /// <param name="comparer">Comparer to use.</param>
        /// <returns>True if the item at the provided index is less than its parent; otherwise false.</returns>
        private bool LessThanParent(int index, Comparer<T> comparer)
        {
            if (index < 1)
            {
                return true;
            }

            return Compare.IsLessThan(m_heap[index], m_heap[(index - 1) / 2], comparer);
        }

        /// <summary>
        /// Min heapifies the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(log n) operation.
        /// </para>
        /// <para>
        /// The key of the parent is less than or equal to that of its child, this property holds throughout the Heap :. the key at the root of 
        /// the Heap is the smallest key in the Heap.
        /// </para>
        /// </remarks>
        private void MinHeapify()
        {
            int i = Count - 1;
            while (i > 0 && Compare.IsLessThan(m_heap[i], m_heap[(i - 1) / 2], m_comparer))
            {
                Sorting.Exchange(m_heap, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }

        /// <summary>
        /// Max heapifies the <see cref="Heap{T}"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(log n) operation.
        /// </para>
        /// <para>
        /// The key of the parent is greater than or equal to that of its child, this property holds throughout the Heap :. the key at the 
        /// root of the Heap is the greatest key in the Heap.
        /// </para>
        /// </remarks>
        private void MaxHeapify()
        {
            int i = Count - 1;
            while (i > 0 && Compare.IsGreaterThan(m_heap[i], m_heap[(i - 1) / 2], m_comparer))
            {
                Sorting.Exchange(m_heap, i, (i - 1) / 2);
                i = (i - 1) / 2;
            }
        }
    }
}
