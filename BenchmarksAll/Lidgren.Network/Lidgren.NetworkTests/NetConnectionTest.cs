// <copyright file="NetConnectionTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetConnection))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetConnectionTest
    {
        [PexMethod]
        public void Approve([PexAssumeUnderTest]NetConnection target)
        {
            target.Approve();
        }

        [PexMethod]
        public void Approve01(
            [PexAssumeUnderTest]NetConnection target,
            NetOutgoingMessage localHail
        )
        {
            target.Approve(localHail);
        }

        [PexMethod]
        public float AverageRoundtripTimeGet([PexAssumeUnderTest]NetConnection target)
        {
            float result = target.AverageRoundtripTime;
            return result;
        }

        [PexMethod]
        public void Deny([PexAssumeUnderTest]NetConnection target)
        {
            target.Deny();
        }

        [PexMethod]
        public void Deny01([PexAssumeUnderTest]NetConnection target, string reason)
        {
            target.Deny(reason);
        }

        [PexMethod]
        public void Disconnect([PexAssumeUnderTest]NetConnection target, string byeMessage)
        {
            target.Disconnect(byeMessage);
        }

        [PexMethod]
        public double GetLocalTime(
            [PexAssumeUnderTest]NetConnection target,
            double remoteTimestamp
        )
        {
            double result = target.GetLocalTime(remoteTimestamp);
            return result;
        }

        [PexMethod]
        public double GetRemoteTime([PexAssumeUnderTest]NetConnection target, double localTimestamp)
        {
            double result = target.GetRemoteTime(localTimestamp);
            return result;
        }

        [PexMethod]
        public void GetSendQueueInfo(
            [PexAssumeUnderTest]NetConnection target,
            NetDeliveryMethod method,
            int sequenceChannel,
            out int windowSize,
            out int freeWindowSlots
        )
        {
            target.GetSendQueueInfo
                (method, sequenceChannel, out windowSize, out freeWindowSlots);
        }

        [PexMethod]
        public NetOutgoingMessage LocalHailMessageGet([PexAssumeUnderTest]NetConnection target)
        {
            NetOutgoingMessage result = target.LocalHailMessage;
            return result;
        }

        [PexMethod]
        public NetPeer PeerGet([PexAssumeUnderTest]NetConnection target)
        {
            NetPeer result = target.Peer;
            return result;
        }

        [PexMethod]
        public IPEndPoint RemoteEndpointGet([PexAssumeUnderTest]NetConnection target)
        {
            IPEndPoint result = target.RemoteEndpoint;
            return result;
        }

        [PexMethod]
        public NetIncomingMessage RemoteHailMessageGet([PexAssumeUnderTest]NetConnection target)
        {
            NetIncomingMessage result = target.RemoteHailMessage;
            return result;
        }

        [PexMethod]
        public float RemoteTimeOffsetGet([PexAssumeUnderTest]NetConnection target)
        {
            float result = target.RemoteTimeOffset;
            return result;
        }

        [PexMethod]
        public long RemoteUniqueIdentifierGet([PexAssumeUnderTest]NetConnection target)
        {
            long result = target.RemoteUniqueIdentifier;
            return result;
        }

        [PexMethod]
        public NetSendResult SendMessage(
            [PexAssumeUnderTest]NetConnection target,
            NetOutgoingMessage msg,
            NetDeliveryMethod method,
            int sequenceChannel
        )
        {
            NetSendResult result = target.SendMessage(msg, method, sequenceChannel);
            return result;
        }

        [PexMethod]
        public NetConnectionStatistics StatisticsGet([PexAssumeUnderTest]NetConnection target)
        {
            NetConnectionStatistics result = target.Statistics;
            return result;
        }

        [PexMethod]
        public NetConnectionStatus StatusGet([PexAssumeUnderTest]NetConnection target)
        {
            NetConnectionStatus result = target.Status;
            return result;
        }

        [PexMethod]
        public object TagGet([PexAssumeUnderTest]NetConnection target)
        {
            object result = target.Tag;
            return result;
        }

        [PexMethod]
        public void TagSet([PexAssumeUnderTest]NetConnection target, object value)
        {
            target.Tag = value;
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetConnection target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
