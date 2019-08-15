using System.Collections.Generic;
using UnityEngine;

namespace BlinkyLights
{
    public class LedChain
    {
        public List<Pixel> Pixels;

        public string GetInfo => "This class represents a string of " +
            "LEDs that are connected to one driver output of a controller.";

        public LedChain()
        {
            Pixels = new List<Pixel>();
        }
    }
}
