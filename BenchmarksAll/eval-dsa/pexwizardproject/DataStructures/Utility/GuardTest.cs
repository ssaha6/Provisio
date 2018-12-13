// <copyright file="GuardTest.cs"></copyright>
using System;
using Dsa.Utility;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.Utility
{
    [PexClass(typeof(Guard))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class GuardTest
    {
        [PexMethod]
        public void ArgumentNull(object value, string parameterName)
        {
            Guard.ArgumentNull(value, parameterName);
        }

        [PexMethod]
        public void InvalidOperation(bool condition, string message)
        {
            Guard.InvalidOperation(condition, message);
        }

        [PexMethod]
        public void OutOfRange(
            bool condition,
            string parameterName,
            string message
        )
        {
            Guard.OutOfRange(condition, parameterName, message);
        }
    }
}
