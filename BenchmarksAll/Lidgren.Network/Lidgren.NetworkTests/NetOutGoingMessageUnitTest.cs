using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PexAPIWrapper;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Globalization;

namespace Lidgren.Network
{
    [PexClass(typeof(NetOutgoingMessage))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetOutgoingMessageUnitTest
    {
        [TestMethod]
        public void TestMethodPUT_Write14()
        {
            NetOutgoingMessage netOutgoingMessage;
            byte[] bs = new byte[0];
            netOutgoingMessage = NetOutgoingMessageFactory.Create("\ud801", "\ud801", bs);
            int a = netOutgoingMessage.LengthBits;
            int b = netOutgoingMessage.LengthBytes;
            int c = netOutgoingMessage.PeekDataBuffer().Length;
            netOutgoingMessage.Write(0, 0);
        }
    }
}
