// <copyright file="PlatformSocketTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using System.Net;
using System.Net.Sockets;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(PlatformSocket))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PlatformSocketTest
    {
        [PexMethod]
        public int AvailableGet([PexAssumeUnderTest]PlatformSocket target)
        {
            int result = target.Available;
            return result;
        }

        [PexMethod]
        public bool BlockingGet([PexAssumeUnderTest]PlatformSocket target)
        {
            bool result = target.Blocking;
            return result;
        }

        [PexMethod]
        public void BlockingSet([PexAssumeUnderTest]PlatformSocket target, bool value)
        {
            target.Blocking = value;
        }

        [PexMethod]
        public void BroadcastSet([PexAssumeUnderTest]PlatformSocket target, bool value)
        {
            target.Broadcast = value;
        }

        [PexMethod]
        public void Close([PexAssumeUnderTest]PlatformSocket target, int timeout)
        {
            target.Close(timeout);
        }

        [PexMethod]
        public PlatformSocket Constructor()
        {
            PlatformSocket target = new PlatformSocket();
            return target;
        }

        [PexMethod]
        public bool DontFragmentGet([PexAssumeUnderTest]PlatformSocket target)
        {
            bool result = target.DontFragment;
            return result;
        }

        [PexMethod]
        public void DontFragmentSet([PexAssumeUnderTest]PlatformSocket target, bool value)
        {
            target.DontFragment = value;
        }

        [PexMethod]
        public void EndSendTo([PexAssumeUnderTest]PlatformSocket target, IAsyncResult res)
        {
            target.EndSendTo(res);
        }

        [PexMethod]
        public bool IsBoundGet([PexAssumeUnderTest]PlatformSocket target)
        {
            bool result = target.IsBound;
            return result;
        }

        [PexMethod]
        public EndPoint LocalEndPointGet([PexAssumeUnderTest]PlatformSocket target)
        {
            EndPoint result = target.LocalEndPoint;
            return result;
        }

        [PexMethod]
        public bool Poll([PexAssumeUnderTest]PlatformSocket target, int microseconds)
        {
            bool result = target.Poll(microseconds);
            return result;
        }

        [PexMethod]
        public int ReceiveBufferSizeGet([PexAssumeUnderTest]PlatformSocket target)
        {
            int result = target.ReceiveBufferSize;
            return result;
        }

        [PexMethod]
        public void ReceiveBufferSizeSet([PexAssumeUnderTest]PlatformSocket target, int value)
        {
            target.ReceiveBufferSize = value;
        }

        [PexMethod]
        public int ReceiveFrom(
            [PexAssumeUnderTest]PlatformSocket target,
            byte[] receiveBuffer,
            int offset,
            int numBytes,
            ref EndPoint senderRemote
        )
        {
            int result
               = target.ReceiveFrom(receiveBuffer, offset, numBytes, ref senderRemote);
            return result;
        }

        [PexMethod]
        public int SendBufferSizeGet([PexAssumeUnderTest]PlatformSocket target)
        {
            int result = target.SendBufferSize;
            return result;
        }

        [PexMethod]
        public void SendBufferSizeSet([PexAssumeUnderTest]PlatformSocket target, int value)
        {
            target.SendBufferSize = value;
        }

        [PexMethod]
        public int SendTo(
            [PexAssumeUnderTest]PlatformSocket target01,
            byte[] data,
            int offset,
            int numBytes,
            EndPoint target
        )
        {
            int result = target01.SendTo(data, offset, numBytes, target);
            return result;
        }

        [PexMethod]
        public void Setup([PexAssumeUnderTest]PlatformSocket target)
        {
            target.Setup();
        }

        [PexMethod]
        public void Shutdown(
            [PexAssumeUnderTest]PlatformSocket target,
            SocketShutdown socketShutdown
        )
        {
            target.Shutdown(socketShutdown);
        }
    }
}
