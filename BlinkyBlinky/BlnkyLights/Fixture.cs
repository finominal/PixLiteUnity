using System.Collections.Generic;
using UnityEngine;

namespace BlinkyLights
{
    public class Fixture
    {
        private List<LedChain> _ledChains { get; set; }
        public Vector3 FixtureLocation;
        public Vector3 Rotation;

        private bool _rotatedLeds = false;

        public string GetInfo = "If setting more than one chain, set all the chains xyz pixels relative to each other.";

        public Fixture(Vector3 location)
        {
            _ledChains = new List<LedChain>();
            FixtureLocation = location;
        }

        public void SetFixtureLocation(Vector3 location)
        {
            FixtureLocation = location;
            MoveLedsToLocation(location);
        }

        private void MoveLedsToLocation(Vector3 location)
        {
            foreach (var ledChain in _ledChains)
            {
                foreach (var pixel in ledChain.Pixels)
                {
                    pixel.vector += location;
                }
            }
        }

        public void RotateFixture(Vector3 rotateBy)
        {
            //rotate the leds around the origin location of the fixture. 
            Rotation = rotateBy;
            RotateLeds();
        }

        private void RotateLeds()
        {
            foreach (var ledChain in _ledChains)
            {
                foreach (var pixel in ledChain.Pixels)
                {
                    //rotate around the origin Location by an amount specified in Rotation.
                    pixel.vector = RotatePointAroundPivot(pixel.vector, FixtureLocation, Rotation);
                }
            }
        }

        private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
        {
            return Quaternion.Euler(angles) * (point - pivot) + pivot;
        }
    }
}
