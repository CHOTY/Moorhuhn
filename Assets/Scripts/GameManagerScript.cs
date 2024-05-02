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
    public TMP_Text livesText;
    public bool specialSpawned=false;
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

    //TODO: NEJAKA ODOZVA TYM BUTTONOM NA START A RESTART NAPR. PREHRANIE ZVUKU ALEBO NECH ZASEDNE NIECO TAKE
    public void StartGame(bool start)
    {
        if (gameStarted == true){
        }
        else {
        gameStarted = true;
        time = 100;
        }
 
    }
    public void StopHry(bool start)
    {
        GameObject[] chicks = GameObject.FindGameObjectsWithTag("Chick");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        chicks=GameObject.FindGameObjectsWithTag("ChickS");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        specialSpawned = false;
        gameStarted = false;
        time = 0;
        lives = 5;
    }
    public void RestartGame(bool start)
    {
        GameObject[] chicks = GameObject.FindGameObjectsWithTag("Chick");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        chicks=GameObject.FindGameObjectsWithTag("ChickS");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        specialSpawned = false;
        gameStarted = true;
        lives = 5;
        time = 100;
    }

    public void DoDamage(int damage)
    {
        lives -= damage;
        livesText.text = "Lives: " + lives.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time = time - Time.deltaTime;
            timeText.text = "Time: " + ((int)time).ToString();
            livesText.text = "Lives: " + lives.ToString();
        }

        if (time <= 0 || lives <= 0)
            GameOver();
    }

    void GameOver()
    {
        GameObject[] chicks = GameObject.FindGameObjectsWithTag("Chick");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        chicks=GameObject.FindGameObjectsWithTag("ChickS");
        foreach (GameObject chick in chicks)
        {
            Destroy(chick);
        }
        specialSpawned = false;
        gameStarted = false;
        time = 0;
        timeText.text = "Time: " + ((int)time).ToString();
        livesText.text = "Lives: " + lives.ToString();
    }

    public void setSpecialSpawned(bool k){
        specialSpawned=k;    
    }
    public bool getSpecialSpawned(){
        return specialSpawned;    
    }
}
