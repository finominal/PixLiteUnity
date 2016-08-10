using System;
using System.Net;
using ArtNet.Sockets;
using ArtNet.Packets;
using System.Threading;

namespace Sample
{
    class MainClass
    {


        public static void Main(string[] args)
        {
            PixliteArtnet artnetManager = new PixliteArtnet();
           
            byte r = 0;
            byte g = 0;
            byte b = 0;
            int counter = 0;
           

            while (true)
            {
                byte[] _dmxData = new byte[510];

                r = (byte)(counter % 255);
                b = (byte)(counter % 255);

                _dmxData[counter % 144] = r;
                _dmxData[counter % 144] = g;
                _dmxData[counter % 144] = b;

                ArtNetDmxPacket packet = new ArtNetDmxPacket();
                packet.DmxData = _dmxData;
                packet.Universe = 0;
                  

                artnetManager.SendArtnetPacket(packet);

                Console.WriteLine(counter );

               counter++;
                
                Thread.Sleep(10);

            }

            //var artnet = new ArtNet.Sockets.ArtNetSocket();
            //artnet.EnableBroadcast = true;

            //Console.WriteLine(artnet.BroadcastAddress.ToString());
            //artnet.Open(IPAddress.Parse("192.168.0.2"), IPAddress.Parse("255.255.255.0"));

            //byte[] _dmxData = new byte[511];

            //artnet.NewPacket += (object sender, ArtNet.Sockets.NewPacketEventArgs<ArtNet.Packets.ArtNetPacket> e) => 
            //{
            //    if(e.Packet.OpCode == ArtNet.Enums.ArtNetOpCodes.Dmx)
            //    {  
            //        var packet = e.Packet as ArtNet.Packets.ArtNetDmxPacket;
            //            Console.Clear();

            //            if(packet.DmxData != _dmxData)
            //            {
            //                Console.WriteLine("New Packet");
            //                for(var i = 0; i < packet.DmxData.Length; i++)
            //                {
            //                    if(packet.DmxData[i] != 0)
            //                        Console.WriteLine(i + " = " + packet.DmxData[i]);

            //                };

            //                _dmxData = packet.DmxData;
            //            }
            //        }
            //};

        }

        //public void SendPacket(byte[] _dmxData, short _universe)
        //{
        //    ArtNetDmxPacket packet = new ArtNetDmxPacket();
        //    packet.DmxData = _dmxData;
        //    packet.Universe = _universe;

        //    artnetManager.SendArtnetPacket(packet);
        //}
    }
}
