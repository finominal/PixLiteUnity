using BlinkyNetwork.DMX;
using System.Collections.Generic;

namespace BlinkyNetwork
{
    public class Manager
    {
        private DmxNetworkManager networkManager;

        public Manager()
        {
            networkManager = new DmxNetworkManager();
        }

        public void AddNetworkDevice( string name, string ipAddress, DMXProtocol networkType)
        {
             networkManager.AddNetworkDevice(name, ipAddress, networkType);
        }

        public IEnumerable<DMXDeviceDetail> GetRegisteredNetworkDevices()
        {
            return networkManager.ListRegisteredDevices();
        }
    }

}
