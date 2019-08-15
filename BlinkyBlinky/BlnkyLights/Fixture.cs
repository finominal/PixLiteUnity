using System.Collections.Generic;
using UnityEngine;

namespace BlinkyLights
{
    public class Fixture
    {
        private List<LedChain> _ledChains { get; set; }
        public Vector3 Location;

        public string GetInfo = "If setting more than one chain, set all the chains xyz pixels relative to each other.";

        public Fixture(Vector3 location = new Vector3())
        {
            _ledChains = new List<LedChain>();
            Location = location;
        }

        public void Rotate(Vector3 rotateBy)
        {
            //Rotate the Location vector by the poassed in vector

        }
    }
}
