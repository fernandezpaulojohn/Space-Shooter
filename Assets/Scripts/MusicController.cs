using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public AudioSource levelMusic, bossMusic, victoyMusic, gameOverMusic;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        levelMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopMusic()
    {
        levelMusic.Stop();
        bossMusic.Play();
        victoyMusic.Stop();
        gameOverMusic.Stop();
    }

    public void PlayBoss()
    {
        StopMusic();
        bossMusic.Play();
    }

    public void PlayVictory()
    {
        StopMusic();
        victoyMusic.Play();
    }

    public void PlayGameOver()
    {
        StopMusic();
        gameOverMusic.Play();  
    }
}
