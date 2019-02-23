// <copyright file="NetRC2EncryptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetRC2Encryption))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetRC2EncryptionTest
    {
        [PexMethod]
        public NetRC2Encryption Constructor(byte[] key, byte[] iv)
        {
            NetRC2Encryption target = new NetRC2Encryption(key, iv);
            return target;
        }

        [PexMethod]
        public NetRC2Encryption Constructor01(string key, int bitsize)
        {
            NetRC2Encryption target = new NetRC2Encryption(key, bitsize);
            return target;
        }

        [PexMethod]
        public NetRC2Encryption Constructor02(string key)
        {
            NetRC2Encryption target = new NetRC2Encryption(key);
            return target;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeUnderTest]NetRC2Encryption target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeUnderTest]NetRC2Encryption target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
