// <copyright file="SinglyLinkedListNodeTTest.cs"></copyright>
using System;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(SinglyLinkedListNode<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SinglyLinkedListNodeTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public SinglyLinkedListNode<T> Constructor<T>(T value)
        {
            SinglyLinkedListNode<T> target = new SinglyLinkedListNode<T>(value);
            return target;
        }
    }
}
