// <copyright file="PriorityQueueTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(PriorityQueue<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PriorityQueueTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]PriorityQueue<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]PriorityQueue<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public PriorityQueue<T> Constructor<T>()
            where T : IComparable<T>
        {
            PriorityQueue<T> target = new PriorityQueue<T>();
            return target;
        }

        [PexMethod]
        public PriorityQueue<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            PriorityQueue<T> target = new PriorityQueue<T>(collection);
            return target;
        }

        [PexMethod]
        public PriorityQueue<T> Constructor02<T>(Strategy strategy)
            where T : IComparable<T>
        {
            PriorityQueue<T> target = new PriorityQueue<T>(strategy);
            return target;
        }

        [PexMethod]
        public PriorityQueue<T> Constructor03<T>(IEnumerable<T> collection, Strategy strategy)
            where T : IComparable<T>
        {
            PriorityQueue<T> target = new PriorityQueue<T>(collection, strategy);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]PriorityQueue<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public T Dequeue<T>([PexAssumeUnderTest]PriorityQueue<T> target)
            where T : IComparable<T>
        {
            T result = target.Dequeue();
            return result;
        }

        [PexMethod]
        public void Enqueue<T>([PexAssumeUnderTest]PriorityQueue<T> target, T item)
            where T : IComparable<T>
        {
            target.Enqueue(item);
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]PriorityQueue<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public T Peek<T>([PexAssumeUnderTest]PriorityQueue<T> target)
            where T : IComparable<T>
        {
            T result = target.Peek();
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]PriorityQueue<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]PriorityQueue<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
