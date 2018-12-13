// <copyright file="AvlTreeNodeTTest.cs"></copyright>
using System;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(AvlTreeNode<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AvlTreeNodeTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public AvlTreeNode<T> Constructor<T>(T value)
        {
            AvlTreeNode<T> target = new AvlTreeNode<T>(value);
            return target;
        }
    }
}
