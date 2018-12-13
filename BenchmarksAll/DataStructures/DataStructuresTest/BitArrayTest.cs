// <copyright file="BitArrayTest.cs">Copyright ©  2018</copyright>
using System;
using System.Collections;
using DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructures
{
    /// <summary>This class contains parameterized unit tests for BitArray</summary>
    [PexClass(typeof(BitArray))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BitArrayTest
    {
        /// <summary>Test stub for And(BitArray)</summary>
        [PexMethod]
        public BitArray PUT_And([PexAssumeUnderTest]BitArray target, BitArray value)
        {
            BitArray result = target.And(value);
            return result;
            // TODO: add assertions to method BitArrayTest.PUT_And(BitArray, BitArray)
        }
    }    
}
