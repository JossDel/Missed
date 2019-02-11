﻿using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float corruption = 0;
    public float movementSpeed = 2.5f;
    public int activeWeapon = 1;
    public float dps = 0.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100;
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (corruption == 20)
        {
            maxHealth = 80;
        }
        if (corruption == 40)
        {
            maxHealth = 60;
        }
        if (corruption == 60)
        {
            maxHealth = 40;
        }
        if (corruption == 80)
        {
            maxHealth = 20;
        }
        if (corruption == 100)
        {
            maxHealth = 0;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }


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
            Die();
        }
    }
    void Die()
    {

        Destroy(gameObject);
    }
}
