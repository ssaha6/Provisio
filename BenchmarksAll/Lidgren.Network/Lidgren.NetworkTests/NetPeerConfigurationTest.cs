// <copyright file="NetPeerConfigurationTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetPeerConfiguration))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetPeerConfigurationTest
    {
        [PexMethod]
        public bool AcceptIncomingConnectionsGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            bool result = target.AcceptIncomingConnections;
            return result;
        }

        [PexMethod]
        public void AcceptIncomingConnectionsSet([PexAssumeUnderTest]NetPeerConfiguration target, bool value)
        {
            target.AcceptIncomingConnections = value;
        }

        [PexMethod]
        public string AppIdentifierGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            string result = target.AppIdentifier;
            return result;
        }

        [PexMethod]
        public bool AutoExpandMTUGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            bool result = target.AutoExpandMTU;
            return result;
        }

        [PexMethod]
        public void AutoExpandMTUSet([PexAssumeUnderTest]NetPeerConfiguration target, bool value)
        {
            target.AutoExpandMTU = value;
        }

        [PexMethod]
        public IPAddress BroadcastAddressGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            IPAddress result = target.BroadcastAddress;
            return result;
        }

        [PexMethod]
        public void BroadcastAddressSet(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            IPAddress value
        )
        {
            target.BroadcastAddress = value;
        }

        [PexMethod]
        public NetPeerConfiguration Clone([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            NetPeerConfiguration result = target.Clone();
            return result;
        }

        [PexMethod]
        public float ConnectionTimeoutGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.ConnectionTimeout;
            return result;
        }

        [PexMethod]
        public void ConnectionTimeoutSet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.ConnectionTimeout = value;
        }

        [PexMethod]
        public NetPeerConfiguration Constructor(string appIdentifier)
        {
            NetPeerConfiguration target = new NetPeerConfiguration(appIdentifier);
            return target;
        }

        [PexMethod]
        public int DefaultOutgoingMessageCapacityGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.DefaultOutgoingMessageCapacity;
            return result;
        }

        [PexMethod]
        public void DefaultOutgoingMessageCapacitySet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.DefaultOutgoingMessageCapacity = value;
        }

        [PexMethod]
        public void DisableMessageType(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            NetIncomingMessageType type
        )
        {
            target.DisableMessageType(type);
        }

        [PexMethod]
        public void EnableMessageType(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            NetIncomingMessageType type
        )
        {
            target.EnableMessageType(type);
        }

        [PexMethod]
        public bool EnableUPnPGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            bool result = target.EnableUPnP;
            return result;
        }

        [PexMethod]
        public void EnableUPnPSet([PexAssumeUnderTest]NetPeerConfiguration target, bool value)
        {
            target.EnableUPnP = value;
        }

        [PexMethod]
        public int ExpandMTUFailAttemptsGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.ExpandMTUFailAttempts;
            return result;
        }

        [PexMethod]
        public void ExpandMTUFailAttemptsSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.ExpandMTUFailAttempts = value;
        }

        [PexMethod]
        public float ExpandMTUFrequencyGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.ExpandMTUFrequency;
            return result;
        }

        [PexMethod]
        public void ExpandMTUFrequencySet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.ExpandMTUFrequency = value;
        }

        [PexMethod]
        public bool IsMessageTypeEnabled(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            NetIncomingMessageType type
        )
        {
            bool result = target.IsMessageTypeEnabled(type);
            return result;
        }

        [PexMethod]
        public IPAddress LocalAddressGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            IPAddress result = target.LocalAddress;
            return result;
        }

        [PexMethod]
        public void LocalAddressSet(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            IPAddress value
        )
        {
            target.LocalAddress = value;
        }

        [PexMethod]
        public int MaximumConnectionsGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.MaximumConnections;
            return result;
        }

        [PexMethod]
        public void MaximumConnectionsSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.MaximumConnections = value;
        }

        [PexMethod]
        public int MaximumHandshakeAttemptsGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.MaximumHandshakeAttempts;
            return result;
        }

        [PexMethod]
        public void MaximumHandshakeAttemptsSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.MaximumHandshakeAttempts = value;
        }

        [PexMethod]
        public int MaximumTransmissionUnitGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.MaximumTransmissionUnit;
            return result;
        }

        [PexMethod]
        public void MaximumTransmissionUnitSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.MaximumTransmissionUnit = value;
        }

        [PexMethod]
        public string NetworkThreadNameGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            string result = target.NetworkThreadName;
            return result;
        }

        [PexMethod]
        public void NetworkThreadNameSet([PexAssumeUnderTest]NetPeerConfiguration target, string value)
        {
            target.NetworkThreadName = value;
        }

        [PexMethod]
        public float PingIntervalGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.PingInterval;
            return result;
        }

        [PexMethod]
        public void PingIntervalSet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.PingInterval = value;
        }

        [PexMethod]
        public int PortGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.Port;
            return result;
        }

        [PexMethod]
        public void PortSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.Port = value;
        }

        [PexMethod]
        public int ReceiveBufferSizeGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.ReceiveBufferSize;
            return result;
        }

        [PexMethod]
        public void ReceiveBufferSizeSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.ReceiveBufferSize = value;
        }

        [PexMethod]
        public float ResendHandshakeIntervalGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.ResendHandshakeInterval;
            return result;
        }

        [PexMethod]
        public void ResendHandshakeIntervalSet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.ResendHandshakeInterval = value;
        }

        [PexMethod]
        public int SendBufferSizeGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            int result = target.SendBufferSize;
            return result;
        }

        [PexMethod]
        public void SendBufferSizeSet([PexAssumeUnderTest]NetPeerConfiguration target, int value)
        {
            target.SendBufferSize = value;
        }

        [PexMethod]
        public void SetMessageTypeEnabled(
            [PexAssumeUnderTest]NetPeerConfiguration target,
            NetIncomingMessageType type,
            bool enabled
        )
        {
            target.SetMessageTypeEnabled(type, enabled);
        }

        [PexMethod]
        public float SimulatedAverageLatencyGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.SimulatedAverageLatency;
            return result;
        }

        [PexMethod]
        public float SimulatedDuplicatesChanceGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.SimulatedDuplicatesChance;
            return result;
        }

        [PexMethod]
        public void SimulatedDuplicatesChanceSet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.SimulatedDuplicatesChance = value;
        }

        [PexMethod]
        public float SimulatedLossGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.SimulatedLoss;
            return result;
        }

        [PexMethod]
        public void SimulatedLossSet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.SimulatedLoss = value;
        }

        [PexMethod]
        public float SimulatedMinimumLatencyGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.SimulatedMinimumLatency;
            return result;
        }

        [PexMethod]
        public void SimulatedMinimumLatencySet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.SimulatedMinimumLatency = value;
        }

        [PexMethod]
        public float SimulatedRandomLatencyGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            float result = target.SimulatedRandomLatency;
            return result;
        }

        [PexMethod]
        public void SimulatedRandomLatencySet([PexAssumeUnderTest]NetPeerConfiguration target, float value)
        {
            target.SimulatedRandomLatency = value;
        }

        [PexMethod]
        public bool UseMessageRecyclingGet([PexAssumeUnderTest]NetPeerConfiguration target)
        {
            bool result = target.UseMessageRecycling;
            return result;
        }

        [PexMethod]
        public void UseMessageRecyclingSet([PexAssumeUnderTest]NetPeerConfiguration target, bool value)
        {
            target.UseMessageRecycling = value;
        }
    }
}
