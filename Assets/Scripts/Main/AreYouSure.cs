using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AreYouSure : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(HideMenu);
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(ExitMenu);
    }
    private void HideMenu()
    {
        Destroy(this.gameObject);
    }
    private void ExitMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
