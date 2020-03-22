using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarHandler : MonoBehaviour
{
    public int[] altarValues = new int[9] { 0, 10000, 20000, 30000, 40000, 50000, 60000, 70000, 80000 };
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
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        int temp = highScore / 80000;
        if(temp >= 1) { GetComponent<Image>().sprite = Resources.Load<Sprite>(altars[80000]); }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>(altars[(highScore / 10000) * 10000]);
        }
    }
}
