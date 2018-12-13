// <copyright file="Compare.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Static generic comparer methods. 
// </summary>
using System.Collections.Generic;

namespace Dsa.Utility
{
    /// <summary>
    /// Methods for comparing generic types.
    /// </summary>
    public static class Compare
    {
        /// <summary>
        /// Determines whether the value of first is less than the value of second.
        /// </summary>
        /// <typeparam name="T">Type of objects to compare.</typeparam>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="comparer">Comparer to use to compare the objects.</param>
        /// <returns>True is first is less than second, otherwise false.</returns>
        public static bool IsLessThan<T>(T first, T second, IComparer<T> comparer)
        {
            return comparer.Compare(first, second) < 0;
        }

        /// <summary>
        /// Determines whether the value of first is greater than the value of second.
        /// </summary>
        /// <typeparam name="T">Type of objects to compare.</typeparam>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="comparer">Comparer to use to compare the objects.</param>
        /// <returns>True if first is greater than second, otherwise false.</returns>
        public static bool IsGreaterThan<T>(T first, T second, IComparer<T> comparer)
        {
            return comparer.Compare(first, second) > 0;
        }

        /// <summary>
        /// Determines whether the value of first and the value of second are equal.
        /// </summary>
        /// <typeparam name="T">Type of objects to compare.</typeparam>
        /// <param name="first">The first object to compare.</param>
        /// <param name="second">The second object to compare.</param>
        /// <param name="comparer">Comparer to use to compare the objects.</param>
        /// <returns>True if the value of first and second are equal, false otherwise.</returns>
        public static bool AreEqual<T>(T first, T second, IComparer<T> comparer)
        {
            return comparer.Compare(first, second) == 0;
        }
    }
}
