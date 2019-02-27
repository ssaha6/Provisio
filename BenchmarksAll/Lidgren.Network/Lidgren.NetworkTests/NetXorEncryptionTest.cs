// <copyright file="NetXorEncryptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetXorEncryption))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetXorEncryptionTest
    {
        [PexMethod]
        public NetXorEncryption Constructor(byte[] key)
        {
            NetXorEncryption target = new NetXorEncryption(key);
            return target;
        }

        [PexMethod]
        public NetXorEncryption Constructor01(string key)
        {
            NetXorEncryption target = new NetXorEncryption(key);
            return target;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetXorEncryption target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeUnderTest]NetXorEncryption target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
