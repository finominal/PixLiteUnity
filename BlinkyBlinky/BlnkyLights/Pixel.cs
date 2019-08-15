using UnityEngine;

namespace BlinkyLights
{
    public class Pixel
    {
        public Color color;
        public Vector3 vector;

        public float r => color.r;
        public float g => color.g;
        public float b => color.b;

        public float x => vector.x;
        public float y => vector.y;
        public float z => vector.z;

        public Pixel() { }

        public Pixel(Color c)
        {
            color = c;
        }

        public Pixel(Color c, Vector3 v)
        {
            color = c;
            vector = v;
        }
        
    }
}
