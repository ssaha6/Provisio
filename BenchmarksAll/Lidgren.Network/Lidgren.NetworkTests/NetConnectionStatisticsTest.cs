// <copyright file="NetConnectionStatisticsTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetConnectionStatistics))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetConnectionStatisticsTest
    {
        [PexMethod]
        public int ReceivedBytesGet([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            int result = target.ReceivedBytes;
            return result;
        }

        [PexMethod]
        public int ReceivedPacketsGet([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            int result = target.ReceivedPackets;
            return result;
        }

        [PexMethod]
        public int ResentMessagesGet([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            int result = target.ResentMessages;
            return result;
        }

        [PexMethod]
        public int SentBytesGet([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            int result = target.SentBytes;
            return result;
        }

        [PexMethod]
        public int SentPacketsGet([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            int result = target.SentPackets;
            return result;
        }

        [PexMethod]
        public string ToString01([PexAssumeUnderTest]NetConnectionStatistics target)
        {
            string result = target.ToString();
            return result;
        }
    }
}
