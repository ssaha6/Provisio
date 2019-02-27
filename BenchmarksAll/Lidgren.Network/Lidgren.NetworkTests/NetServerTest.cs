// <copyright file="NetServerTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetServer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetServerTest
    {
        [PexMethod]
        public NetServer Constructor(NetPeerConfiguration config)
        {
            NetServer target = new NetServer(config);
            return target;
        }

        [PexMethod]
        public void SendToAll(
            [PexAssumeUnderTest]NetServer target,
            NetOutgoingMessage msg,
            NetDeliveryMethod method
        )
        {
            target.SendToAll(msg, method);
        }

        [PexMethod]
        public void SendToAll01(
            [PexAssumeUnderTest]NetServer target,
            NetOutgoingMessage msg,
            NetConnection except,
            NetDeliveryMethod method,
            int sequenceChannel
        )
        {
            target.SendToAll(msg, except, method, sequenceChannel);
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetServer target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
