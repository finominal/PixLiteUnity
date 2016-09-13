using System.Collections.Generic;
using UnityEngine;

namespace PixliteForUnity
{
    public interface IPixlite
    {
        void SendAllSectionsArtnet(List<List<Color32>> sections);
        void SendAllSectionsArtnet(List<List<byte>> sections);
        void SendOneSectionArtnet(List<Color32> sectionData, int sectionNumber);
        void SendOneSectionArtnet(List<byte> sectionColors, int sectionNumber);

        void SendAllSectionsSACN(List<List<Color32>> sections);
        void SendAllSectionsSACN(List<List<byte>> sections);
        void SendOneSectionSACN(List<Color32> sectionData, int sectionNumber);
        void SendOneSectionSACN(List<byte> sectionColors, int sectionNumber);

    }
}