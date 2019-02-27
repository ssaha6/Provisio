// <copyright file="NetIncomingMessageTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using System.Reflection;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetIncomingMessage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetIncomingMessageTest
    {
        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetIncomingMessage target,
            INetEncryption encryption
        )
        {
            bool result = target.Decrypt(encryption);
            return result;
        }

        [PexMethod]
        public NetDeliveryMethod DeliveryMethodGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            NetDeliveryMethod result = target.DeliveryMethod;
            return result;
        }

        [PexMethod]
        public int LengthBitsGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.LengthBits;
            return result;
        }

        [PexMethod]
        public int LengthBytesGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.LengthBytes;
            return result;
        }

        [PexMethod]
        public NetIncomingMessageType MessageTypeGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            NetIncomingMessageType result = target.MessageType;
            return result;
        }

        [PexMethod]
        public bool PeekBoolean([PexAssumeUnderTest]NetIncomingMessage target)
        {
            bool result = target.PeekBoolean();
            return result;
        }

        [PexMethod]
        public byte PeekByte([PexAssumeUnderTest]NetIncomingMessage target)
        {
            byte result = target.PeekByte();
            return result;
        }

        [PexMethod]
        public byte PeekByte01(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            byte result = target.PeekByte(numberOfBits);
            return result;
        }

        [PexMethod]
        public byte[] PeekBytes(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBytes
        )
        {
            byte[] result = target.PeekBytes(numberOfBytes);
            return result;
        }

        [PexMethod]
        public void PeekBytes01(
            [PexAssumeUnderTest]NetIncomingMessage target,
            byte[] into,
            int offset,
            int numberOfBytes
        )
        {
            target.PeekBytes(into, offset, numberOfBytes);
        }

        [PexMethod]
        public byte[] PeekDataBuffer([PexAssumeUnderTest]NetIncomingMessage target)
        {
            byte[] result = target.PeekDataBuffer();
            return result;
        }

        [PexMethod]
        public double PeekDouble([PexAssumeUnderTest]NetIncomingMessage target)
        {
            double result = target.PeekDouble();
            return result;
        }

        [PexMethod]
        public float PeekFloat([PexAssumeUnderTest]NetIncomingMessage target)
        {
            float result = target.PeekFloat();
            return result;
        }

        [PexMethod]
        public short PeekInt16([PexAssumeUnderTest]NetIncomingMessage target)
        {
            short result = target.PeekInt16();
            return result;
        }

        [PexMethod]
        public int PeekInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.PeekInt32();
            return result;
        }

        [PexMethod]
        public int PeekInt3201(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            int result = target.PeekInt32(numberOfBits);
            return result;
        }

        [PexMethod]
        public long PeekInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            long result = target.PeekInt64();
            return result;
        }

        [PexMethod]
        public long PeekInt6401(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            long result = target.PeekInt64(numberOfBits);
            return result;
        }

        [PexMethod]
        public sbyte PeekSByte([PexAssumeUnderTest]NetIncomingMessage target)
        {
            sbyte result = target.PeekSByte();
            return result;
        }

        [PexMethod]
        public float PeekSingle([PexAssumeUnderTest]NetIncomingMessage target)
        {
            float result = target.PeekSingle();
            return result;
        }

        [PexMethod]
        public string PeekString([PexAssumeUnderTest]NetIncomingMessage target)
        {
            string result = target.PeekString();
            return result;
        }

        [PexMethod]
        public ushort PeekUInt16([PexAssumeUnderTest]NetIncomingMessage target)
        {
            ushort result = target.PeekUInt16();
            return result;
        }

        [PexMethod]
        public uint PeekUInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            uint result = target.PeekUInt32();
            return result;
        }

        [PexMethod]
        public uint PeekUInt3201(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            uint result = target.PeekUInt32(numberOfBits);
            return result;
        }

        [PexMethod]
        public ulong PeekUInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            ulong result = target.PeekUInt64();
            return result;
        }

        [PexMethod]
        public ulong PeekUInt6401(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            ulong result = target.PeekUInt64(numberOfBits);
            return result;
        }

        [PexMethod]
        public long PositionGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            long result = target.Position;
            return result;
        }

        [PexMethod]
        public int PositionInBytesGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.PositionInBytes;
            return result;
        }

        [PexMethod]
        public void PositionSet([PexAssumeUnderTest]NetIncomingMessage target, long value)
        {
            target.Position = value;
        }

        [PexMethod]
        public void ReadAllFields([PexAssumeUnderTest]NetIncomingMessage target01, object target)
        {
            target01.ReadAllFields(target);
        }

        [PexMethod]
        public void ReadAllFields01(
            [PexAssumeUnderTest]NetIncomingMessage target01,
            object target,
            BindingFlags flags
        )
        {
            target01.ReadAllFields(target, flags);
        }

        [PexMethod]
        public void ReadAllProperties([PexAssumeUnderTest]NetIncomingMessage target01, object target)
        {
            target01.ReadAllProperties(target);
        }

        [PexMethod]
        public void ReadAllProperties01(
            [PexAssumeUnderTest]NetIncomingMessage target01,
            object target,
            BindingFlags flags
        )
        {
            target01.ReadAllProperties(target, flags);
        }

        [PexMethod]
        public void ReadBits(
            [PexAssumeUnderTest]NetIncomingMessage target,
            byte[] into,
            int offset,
            int numberOfBits
        )
        {
            target.ReadBits(into, offset, numberOfBits);
        }

        [PexMethod]
        public bool ReadBoolean([PexAssumeUnderTest]NetIncomingMessage target)
        {
            bool result = target.ReadBoolean();
            return result;
        }

        [PexMethod]
        public byte ReadByte([PexAssumeUnderTest]NetIncomingMessage target)
        {
            byte result = target.ReadByte();
            return result;
        }

        [PexMethod]
        public byte ReadByte01(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            byte result = target.ReadByte(numberOfBits);
            return result;
        }

        [PexMethod]
        public byte[] ReadBytes(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBytes
        )
        {
            byte[] result = target.ReadBytes(numberOfBytes);
            return result;
        }

        [PexMethod]
        public void ReadBytes01(
            [PexAssumeUnderTest]NetIncomingMessage target,
            byte[] into,
            int offset,
            int numberOfBytes
        )
        {
            target.ReadBytes(into, offset, numberOfBytes);
        }

        [PexMethod]
        public double ReadDouble([PexAssumeUnderTest]NetIncomingMessage target)
        {
            double result = target.ReadDouble();
            return result;
        }

        [PexMethod]
        public float ReadFloat([PexAssumeUnderTest]NetIncomingMessage target)
        {
            float result = target.ReadFloat();
            return result;
        }

        [PexMethod]
        public IPEndPoint ReadIPEndpoint([PexAssumeUnderTest]NetIncomingMessage target)
        {
            IPEndPoint result = target.ReadIPEndpoint();
            return result;
        }

        [PexMethod]
        public short ReadInt16([PexAssumeUnderTest]NetIncomingMessage target)
        {
            short result = target.ReadInt16();
            return result;
        }

        [PexMethod]
        public int ReadInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.ReadInt32();
            return result;
        }

        [PexMethod]
        public int ReadInt3201(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            int result = target.ReadInt32(numberOfBits);
            return result;
        }

        [PexMethod]
        public long ReadInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            long result = target.ReadInt64();
            return result;
        }

        [PexMethod]
        public long ReadInt6401(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            long result = target.ReadInt64(numberOfBits);
            return result;
        }

        [PexMethod]
        public void ReadPadBits([PexAssumeUnderTest]NetIncomingMessage target)
        {
            target.ReadPadBits();
        }

        [PexMethod]
        public int ReadRangedInteger(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int min,
            int max
        )
        {
            int result = target.ReadRangedInteger(min, max);
            return result;
        }

        [PexMethod]
        public float ReadRangedSingle(
            [PexAssumeUnderTest]NetIncomingMessage target,
            float min,
            float max,
            int numberOfBits
        )
        {
            float result = target.ReadRangedSingle(min, max, numberOfBits);
            return result;
        }

        [PexMethod]
        public sbyte ReadSByte([PexAssumeUnderTest]NetIncomingMessage target)
        {
            sbyte result = target.ReadSByte();
            return result;
        }

        [PexMethod]
        public float ReadSignedSingle(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            float result = target.ReadSignedSingle(numberOfBits);
            return result;
        }

        [PexMethod]
        public float ReadSingle([PexAssumeUnderTest]NetIncomingMessage target)
        {
            float result = target.ReadSingle();
            return result;
        }

        [PexMethod]
        public string ReadString([PexAssumeUnderTest]NetIncomingMessage target)
        {
            string result = target.ReadString();
            return result;
        }

        [PexMethod]
        public double ReadTime(
            [PexAssumeUnderTest]NetIncomingMessage target,
            bool highPrecision
        )
        {
            double result = target.ReadTime(highPrecision);
            return result;
        }

        [PexMethod]
        public ushort ReadUInt16([PexAssumeUnderTest]NetIncomingMessage target)
        {
            ushort result = target.ReadUInt16();
            return result;
        }

        [PexMethod]
        public uint ReadUInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            uint result = target.ReadUInt32();
            return result;
        }

        [PexMethod]
        public uint ReadUInt3201(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            uint result = target.ReadUInt32(numberOfBits);
            return result;
        }

        [PexMethod]
        public ulong ReadUInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            ulong result = target.ReadUInt64();
            return result;
        }

        [PexMethod]
        public ulong ReadUInt6401(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            ulong result = target.ReadUInt64(numberOfBits);
            return result;
        }

        [PexMethod]
        public float ReadUnitSingle(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            float result = target.ReadUnitSingle(numberOfBits);
            return result;
        }

        [PexMethod]
        public int ReadVariableInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.ReadVariableInt32();
            return result;
        }

        [PexMethod]
        public long ReadVariableInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            long result = target.ReadVariableInt64();
            return result;
        }

        [PexMethod]
        public uint ReadVariableUInt32([PexAssumeUnderTest]NetIncomingMessage target)
        {
            uint result = target.ReadVariableUInt32();
            return result;
        }

        [PexMethod]
        public ulong ReadVariableUInt64([PexAssumeUnderTest]NetIncomingMessage target)
        {
            ulong result = target.ReadVariableUInt64();
            return result;
        }

        [PexMethod]
        public double ReceiveTimeGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            double result = target.ReceiveTime;
            return result;
        }

        [PexMethod]
        public NetConnection SenderConnectionGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            NetConnection result = target.SenderConnection;
            return result;
        }

        [PexMethod]
        public IPEndPoint SenderEndpointGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            IPEndPoint result = target.SenderEndpoint;
            return result;
        }

        [PexMethod]
        public int SequenceChannelGet([PexAssumeUnderTest]NetIncomingMessage target)
        {
            int result = target.SequenceChannel;
            return result;
        }

        [PexMethod]
        public void SkipPadBits([PexAssumeUnderTest]NetIncomingMessage target)
        {
            target.SkipPadBits();
        }

        [PexMethod]
        public void SkipPadBits01(
            [PexAssumeUnderTest]NetIncomingMessage target,
            int numberOfBits
        )
        {
            target.SkipPadBits(numberOfBits);
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetIncomingMessage target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
