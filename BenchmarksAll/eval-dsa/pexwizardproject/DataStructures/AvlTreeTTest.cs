// <copyright file="AvlTreeTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(AvlTree<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AvlTreeTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]AvlTree<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public AvlTree<T> Constructor<T>()
            where T : IComparable<T>
        {
            AvlTree<T> target = new AvlTree<T>();
            return target;
        }

        [PexMethod]
        public AvlTree<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            AvlTree<T> target = new AvlTree<T>(collection);
            return target;
        }

        [PexMethod]
        public int GetBalanceFactor<T>(
            [PexAssumeUnderTest]AvlTree<T> target,
            AvlTreeNode<T> node
        )
            where T : IComparable<T>
        {
            int result = target.GetBalanceFactor(node);
            return result;
        }

        [PexMethod]
        public int Height<T>(
            [PexAssumeUnderTest]AvlTree<T> target,
            AvlTreeNode<T> node
        )
            where T : IComparable<T>
        {
            int result = target.Height(node);
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]AvlTree<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }
    }
}
