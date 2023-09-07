using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;

    public int currentHealth;
    public int maxHealth;

    public GameObject deathEffect;

    public float invincibleLength = 2f;
    private float invincCounter;
    public SpriteRenderer theSR;

    private void Awake()
    {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter >= 0)
        {
            invincCounter -= Time.deltaTime;

            if(invincCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void HurtPlayer()
    {
        if (invincCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                gameObject.SetActive(false);

                GameManager.instance.KillPlayer();

                WaveManager.instance.canSpawnWaves = false;
            }
        }
    }

    public void Respawn()
    {

        gameObject.SetActive(true); 
        currentHealth = maxHealth;

        invincCounter = invincibleLength;
        theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);
    }
}
