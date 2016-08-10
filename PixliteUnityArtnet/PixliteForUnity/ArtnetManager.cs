using System;
using System.Net;
using ArtNet.Sockets;
using ArtNet.Packets;

namespace PixliteForUnity
{
    class ArtnetManager
    {
        private ArtNetSocket artnet;

        public ArtnetManager()
        {
            //initialize Artnet
            artnet = new ArtNetSocket();
            artnet.EnableBroadcast = true;

            artnet.Open(IPAddress.Parse("192.168.0.2"), IPAddress.Parse("255.255.255.0"));
        }

        public void SendArtnetPacket(ArtNetDmxPacket dmxPacket)
        {
            artnet.Send(dmxPacket);
        }
    }
}
