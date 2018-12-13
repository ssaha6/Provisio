// <copyright file="SortingTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    [PexClass(typeof(Sorting))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SortingTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> BubbleSort<T>(IList<T> list, SortType sortType)
        {
            IList<T> result = Sorting.BubbleSort<T>(list, sortType);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> Concatenate<T>(
            IList<T> first,
            IList<T> second,
            IList<T> third
        )
        {
            IList<T> result = Sorting.Concatenate<T>(first, second, third);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> InsertionSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.InsertionSort<T>(list);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MedianLeft<T>(IList<T> list)
        {
            IList<T> result = Sorting.MedianLeft<T>(list);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MergeOrdered<T>(IList<T> first, IList<T> second)
        {
            IList<T> result = Sorting.MergeOrdered<T>(first, second);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> MergeSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.MergeSort<T>(list);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> QuickSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.QuickSort<T>(list);
            return result;
        }

        [PexMethod]
        public IList<string> RadixSort(IList<string> list, int keySize)
        {
            IList<string> result = Sorting.RadixSort(list, keySize);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IList<T> ShellSort<T>(IList<T> list)
        {
            IList<T> result = Sorting.ShellSort<T>(list);
            return result;
        }
    }
}
