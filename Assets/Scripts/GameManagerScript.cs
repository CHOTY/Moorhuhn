using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float time;
    public TMP_Text timeText;
    public TMP_Text scoreText;
    int score = 0;
    public static int zivoty = 5;
    public static GameManager gm = null; // singleton

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
        } // tu by mohla nasledovať kontrola či neexistuje inštancia, 
          // ktorá nie je tento objekt a ak áno deštrukcia...
    }

    public void ChangeScore(int sc)
    {
        score += sc;
        Debug.Log(score);
        // TODO: MENU A ODKOMENTOVAT 
        //scoreText.text = "Score: " + score.ToString();
    }

    public void DoDamage(int damage)
    {
        lives -= damage;
        Debug.Log(lives);
        // TODO: MENU A ODKOMENTOVAT 
        //scoreText.text = "Score: " + score.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        if (time <= 0 || zivoty <= 0)
            GameOver();
        // TODO: MENU A ODKOMENTOVAT 
        //timeText.text = time.ToString();
    }

    void GameOver()
    {
        //Debug.Log("You Lose");
        //  Scene scene = SceneManager.GetActiveScene();
        //  SceneManager.LoadScene(scene.name);
    }

}
