// <copyright file="NetOutgoingMessageTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using System.Reflection;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using Microsoft.Pex.Framework.Settings;

namespace Lidgren.Network
{
    [PexClass(typeof(NetOutgoingMessage))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetOutgoingMessageTest
    {

        public static bool IsNull(object obj)
        {
            return obj == null;
        }
        // [PexMethod]
        [PexMethod]
        public bool PUT_Encrypt(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            INetEncryption encryption
        )
        {
            int encryptionBytesLength = encryption != null ? ((NetXorEncryption)encryption).m_key.Length : -1;

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_encryptionLength", encryptionBytesLength);
            PexObserve.ValueForViewing("$input_targetBytes", NetOutgoingMessageTest.IsNull(encryption));

            AssumePrecondition.IsTrue(  ((!(encryptionBytesLength <= 0))) );
            bool result = target.Encrypt(encryption);
            return result;
        }

        [PexMethod]
        public void PUT_EnsureBufferSize(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);

            AssumePrecondition.IsTrue(  true);
            target.EnsureBufferSize(numberOfBits);
        }

        [PexMethod]
        public void PUT_InternalEnsureBufferSize(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);

            AssumePrecondition.IsTrue(  true);
            target.InternalEnsureBufferSize(numberOfBits);
        }

        [PexMethod]
        public int PUT_LengthBitsGet([PexAssumeUnderTest]NetOutgoingMessage target)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            AssumePrecondition.IsTrue(  true);
            int result = target.LengthBits;
            return result;
        }

        [PexMethod]
        public void PUT_LengthBitsSet([PexAssumeUnderTest]NetOutgoingMessage target, int value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            target.LengthBits = value;
        }

        [PexMethod]
        public int PUT_LengthBytesGet([PexAssumeUnderTest]NetOutgoingMessage target)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            AssumePrecondition.IsTrue(  true);
            int result = target.LengthBytes;
            return result;
        }

        [PexMethod]
        public void PUT_LengthBytesSet([PexAssumeUnderTest]NetOutgoingMessage target, int value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            target.LengthBytes = value;
        }

        [PexMethod]
        public byte[] PUT_PeekDataBuffer([PexAssumeUnderTest]NetOutgoingMessage target)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            AssumePrecondition.IsTrue(  true);
            byte[] result = target.PeekDataBuffer();
            return result;
        }

        [PexMethod]
        public string PUT_ToString01([PexAssumeUnderTest]NetOutgoingMessage target)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);


            AssumePrecondition.IsTrue(  true);
            string result = target.ToString();
            return result;
        }

        [PexMethod]
        public void PUT_Write([PexAssumeUnderTest]NetOutgoingMessage target, bool value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            target.Write(value);
        }

        [PexMethod]
        public void PUT_Write01([PexAssumeUnderTest]NetOutgoingMessage target, byte source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write02([PexAssumeUnderTest]NetOutgoingMessage target, sbyte source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);


            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write03(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            byte source,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);

            AssumePrecondition.IsTrue(  ((!(numberOfBits <= 0)) && ((numberOfBits <= 8))) );
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write04([PexAssumeUnderTest]NetOutgoingMessage target, byte[] source)
        {
            int sourceLength = source != null ? source.Length : -1;
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", sourceLength);
            PexObserve.ValueForViewing("$input_targetBytes", NetOutgoingMessageTest.IsNull(source));

            //AssumePrecondition.IsTrue(  ((!(NetOutgoingMessageTest.IsNull(source)))) );
            AssumePrecondition.IsTrue(true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write05(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            byte[] source,
            int offsetInBytes,
            int numberOfBytes
        )
        {
            //PexAssume.IsTrue(offsetInBytes > -5 && offsetInBytes < 5);
            //PexAssume.IsTrue(numberOfBytes > -5 && numberOfBytes < 5);

            int sourceLength = source != null ? source.Length : -1;
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", sourceLength);
            PexObserve.ValueForViewing("$input_targetBytes", offsetInBytes);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBytes);
            PexObserve.ValueForViewing("$input_targetBytes", NetOutgoingMessageTest.IsNull(source));

            AssumePrecondition.IsTrue( true );
            target.Write(source, offsetInBytes, numberOfBytes);
        }

        [PexMethod]
        public void PUT_Write06([PexAssumeUnderTest]NetOutgoingMessage target, ushort source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write07(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            ushort source,
            int numberOfBits
        )
        {

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);
            PexObserve.ValueForViewing("$input_targetBits", numberOfBits);

            AssumePrecondition.IsTrue(  ((!(numberOfBits <= 0)) && ((numberOfBits <= 16))) );
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write08([PexAssumeUnderTest]NetOutgoingMessage target, short source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write09([PexAssumeUnderTest]NetOutgoingMessage target, int source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write10([PexAssumeUnderTest]NetOutgoingMessage target, uint source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write11(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            uint source,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);
            PexObserve.ValueForViewing("$input_targetBits", numberOfBits);

            AssumePrecondition.IsTrue(!(  ((!(numberOfBits <= 0)) && ((numberOfBits <= 32 && ((-target.LengthBits + target.LengthBytes + target.PeekDataBuffer().Length + -source + numberOfBits <= 19))))) ));
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write12(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int source,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);
            PexObserve.ValueForViewing("$input_targetBits", numberOfBits);
            AssumePrecondition.IsTrue(true);
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write13([PexAssumeUnderTest]NetOutgoingMessage target, ulong source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write14(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int source,
            int numberOfBits
        )
        {
            //PexAssume.IsTrue(source > -10001 && source < 10001);
            //PexAssume.IsTrue(numberOfBits > -10001 && numberOfBits < 10001);

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);
            PexObserve.ValueForViewing("$input_targetBits", numberOfBits);

            AssumePrecondition.IsTrue(  ((!(numberOfBits <= 0)) && ((numberOfBits <= 32))) );
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write15(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            long source
            )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write16(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            long source,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);
            PexObserve.ValueForViewing("$input_targetBits", numberOfBits);

            AssumePrecondition.IsTrue(  ((!(numberOfBits <= 0)) && ((numberOfBits <= 64))) );
            target.Write(source, numberOfBits);
        }

        [PexMethod]
        public void PUT_Write17([PexAssumeUnderTest]NetOutgoingMessage target, float source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true );
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write18([PexAssumeUnderTest]NetOutgoingMessage target, double source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source);

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write19([PexAssumeUnderTest]NetOutgoingMessage target, string source)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", source != null ? source.Length : -1);

            PexObserve.ValueForViewing("$input_targetBits", string.IsNullOrEmpty(source));

            AssumePrecondition.IsTrue(  true);
            target.Write(source);
        }

        [PexMethod]
        public void PUT_Write20(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            IPEndPoint endPoint
        )
        {
            int endPointPort = endPoint != null ? endPoint.Port : -7;
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", endPointPort);
            PexObserve.ValueForViewing("$input_targetBits", IsNull(endPoint));

            AssumePrecondition.IsTrue(  ((!(IsNull(endPoint)))) );
            target.Write(endPoint);
        }

        [PexMethod]
        public void PUT_Write21(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            NetOutgoingMessage message
        )
        {
            //NetOutgoingMessage[] tmp = new NetOutgoingMessage[2];
            //tmp[0] = target;
            //tmp[1] = message;
            //PexAssume.AreDistinctReferences(tmp);

            int messageLengthBits = !NetOutgoingMessageTest.IsNull(message) ? message.LengthBits : -1;
            int messageLengthBytes = !NetOutgoingMessageTest.IsNull(message) ? message.LengthBytes : -1;
            int messageBufferLength = !NetOutgoingMessageTest.IsNull(message) ? message.PeekDataBuffer().Length : -1;

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", messageLengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", messageLengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", messageBufferLength);
            PexObserve.ValueForViewing("$input_targetBits", IsNull(message));

            AssumePrecondition.IsTrue(  ((!(IsNull(message)))) );
            target.Write(message);
        }

        //[PexMethod]
        [PexMethod(TestEmissionFilter = PexTestEmissionFilter.All )]        
        public void PUT_Write22(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            NetIncomingMessage message
        )
        {
            int messageLengthBits = !NetOutgoingMessageTest.IsNull(message) ? message.LengthBits : -1;
            int messageLengthBytes = !NetOutgoingMessageTest.IsNull(message) ? message.LengthBytes : -1;
            int messageBufferLength = !NetOutgoingMessageTest.IsNull(message) ? message.PeekDataBuffer().Length : -1;

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBits", messageLengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", messageLengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", messageBufferLength);
            PexObserve.ValueForViewing("$input_targetBits", IsNull(message));

            AssumePrecondition.IsTrue(true);
            target.Write(message);
        }

        [PexMethod]
        public void PUT_WriteAllFields([PexAssumeUnderTest]NetOutgoingMessage target, object ob)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);

            AssumePrecondition.IsTrue(  true);
            target.WriteAllFields(ob);
        }

        [PexMethod]
        public void PUT_WriteAllFields01(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            object ob,
            BindingFlags flags
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);


            AssumePrecondition.IsTrue(  true);
            target.WriteAllFields(ob, flags);
        }

        [PexMethod]
        public void PUT_WriteAllProperties([PexAssumeUnderTest]NetOutgoingMessage target, object ob)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);

            AssumePrecondition.IsTrue(  true);
            target.WriteAllProperties(ob);
        }

        [PexMethod]
        public void PUT_WriteAllProperties01(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            object ob,
            BindingFlags flags
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            AssumePrecondition.IsTrue(  true);
            target.WriteAllProperties(ob, flags);
        }

        [PexMethod]
        public void PUT_WritePadBits([PexAssumeUnderTest]NetOutgoingMessage target)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            AssumePrecondition.IsTrue(true);
            target.WritePadBits();
        }

        [PexMethod]
        public void PUT_WritePadBits01(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int numberOfBits
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);
            AssumePrecondition.IsTrue(!(  ((!(target.LengthBits == target.LengthBytes))) ));
            target.WritePadBits(numberOfBits);
        }

        [PexMethod]
        public int PUT_WriteRangedInteger(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            int min,
            int max,
            int value
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", min);
            PexObserve.ValueForViewing("$input_targetBytes", max);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  ((!(-min + value <= -1)) && ((-max + value <= 0))) );
            int result = target.WriteRangedInteger(min, max, value);
            return result;
        }
           
        //[PexMethod(MaxRuns=200, TestEmissionFilter = PexTestEmissionFilter.All )]
        [PexMethod]
        public void PUT_WriteRangedSingle(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            float value,
            float min,
            float max,
            int numberOfBits
        )
        {
            //PexAssume.IsTrue(value > -101.0 && value < 101.0);
            //PexAssume.IsTrue(min > -101.0 && min < 101.0);
            //PexAssume.IsTrue(max > -101.0 && max < 101.0);

            //PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            //PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            //PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);
            PexObserve.ValueForViewing("$input_targetBytes", min);
            PexObserve.ValueForViewing("$input_targetBytes", max);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);

            AssumePrecondition.IsTrue(!(  ((!(-value + -min + max <= -0.9327261)) && ((-value + -min + max <= 16271.92 && (((!(min == numberOfBits)) && (((!(numberOfBits <= 0)) && ((numberOfBits <= 32 && ((-value + min + numberOfBits <= -234881000.0 && ((-min + numberOfBits <= -1))) ||  ((!(-value + min + numberOfBits <= -234881000.0))))))))))))) ));
            target.WriteRangedSingle(value, min, max, numberOfBits);
        }

        [PexMethod]
        public void PUT_WriteSignedSingle(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            float value,
            int numberOfBits
        )
        {
            //PexAssume.IsTrue(value > -101.0 && value < 101.0);

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);

            AssumePrecondition.IsTrue((value >= -1.0) && (value <= 1.0) && numberOfBits > 0 && numberOfBits <= 32);
            target.WriteSignedSingle(value, numberOfBits);
        }

        [PexMethod]
        public void PUT_WriteTime(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            double localTime,
            bool highPrecision
        )
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", localTime);
            PexObserve.ValueForViewing("$input_targetBytes", highPrecision);

            AssumePrecondition.IsTrue(  true);
            target.WriteTime(localTime, highPrecision);
        }

        [PexMethod]
        public void PUT_WriteUnitSingle(
            [PexAssumeUnderTest]NetOutgoingMessage target,
            float value,
            int numberOfBits
        )
        {
            PexAssume.IsTrue(value > -101.0 && value < 101.0);

            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);
            PexObserve.ValueForViewing("$input_targetBytes", numberOfBits);
            AssumePrecondition.IsTrue(  ((!(value <= -1.702578e-42)) && ((value <= 1 && (((!(numberOfBits <= 0)) && ((numberOfBits <= 32))))))) );
            target.WriteUnitSingle(value, numberOfBits);
        }

        [PexMethod]
        public int PUT_WriteVariableInt32([PexAssumeUnderTest]NetOutgoingMessage target, int value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            int result = target.WriteVariableInt32(value);
            return result;
        }

        [PexMethod]
        public int PUT_WriteVariableInt64([PexAssumeUnderTest]NetOutgoingMessage target, long value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            int result = target.WriteVariableInt64(value);
            return result;
        }

        [PexMethod]
        public int PUT_WriteVariableUInt32([PexAssumeUnderTest]NetOutgoingMessage target, uint value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            int result = target.WriteVariableUInt32(value);
            return result;
        }

        [PexMethod]
        public int PUT_WriteVariableUInt64([PexAssumeUnderTest]NetOutgoingMessage target, ulong value)
        {
            PexObserve.ValueForViewing("$input_targetBits", target.LengthBits);
            PexObserve.ValueForViewing("$input_targetBytes", target.LengthBytes);
            PexObserve.ValueForViewing("$input_targetBytes", target.PeekDataBuffer().Length);
            PexObserve.ValueForViewing("$input_targetBytes", value);

            AssumePrecondition.IsTrue(  true);
            int result = target.WriteVariableUInt64(value);
            return result;
        }
    }
}
