// <copyright file="DequeTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(Deque<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DequeTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]Deque<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public Deque<T> Constructor<T>()
            where T : IComparable<T>
        {
            Deque<T> target = new Deque<T>();
            return target;
        }

        [PexMethod]
        public Deque<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            Deque<T> target = new Deque<T>(collection);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]Deque<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public T DequeueBack<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            T result = target.DequeueBack();
            return result;
        }

        [PexMethod]
        public T DequeueFront<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            T result = target.DequeueFront();
            return result;
        }

        [PexMethod]
        public void EnqueueBack<T>([PexAssumeUnderTest]Deque<T> target, T item)
            where T : IComparable<T>
        {
            target.EnqueueBack(item);
        }

        [PexMethod]
        public void EnqueueFront<T>([PexAssumeUnderTest]Deque<T> target, T item)
            where T : IComparable<T>
        {
            target.EnqueueFront(item);
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public T PeekBack<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            T result = target.PeekBack();
            return result;
        }

        [PexMethod]
        public T PeekFront<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            T result = target.PeekFront();
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]Deque<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]Deque<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
