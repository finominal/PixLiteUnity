using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlinkyNetwork.DMX;
using BlinkyNetwork;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace BlinkyLights.Tests
{
    [TestClass]
    public class SetupNetworkTests
    {
        private DmxNetworkManager dmxNetworks;
        private List<Fixture> fixtures; 

        [TestMethod]
        public void LoadControllerAndFixtures()
        {
            dmxNetworks = new DmxNetworkManager();
            LoadDMXCotrollers(); //load each DMX Controller Hardware (per IP) 
            fixtures = LoadFixtures();

            var x = 1;
        }

        private List<Fixture> LoadFixtures()
        {
            var fixtures = new List<Fixture>();
            fixtures.Add(GenerateLeftWingFixture());
            return fixtures;
        }

        private Fixture GenerateLeftWingFixture()
        {
            var wing = new Fixture("LeftWing");

            wing.AddLedChain(GetFakeLedChainWingTop());
            wing.AddLedChain(GetFakeLedChainWingBottom());

            wing.SetFixtureLocation(new Vector3(1000, 500, 500));

            var rotation = new Vector3(0, 0, 45);

            //wing.RotateFixture(rotation);

            return wing;
        }

        private static LedChain GetFakeLedChainWingTop()
        {
            var ledChainTop = new LedChain("LeftWingTop");
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    ledChainTop.AddPixel(new Pixel(new Color(100, 0, 100), new Vector3(x, y)));
                }
            }

            return ledChainTop;
        }

        private static LedChain GetFakeLedChainWingBottom()
        {
            //fake an led chain for the bottm section of the wing
            var ledChainBottom = new LedChain("LeftWingBottom");
            for (var x = 0; x < 10; x++)
            {
                for (var y = -1; y > 11; y--)
                {
                    ledChainBottom.AddPixel(new Pixel(new Color(100, 0, 100), new Vector3(x, y)));
                }
            }

            return ledChainBottom;
        }

        private byte[] MakeDmxUniverse(List<Pixel> pixels)
        {
            //NOTE:needs to be less than 170 pixels
            if (pixels.Count > 170) throw new Exception("More than 170 pixels sent to dmx universe builder!");

            byte[] dmxBytes = new byte[512];
            int counter = 0;
            foreach(var pixel in pixels)
            {
                var location = counter * 3; //offset per three bytes per pixel

                //assumed DMX Protocol is ordered RGB.
                dmxBytes[location] = (byte)pixel.r;
                dmxBytes[location + 1] = (byte)pixel.g;
                dmxBytes[location + 2] = (byte)pixel.b;

                counter++;
            }
            return dmxBytes;
        }

        private void LoadDMXCotrollers()
        {
            dmxNetworks = new DmxNetworkManager();
            dmxNetworks.AddNetworkDevice("Pixlite16", "192.168.20.50", DMXProtocol.sACN);
            //dmxNetworks.AddNetworkDevice("LEDMX1", "10.1.1.20", DMXProtocol.Artnet);
        }
    }
}
