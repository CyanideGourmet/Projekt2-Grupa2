using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarHandler : MonoBehaviour
{
    private int[] altarValues = new int[9] { 0, 100, 200, 300, 450, 700, 1200, 2000, 3000 };
    private static Dictionary<int, string> altars;
    void Start()
    {
        if(altars == null)
        {
            altars = new Dictionary<int, string>
            {
                { altarValues[0], "Altar_1" },
                { altarValues[1], "Altar_2" },
                { altarValues[2], "Altar_3" },
                { altarValues[3], "Altar_4" },
                { altarValues[4], "Altar_5" },
                { altarValues[5], "Altar_6" },
                { altarValues[6], "Altar_7" },
                { altarValues[7], "Altar_8" },
                { altarValues[8], "Altar_9" },
            };
        }
        SetAltar();
    }
    public void SetAltar()
    {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        string filename = "";
        foreach (KeyValuePair<int, string> pair in altars)
        {
            if (highScore >= pair.Key)
            {
                filename = pair.Value;
            }
        }
        GetComponent<Image>().sprite = Resources.Load<Sprite>(filename);
    }
}
