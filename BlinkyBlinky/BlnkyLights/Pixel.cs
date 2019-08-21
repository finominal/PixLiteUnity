using UnityEngine;

namespace BlinkyLights
{
    public class Pixel
    {
        public Color color;
        public Vector3 origin { get; private set; }
        public Vector3 location { get; private set; }

        public float r => color.r;
        public float g => color.g;
        public float b => color.b;

        public float x => location.x;
        public float y => location.y;
        public float z => location.z;

        public Pixel() { }

        public Pixel(Color c)
        {
            color = c;
        }

        public Pixel(Color c, Vector3 v)
        {
            color = c;
            origin = location = v;
        }

        public void Relocate(Vector3 relocationPoint)
        {
            location = relocationPoint;
        }

    }
}
