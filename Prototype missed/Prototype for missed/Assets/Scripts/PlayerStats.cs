using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float movementSpeed = 2.5f;
    public int activeWeapon = 1;
    public int progress = 0;

    GameObject gameManager;
    GameManager gameManagerScript;
    GameObject lightUnderPlayer;

    public Slider healthbar;

    float _weaponChangeBuffer;
    [SerializeField]
    float _weaponChangeBufferTime = 3;

    public GameObject _light;
    public GameObject _fire;
    public GameObject _electr;

    void Start()
    {
        lightUnderPlayer = GameObject.FindGameObjectWithTag("LightUnderPlayer");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.Load();

        
        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "End")
            return;
        ChangeWeapon(activeWeapon);
        healthbar.value = CalculateHealth();
    }
    

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "TitleScreen" || SceneManager.GetActiveScene().name == "End")
            return;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthbar.value = CalculateHealth();

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
    }

    public void takeDamage(int damage)
    {
        health -= damage;
       
        if(health <= 0)
            Die();
    }
    void Die()
    {
        health = 100;
        SceneManager.LoadScene("DeathScreen");
    }

    float CalculateHealth()
    {
        return (float)health / 100f;
    }

    void ChangeWeapon(int weapon)
    {
        if (_weaponChangeBuffer <= 0)
        {
            activeWeapon = weapon;

            _light.SetActive(false);
            _fire.SetActive(false);
            _electr.SetActive(false);

            transform.GetComponentInParent<weapom>().enabled = false;
            transform.GetComponentInParent<FireWeapon>().enabled = false;
            transform.GetComponentInParent<ThunderWeapon>().enabled = false;

            if (weapon == 2)
            {
                _light.SetActive(true);
                lightUnderPlayer.gameObject.GetComponent<Light>().color = new Color32(0xff, 0xff, 0xff, 0xff); //FFFFF

                transform.GetComponentInParent<weapom>().enabled = true;
            }
            else if (weapon == 1)
            {
                _fire.SetActive(true);
                lightUnderPlayer.gameObject.GetComponent<Light>().color = new Color(255, 255, 255);
                lightUnderPlayer.gameObject.GetComponent<Light>().color = new Color32(0xff, 0x96, 0x50, 0xff); //FF9650

                transform.GetComponentInParent<FireWeapon>().enabled = true;
            }
            else if (weapon == 3)
            {
                _electr.SetActive(true);
                lightUnderPlayer.gameObject.GetComponent<Light>().color = new Color32(0x50, 0xd7, 0xff, 0xff); //50D7FF

                transform.GetComponentInParent<ThunderWeapon>().enabled = true;
            }
            _weaponChangeBuffer = _weaponChangeBufferTime;
        }
    }
}
