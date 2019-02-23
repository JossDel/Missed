using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float corruption = 0;
    public float movementSpeed = 2.5f;
    public int activeWeapon = 1;
    public float dps = 0.5f;

    GameObject gameManager;
    GameManager gameManagerScript;

    public Slider healthbar;
    public Slider corruptionbar;


    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.Load();

        healthbar.value = CalculateHealth();
        corruptionbar.value = CalculateCorruption();
    }

    void Update()
    {
        if (corruption >= 100)
        {
            maxHealth = 0;
        }
        else if (corruption >= 80)
        {
            maxHealth = 20;
        }
        else if (corruption >= 60)
        {
            maxHealth = 40;
        }
        else if (corruption >= 40)
        {
            maxHealth = 60;
        }
        else if (corruption >= 20)
        {
            maxHealth = 80;
        }
        else if (corruption >= 0)
        {
            maxHealth = 100;
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthbar.value = CalculateHealth();
        corruptionbar.value = CalculateCorruption();

        if (health <= 0)
        {
            Die();
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
       
        if(health <= 0)
        {
            health = 100;
            corruption = 0;
            Die();
        }
    }
    void Die()
    {
        health = 100;
        maxHealth = 100;
        corruption = 0;
        SceneManager.LoadScene(3);
    }

    float CalculateHealth()
    {
        return (float)health / 100f;
    }

    float CalculateCorruption()
    {
        return corruption / 100f;
    }
}
