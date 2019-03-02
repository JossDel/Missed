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

    float _weaponChangeBuffer;
    [SerializeField]
    float _weaponChangeBufferTime = 3;

    public GameObject _light;
    public GameObject _fire;
    public GameObject _electr;

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

        if (Input.GetKeyDown("1") && activeWeapon != 1)
        {
            Debug.Log("First Key pressed");
            ChangeWeapon(1);
        }
        else if (Input.GetKey("2") && activeWeapon != 2)
        {
            Debug.Log("Second Key pressed");
            ChangeWeapon(2);
        }
        else if (Input.GetKey("3") && activeWeapon != 3)
        {
            Debug.Log("Third Key pressed");
            ChangeWeapon(3);
        }

        if (_weaponChangeBuffer > 0)
        {
            Debug.Log("inside buffer");
            _weaponChangeBuffer -= Time.deltaTime * 100;
            Debug.Log(_weaponChangeBuffer);
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

    void ChangeWeapon(int weapon)
    {
        if (_weaponChangeBuffer == 0)
        {
            Debug.Log("weapon changing to" + weapon);
            _weaponChangeBuffer = _weaponChangeBufferTime;
            activeWeapon = weapon;

            _light.GetComponent("Is On").Equals(false);
            _fire.GetComponent("Is On").Equals(false);
            _electr.GetComponent("Is On").Equals(false);

            if (weapon == 1)
            {
                _light.GetComponent("Is On").Equals(true);
                Debug.Log("one made true");
            }
            else if (weapon == 2)
            {
                _fire.GetComponent("Is On").Equals(true);
                Debug.Log("two made true");
            }
            else if (weapon == 3)
            {
                _electr.GetComponent("Is On").Equals(true);
                Debug.Log("three made true");
            }
        }
    }
}
