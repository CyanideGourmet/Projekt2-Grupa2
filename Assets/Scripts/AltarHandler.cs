using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltarHandler : MonoBehaviour
{
    private static Dictionary<int, string> altairs = new Dictionary<int, string>
    {
        { 0, "Altar_1" },
        { 10000, "Altar_2" },
        { 20000, "Altar_3" },
        { 30000, "Altar_4" },
        { 40000, "Altar_5" },
        { 50000, "Altar_6" },
        { 60000, "Altar_7" },
        { 70000, "Altar_8" },
        { 80000, "Altar_9" }
    };
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        int temp = highScore / 80000;
        if(temp >= 1) { GetComponent<Image>().sprite = Resources.Load<Sprite>(altairs[80000]); }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>(altairs[(highScore / 10000) * 10000]);
        }
    }
}
