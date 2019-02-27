// <copyright file="NetAESEncryptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetAESEncryption))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetAESEncryptionTest
    {
        [PexMethod]
        public NetAESEncryption Constructor(byte[] key, byte[] iv)
        {
            NetAESEncryption target = new NetAESEncryption(key, iv);
            return target;
        }

        [PexMethod]
        public NetAESEncryption Constructor01(string key, int bitsize)
        {
            NetAESEncryption target = new NetAESEncryption(key, bitsize);
            return target;
        }

        [PexMethod]
        public NetAESEncryption Constructor02(string key)
        {
            NetAESEncryption target = new NetAESEncryption(key);
            return target;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetAESEncryption target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeUnderTest]NetAESEncryption target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
