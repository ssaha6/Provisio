// <copyright file="NetXteaTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetXtea))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetXteaTest
    {
        [PexMethod]
        public int BlockSizeGet([PexAssumeUnderTest]NetXtea target)
        {
            int result = target.BlockSize;
            return result;
        }

        [PexMethod]
        public NetXtea Constructor(byte[] key, int rounds)
        {
            NetXtea target = new NetXtea(key, rounds);
            return target;
        }

        [PexMethod]
        public NetXtea Constructor01(byte[] key)
        {
            NetXtea target = new NetXtea(key);
            return target;
        }

        [PexMethod]
        public NetXtea Constructor02(string key)
        {
            NetXtea target = new NetXtea(key);
            return target;
        }
    }
}
