// <copyright file="NetTimeTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetTime))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetTimeTest
    {
        [PexMethod]
        public double NowGet()
        {
            double result = NetTime.Now;
            return result;
        }

        [PexMethod]
        public string ToReadable(double seconds)
        {
            string result = NetTime.ToReadable(seconds);
            return result;
        }
    }
}
