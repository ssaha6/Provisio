// <copyright file="DoublyLinkedListNodeTTest.cs"></copyright>
using System;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(DoublyLinkedListNode<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DoublyLinkedListNodeTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public DoublyLinkedListNode<T> Constructor<T>(T value)
        {
            DoublyLinkedListNode<T> target = new DoublyLinkedListNode<T>(value);
            return target;
        }
    }
}
