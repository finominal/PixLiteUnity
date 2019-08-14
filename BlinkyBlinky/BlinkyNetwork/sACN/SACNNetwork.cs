using System;
using System.Net;
using BlinkyNetwork.DMX;
using kadmium_sacn;

namespace BlinkyNetwork.sACN
{
    public class SACNNetwork : DMXNetwork
    {
        private SACNSender Sender;

        public SACNNetwork(string name, IPAddress ipaddress) : base(name, ipaddress, DMXProtocol.sACN)
        {
            Sender = new SACNSender(new Guid(), name);
            Sender.UnicastAddress = ipaddress;
        }

        public override void Send(DMXDatagram data)
        {
            Sender.Send(data.UniverseNo, data.Buffer);
        }

        public override string ToString()
        {
            return Sender.ToString();
        }

    }
}
