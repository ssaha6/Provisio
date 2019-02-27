using System;
using Microsoft.Pex.Framework;
using Lidgren.Network;

namespace Lidgren.Network
{
    /// <summary>A factory for Lidgren.Network.NetOutgoingMessage instances</summary>
    public static partial class NetIncomingMessageFactory
    {
        /// <summary>A factory for Lidgren.Network.NetOutgoingMessage instances</summary>
        [PexFactoryMethod(typeof(NetIncomingMessage))]
        public static NetIncomingMessage Create(int size, [PexAssumeNotNull]string appIdentifier, byte source)
        {
            //PexAssume.IsTrue(!string.IsNullOrEmpty(appIdentifier));

            NetPeerConfiguration config = new NetPeerConfiguration(appIdentifier);
            NetPeer peer = new NetPeer(config);

            NetIncomingMessage inM = peer.CreateIncomingMessage(NetIncomingMessageType.Data , size);
            return inM;
            // TODO: Edit factory method of NetOutgoingMessage
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
