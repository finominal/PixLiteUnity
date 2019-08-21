using System.Collections.Generic;
using UnityEngine;

namespace BlinkyLights
{
    public class Fixture 
    {
        public string Name;
        public List<LedChain> LedChains;
        public Vector3 Origin { get; private set; }

        public string GetInfo = "If setting more than one chain, set all the chains xyz pixels relative to each other.";

        public Fixture(string name)
        {
            Name = name;
            LedChains = new List<LedChain>();
        }

        public void SetFixtureLocation(Vector3 origin)
        {
            Origin = origin;
            MovePixelsToFixtureOrigin();
        }

        public void AddLedChain(LedChain chain)
        {
            LedChains.Add(chain);
        }

        private void MovePixelsToFixtureOrigin()
        {
            foreach (var ledChain in LedChains)
            {
                foreach (var pixel in ledChain.Pixels)
                {
                    pixel.Relocate(pixel.origin + Origin);
                }
            }
        }

        public void RotateFixture( Vector3 rotateBy)
        {
            foreach (var ledChain in LedChains)
            {
                foreach (var pixel in ledChain.Pixels)
                {
                    //rotate around the origin Location by an amount specified in Rotation.
                    pixel.Relocate(RotatePointAroundPivot(pixel.location, Origin, rotateBy));
                }
            }
        }

        private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 rotationAngle)
        {
            return Quaternion.Euler(rotationAngle) * (point - pivot) + pivot;
        }
    }
}
