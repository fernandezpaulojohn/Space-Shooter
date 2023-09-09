using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int currentLives = 3;

    public float respawnTime = 2f;

    public int currentScore;
    private int highScore = 500;

    private void Awake()
    {
        instance = this; 
    }

     void Start()
    {
        UIManager.instance.livesText.text = "x " + currentLives;

        UIManager.instance.scoreText.text = "Score: " + currentScore;

        highScore = PlayerPrefs.GetInt("HighScore");

        UIManager.instance.hiScoreText.text = "Hi-Score: " + highScore;

    }

    private void Update()
    {
        
    }

    public void KillPlayer()
    {
        currentLives--;
        UIManager.instance.livesText.text = "x " + currentLives;

        if (currentLives > 0)
        {
            //respawn code
            StartCoroutine(RespawnCo());
        }
        else
        {
            //game over code 

            UIManager.instance.gameOverScreen.SetActive(true);
            WaveManager.instance.canSpawnWaves = false;
        }
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnTime);
        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UIManager.instance.scoreText.text = "Score :" + currentScore;

        if(currentScore > highScore)
        {
            highScore = currentScore;
            UIManager.instance.hiScoreText.text = "Hi-Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore); 
        }
    }
}

