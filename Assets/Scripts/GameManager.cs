using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int currentLives = 3;

    private void Awake()
    {
        instance = this; 
    }

    public void KillPlayer()
    {
        currentLives--;

        if (currentLives > 0)
        {

        }
    }
}
