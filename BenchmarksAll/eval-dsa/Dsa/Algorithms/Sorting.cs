// <copyright file="Sorting.cs" company="Data Structures and Algorithms">
//   Copyright (C) Data Structures and Algorithms Team.
// </copyright>
// <summary>
//   Common sorting algorithms. Implemented at static, and extension methods.
// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using Dsa.Properties;
using Dsa.Utility;

namespace Dsa.Algorithms
{
    /// <summary>
    /// Sorting algorithms.
    /// </summary>
    public static class Sorting
    {
        /// <summary>
        /// Bubble sorts the items in an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n^2) operation.
        /// </remarks>
        /// <typeparam name="T">Type of collection to sort.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to sort.</param>
        /// <param name="sortType">Order in which the items of the <see cref="IList{T}"/> are to be sorted.</param>
        /// <returns>The sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> BubbleSort<T>(this IList<T> list, SortType sortType)
        {
            //Guard.ArgumentNull(list, "list");

            Comparer<T> comparer = Comparer<T>.Default;

            // compare each item of the list with every other item in the list
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            if (Compare.IsLessThan(list[i], list[j], comparer))
                            {
                                Exchange(list, j, i);
                            }

                            break;
                        case SortType.Descending:
                            if (Compare.IsGreaterThan(list[i], list[j], comparer))
                            {
                                Exchange(list, j, i);
                            }

                            break;
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Places the median value of 3 keys (left, right, and middle) at index 0 (left) in the <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(1) operation.
        /// </remarks>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to find the median value of.</param>
        /// <returns><see cref="IList{T}"/> with the median key at index 0.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> MedianLeft<T>(this IList<T> list)
        {
            //Guard.ArgumentNull(list, "list");

            Comparer<T> comparer = Comparer<T>.Default;
            int middle = list.Count / 2;
            const int Left = 0;
            int right = list.Count - 1;

            // place the keys in the correct positions of list
            if (Compare.IsGreaterThan(list[Left], list[middle], comparer))
            {
                Exchange(list, Left, middle);
            }

            if (Compare.IsGreaterThan(list[Left], list[right], comparer))
            {
                Exchange(list, Left, right);
            }

            if (Compare.IsGreaterThan(list[middle], list[right], comparer))
            {
                Exchange(list, middle, right);
            }

            // place the median key at index 0
            Exchange(list, middle, Left);
            return list;
        }

        /// <summary>
        /// Merges two ordered <see cref="IList{T}"/> collections into a single ordered <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number of items in both lists.
        /// </remarks>
        /// <typeparam name="T">Type of the <see cref="IList{T}"/>'s to merge.</typeparam>
        /// <param name="first">First <see cref="IList{T}"/>.</param>
        /// <param name="second">Second <see cref="IList{T}"/>.</param>
        /// <returns>Merged <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>first</strong> or <strong>second</strong> are null.</exception>
        public static IList<T> MergeOrdered<T>(IList<T> first, IList<T> second)
        {
            //Guard.ArgumentNull(first, "first");
            //Guard.ArgumentNull(second, "second");

            T[] merged = new T[first.Count + second.Count];

            // merge the items in both arrays
            for (int i = 0, j = 0, m = 0; m < merged.Length; m++)
            {
                if (i == first.Count)
                {
                    // all items in a1 have been exhausted so copy the remaining items (if any) from a2 starting at index j to merged
                    Array.Copy(second.ToArray(), j, merged, m, merged.Length - m);
                    break;
                }

                if (j == second.Count)
                {
                    Array.Copy(first.ToArray(), i, merged, m, merged.Length - m);
                    break;
                }

                // add the smallest item of the two arrays at indexes i and j respectively to merged
                merged[m] = Compare.IsLessThan(first[i], second[j], Comparer<T>.Default) ? first[i++] : second[j++];
            }

            return merged;
        }

        /// <summary>
        /// Merge sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n log n) operation.
        /// </remarks>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to be sorted.</param>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> MergeSort<T>(this IList<T> list)
        {
            //Guard.ArgumentNull(list, "list");

            return MergeSortInternal(list);
        }

        /// <summary>
        /// Concatenates three <see cref="IList{T}"/>'s into a single <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n) operation where n is the number os items in the three lists combined.
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="IList{T}"/>'s to concatenate.</typeparam>
        /// <param name="first">First <see cref="IList{T}"/>.</param>
        /// <param name="second">Second <see cref="IList{T}"/>.</param>
        /// <param name="third">Third <see cref="IList{T}"/>.</param>
        /// <returns>Concatenated <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>first</strong>, <strong>second</strong>, or <strong>third</strong> are <strong>null</strong>.</exception>
        public static IList<T> Concatenate<T>(IList<T> first, IList<T> second, IList<T> third)
        {
            //Guard.ArgumentNull(first, "first");
            //Guard.ArgumentNull(second, "second");
            //Guard.ArgumentNull(third, "third");

            List<T> concatenated = new List<T>();

            // iterate through each of the three lists adding their items to concatenated
            foreach (T item in first)
            {
                concatenated.Add(item);
            }

            foreach (T item in second)
            {
                concatenated.Add(item);
            }

            foreach (T item in third)
            {
                concatenated.Add(item);
            }

            return concatenated;
        }

        /// <summary>
        /// Quick sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n log n) operation.
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="IList{T}"/> to sort.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to sort.</param>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> QuickSort<T>(this IList<T> list)
        {
            //Guard.ArgumentNull(list, "list");

            Comparer<T> comparer = Comparer<T>.Default;
            return QuickSortInternal(list, ref comparer);
        }

        /// <summary>
        /// Insertion sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n^2) operation.
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="IList{T}"/> to sort.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to sort.</param>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> InsertionSort<T>(this IList<T> list)
        {
            //Guard.ArgumentNull(list, "list");

            Comparer<T> comparer = Comparer<T>.Default;
            int unsorted = 1;
            while (unsorted < list.Count)
            {
                T hold = list[unsorted];
                int i = unsorted - 1;
                while (i >= 0 && Compare.IsLessThan(hold, list[i], comparer))
                {
                    list[i + 1] = list[i--];
                }

                list[i + 1] = hold;
                unsorted++;
            }

            return list;
        }

        /// <summary>
        /// Shell sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <remarks>
        /// This method is an O(n^1.25) operation.
        /// </remarks>
        /// <typeparam name="T">Type of <see cref="IList{T}"/> to sort.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to sort.</param>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        public static IList<T> ShellSort<T>(this IList<T> list)
        {
            //Guard.ArgumentNull(list, "list");

            Comparer<T> comparer = Comparer<T>.Default;
            int increment = list.Count / 2;
            while (increment != 0)
            {
                int current = increment;
                while (current < list.Count)
                {
                    T hold = list[current];
                    int i = current - increment;
                    while (i >= 0 && Compare.IsLessThan(hold, list[i], comparer))
                    {
                        list[i + increment] = list[i];
                        i -= increment;
                    }

                    list[i + increment] = hold;
                    current++;
                }

                increment /= 2;
            }

            return list;
        }

        /// <summary>
        /// Radix sorts an array of <see cref="String"/>. The strings MUST be of the same key size.
        /// </summary>
        /// <param name="list">List to sort.</param>
        /// <param name="keySize">Key size of all strings, e.g. "abc", "bde" both have same key size of 3 chars.</param>
        /// <returns>Sorted list.</returns>
        /// <exception cref="ArgumentNullException"><strong>list</strong> is <strong>null</strong>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><strong>keySize</strong> is less than <strong>1</strong>.</exception>
        /// <exception cref="InvalidOperationException"><strong>list</strong> contains a <strong>null</strong> item.</exception>
        public static IList<string> RadixSort(this IList<string> list, int keySize)
        {
            //Guard.ArgumentNull(list, "list");
            //Guard.OutOfRange(keySize < 1, "keySize", Resources.RadixKeySizeTooSmall);
            //Guard.InvalidOperation(list[0] == null, Resources.RadixItemNullInList);

            int listCount = list.Count;
            string[] partiallySorted = new string[listCount]; // used for partial sort
            const int Radix = 256; // 256 is number of ASCII chars

            for (int d = keySize - 1; d >= 0; d--)
            {
                int[] count = new int[Radix]; // used for ascii char count

                // go ahead a track counts of ascii values for the char at key d
                for (int i = 0; i < listCount; i++)
                {
                    int charAsciiValue = list[i][d];//[] implicit call to get_Chars

                    // increment count for that ascii char, e.g. c = 99 => count[100] = count[100] + 1
                    count[charAsciiValue + 1]++; 
                }

                // count[101] = count[100] which is c, => count 101 = 3 on first key pass
                for (int k = 1; k < Radix; k++)
                {
                    count[k] += count[k - 1];
                }

                // populate temp with the values of 'a' using the counted values for the relevant chars in 
                // count as the index to temp e.g. if char with ASCII code 99 has a count of 2 then temp[2] = a[i]
                for (int i = 0; i < listCount; i++)
                {
                    int charAsciiValue = list[i][d];
                    partiallySorted[count[charAsciiValue]++] = list[i];
                }

                // copy temp values to a
                for (int i = 0; i < listCount; i++)
                {
                    list[i] = partiallySorted[i];
                }
            }

            return list;
        }

        /// <summary>
        /// Exchanges two items in an <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> that holds the items to be exchanged.</param>
        /// <param name="first">Index of first item.</param>
        /// <param name="second">Index of second item.</param>
        internal static void Exchange<T>(IList<T> list, int first, int second)
        {
            T temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }

        /// <summary>
        /// Merge sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <param name="list"><see cref="IList{T}"/> to be sorted.</param>
        /// <typeparam name="T">Type of the list.</typeparam>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        private static IList<T> MergeSortInternal<T>(IList<T> list)
        {
            if (list.Count <= 1)
            {
                return list; // base case the array is of size one thus it is already sorted
            }

            int middle = list.Count / 2; // find middle or thereabouts of the array

            // create two arrays to store the left and right items of array split
            T[] left = new T[middle];
            T[] right = new T[list.Count - middle];

            // populate left and right arrays with the appropriate items from list
            for (int i = 0; i < left.Length; i++)
            {
                left[i] = list[i];
            }

            for (int i = 0; i < right.Length; i++, middle++)
            {
                right[i] = list[middle];
            }

            // merge the sorted array branches into their respective sides
            left = MergeSortInternal(left) as T[];
            right = MergeSortInternal(right) as T[];

            // merge and return the ordered left and right arrays
            return MergeOrdered(left, right);
        }

        /// <summary>
        /// Quick sorts an <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of <see cref="IList{T}"/> to sort.</typeparam>
        /// <param name="list"><see cref="IList{T}"/> to sort.</param>
        /// <param name="comparer">Comparer to use.</param>
        /// <returns>Sorted <see cref="IList{T}"/>.</returns>
        private static IList<T> QuickSortInternal<T>(IList<T> list, ref Comparer<T> comparer)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            // lists to store relevant items
            List<T> less = new List<T>();
            List<T> greater = new List<T>();
            List<T> equal = new List<T>();

            // put the median value at index 0 of list
            list = MedianLeft(list);

            // place values in correct list {less, greater, equal}
            foreach (T item in list)
            {
                if (Compare.IsLessThan(item, list[0], comparer))
                {
                    less.Add(item);
                }
                else if (Compare.IsGreaterThan(item, list[0], comparer))
                {
                    greater.Add(item);
                }
                else
                {
                    equal.Add(item);
                }
            }

            // return list with items in the following order: less -> equal -> greater
            return Concatenate(QuickSortInternal(less, ref comparer), equal, QuickSortInternal(greater, ref comparer));
        }
    }
}
