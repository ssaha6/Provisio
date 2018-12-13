// <copyright file="DoublyLinkedListTTest.cs"></copyright>
using System;
using System.Collections.Generic;
using Dsa.DataStructures;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dsa.DataStructures
{
    [PexClass(typeof(DoublyLinkedList<>))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DoublyLinkedListTTest
    {
        [PexMethod]
        public void Add<T>([PexAssumeUnderTest]DoublyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            target.Add(item);
        }

        [PexMethod]
        public void AddAfter<T>(
            [PexAssumeUnderTest]DoublyLinkedList<T> target,
            DoublyLinkedListNode<T> node,
            T value
        )
            where T : IComparable<T>
        {
            target.AddAfter(node, value);
        }

        [PexMethod]
        public void AddBefore<T>(
            [PexAssumeUnderTest]DoublyLinkedList<T> target,
            DoublyLinkedListNode<T> node,
            T value
        )
            where T : IComparable<T>
        {
            target.AddBefore(node, value);
        }

        [PexMethod]
        public void AddFirst<T>([PexAssumeUnderTest]DoublyLinkedList<T> target, T value)
            where T : IComparable<T>
        {
            target.AddFirst(value);
        }

        [PexMethod]
        public void AddLast<T>([PexAssumeUnderTest]DoublyLinkedList<T> target, T value)
            where T : IComparable<T>
        {
            target.AddLast(value);
        }

        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            target.Clear();
        }

        [PexMethod]
        public DoublyLinkedList<T> Constructor<T>()
            where T : IComparable<T>
        {
            DoublyLinkedList<T> target = new DoublyLinkedList<T>();
            return target;
        }

        [PexMethod]
        public DoublyLinkedList<T> Constructor01<T>(IEnumerable<T> collection)
            where T : IComparable<T>
        {
            DoublyLinkedList<T> target = new DoublyLinkedList<T>(collection);
            return target;
        }

        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]DoublyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexMethod]
        public IEnumerator<T> GetEnumerator<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            IEnumerator<T> result = target.GetEnumerator();
            return result;
        }

        [PexMethod]
        public DoublyLinkedListNode<T> HeadGet<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            DoublyLinkedListNode<T> result = target.Head;
            return result;
        }

        [PexMethod]
        public bool IsEmpty<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.IsEmpty();
            return result;
        }

        [PexMethod]
        public bool Remove<T>([PexAssumeUnderTest]DoublyLinkedList<T> target, T item)
            where T : IComparable<T>
        {
            bool result = target.Remove(item);
            return result;
        }

        [PexMethod]
        public bool RemoveFirst<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.RemoveFirst();
            return result;
        }

        [PexMethod]
        public bool RemoveLast<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            bool result = target.RemoveLast();
            return result;
        }

        [PexMethod]
        public DoublyLinkedListNode<T> TailGet<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            DoublyLinkedListNode<T> result = target.Tail;
            return result;
        }

        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]DoublyLinkedList<T> target)
            where T : IComparable<T>
        {
            T[] result = target.ToArray();
            return result;
        }
    }
}
