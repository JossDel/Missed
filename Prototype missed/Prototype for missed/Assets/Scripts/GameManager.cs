using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;
    public GameObject enemiesPrefab;
    GameObject prefChild;

    void Awake()
    {
        prefChild = enemiesPrefab.transform.GetChild(Random.Range(0, 2)).gameObject;
        Instantiate(prefChild, new Vector3(20.43916f, -57.34339f, 0), new Quaternion());
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

    public void Save(string room)
    {
        Save();
        PlayerPrefs.SetString("progress", room);
    }

    public void Load()
    {
        playerStats.health = PlayerPrefs.GetInt("health", playerStats.health);
        playerStats.maxHealth = PlayerPrefs.GetInt("maxHealth", playerStats.maxHealth);
        playerStats.corruption = PlayerPrefs.GetFloat("corruption", playerStats.corruption);
        playerStats.movementSpeed = PlayerPrefs.GetFloat("movementSpeed", playerStats.movementSpeed);
        playerStats.activeWeapon = PlayerPrefs.GetInt("activeWeapon", playerStats.activeWeapon);
    }
    private void OnDestroy()
    {
        Save();
    }
}

