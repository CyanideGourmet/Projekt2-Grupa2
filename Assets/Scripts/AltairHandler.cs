using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltairHandler : MonoBehaviour
{
    private static Dictionary<int, string> altairs = new Dictionary<int, string>
    {
        { 0, "Altair_1" },
        { 10000, "Altair_2" },
        { 20000, "Altair_3" },
        { 30000, "Altair_4" },
        { 40000, "Altair_5" },
        { 50000, "Altair_6" },
        { 60000, "Altair_7" },
        { 70000, "Altair_8" },
        { 80000, "Altair_9" }
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
