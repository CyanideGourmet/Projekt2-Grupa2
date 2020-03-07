using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance_Randomizer : MonoBehaviour
{
    public int backNumber;
    public int eyesNumber;
    public int markingsNumber;

    Sprite back;
    Sprite eyes;
    Sprite markings;

    SpriteRenderer backGO;
    SpriteRenderer eyesGO;
    SpriteRenderer markingsGO;
    void Start()
    {
        string backSpriteName     = "back_"     + Random.Range(1, backNumber+1)     as string;
        string eyesSpriteName     = "eyes_"     + Random.Range(1, eyesNumber+1)     as string;
        string markingsSpriteName = "markings_" + Random.Range(1, markingsNumber+1) as string;
        back     = Resources.Load(backSpriteName,     typeof(Sprite)) as Sprite;
        eyes     = Resources.Load(eyesSpriteName,     typeof(Sprite)) as Sprite;
        markings = Resources.Load(markingsSpriteName, typeof(Sprite)) as Sprite;

        backGO     = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        eyesGO     = this.gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        markingsGO = this.gameObject.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();

        backGO.sprite     = back;
        eyesGO.sprite     = eyes;
        markingsGO.sprite = markings;
    }
    void Update()
    {
        
    }
}
