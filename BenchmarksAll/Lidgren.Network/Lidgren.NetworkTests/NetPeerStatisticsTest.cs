// <copyright file="NetPeerStatisticsTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetPeerStatistics))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetPeerStatisticsTest
    {
        [PexMethod]
        public int BytesInRecyclePoolGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.BytesInRecyclePool;
            return result;
        }

        [PexMethod]
        public int ReceivedBytesGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.ReceivedBytes;
            return result;
        }

        [PexMethod]
        public int ReceivedMessagesGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.ReceivedMessages;
            return result;
        }

        [PexMethod]
        public int ReceivedPacketsGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.ReceivedPackets;
            return result;
        }

        [PexMethod]
        public int SentBytesGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.SentBytes;
            return result;
        }

        [PexMethod]
        public int SentMessagesGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.SentMessages;
            return result;
        }

        [PexMethod]
        public int SentPacketsGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            int result = target.SentPackets;
            return result;
        }

        [PexMethod]
        public long StorageBytesAllocatedGet([PexAssumeUnderTest]NetPeerStatistics target)
        {
            long result = target.StorageBytesAllocated;
            return result;
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetPeerStatistics target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
