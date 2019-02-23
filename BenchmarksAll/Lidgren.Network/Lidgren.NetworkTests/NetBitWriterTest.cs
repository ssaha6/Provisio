// <copyright file="NetBitWriterTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetBitWriter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetBitWriterTest
    {
        [PexMethod]
        public byte ReadByte(
            byte[] fromBuffer,
            int numberOfBits,
            int readBitOffset
        )
        {
            byte result = NetBitWriter.ReadByte(fromBuffer, numberOfBits, readBitOffset);
            return result;
        }

        [PexMethod]
        public void ReadBytes(
            byte[] fromBuffer,
            int numberOfBytes,
            int readBitOffset,
            byte[] destination,
            int destinationByteOffset
        )
        {
            NetBitWriter.ReadBytes(fromBuffer, numberOfBytes, 
                                   readBitOffset, destination, destinationByteOffset);
        }

        [PexMethod]
        public uint ReadUInt32(
            byte[] fromBuffer,
            int numberOfBits,
            int readBitOffset
        )
        {
            uint result = NetBitWriter.ReadUInt32(fromBuffer, numberOfBits, readBitOffset);
            return result;
        }

        [PexMethod]
        public uint ReadVariableUInt32(byte[] buffer, ref int offset)
        {
            uint result = NetBitWriter.ReadVariableUInt32(buffer, ref offset);
            return result;
        }

        [PexMethod]
        public void WriteByte(
            byte source,
            int numberOfBits,
            byte[] destination,
            int destBitOffset
        )
        {
            NetBitWriter.WriteByte(source, numberOfBits, destination, destBitOffset);
        }

        [PexMethod]
        public void WriteBytes(
            byte[] source,
            int sourceByteOffset,
            int numberOfBytes,
            byte[] destination,
            int destBitOffset
        )
        {
            NetBitWriter.WriteBytes
                (source, sourceByteOffset, numberOfBytes, destination, destBitOffset);
        }

        [PexMethod]
        public int WriteUInt32(
            uint source,
            int numberOfBits,
            byte[] destination,
            int destinationBitOffset
        )
        {
            int result = NetBitWriter.WriteUInt32
                             (source, numberOfBits, destination, destinationBitOffset);
            return result;
        }

        [PexMethod]
        public int WriteUInt64(
            ulong source,
            int numberOfBits,
            byte[] destination,
            int destinationBitOffset
        )
        {
            int result = NetBitWriter.WriteUInt64
                             (source, numberOfBits, destination, destinationBitOffset);
            return result;
        }

        [PexMethod]
        public int WriteVariableUInt32(
            byte[] intoBuffer,
            int offset,
            uint value
        )
        {
            int result = NetBitWriter.WriteVariableUInt32(intoBuffer, offset, value);
            return result;
        }
    }
}
