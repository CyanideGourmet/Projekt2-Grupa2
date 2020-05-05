using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSounds : MonoBehaviour
{
    public AudioClip goodSkull;
    public AudioClip badSkull;
    public AudioClip lostSkull;

    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(PlayerPrefs.GetInt("Music", 1) == 1)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

    public void GoodSkull()
    {
        audioSource.clip = goodSkull;
        audioSource.Play();
    }
    public void BadSkull()
    {
        audioSource.clip = badSkull;
        audioSource.Play();
    }
    public void LostSkull()
    {
        audioSource.clip = lostSkull;
        audioSource.Play();
    }
}
