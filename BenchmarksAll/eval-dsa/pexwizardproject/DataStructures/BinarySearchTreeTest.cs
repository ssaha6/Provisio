// <copyright file="BinarySearchTreeTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(BinarySearchTree<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BinarySearchTreeTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]BinarySearchTree<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public BinarySearchTree<T> Constructor<T>()
            where T : IComparable<T>
        {
            BinarySearchTree<T> target = new BinarySearchTree<T>();
            return target;
        }

        [PexMethod]
        public BinarySearchTree<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            BinarySearchTree<T> target = new BinarySearchTree<T>(collection);
            return target;
        }

        [PexMethod]
        public void CopyTo<T>([PexAssumeUnderTest]BinarySearchTree<T> target, T[] array)
            where T : IComparable<T>
        {
            target.CopyTo(array);
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]BinarySearchTree<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }
    }
}
