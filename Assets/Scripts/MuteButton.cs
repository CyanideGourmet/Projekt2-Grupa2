using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private void Start()
    {
        OnClick();
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Color color;
        if (PlayerPrefs.GetInt("Music", 1) == 1) { color = Color.white; }
        else                                     { color = Color.gray; }
        GetComponent<Image>().color = color;
    }
}
