// <copyright file="OrderedSetTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(OrderedSet<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class OrderedSetTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]OrderedSet<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]OrderedSet<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public OrderedSet<T> Constructor<T>()
            where T : IComparable<T>
        {
            OrderedSet<T> target = new OrderedSet<T>();
            return target;
        }

        [PexMethod]
        public OrderedSet<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            OrderedSet<T> target = new OrderedSet<T>(collection);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]OrderedSet<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]OrderedSet<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]OrderedSet<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]OrderedSet<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
