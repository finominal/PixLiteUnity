using System;
using BlinkyNetwork.DMX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlinkyNetwork.Tests
{
    [TestClass]
    public class ToStringTest
    {
        private DmxNetworkManager dmxNetworks;

        [TestMethod]
        public void ListRegisteredDevicesTest()
        {
            LoadDevices();

            var devices = dmxNetworks.ListRegisteredDevices();

            foreach (var d in devices)
            {
                Console.WriteLine(d.NetworkName + " " + d.IPAddress.AddressFamily.ToString());
            }

            var stringReporesentation = dmxNetworks.ToString();

        }

        [TestMethod]
        public void SendRed()
        {
            LoadDevices();
            var devices = dmxNetworks.ListRegisteredDevices();
            short universeId = 1;

            foreach (var device in devices)
            {
                var dmxBytes = MakeDmxBytes(255, 0, 0);
                dmxNetworks.Send(new DMXDatagram(dmxBytes, universeId, device.NetworkName));
            }

        }

        private byte[] MakeDmxBytes(byte red, byte green, byte blue)
        {
            byte[] dmxBytes = new byte[512];
            for (int i = 0; i < 170; i++)
            {
                var location = i * 3; //offset per three bytes per pixel

                //assumed DMX Protocol is ordered RGB
                dmxBytes[location] = red;
                dmxBytes[location + 1] = green;
                dmxBytes[location + 2] = blue;
            }
            return dmxBytes;
        }

        private void LoadDevices()
        {
            dmxNetworks = new DmxNetworkManager();
            dmxNetworks.AddNetworkDevice("Pixlite16", "192.168.20.50", DMXProtocol.sACN);
            //dmxNetworks.AddNetworkDevice("LEDMX1", "10.1.1.20", DMXProtocol.Artnet);
        }
    }
}
