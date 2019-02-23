// <copyright file="NetQueueTTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetQueue<>))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetQueueTTest
    {
        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CapacityGet<T>([PexAssumeUnderTest]NetQueue<T> target)
        {
            int result = target.Capacity;
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void Clear<T>([PexAssumeUnderTest]NetQueue<T> target)
        {
            target.Clear();
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public NetQueue<T> Constructor<T>(int initialCapacity)
        {
            NetQueue<T> target = new NetQueue<T>(initialCapacity);
            return target;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool Contains<T>([PexAssumeUnderTest]NetQueue<T> target, T item)
        {
            bool result = target.Contains(item);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public int CountGet<T>([PexAssumeUnderTest]NetQueue<T> target)
        {
            int result = target.Count;
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void Enqueue<T>([PexAssumeUnderTest]NetQueue<T> target, T item)
        {
            target.Enqueue(item);
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public void EnqueueFirst<T>([PexAssumeUnderTest]NetQueue<T> target, T item)
        {
            target.EnqueueFirst(item);
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T[] ToArray<T>([PexAssumeUnderTest]NetQueue<T> target)
        {
            T[] result = target.ToArray();
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public bool TryDequeue<T>([PexAssumeUnderTest]NetQueue<T> target, out T item)
        {
            bool result = target.TryDequeue(out item);
            return result;
        }

        [PexGenericArguments(typeof(int))]
        [PexMethod]
        public T TryPeek<T>([PexAssumeUnderTest]NetQueue<T> target, int offset)
        {
            T result = target.TryPeek(offset);
            return result;
        }
    }
}
