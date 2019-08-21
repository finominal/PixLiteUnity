using System.Collections.Generic;

namespace BlinkyLights
{
    public class LedChain
    {
        public string Name { get; private set; }
        public List<Pixel> Pixels { get; set; }

        public string GetInfo => "This class represents a string of " +
            "LEDs that are connected to one driver output of a controller.";

        public LedChain(string name)
        {
            Name = name;
            Pixels = new List<Pixel>();
        }

        public void AddPixel(Pixel p) => Pixels.Add(p);
    }
}
