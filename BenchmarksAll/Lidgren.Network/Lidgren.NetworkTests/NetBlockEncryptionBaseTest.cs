// <copyright file="NetBlockEncryptionBaseTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetBlockEncryptionBase))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetBlockEncryptionBaseTest
    {
        [PexMethod]
        public int BlockSizeGet([PexAssumeNotNull]NetBlockEncryptionBase target)
        {
            int result = target.BlockSize;
            return result;
        }

        [PexMethod]
        public bool Decrypt(
            [PexAssumeNotNull]NetBlockEncryptionBase target,
            NetIncomingMessage msg
        )
        {
            bool result = target.Decrypt(msg);
            return result;
        }

        [PexMethod]
        public bool Encrypt(
            [PexAssumeNotNull]NetBlockEncryptionBase target,
            NetOutgoingMessage msg
        )
        {
            bool result = target.Encrypt(msg);
            return result;
        }
    }
}
