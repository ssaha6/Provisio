// <copyright file="CollectionBaseTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(CollectionBase<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class CollectionBaseTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void Add<T>([PexAssumeNotNull]CollectionBase<T> target, T item)
        {
            target.Add(item);
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void Clear<T>([PexAssumeNotNull]CollectionBase<T> target)
        {
            target.Clear();
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Contains<T>([PexAssumeNotNull]CollectionBase<T> target, T item)
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void CopyTo<T>(
            [PexAssumeNotNull]CollectionBase<T> target,
            T[] array,
            int arrayIndex
        )
        {
            target.CopyTo(array, arrayIndex);
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void CopyTo01<T>(
            [PexAssumeNotNull]CollectionBase<T> target,
            Array array,
            int index
        )
        {
            target.CopyTo(array, index);
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeNotNull]CollectionBase<T> target)
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool IsSynchronizedGet<T>([PexAssumeNotNull]CollectionBase<T> target)
        {
            bool result = target.IsSynchronized;
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Remove<T>([PexAssumeNotNull]CollectionBase<T> target, T item)
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T[] ToArray<T>([PexAssumeNotNull]CollectionBase<T> target)
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
