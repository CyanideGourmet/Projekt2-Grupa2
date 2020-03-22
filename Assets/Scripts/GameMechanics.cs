using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{

    public GateManager gateManager;
    public Text pointText;
    public Image[] candles;
    public int initialPoints = 100;
    public int pointsIncrease = 100;
    public float pointsIncreaseTimer = 30;
    private int points { get; set; }
    private int highScore { get; set; }
    private int health { get; set; }
    public int pointReward { get; set; }
    public bool MorePointActive { get; set; } = false;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        pointReward = initialPoints;
        foreach (Image candle in candles)
        {
            candle.color = Color.red;
        }
        points = 0;
        health = 4;
        pointText.text = points.ToString();
        StartCoroutine(PointsIncrease());
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointText.text = points.ToString();
    }
    public void Damage()
    {
        health -= 1;
        candles[health].color = Color.white;
        if(health == 0)
        {
            gateManager.pause = true;
            Instantiate(Resources.Load<GameObject>("GameOver"), new Vector2(-15, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            if(points > highScore)
            {
                PlayerPrefs.SetInt("highscore", points);
            }
            StartCoroutine(MenuScene());
        }
    }
    private IEnumerator PointsIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(pointsIncreaseTimer);
            pointReward += pointsIncrease;
        }
    }
    private IEnumerator MenuScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
