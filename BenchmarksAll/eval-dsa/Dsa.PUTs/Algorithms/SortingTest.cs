// <copyright file="SortingTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    /// <summary>This class contains parameterized unit tests for Sorting</summary>
    [PexClass(typeof(Sorting))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SortingTest
    {
        /// <summary>Test stub for BubbleSort(IList`1&lt;!!0&gt;, SortType)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> BubbleSort<T>(IList<T> list, SortType sortType)
        {
            IList<T> result = Sorting.BubbleSort<T>(list, sortType);
            return result;
            // TODO: add assertions to method SortingTest.BubbleSort(IList`1<!!0>, SortType)
        }

        /// <summary>Test stub for Concatenate(IList`1&lt;!!0&gt;, IList`1&lt;!!0&gt;, IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod(MaxRuns = 30)]
        public IList<T> Concatenate<T>(
            IList<T> first,
            IList<T> second,
            IList<T> third
        )
        {
            IList<T> result = Sorting.Concatenate<T>(first, second, third);


            return result;
            // TODO: add assertions to method SortingTest.Concatenate(IList`1<!!0>, IList`1<!!0>, IList`1<!!0>)
        }

        ///// <summary>Test stub for Exchange(IList`1&lt;!!0&gt;, Int32, Int32)</summary>
        //[PexGenericArguments(typeof(int))]
        //[PexMethod]
        //internal void Exchange<T>(
        //    IList<T> list,
        //    int first,
        //    int second
        //)
        //{
        //    Sorting.Exchange<T>(list, first, second);
        //    // TODO: add assertions to method SortingTest.Exchange(IList`1<!!0>, Int32, Int32)
        //}

        /// <summary>Test stub for InsertionSort(IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> InsertionSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.InsertionSort<T>(list);
            return result;
            // TODO: add assertions to method SortingTest.InsertionSort(IList`1<!!0>)
        }

        /// <summary>Test stub for MedianLeft(IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MedianLeft<T>(IList<T> list)
        {

            IList<T> result = Sorting.MedianLeft<T>(list);
            return result;
            // TODO: add assertions to method SortingTest.MedianLeft(IList`1<!!0>)
        }

        /// <summary>Test stub for MergeOrdered(IList`1&lt;!!0&gt;, IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MergeOrdered<T>(IList<T> first, IList<T> second)
        {
            IList<T> result = Sorting.MergeOrdered<T>(first, second);
            return result;
            // TODO: add assertions to method SortingTest.MergeOrdered(IList`1<!!0>, IList`1<!!0>)
        }

        /// <summary>Test stub for MergeSort(IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MergeSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.MergeSort<T>(list);
            return result;
            // TODO: add assertions to method SortingTest.MergeSort(IList`1<!!0>)
        }

        /// <summary>Test stub for QuickSort(IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> QuickSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.QuickSort<T>(list);
            return result;
            // TODO: add assertions to method SortingTest.QuickSort(IList`1<!!0>)
        }

        /// <summary>Test stub for RadixSort(IList`1&lt;String&gt;, Int32)</summary>
        [PexMethod]
        public IList<string> RadixSort(IList<string> list, int keySize)
        {
            IList<string> result = Sorting.RadixSort(list, keySize);
            return result;
            // TODO: add assertions to method SortingTest.RadixSort(IList`1<String>, Int32)
        }

        /// <summary>Test stub for ShellSort(IList`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> ShellSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.ShellSort<T>(list);
            return result;
            // TODO: add assertions to method SortingTest.ShellSort(IList`1<!!0>)
        }
    }
}
