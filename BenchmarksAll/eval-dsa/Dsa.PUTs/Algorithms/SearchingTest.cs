// <copyright file="SearchingTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dsa.Utility;
namespace Dsa.Algorithms
{
    /// <summary>This class contains parameterized unit tests for Searching</summary>
    [PexClass(typeof(Searching))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SearchingTest
    {
        /// <summary>Test stub for ProbabilitySearch(IList`1&lt;!!0&gt;, !!0)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool ProbabilitySearch<T>(IList<T> list, T item)
        {
            bool result = Searching.ProbabilitySearch<T>(list, item);
            return result;
            // TODO: add assertions to method SearchingTest.ProbabilitySearch(IList`1<!!0>, !!0)
        }

        /// <summary>Test stub for SequentialSearch(IList`1&lt;!!0&gt;, !!0)</summary>
        //[PexGenericArguments(typeof(int))]
        [PexMethod]
        public int SequentialSearch<T>(IList<int> list, int item)
        {

           int result = Searching.SequentialSearch<int>(list, item);
            
            return result;
            // TODO: add assertions to method SearchingTest.SequentialSearch(IList`1<!!0>, !!0)
        }
        [TestMethod]
        public void SequentialSearchseed()
        {
            int i;
            int[] ints = new int[3];
            i = SequentialSearch<int>((IList<int>)ints, 1);
        }
    }
}
