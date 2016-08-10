using System.Collections.Generic;
using UnityEngine;

namespace PixliteForUnity
{
    public interface IPixlite
    {
        void SendAllSections(List<List<Color32>> sections);
        void SendAllSections(List<List<byte>> sections);
        void SendOneSection(List<Color32> sectionData, int sectionNumber);
        void SendOneSection(List<byte> sectionColors, int sectionNumber);
    }
}