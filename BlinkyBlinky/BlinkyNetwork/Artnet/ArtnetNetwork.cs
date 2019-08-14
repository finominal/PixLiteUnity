using System.Net;
using ArtNet.Sockets;
using ArtNet.Packets;
using BlinkyNetwork.DMX;

namespace BlinkyNetwork.Artnet
{
    class ArtnetNetwork : DMXNetwork
    {
        private ArtNetSocket artnetSocket;
        private const int artnetPort = 6454;

        public ArtnetNetwork(string networkName, IPAddress ipAddress) : base(networkName, ipAddress, DMXProtocol.Artnet)
        {
            //initialize Artnet Device
            artnetSocket = new ArtNetSocket();
            artnetSocket.EnableBroadcast = false;
            artnetSocket.Connect(ipAddress, artnetPort);
        }

        public override void Send(DMXDatagram datagram)
        {
            ArtNetDmxPacket packet = new ArtNetDmxPacket();
            packet.DmxData = datagram.Buffer;
            packet.Universe = datagram.UniverseNo;
            artnetSocket.Send(packet);
        }

        public override string ToString()
        {
            return artnetSocket.ToString();
        }
    }
}
