// <copyright file="SearchingTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Algorithms;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    [PexClass(typeof(Searching))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SearchingTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool ProbabilitySearch<T>(IList<T> list, T item)
        {
            bool result = Searching.ProbabilitySearch<T>(list, item);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int SequentialSearch<T>(IList<T> list, T item)
        {
            int result = Searching.SequentialSearch<T>(list, item);
            return result;
        }
    }
}
