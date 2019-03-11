using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;
    public GameObject enemiesPrefab;
    GameObject prefChild;

    void Awake()
    {
        if (enemiesPrefab != null)
        {
            prefChild = enemiesPrefab.transform.GetChild(Random.Range(0, enemiesPrefab.transform.childCount)).gameObject;
            Instantiate(prefChild, Vector3.zero, new Quaternion());
        }
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("health", playerStats.health);
        PlayerPrefs.SetInt("maxHealth", playerStats.maxHealth);
        PlayerPrefs.SetFloat("corruption", playerStats.corruption);
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
        PlayerPrefs.SetInt("activeWeapon", playerStats.activeWeapon);
    }

    public void Save(int room)
    {
        Save();
        PlayerPrefs.SetInt("progress", room);
    }

    public void Load()
    {
        playerStats.health = PlayerPrefs.GetInt("health", playerStats.health);
        playerStats.maxHealth = PlayerPrefs.GetInt("maxHealth", playerStats.maxHealth);
        playerStats.corruption = PlayerPrefs.GetFloat("corruption", playerStats.corruption);
        playerStats.movementSpeed = PlayerPrefs.GetFloat("movementSpeed", playerStats.movementSpeed);
        playerStats.activeWeapon = PlayerPrefs.GetInt("activeWeapon", playerStats.activeWeapon);
        playerStats.progress = PlayerPrefs.GetInt("progress", playerStats.progress);
    }

    public void SaveReset()
    {
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("maxHealth", 100);
        PlayerPrefs.SetFloat("corruption", 0);
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
        PlayerPrefs.SetInt("activeWeapon", 1);
    }

    public void HardSaveReset()
    {
        SaveReset();
        PlayerPrefs.SetInt("progress", 0);
    }
}

