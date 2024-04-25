using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float time = 0;
    public bool gameStarted = false;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    int score = 0;
    public int lives = 5;
    public static GameManager gm = null; // singleton

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }

    public void ChangeScore(int sc)
    {
        score += sc;
        scoreText.text = "Score: " + score.ToString();
    }

    //TODO: VYPNUT TLACIDLO ABY SA NEDALO STLACIT AK JE HRA STARTNUTA
    //TODO: NEJAKA ODOZVA TYM BUTTONOM NA START A RESTART NAPR. PREHRANIE ZVUKU ALEBO NECH ZASEDNE NIECO TAKE
    public void StartGame(bool start)
    {
        gameStarted = true;
        time = 100;
    }
    //TODO: ABY SA DESPAWNLI SLIEPKY 
    public void RestartGame(bool start)
    {
        gameStarted = true;
        time = 100;
    }

    public void DoDamage(int damage)
    {
        lives -= damage;
        Debug.Log(lives);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameStarted);
        if (time > 0)
        {
            time = time - Time.deltaTime;
            timeText.text = "Time: " + ((int)time).ToString();
        }

        if (time <= 0 || lives <= 0)
            GameOver();
    }
    //TODO: ABY SA DESPAWNLI SLIEPKY
    void GameOver()
    {
        gameStarted = false;
        time = 0;
        timeText.text = "Time: " + ((int)time).ToString();
    }

}
