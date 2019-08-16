using System.Collections.Generic;
using UnityEngine;

namespace BlinkyLights
{
    public class Fixture
    {
        private List<LedChain> _ledChains { get; set; }
        public Vector3 Location;
        public Vector3 Rotation;

        private bool _rotatedLeds = false;

        public string GetInfo = "If setting more than one chain, set all the chains xyz pixels relative to each other.";

        public Fixture(Vector3 location)
        {
            _ledChains = new List<LedChain>();
            Location = location;
        }

        public void RotateFixture(Vector3 rotateBy)
        {
            //rotate the leds around the origin location of the fixture. 
            //The first LED is located at the fixtures location. The rest are rotated around it?
            if (Location != null)
            {
                Rotation = rotateBy;
                RotateLeds();
            }
        }

        private void RotateLeds()
        {
            foreach (var ledChain in _ledChains)
            {
                foreach (var pixel in ledChain.Pixels)
                {
                    //rotate around the origin Location by an amount specified in Rotation.
                }
            }
        }
    }
}
