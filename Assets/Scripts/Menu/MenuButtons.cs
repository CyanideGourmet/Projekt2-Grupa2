using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GameStart() 
    {
        StartCoroutine(LoadScene("Main"));
    }
    public void Mute()
    {
        PlayerPrefs.SetInt("Music", (PlayerPrefs.GetInt("Music", 1)+1)%2);
    }
    public void Credits()
    {
        StartCoroutine(LoadScene("Credits"));
    }
    public void Tutorial()
    {
        StartCoroutine(LoadScene("HowToPlay"));
    }
    public void Sound()
    {
        GetComponent<AudioSource>().Play();
    }
    public void Exit()
    {
        Application.Quit();
    }
    private IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
