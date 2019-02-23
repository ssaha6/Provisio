// <copyright file="NetTripleDESEncryptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetTripleDESEncryption))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetTripleDESEncryptionTest
    {
        [PexMethod]
        public NetTripleDESEncryption Constructor(byte[] key, byte[] iv)
        {
            NetTripleDESEncryption target = new NetTripleDESEncryption(key, iv);
            return target;
        }

        [PexMethod]
        public NetTripleDESEncryption Constructor01(string key, int bitsize)
        {
            NetTripleDESEncryption target = new NetTripleDESEncryption(key, bitsize);
            return target;
        }

        [PexMethod]
        public NetTripleDESEncryption Constructor02(string key)
        {
            NetTripleDESEncryption target = new NetTripleDESEncryption(key);
            return target;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetTripleDESEncryption target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeUnderTest]NetTripleDESEncryption target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
