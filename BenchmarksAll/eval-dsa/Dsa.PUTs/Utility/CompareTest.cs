// <copyright file="CompareTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Utility;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Utility
{
    /// <summary>This class contains parameterized unit tests for Compare</summary>
    [PexClass(typeof(Compare))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CompareTest
    {
        /// <summary>Test stub for AreEqual(!!0, !!0, IComparer`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool AreEqual<T>(
            T first,
            T second,
            IComparer<T> comparer
        )
        {
            bool result = Compare.AreEqual<T>(first, second, comparer);
            return result;
            // TODO: add assertions to method CompareTest.AreEqual(!!0, !!0, IComparer`1<!!0>)
        }

        /// <summary>Test stub for IsGreaterThan(!!0, !!0, IComparer`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool IsGreaterThan<T>(
            T first,
            T second,
            IComparer<T> comparer
        )
        {
            bool result = Compare.IsGreaterThan<T>(first, second, comparer);
            return result;
            // TODO: add assertions to method CompareTest.IsGreaterThan(!!0, !!0, IComparer`1<!!0>)
        }

        /// <summary>Test stub for IsLessThan(!!0, !!0, IComparer`1&lt;!!0&gt;)</summary>
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool IsLessThan<T>(
            T first,
            T second,
            IComparer<T> comparer
        )
        {
            bool result = Compare.IsLessThan<T>(first, second, comparer);
            return result;
            // TODO: add assertions to method CompareTest.IsLessThan(!!0, !!0, IComparer`1<!!0>)
        }
    }
}
