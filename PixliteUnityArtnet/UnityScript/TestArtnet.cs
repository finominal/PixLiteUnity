using UnityEngine;
using PixliteForUnity;
using System.Collections.Generic;

public class TestArtnet : MonoBehaviour {

    // Use this for initialization
    Pixlite pixlite;
    int counter = 0;
    int numPixelsPerString = 144;

    void Start () {
	
	}

    void Awake()
    {
        pixlite = new Pixlite();
    }
	
	// Update is called once per frameE
	void Update () {

        var section1 = new List<Color32>();
        var section2 = new List<Color32>();

        var allSections = new List<List<Color32>>();

        for (int i = 0; i < numPixelsPerString; i++)
        {
            if (i == counter % numPixelsPerString)
            {
			    section1.Add(new Color32 { r = 10 });
                section2.Add(new Color32 { g = 10 });
            }
            else
            {
			    section1.Add(new Color32());
                section2.Add(new Color32());
            }
        }

        allSections.Add(section1);
        allSections.Add(section2);

        pixlite.SendAllSections(allSections);

        Debug.Log("Artnet " + counter.ToString());

        counter++;

    }
}
