// <copyright file="NetClientTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetClient))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetClientTest
    {
        [PexMethod]
        public NetConnection Connect(
            [PexAssumeUnderTest]NetClient target,
            IPEndPoint remoteEndpoint,
            NetOutgoingMessage hailMessage
        )
        {
            NetConnection result = target.Connect(remoteEndpoint, hailMessage);
            return result;
        }

        [PexMethod]
        public NetConnectionStatus ConnectionStatusGet([PexAssumeUnderTest]NetClient target)
        {
            NetConnectionStatus result = target.ConnectionStatus;
            return result;
        }

        [PexMethod]
        public NetClient Constructor(NetPeerConfiguration config)
        {
            NetClient target = new NetClient(config);
            return target;
        }

        [PexMethod]
        public void Disconnect([PexAssumeUnderTest]NetClient target, string byeMessage)
        {
            target.Disconnect(byeMessage);
        }

        [PexMethod]
        public NetSendResult SendMessage(
            [PexAssumeUnderTest]NetClient target,
            NetOutgoingMessage msg,
            NetDeliveryMethod method
        )
        {
            NetSendResult result = target.SendMessage(msg, method);
            return result;
        }

        [PexMethod]
        public NetSendResult SendMessage01(
            [PexAssumeUnderTest]NetClient target,
            NetOutgoingMessage msg,
            NetDeliveryMethod method,
            int sequenceChannel
        )
        {
            NetSendResult result = target.SendMessage(msg, method, sequenceChannel);
            return result;
        }

        [PexMethod]
        public NetConnection ServerConnectionGet([PexAssumeUnderTest]NetClient target)
        {
            NetConnection result = target.ServerConnection;
            return result;
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetClient target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
