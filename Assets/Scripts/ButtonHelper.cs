using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHelper : MonoBehaviour
{
    public GateManager gateManager;
    public GameObject areYouSure;
    public Image muteImage;

    private GameObject areYouSureInst;
    private void Start()
    {
        if (muteImage != null)
        {
            if (PlayerPrefs.GetInt("audio", 1) == 1)
            {
                muteImage.color = Color.white;
            }
            else
            {
                muteImage.color = Color.grey;
            }
        }
    }
    public void Pause()
    {
        gateManager.pause = !gateManager.pause;
    }
    public void MenuScene()
    {
        Pause();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void ShowMenu()
    {
        Pause();
        areYouSureInst = Instantiate(areYouSure, Vector2.zero, Quaternion.identity, GameObject.Find("Canvas").transform);
    }
    public void HideMenu()
    {
        Destroy(areYouSureInst);
        Pause();
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Mute()
    {
        if(muteImage.color == Color.white)
        {
            muteImage.color = Color.grey;
        } else
        {
            muteImage.color = Color.white;
        }
        int temp = (PlayerPrefs.GetInt("audio", 1) + 1) % 2;
        PlayerPrefs.SetInt("audio", temp);
    }
}
