using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using NUnit.Framework;

namespace Dsa.Test.Algorithms
{
    /// <summary>
    /// Sorting tests.
    /// </summary>
    [TestFixture]
    public sealed class SortingTest
    {
        /// <summary>
        /// Check to see that the bubblesort algorithm sorts the items in ascending order.
        /// </summary>
        [Test]
        public void BubbleSortAscTest()
        {
            List<int> myInts = new List<int> { 23, 1, 44, 62, 1, 6, 90, 34 };
            List<int> expected = new List<int> { 1, 1, 6, 23, 34, 44, 62, 90 };
            IList<int> actual = myInts.BubbleSort(SortType.Ascending);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the bubblesort algorithm sorts the items in descending order.
        /// </summary>
        [Test]
        public void BubbleSortDescTest()
        {
            List<int> myInts = new List<int> { 23, 1, 44, 62, 1, 6, 90, 34 };
            List<int> expected = new List<int> { 90, 62, 44, 34, 23, 6, 1, 1 };
            IList<int> actual = myInts.BubbleSort(SortType.Descending);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that passing in a null array to BubbleSort results in the expected exception being thrown.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BubbleSortNullArrayTest()
        {
            const IList<int> actual = null;

            actual.BubbleSort(SortType.Ascending);
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [Test]
        public void MedianLeftTest()
        {
            List<int> actual = new List<int> { 2, 5, 23, 17, 1 };
            List<int> expected = new List<int> { 2, 5, 1, 17, 23 };

            actual.MedianLeft();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the median value of the array is in the correct location of the array.
        /// </summary>
        [Test]
        public void MedianLeftLeftIsGreaterThanMidTest()
        {
            List<int> actual = new List<int> { 23, 1, 4, 8, 10 };
            List<int> expected = new List<int> { 10, 1, 4, 8, 23 };

            actual.MedianLeft();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that median left raise the correct exception when the array is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MedianLeftArrayNullTest()
        {
            int[] actual = null;

            actual.MedianLeft();
        }

        /// <summary>
        /// Check to see that an array with the correct ordering of its items is returned.
        /// </summary>
        [Test]
        public void MergeOrderedTest()
        {
            int[] a1 = { 1, 5, 9 };
            int[] a2 = { 1, 3, 6 };
            int[] expected = { 1, 1, 3, 5, 6, 9 };

            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct array is returned when the first array is smaller than the second.
        /// </summary>
        [Test]
        public void MergeOrderedFirstArraySmallerTest()
        {
            int[] a1 = { 1, 4, 12 };
            int[] a2 = { 5, 9, 10, 14 };
            int[] expected = { 1, 4, 5, 9, 10, 12, 14 };

            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct array is returned when the second array is smaller than the first.
        /// </summary>
        [Test]
        public void MergeOrderedSecondArraySmallerTest()
        {
            int[] a1 = { 5, 9, 10, 14 };
            int[] a2 = { 1, 4, 12 };
            int[] expected = { 1, 4, 5, 9, 10, 12, 14 };

            IList<int> actual = Sorting.MergeOrdered(a1, a2);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see the correct expection is raised when the first array is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeOrderedArrayOneNullTest()
        {
            int[] a1 = null;
            int[] a2 = { 1, 2 };

            Sorting.MergeOrdered(a1, a2);
        }

        /// <summary>
        /// Check to see the the correct exception is raised when the second array is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeOrderedArrayTwoNullTest()
        {
            int[] a1 = { 1, 2 };
            int[] a2 = null;

            Sorting.MergeOrdered(a1, a2);
        }

        /// <summary>
        /// Check to see that MergeSort orders the array correctly.
        /// </summary>
        [Test]
        public void MergeSortTest()
        {
            int[] unsorted = { 12, 9, 4, 67, 3, 25 };
            int[] expected = { 3, 4, 9, 12, 25, 67 };

            IList<int> actual = unsorted.MergeSort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the char data type is ordered correctly when using merge ordered.
        /// </summary>
        [Test]
        public void MergeOrderedCharsTest()
        {
            char[] unsorted = { 'g', 'r', 'f', 'b', 'z', 'k' };
            char[] expected = { 'b', 'f', 'g', 'k', 'r', 'z' };

            IList<char> actual = unsorted.MergeSort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the array passed is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortArrayNullTest()
        {
            int[] actual = null;

            actual.MergeSort();
        }

        /// <summary>
        /// Check to see that the correct list is returned when concatenating 3 arrays.
        /// </summary>
        [Test]
        public void ConcatenateTest()
        {
            int[] array1 = { 5, 7, 8 };
            int[] array2 = { 6, 2 };
            int[] array3 = { 1 };
            int[] expected = { 5, 7, 8, 6, 2 };

            IList<int> actual = Sorting.Concatenate(array1, array2, array3);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the first list is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConcatenateFirstListNullTest()
        {
            char[] second = { 'a' };
            char[] third = { 'c' };

            Sorting.Concatenate(null, second, third);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the second list is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConcatenateSecondListNullTest()
        {
            char[] first = { 'a' };
            char[] third = { 'c' };

            Sorting.Concatenate(first, null, third);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the third list is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConcatenateThirdListNullTest()
        {
            char[] first = { 'a' };
            char[] second = { 'c' };

            Sorting.Concatenate(first, second, null);
        }

        /// <summary>
        /// Test to see that the correct list is returned when quick sorting a list.
        /// </summary>
        [Test]
        public void QuickSortTest()
        {
            int[] unsorted = { 10, 9, 7, 16 };
            int[] expected = { 7, 9, 10, 16 };

            IList<int> actual = unsorted.QuickSort();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is raised when the list is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortListNullTest()
        {
            char[] actual = null;

            actual.QuickSort();
        }

        /// <summary>
        /// Check to see that a list is sorted correctly when using insertion sort.
        /// </summary>
        [Test]
        public void InsertionSortTest()
        {
            int[] unsorted = { 78, 5, 23, 101, 1 };
            int[] expected = { 1, 5, 23, 78, 101 };

            int[] actual = unsorted.InsertionSort() as int[];

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the list to 
        /// insertion sort is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertionSortListNullTest()
        {
            char[] actual = null;

            actual.InsertionSort();
        }

        /// <summary>
        /// Check to see that the correct array is returned.
        /// </summary>
        [Test]
        public void ShellSortTest()
        {
            int[] unsorted = { 34, 78, 12, 9, 0, 3 };
            int[] expected = { 0, 3, 9, 12, 34, 78 };

            int[] actual = unsorted.ShellSort() as int[];

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when the list is null.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShellSortListNullTest()
        {
            char[] actual = null;

            actual.ShellSort();
        }

        /// <summary>
        /// Check to see that the list is sorted.
        /// </summary>
        [Test]
        public void RadixStringFixedKeyTest()
        {
            string[] actual = { "abc", "cfg", "cde", "rgf", "abd" };
            string[] expected = { "abc", "abd", "cde", "cfg", "rgf" };

            actual.RadixSort(3);

            CollectionAssert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Check to see that the correct exception is thrown when passing in a null list to sort.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RadixStringListNullTest()
        {
            string[] actual = null;

            actual.RadixSort(3);
        }

        /// <summary>
        /// Check to make sure that the correct exception is thrown when the key size is less than 1.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RadixStringKeySizeLessThanOneTest()
        {
            string[] actual = { "abc", "cfg", "cde", "rgf", "abd" };

            actual.RadixSort(0);
        }

        /// <summary>
        /// Cheap test to check that an item is not null within the list.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RadixStringItemNullTest()
        {
            string[] actual = new string[10];

            actual.RadixSort(2);
        }
    }
}