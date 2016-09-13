using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using PixliteForUnity;
using System.Collections.Generic;
using UnityEngine;

namespace TestPixliteLibrary
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBytes()
        {

            Pixlite pixlite = new Pixlite();

            int counter = 0;
            int numleds = 144;

            while (counter < 300)
            {

                var section1 = new List<byte>();
                var section2 = new List<byte>();

                var allSections = new List<List<byte>>();

                for (int i = 0; i < numleds; i++)
                {
                    if (i == counter % numleds)
                    {

                        section1.Add(10);
                        section1.Add(0);
                        section1.Add(15);

                    }
                    else
                    {
                        section1.Add(0);
                        section1.Add(0);
                        section1.Add(0);

                    }
                }

                allSections.Add(section1);
                allSections.Add(section2);

                pixlite.SendAllSectionsArtnet(allSections);

                counter++;
                Thread.Sleep(33);

            }
        }

        [TestMethod]
        public void TestColor()
        {

            Pixlite pixlite = new Pixlite();

            int counter = 0;
            int numleds = 144;

            while (counter < 300)
            {

                var section1 = new List<Color32>();
                var section2 = new List<Color32>();

                var allSections = new List<List<Color32>>();

                for (int i = 0; i < numleds; i++)
                {
                    if (i == counter % numleds)
                    {
                        var c = new Color32();
                        c.r = 10;
                        c.b = 15;
                        section1.Add(c);


                    }
                    else
                    {
                        var c = new Color32();
                        section1.Add(c);

                    }
                }

                allSections.Add(section1);
                allSections.Add(section2);

                pixlite.SendAllSectionsArtnet(allSections);

                counter++;
                Thread.Sleep(33);

            }
        }
    }

}