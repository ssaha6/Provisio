// <copyright file="NetSRPTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetSRP))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetSRPTest
    {
        [PexMethod]
        public byte[] ComputeClientEphemeral(byte[] clientPrivateEphemeral)
        {
            byte[] result = NetSRP.ComputeClientEphemeral(clientPrivateEphemeral);
            return result;
        }

        [PexMethod]
        public byte[] ComputeClientSessionValue(
            byte[] serverPublicEphemeral,
            byte[] xdata,
            byte[] udata,
            byte[] clientPrivateEphemeral
        )
        {
            byte[] result = NetSRP.ComputeClientSessionValue
                                (serverPublicEphemeral, xdata, udata, clientPrivateEphemeral);
            return result;
        }

        [PexMethod]
        public byte[] ComputePrivateKey(
            string username,
            string password,
            byte[] salt
        )
        {
            byte[] result = NetSRP.ComputePrivateKey(username, password, salt);
            return result;
        }

        [PexMethod]
        public byte[] ComputeServerEphemeral(byte[] serverPrivateEphemeral, byte[] verifier)
        {
            byte[] result = NetSRP.ComputeServerEphemeral(serverPrivateEphemeral, verifier);
            return result;
        }

        [PexMethod]
        public byte[] ComputeServerSessionValue(
            byte[] clientPublicEphemeral,
            byte[] verifier,
            byte[] udata,
            byte[] serverPrivateEphemeral
        )
        {
            byte[] result = NetSRP.ComputeServerSessionValue
                                (clientPublicEphemeral, verifier, udata, serverPrivateEphemeral);
            return result;
        }

        [PexMethod]
        public byte[] ComputeServerVerifier(byte[] privateKey)
        {
            byte[] result = NetSRP.ComputeServerVerifier(privateKey);
            return result;
        }

        [PexMethod]
        public byte[] ComputeU(byte[] clientPublicEphemeral, byte[] serverPublicEphemeral)
        {
            byte[] result = NetSRP.ComputeU(clientPublicEphemeral, serverPublicEphemeral);
            return result;
        }

        [PexMethod]
        public NetXtea CreateEncryption(byte[] sessionValue)
        {
            NetXtea result = NetSRP.CreateEncryption(sessionValue);
            return result;
        }

        [PexMethod]
        public byte[] CreateRandomEphemeral()
        {
            byte[] result = NetSRP.CreateRandomEphemeral();
            return result;
        }

        [PexMethod]
        public byte[] CreateRandomSalt()
        {
            byte[] result = NetSRP.CreateRandomSalt();
            return result;
        }

        [PexMethod]
        public byte[] Hash(byte[] data)
        {
            byte[] result = NetSRP.Hash(data);
            return result;
        }
    }
}
