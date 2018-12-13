// <copyright file="SinglyLinkedListTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(SinglyLinkedList<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class SinglyLinkedListTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]SinglyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void AddAfter<T>(
            [PexAssumeUnderTest]SinglyLinkedList<T> target,
            SinglyLinkedListNode<T> node,
            T item
        )
            where T : IComparable<T>
        {
            target.AddAfter(node, item);
        }

        [PexMethod]
        public void AddBefore<T>(
            [PexAssumeUnderTest]SinglyLinkedList<T> target,
            SinglyLinkedListNode<T> node,
            T item
        )
            where T : IComparable<T>
        {
            target.AddBefore(node, item);
        }

        [PexMethod]
        public void AddFirst<T>([PexAssumeUnderTest]SinglyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            target.AddFirst(item);
        }

        [PexMethod]
        public void AddLast<T>([PexAssumeUnderTest]SinglyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            target.AddLast(item);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public SinglyLinkedList<T> Constructor<T>()
            where T : IComparable<T>
        {
            SinglyLinkedList<T> target = new SinglyLinkedList<T>();
            return target;
        }

        [PexMethod]
        public SinglyLinkedList<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            SinglyLinkedList<T> target = new SinglyLinkedList<T>(collection);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]SinglyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public IEnumerable<T> GetReverseEnumerator<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            IEnumerable<T> result = target.GetReverseEnumerator();
            return result;
        }

        [PexMethod]
        public SinglyLinkedListNode<T> HeadGet<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            SinglyLinkedListNode<T> result = target.Head;
            return result;
        }

        [PexMethod]
        public bool IsEmpty<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.IsEmpty();
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]SinglyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public bool RemoveFirst<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.RemoveFirst();
            return result;
        }

        [PexMethod]
        public bool RemoveLast<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.RemoveLast();
            return result;
        }

        [PexMethod]
        public SinglyLinkedListNode<T> TailGet<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            SinglyLinkedListNode<T> result = target.Tail;
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }

        [PexMethod]
        public T[] ToReverseArray<T>([PexAssumeUnderTest]SinglyLinkedList<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToReverseArray();
            return result;
        }
    }
}
