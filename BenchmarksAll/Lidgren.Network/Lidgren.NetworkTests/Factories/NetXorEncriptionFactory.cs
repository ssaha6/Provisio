using System;
using Microsoft.Pex.Framework;
using Lidgren.Network;

namespace Lidgren.Network
{
    /// <summary>A factory for Lidgren.Network.NetOutgoingMessage instances</summary>
    public static partial class NetXorEncryptionFactory
    {
        /// <summary>A factory for Lidgren.Network.NetOutgoingMessage instances</summary>
        [PexFactoryMethod(typeof(NetXorEncryption))]
        public static NetXorEncryption Create([PexAssumeNotNull]byte[] key)
        {
            return new NetXorEncryption(key);
            
        }
    }
}
