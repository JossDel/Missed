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
    public int progress = 0;

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

        
        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "End")
            return;
        ChangeWeapon(activeWeapon);
        healthbar.value = CalculateHealth();
        corruptionbar.value = CalculateCorruption();
    }
    

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "End")
            return;

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
            ChangeWeapon(1);
        }
        else if (Input.GetKey("2") && activeWeapon != 2)
        {
            ChangeWeapon(2);
        }
        else if (Input.GetKey("3") && activeWeapon != 3)
        {
            ChangeWeapon(3);
        }

        if (_weaponChangeBuffer > 0)
        {
            _weaponChangeBuffer -= Time.deltaTime * 2;
        }

        if (health <= 0)
        {
            Die();
        }
        corruption = Mathf.Clamp(corruption, 0, 100);
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
        SceneManager.LoadScene("End");
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
        if (_weaponChangeBuffer <= 0)
        {
            activeWeapon = weapon;

            _light.SetActive(false);
            _fire.SetActive(false);
            _electr.SetActive(false);

            if (weapon == 1)
            {
                _light.SetActive(true);
            }
            else if (weapon == 2)
            {
                _fire.SetActive(true);
            }
            else if (weapon == 3)
            {
                _electr.SetActive(true);
            }
            _weaponChangeBuffer = _weaponChangeBufferTime;
        }
    }
}
