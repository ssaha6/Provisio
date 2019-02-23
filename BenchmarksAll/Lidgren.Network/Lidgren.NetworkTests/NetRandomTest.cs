// <copyright file="NetRandomTest.cs" company="Microsoft">Copyright © Microsoft 2010</copyright>
using System;
using Lidgren.Network;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lidgren.Network
{
    [PexClass(typeof(NetRandom))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class NetRandomTest
    {
        [PexMethod]
        public NetRandom Constructor()
        {
            NetRandom target = new NetRandom();
            return target;
        }

        [PexMethod]
        public NetRandom Constructor01(int seed)
        {
            NetRandom target = new NetRandom(seed);
            return target;
        }

        [PexMethod]
        public int GetSeed([PexAssumeUnderTest]NetRandom target, object forObject)
        {
            int result = target.GetSeed(forObject);
            return result;
        }

        [PexMethod]
        public int Next([PexAssumeUnderTest]NetRandom target)
        {
            int result = target.Next();
            return result;
        }

        [PexMethod]
        public int Next01([PexAssumeUnderTest]NetRandom target, int upperBound)
        {
            int result = target.Next(upperBound);
            return result;
        }

        [PexMethod]
        public int Next02(
            [PexAssumeUnderTest]NetRandom target,
            int lowerBound,
            int upperBound
        )
        {
            int result = target.Next(lowerBound, upperBound);
            return result;
        }

        [PexMethod]
        public bool NextBool([PexAssumeUnderTest]NetRandom target)
        {
            bool result = target.NextBool();
            return result;
        }

        [PexMethod]
        public void NextBytes([PexAssumeUnderTest]NetRandom target, byte[] buffer)
        {
            target.NextBytes(buffer);
        }

        [PexMethod]
        public double NextDouble([PexAssumeUnderTest]NetRandom target)
        {
            double result = target.NextDouble();
            return result;
        }

        [PexMethod]
        public int NextInt([PexAssumeUnderTest]NetRandom target)
        {
            int result = target.NextInt();
            return result;
        }

        [PexMethod]
        public float NextSingle([PexAssumeUnderTest]NetRandom target)
        {
            float result = target.NextSingle();
            return result;
        }

        [PexMethod]
        public uint NextUInt([PexAssumeUnderTest]NetRandom target)
        {
            uint result = target.NextUInt();
            return result;
        }

        [PexMethod]
        public void Reinitialise([PexAssumeUnderTest]NetRandom target, int seed)
        {
            target.Reinitialise(seed);
        }
    }
}
