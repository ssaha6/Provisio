// <copyright file="BinaryTreeNodeTTest.cs"></copyright>
using System;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(BinaryTreeNode<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BinaryTreeNodeTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public BinaryTreeNode<T> Constructor<T>(T value)
        {
            BinaryTreeNode<T> target = new BinaryTreeNode<T>(value);
            return target;
        }
    }
}
