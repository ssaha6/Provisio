// <copyright file="NetUtilityTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using System.Net.NetworkInformation;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetUtility))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetUtilityTest
    {
        [PexMethod]
        public int BitsToHoldUInt(uint value)
        {
            int result = NetUtility.BitsToHoldUInt(value);
            return result;
        }

        [PexMethod]
        public int BytesToHoldBits(int numBits)
        {
            int result = NetUtility.BytesToHoldBits(numBits);
            return result;
        }

        [PexMethod]
        public IPAddress GetBroadcastAddress()
        {
            IPAddress result = NetUtility.GetBroadcastAddress();
            return result;
        }

        [PexMethod]
        public PhysicalAddress GetMacAddress()
        {
            PhysicalAddress result = NetUtility.GetMacAddress();
            return result;
        }

        [PexMethod]
        public IPAddress GetMyAddress(out IPAddress mask)
        {
            IPAddress result = NetUtility.GetMyAddress(out mask);
            return result;
        }

        [PexMethod]
        public int GetWindowSize(NetDeliveryMethod method)
        {
            int result = NetUtility.GetWindowSize(method);
            return result;
        }

        [PexMethod]
        public bool IsLocal(IPEndPoint endpoint)
        {
            bool result = NetUtility.IsLocal(endpoint);
            return result;
        }

        [PexMethod]
        public bool IsLocal01(IPAddress remote)
        {
            bool result = NetUtility.IsLocal(remote);
            return result;
        }

        [PexMethod]
        public IPEndPoint Resolve(string ipOrHost, int port)
        {
            IPEndPoint result = NetUtility.Resolve(ipOrHost, port);
            return result;
        }

        [PexMethod]
        public IPAddress Resolve01(string ipOrHost)
        {
            IPAddress result = NetUtility.Resolve(ipOrHost);
            return result;
        }

        [PexMethod]
        public byte[] ToByteArray(string hexString)
        {
            byte[] result = NetUtility.ToByteArray(hexString);
            return result;
        }

        [PexMethod]
        public string ToHexString(long data)
        {
            string result = NetUtility.ToHexString(data);
            return result;
        }

        [PexMethod]
        public string ToHexString01(byte[] data)
        {
            string result = NetUtility.ToHexString(data);
            return result;
        }

        [PexMethod]
        public string ToHumanReadable(long bytes)
        {
            string result = NetUtility.ToHumanReadable(bytes);
            return result;
        }
    }
}
