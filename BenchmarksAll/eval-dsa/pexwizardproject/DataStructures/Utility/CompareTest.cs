// <copyright file="CompareTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.Utility;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Utility
{
    [PexClass(typeof(Compare))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CompareTest
    {
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
        }

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
        }

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
        }
    }
}
