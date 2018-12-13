// <copyright file="PriorityQueue.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Heap based implementation of a PriorityQueue.
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Properties;
using Dsa.Utility;

using System.Diagnostics.CodeAnalysis;
namespace Dsa.DataStructures
{
    /// <summary>
    /// Priority queue.
    /// </summary>
    /// <remarks>
    /// Higher priority given to "lower" value objects by default.
    /// </remarks>
    /// <typeparam name="T">Type of the <see cref="PriorityQueue{T}"/>.</typeparam>
    [ExcludeFromCodeCoverage]
    public sealed class PriorityQueue<T> : CollectionBase<T>
        where T : IComparable<T>
    {
        [NonSerialized]
        private readonly Heap<T> m_heap;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class.
        /// </summary>
        public PriorityQueue()
        {
            m_heap = new Heap<T>(Strategy.Min);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class, populating it with the items of the 
        /// <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="PriorityQueue{T}"/> with.</param>
        public PriorityQueue(IEnumerable<T> collection)
            : this()
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class using a defined priority
        /// strategy.
        /// </summary>
        /// <param name="strategy">Strategy to use to define priority.</param>
        public PriorityQueue(Strategy strategy) 
        {
            m_heap = new Heap<T>(strategy);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityQueue{T}"/> class, populating it with the items of the 
        /// <see cref="IEnumerable{T}"/>, and using a defined <see cref="Strategy"/>.
        /// </summary>
        /// <param name="collection">Items to populate <see cref="PriorityQueue{T}"/> with.</param>
        /// <param name="strategy">Strategy to use to define priority.</param>
        public PriorityQueue(IEnumerable<T> collection, Strategy strategy)
            : this(strategy)
        {
            CopyCollection(collection);
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the queue.</param>
        public override void Add(T item)
        {
            Enqueue(item);
        }

        /// <summary>
        /// Clears the <see cref="PriorityQueue{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        public override void Clear()
        {
            m_heap.Clear();
            Count = 0;
        }

        /// <summary>
        /// Determines whether or not the <see cref="PriorityQueue{T}"/> contains a specific item.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="PriorityQueue{T}"/>.
        /// </remarks>
        /// <param name="item">Item to see if the queue contains.</param>
        /// <returns>True if the item is in the queue; otherwise false.</returns>
        public override bool Contains(T item)
        {
            return m_heap.Contains(item);
        }

        /// <summary>
        /// Not supported.
        /// </summary>
        /// <param name="item">Item to remove from the collection.</param>
        /// <returns>True if the item was removed; otherwise false.</returns>
        /// <exception cref="NotSupportedException">Remove is not supported for <see cref="PriorityQueue{T}"/>.</exception>
        public override bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Converts the <see cref="PriorityQueue{T}"/> to a one-dimensional array.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in the <see cref="PriorityQueue{T}"/>.
        /// </remarks>
        /// <returns>A one-dimensional <see cref="Array"/> containing the values of the items contained in the 
        /// <see cref="PriorityQueue{T}"/>.</returns>
        public override T[] ToArray()
        {
            return m_heap.ToArray();
        }

        /// <summary>
        /// Peeks at the item at the front of the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException"><strong>Count</strong> is less than <strong>1</strong>.</exception>
        public T Peek()
        {
            //Guard.InvalidOperation(Count < 1, Resources.QueueEmpty);

            return m_heap[0];
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(log n) operation.
        /// </remarks>
        /// <param name="item">Item to add to the queue.</param>
        public void Enqueue(T item)
        {
            m_heap.Add(item);
            Count++;
        }

        /// <summary>
        /// Removes and returns the item at the front of the queue.
        /// </summary>
        /// <remarks>
        /// This is an O(1) operation.
        /// </remarks>
        /// <returns>The item at the front of the queue.</returns>
        /// <exception cref="InvalidOperationException"><strong>Count</strong> is less than <strong>1</strong>.</exception>
        public T Dequeue()
        {
            //Guard.InvalidOperation(Count < 1, Resources.QueueEmpty);

            T head = m_heap[0];
            m_heap.Remove(head);
            Count--;
            return head;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the items in the <see cref="PriorityQueue{T}"/>.
        /// </summary>
        /// <remarks>
        /// This is an O(n) operation where n is the number of items in the <see cref="PriorityQueue{T}"/>.
        /// </remarks>
        /// <returns>An <see cref="IEnumerator{T}"/> for the <see cref="PriorityQueue{T}"/>.</returns>
        public override IEnumerator<T> GetEnumerator()
        {
            return m_heap.GetEnumerator();
        }
    }
}