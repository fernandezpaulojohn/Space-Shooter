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

    private void Awake()
    {
        instance = this; 
    }
     
    public void KillPlayer()
    {
        currentLives--;

        if (currentLives > 0)
        {
            //respawn code
            StartCoroutine(RespawnCo());
        }
        else
        {
            //game over code 
        }
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnTime);
        HealthManager.instance.Respawn();

        WaveManager.instance.ContinueSpawning();
    }
}
