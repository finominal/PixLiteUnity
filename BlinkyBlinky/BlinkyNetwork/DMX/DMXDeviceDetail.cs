using System.Net;

namespace BlinkyNetwork.DMX
{
    public class DMXDeviceDetail
    {
        public IPAddress IPAddress { get; private set; }
        public string NetworkName { get; private set; }
        public DMXProtocol Protocol { get; private set; }

        public DMXDeviceDetail(string networkName, IPAddress ipaddress, DMXProtocol protocol)
        {
            NetworkName = networkName;
            IPAddress = ipaddress;
            Protocol = protocol;
        }
    }
}