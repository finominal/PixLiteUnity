using System;
using System.Net;
using ArtNet.Sockets;
using ArtNet.Packets;

namespace Sample
{

    class PixliteArtnet
    {
        private ArtNet.Sockets.ArtNetSocket artnet;

        public PixliteArtnet()
           { 
             //initialize Artnet
             artnet  = new ArtNet.Sockets.ArtNetSocket();
             artnet.EnableBroadcast = true;

             Console.WriteLine(artnet.BroadcastAddress.ToString());
             artnet.Open(IPAddress.Parse("192.168.0.2"), IPAddress.Parse("255.255.255.0"));
           }

        public void SendArtnetPacket(ArtNetDmxPacket dmxPacket)
        {
            artnet.Send(dmxPacket);

        }
    }
}
