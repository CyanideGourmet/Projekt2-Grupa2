using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreYouSure : MonoBehaviour
{
    private GameObject EventManager;
    private void Start()
    {
        EventManager = GameObject.Find("EventSystem");
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(EventManager.GetComponent<ButtonHelper>().HideMenu);
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(EventManager.GetComponent<ButtonHelper>().MenuScene);
    }
}
