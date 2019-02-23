// <copyright file="NetPeerTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetPeer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetPeerTest
    {
        [PexMethod]
        public NetPeerConfiguration ConfigurationGet([PexAssumeUnderTest]NetPeer target)
        {
            NetPeerConfiguration result = target.Configuration;
            return result;
        }

        [PexMethod]
        public NetConnection Connect(
            [PexAssumeUnderTest]NetPeer target,
            string host,
            int port
        )
        {
            NetConnection result = target.Connect(host, port);
            return result;
        }

        [PexMethod]
        public NetConnection Connect01(
            [PexAssumeUnderTest]NetPeer target,
            string host,
            int port,
            NetOutgoingMessage hailMessage
        )
        {
            NetConnection result = target.Connect(host, port, hailMessage);
            return result;
        }

        [PexMethod]
        public NetConnection Connect02([PexAssumeUnderTest]NetPeer target, IPEndPoint remoteEndpoint)
        {
            NetConnection result = target.Connect(remoteEndpoint);
            return result;
        }

        [PexMethod]
        public NetConnection Connect03(
            [PexAssumeUnderTest]NetPeer target,
            IPEndPoint remoteEndpoint,
            NetOutgoingMessage hailMessage
        )
        {
            NetConnection result = target.Connect(remoteEndpoint, hailMessage);
            return result;
        }

        [PexMethod]
        public int ConnectionsCountGet([PexAssumeUnderTest]NetPeer target)
        {
            int result = target.ConnectionsCount;
            return result;
        }

        [PexMethod]
        public List<NetConnection> ConnectionsGet([PexAssumeUnderTest]NetPeer target)
        {
            List<NetConnection> result = target.Connections;
            return result;
        }

        [PexMethod]
        public NetPeer Constructor(NetPeerConfiguration config)
        {
            NetPeer target = new NetPeer(config);
            return target;
        }

        [PexMethod]
        public NetOutgoingMessage CreateMessage([PexAssumeUnderTest]NetPeer target)
        {
            NetOutgoingMessage result = target.CreateMessage();
            return result;
        }

        [PexMethod]
        public NetOutgoingMessage CreateMessage01([PexAssumeUnderTest]NetPeer target, string content)
        {
            NetOutgoingMessage result = target.CreateMessage(content);
            return result;
        }

        [PexMethod]
        public NetOutgoingMessage CreateMessage02([PexAssumeUnderTest]NetPeer target, int initialCapacity)
        {
            NetOutgoingMessage result = target.CreateMessage(initialCapacity);
            return result;
        }

        [PexMethod]
        public bool DiscoverKnownPeer(
            [PexAssumeUnderTest]NetPeer target,
            string host,
            int serverPort
        )
        {
            bool result = target.DiscoverKnownPeer(host, serverPort);
            return result;
        }

        [PexMethod]
        public void DiscoverKnownPeer01([PexAssumeUnderTest]NetPeer target, IPEndPoint endpoint)
        {
            target.DiscoverKnownPeer(endpoint);
        }

        [PexMethod]
        public void DiscoverLocalPeers([PexAssumeUnderTest]NetPeer target, int serverPort)
        {
            target.DiscoverLocalPeers(serverPort);
        }

        [PexMethod]
        public NetConnection GetConnection([PexAssumeUnderTest]NetPeer target, IPEndPoint ep)
        {
            NetConnection result = target.GetConnection(ep);
            return result;
        }

        [PexMethod]
        public void Introduce(
            [PexAssumeUnderTest]NetPeer target,
            IPEndPoint hostInternal,
            IPEndPoint hostExternal,
            IPEndPoint clientInternal,
            IPEndPoint clientExternal,
            string token
        )
        {
            target.Introduce
                (hostInternal, hostExternal, clientInternal, clientExternal, token);
        }

        [PexMethod]
        public AutoResetEvent MessageReceivedEventGet([PexAssumeUnderTest]NetPeer target)
        {
            AutoResetEvent result = target.MessageReceivedEvent;
            return result;
        }

        [PexMethod]
        public int PortGet([PexAssumeUnderTest]NetPeer target)
        {
            int result = target.Port;
            return result;
        }

        [PexMethod]
        public void RawSend(
            [PexAssumeUnderTest]NetPeer target,
            byte[] arr,
            int offset,
            int length,
            IPEndPoint destination
        )
        {
            target.RawSend(arr, offset, length, destination);
        }

        [PexMethod]
        public NetIncomingMessage ReadMessage([PexAssumeUnderTest]NetPeer target)
        {
            NetIncomingMessage result = target.ReadMessage();
            return result;
        }

        [PexMethod]
        public void Recycle([PexAssumeUnderTest]NetPeer target, NetIncomingMessage msg)
        {
            target.Recycle(msg);
        }

        [PexMethod]
        public void RegisterReceivedCallback([PexAssumeUnderTest]NetPeer target, SendOrPostCallback callback)
        {
            target.RegisterReceivedCallback(callback);
        }

        [PexMethod]
        public void SendDiscoveryResponse(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            IPEndPoint recipient
        )
        {
            target.SendDiscoveryResponse(msg, recipient);
        }

        [PexMethod]
        public NetSendResult SendMessage(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            NetConnection recipient,
            NetDeliveryMethod method
        )
        {
            NetSendResult result = target.SendMessage(msg, recipient, method);
            return result;
        }

        [PexMethod]
        public NetSendResult SendMessage01(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            NetConnection recipient,
            NetDeliveryMethod method,
            int sequenceChannel
        )
        {
            NetSendResult result
               = target.SendMessage(msg, recipient, method, sequenceChannel);
            return result;
        }

        [PexMethod]
        public void SendMessage02(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            IList<NetConnection> recipients,
            NetDeliveryMethod method,
            int sequenceChannel
        )
        {
            target.SendMessage(msg, recipients, method, sequenceChannel);
        }

        [PexMethod]
        public void SendUnconnectedMessage(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            string host,
            int port
        )
        {
            target.SendUnconnectedMessage(msg, host, port);
        }

        [PexMethod]
        public void SendUnconnectedMessage01(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            IPEndPoint recipient
        )
        {
            target.SendUnconnectedMessage(msg, recipient);
        }

        [PexMethod]
        public void SendUnconnectedMessage02(
            [PexAssumeUnderTest]NetPeer target,
            NetOutgoingMessage msg,
            IList<IPEndPoint> recipients
        )
        {
            target.SendUnconnectedMessage(msg, recipients);
        }

        [PexMethod]
        public void Shutdown([PexAssumeUnderTest]NetPeer target, string bye)
        {
            target.Shutdown(bye);
        }

        [PexMethod]
        public PlatformSocket SocketGet([PexAssumeUnderTest]NetPeer target)
        {
            PlatformSocket result = target.Socket;
            return result;
        }

        [PexMethod]
        public void Start([PexAssumeUnderTest]NetPeer target)
        {
            target.Start();
        }

        [PexMethod]
        public NetPeerStatistics StatisticsGet([PexAssumeUnderTest]NetPeer target)
        {
            NetPeerStatistics result = target.Statistics;
            return result;
        }

        [PexMethod]
        public NetPeerStatus StatusGet([PexAssumeUnderTest]NetPeer target)
        {
            NetPeerStatus result = target.Status;
            return result;
        }

        [PexMethod]
        public object TagGet([PexAssumeUnderTest]NetPeer target)
        {
            object result = target.Tag;
            return result;
        }

        [PexMethod]
        public void TagSet([PexAssumeUnderTest]NetPeer target, object value)
        {
            target.Tag = value;
        }

        [PexMethod]
        public NetUPnP UPnPGet([PexAssumeUnderTest]NetPeer target)
        {
            NetUPnP result = target.UPnP;
            return result;
        }

        [PexMethod]
        public long UniqueIdentifierGet([PexAssumeUnderTest]NetPeer target)
        {
            long result = target.UniqueIdentifier;
            return result;
        }

        [PexMethod]
        public NetIncomingMessage WaitMessage([PexAssumeUnderTest]NetPeer target, int maxMillis)
        {
            NetIncomingMessage result = target.WaitMessage(maxMillis);
            return result;
        }
    }
}
