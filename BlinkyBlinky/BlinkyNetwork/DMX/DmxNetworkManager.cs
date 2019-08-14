using System;
using System.Collections.Generic;
using System.Net;
using BlinkyNetwork.sACN;
using BlinkyNetwork.Artnet;
using System.Linq;

namespace BlinkyNetwork.DMX
{
    public class DmxNetworkManager
    {
        public IList<DMXNetwork> networks;

        public DmxNetworkManager()
        {
            networks = new List<DMXNetwork>();
        }

        public void AddNetworkDevice(string name, string ipAddress, DMXProtocol protocol )
        {
            if (!IPAddress.TryParse(ipAddress, out IPAddress ip))
                throw new Exception("The IP adress passed in is not valid: " + ipAddress);

            switch (protocol)
            {
                case DMXProtocol.Artnet:
                    networks.Add(new ArtnetNetwork(name, ip));
                    break;
                case DMXProtocol.sACN:
                    networks.Add(new SACNNetwork(name, ip));
                    break;
            }
        }

        public IEnumerable<DMXDeviceDetail> ListRegisteredDevices()
        {
            var result = new List<DMXDeviceDetail>();
            foreach (var net in networks)
            {
                result.Add(net.DeviceDetail) ;
            }
            return result;
        }

        public void Send(DMXDatagram datagram)
        {
            try
            {
                if(networks.Count > 0) networks.First(x => x.DeviceDetail.NetworkName == datagram.NetworkName).Send(datagram);
            }
            catch { Console.WriteLine("Error sending DMXDatagram: Network Not Initialized: " + datagram.NetworkName); }
        }
    }
}
