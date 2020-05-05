using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("Music", 1) == 1)
        {
            GetComponent<AudioSource>().mute = false;
        } else
        {
            GetComponent<AudioSource>().mute = true;
        }
    }
}
