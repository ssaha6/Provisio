using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace Lidgren.Network
{
    [PexClass(typeof(NetBigInteger))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetBigIntegerUnitTest
    {
        [TestMethod]
        public void TestMethodModInverse()
        {
            NetBigInteger target = new NetBigInteger("5");
            NetBigInteger value = new NetBigInteger("1");
            NetBigInteger result = target.ModInverse(value);
            Assert.AreEqual(value.IntValue, 2);
            Assert.AreEqual(value.SignValue, 1);
        }

        [TestMethod]
        public void TestMethodMultiply()
        {
            NetBigInteger target = new NetBigInteger("5");
            NetBigInteger value = new NetBigInteger("1");
            NetBigInteger result = target.ModInverse(value);
            Assert.AreEqual(value.IntValue, 2);
            Assert.AreEqual(value.SignValue, 1);
        }

        [TestMethod]
        public void TestMethodGcd()
        {
            NetBigInteger target = new NetBigInteger("0");
            NetBigInteger value = new NetBigInteger("-1");
            NetBigInteger result = target.Gcd(value);
            Assert.AreEqual(value.IntValue, 2);
            Assert.AreEqual(value.SignValue, 1);
        }

        [TestMethod]
        public void TestMethodConstructor05()
        {
            NetBigInteger target = new NetBigInteger(0, (byte[])null, -35, 36);
        }

        [TestMethod]
        public void TestMethodModInverse1()
        {
            NetBigInteger target = new NetBigInteger("3");
            NetBigInteger value = new NetBigInteger("2");
            NetBigInteger result = target.ModInverse(value);
        }
    }
}
