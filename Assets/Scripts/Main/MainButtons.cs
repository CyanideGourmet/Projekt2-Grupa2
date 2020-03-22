using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtons : MonoBehaviour
{
    private static GameObject menuObject;
    public void ShowMenu()
    {
        if (menuObject == null)
        {
            GameObject.Find("GateManager").GetComponent<GateManager>().Pause();
            menuObject = Instantiate(Resources.Load<GameObject>("AreYouSure"), Vector2.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
            StartCoroutine(MenuClose(menuObject));
        }
    }

    private IEnumerator MenuClose(GameObject menu)
    {
        while (menu != null) { yield return null; }
        GameObject.Find("GateManager").GetComponent<GateManager>().Pause();
    }
}
