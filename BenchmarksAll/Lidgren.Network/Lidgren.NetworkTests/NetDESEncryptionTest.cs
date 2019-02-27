// <copyright file="NetDESEncryptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetDESEncryption))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetDESEncryptionTest
    {
        [PexMethod]
        public NetDESEncryption Constructor(byte[] key, byte[] iv)
        {
            NetDESEncryption target = new NetDESEncryption(key, iv);
            return target;
        }

        [PexMethod]
        public NetDESEncryption Constructor01(string key, int bitsize)
        {
            NetDESEncryption target = new NetDESEncryption(key, bitsize);
            return target;
        }

        [PexMethod]
        public NetDESEncryption Constructor02(string key)
        {
            NetDESEncryption target = new NetDESEncryption(key);
            return target;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetDESEncryption target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeUnderTest]NetDESEncryption target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
