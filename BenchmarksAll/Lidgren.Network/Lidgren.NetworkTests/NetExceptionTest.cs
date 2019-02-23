// <copyright file="NetExceptionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetExceptionTest
    {
        [PexMethod]
        public void Assert(bool isOk, string message)
        {
            NetException.Assert(isOk, message);
        }

        [PexMethod]
        public void Assert01(bool isOk)
        {
            NetException.Assert(isOk);
        }

        [PexMethod]
        public NetException Constructor(string message)
        {
            NetException target = new NetException(message);
            return target;
        }

        [PexMethod]
        public NetException Constructor01(string message, Exception inner)
        {
            NetException target = new NetException(message, inner);
            return target;
        }
    }
}
