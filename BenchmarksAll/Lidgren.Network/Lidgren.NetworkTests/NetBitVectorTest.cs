// <copyright file="NetBitVectorTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetBitVector))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetBitVectorTest
    {
        [PexMethod]
        public bool BitGet([PexAssumeUnderTest]NetBitVector target, int index)
        {
            bool result = target[index];
            return result;
        }

        [PexMethod]
        public void BitSet(
            [PexAssumeUnderTest]NetBitVector target,
            int index,
            bool value
        )
        {
            target[index] = value;
        }

        [PexMethod]
        public int CapacityGet([PexAssumeUnderTest]NetBitVector target)
        {
            int result = target.Capacity;
            return result;
        }

        [PexMethod]
        public void Clear([PexAssumeUnderTest]NetBitVector target)
        {
            target.Clear();
        }

        [PexMethod]
        public NetBitVector Constructor(int bitsCapacity)
        {
            NetBitVector target = new NetBitVector(bitsCapacity);
            return target;
        }

        [PexMethod]
        public int Count([PexAssumeUnderTest]NetBitVector target)
        {
            int result = target.Count();
            return result;
        }

        [PexMethod]
        public bool Get([PexAssumeUnderTest]NetBitVector target, int bitIndex)
        {
            bool result = target.Get(bitIndex);
            return result;
        }

        [PexMethod]
        public int GetFirstSetIndex([PexAssumeUnderTest]NetBitVector target)
        {
            int result = target.GetFirstSetIndex();
            return result;
        }

        [PexMethod]
        public bool IsEmpty([PexAssumeUnderTest]NetBitVector target)
        {
            bool result = target.IsEmpty();
            return result;
        }

        [PexMethod]
        public void RotateDown([PexAssumeUnderTest]NetBitVector target)
        {
            target.RotateDown();
        }

        [PexMethod]
        public void Set(
            [PexAssumeUnderTest]NetBitVector target,
            int bitIndex,
            bool value
        )
        {
            target.Set(bitIndex, value);
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetBitVector target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
