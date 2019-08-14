using System.Net;

namespace BlinkyNetwork.DMX
{
    public interface IDMXNetwork { }

    public abstract class DMXNetwork : IDMXNetwork 
    {
        public DMXDeviceDetail DeviceDetail { get; private set; }

        public DMXNetwork(string name, IPAddress ip, DMXProtocol protocol)
        {
            DeviceDetail = new DMXDeviceDetail(name, ip, protocol);
        }

        public abstract void Send(DMXDatagram datagram);
        
    }
}
