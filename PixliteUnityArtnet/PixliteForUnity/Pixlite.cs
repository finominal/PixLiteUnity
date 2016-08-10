
using System.Collections.Generic;
using ArtNet.Packets;
using UnityEngine;

namespace PixliteForUnity
{
    public class Pixlite : IPixlite
    {
        private ArtnetManager artnet;

        public Pixlite()
        {
            artnet = new ArtnetManager();
        }

        public void SendAllSections(List<List<byte>> sections)
        {
            int sectionsProcessed = 0;

            foreach (var section in sections)
            {
                SendOneSection(section, sectionsProcessed );

                //update that this section was completed
                sectionsProcessed++;
            }
        }

        public void SendOneSection(List<byte> sectionColors, int sectionNumber )
        {
            int bytesProcessedInSection = 0; //or current?
            int universesProcessed = 0; //preload the universes, helps advance universe counter (this) when a section has less than 6 universes worth of data.

            int completeUniversesToProcess = (sectionColors.Count / 510); //add universesProcessed 
            int remainingBytesToProcess = sectionColors.Count % 510;


            //PROCESS FULL UNIVERSES (more than 510 bytes of color data) 
            while (universesProcessed < completeUniversesToProcess)
            {
                var buffer = new byte[510];
                var bufferIndex = 0;

                while (bufferIndex < 510)
                {
                    buffer[bufferIndex] = sectionColors[bytesProcessedInSection];
                    bufferIndex++;
                }

                SendDataToArtnet(buffer, CalculateUniverse(universesProcessed, sectionNumber));

                bytesProcessedInSection += bufferIndex;
                universesProcessed++;
            }


            //PROCESSS REMAINING DATA IN THE LAST UNIVERSE 
            var bufferRemainder = new byte[510];

            for (int x = 0; x < remainingBytesToProcess; x++)
            {

                bufferRemainder[x] = sectionColors[bytesProcessedInSection];
                bytesProcessedInSection++;
            }

            SendDataToArtnet(bufferRemainder, CalculateUniverse(universesProcessed, sectionNumber));
        }

        private void SendDataToArtnet(byte[] buffer, short universe)
        {
            ArtNetDmxPacket packet = new ArtNetDmxPacket();
            packet.DmxData = buffer;
            packet.Universe = universe;
            artnet.SendArtnetPacket(packet);
        }


        private short CalculateUniverse(int universesProcessed, int sectionsProcessed)
        {
            return (short)(universesProcessed + (sectionsProcessed * 6));
        }



        public void SendAllSections(List<List<Color32>> sections)
        {
            int sectionsProcessed = 0;

            foreach (var section in sections)
            {
                SendOneSection(section, sectionsProcessed);

                //update that this section was completed
                sectionsProcessed++;
            }
        }


 
        public void SendOneSection(List<Color32> sectionData, int sectionNumber)
        {
                

                int colorsProcessedInSection = 0;
                int universesProcessed = 0; //preload the universes, helps advance universe counter (this) when a section has less than 6 universes worth of data.

                int completeUniversesToProcess = (sectionData.Count / 170);
                int remainingColorsToProcess = sectionData.Count % 170;

                //PROCESS FULL UNIVERSES (more than 510 bytes of color data) 
                while (universesProcessed < completeUniversesToProcess)
                {
                    var buffer = new byte[510];
                    var colorIndex = 0;

                    while (colorIndex < 170)
                    {
                        buffer[colorIndex] = sectionData[colorsProcessedInSection].r;
                        buffer[colorIndex + 1] = sectionData[colorsProcessedInSection].g;
                        buffer[colorIndex + 2] = sectionData[colorsProcessedInSection].b;
                        colorIndex++;

                        colorsProcessedInSection++;

                    }

                    SendDataToArtnet(buffer, CalculateUniverse(universesProcessed, sectionNumber));

                    universesProcessed++;
                }

                //PROCESSS REMAINING DATA IN THE LAST UNIVERSE 
                var bufferRemainder = new byte[510];

                for (int remainingColorIndex = 0; remainingColorIndex < remainingColorsToProcess; remainingColorIndex++)
                {
                    bufferRemainder[remainingColorIndex * 3] = sectionData[colorsProcessedInSection].r;
                    bufferRemainder[remainingColorIndex * 3 + 1] = sectionData[colorsProcessedInSection].g;
                    bufferRemainder[remainingColorIndex * 3 + 2] = sectionData[colorsProcessedInSection].b;

                    colorsProcessedInSection++;
                }

                SendDataToArtnet(bufferRemainder, CalculateUniverse(universesProcessed, sectionNumber));

            }
        }

    }
