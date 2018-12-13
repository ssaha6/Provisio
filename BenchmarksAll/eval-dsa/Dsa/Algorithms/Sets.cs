// <copyright file="Sets.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Algorithms for common set problems implemented as extension methods.
// </summary>
using System;
using Dsa.DataStructures;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.Algorithms
{
    /// <summary>
    /// <see cref="OrderedSet{T}"/> algorithms.
    /// </summary>
    public static class Sets
    {
        /// <summary>
        /// Determines the number of permutations a set of <em>n</em> items can have with different permutations of <em>setCount</em> items.
        /// </summary>
        /// <remarks>
        /// <em>Permutations(n, k) = n!/(n-k)!</em>. 
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="OrderedSet{T}"/>.</typeparam>
        /// <param name="set">Set to count permutations of.</param>
        /// <param name="setCount">Permutations of setCount items.</param>
        /// <returns>The number of set permutations of <em>setCount</em> items.</returns>
        public static int Permutations<T>(this OrderedSet<T> set, int setCount)
            where T : IComparable<T>
        {
            //Guard.ArgumentNull(set, "set");
            //Guard.OutOfRange(setCount < 1, "setCount", Resources.PermutationsKGreaterThanZero);

            return (set.Count - setCount) < 0 ? 0 : set.Count.Factorial() / (set.Count - setCount).Factorial();
        }
    }
}
