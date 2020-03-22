using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GameStart() 
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void Mute()
    {
        PlayerPrefs.SetInt("Music", (PlayerPrefs.GetInt("Music", 1)+1)%2);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
