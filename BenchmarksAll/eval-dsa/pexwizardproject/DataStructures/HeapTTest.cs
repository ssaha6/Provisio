// <copyright file="HeapTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(Heap<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class HeapTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]Heap<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]Heap<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public Heap<T> Constructor<T>()
            where T : IComparable<T>
        {
            Heap<T> target = new Heap<T>();
            return target;
        }

        [PexMethod]
        public Heap<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            Heap<T> target = new Heap<T>(collection);
            return target;
        }

        [PexMethod]
        public Heap<T> Constructor02<T>(Strategy strategy)
            where T : IComparable<T>
        {
            Heap<T> target = new Heap<T>(strategy);
            return target;
        }

        [PexMethod]
        public Heap<T> Constructor03<T>(IEnumerable<T> collection, Strategy strategy)
            where T : IComparable<T>
        {
            Heap<T> target = new Heap<T>(collection, strategy);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]Heap<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]Heap<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public T ItemGet<T>([PexAssumeUnderTest]Heap<T> target, int index)
            where T : IComparable<T>
        {
            T result = target[index];
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]Heap<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]Heap<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
