// <copyright file="Searching.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Common searching algorithms implemented as static, and extension methods. 
// </summary>
using System;
using System.Collections.Generic;
using Dsa.Utility;

namespace Dsa.Algorithms
{
    /// <summary>
    /// Searching algorithms.
    /// </summary>
    public static class Searching
    {
        /// <summary>
        /// Sequential search for an item within an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation.
        /// </remarks>
        /// <typeparam name="T">Type of collection to search.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to search item for.</param>
        /// <param name="item">Item to search for.</param>
        /// <returns>The index of the item if found; otherwise -1.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static int SequentialSearch<T>(this IList<T> list, T item)
        {
            //Guard.ArgumentNull(list, "list");

            int i = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            while (i < list.Count && !Compare.AreEqual(list[i], item, comparer))
            {
                i++;
            }

            if (i < list.Count && Compare.AreEqual(list[i], item, comparer))
            {
                return i;
            }

            return -1;
        }

        /// <summary>
        /// Probability search for an item in an <see cref="IList{T}"/>.  
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an O(n) operation.
        /// </para>
        /// <para>
        /// If the item is found in the <see cref="IList{T}"/> then it's priority is increased by swapping it with it's predecessor in the <see cref="IList{T}"/>.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">Type of the collection to search.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to search.</param>
        /// <param name="item">The item to search the <see cref="IList{T}"/> for.</param>
        /// <returns>True if the item was found; otherwise false.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static bool ProbabilitySearch<T>(this IList<T> list, T item)
        {
            //Guard.ArgumentNull(list, "list");

            int i = 0;
            Comparer<T> comparer = Comparer<T>.Default;
            while (i < list.Count && !Compare.AreEqual(list[i], item, comparer))
            {
                i++;
            }

            if (i >= list.Count || !Compare.AreEqual(list[i], item, comparer))
            {
                return false;
            }

            // we can increase the items' priority as the item is not the first element in the array
            if (i > 0)
            {
                T temp = list[i - 1];
                list[i - 1] = list[i];
                list[i] = temp;
            }

            return true;
        }
    }
}
