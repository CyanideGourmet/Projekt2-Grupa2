using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHelper : MonoBehaviour
{
    public GateManager gateManager;
    public void Pause()
    {
        gateManager.pause = !gateManager.pause;
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void MainScene()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
