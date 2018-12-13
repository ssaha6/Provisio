// <copyright file="SetsTest.cs"></copyright>
using System;
using Dsa.Algorithms;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Algorithms
{
    [PexClass(typeof(Sets))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SetsTest
    {
        [PexMethod]
        public int Permutations<T>(OrderedSet<T> set, int setCount)
            where T : IComparable<T>
        {
            int result = Sets.Permutations<T>(set, setCount);
            return result;
        }
    }
}
