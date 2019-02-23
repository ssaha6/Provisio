// <copyright file="NetUPnPTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetUPnP))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetUPnPTest
    {
        [PexMethod]
        public NetUPnP Constructor(NetPeer peer)
        {
            NetUPnP target = new NetUPnP(peer);
            return target;
        }

        [PexMethod]
        public bool DeleteForwardingRule([PexAssumeUnderTest]NetUPnP target, int port)
        {
            bool result = target.DeleteForwardingRule(port);
            return result;
        }

        [PexMethod]
        public bool ForwardPort(
            [PexAssumeUnderTest]NetUPnP target,
            int port,
            string description
        )
        {
            bool result = target.ForwardPort(port, description);
            return result;
        }

        [PexMethod]
        public IPAddress GetExternalIP([PexAssumeUnderTest]NetUPnP target)
        {
            IPAddress result = target.GetExternalIP();
            return result;
        }
    }
}
