using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LeaveTutorial);
    }
    private void LeaveTutorial()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
