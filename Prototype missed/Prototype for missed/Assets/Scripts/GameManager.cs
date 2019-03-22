using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    PlayerStats playerStats;
    public GameObject enemiesPrefab;
    GameObject prefChild;
    public GameObject boxOfMists;
    float mistTime = 0;
    [SerializeField]
    float delay = 1;

    void Awake()
    {
        if (enemiesPrefab != null)
        {
            prefChild = enemiesPrefab.transform.GetChild(Random.Range(0, enemiesPrefab.transform.childCount)).gameObject;
            Instantiate(prefChild, Vector3.zero, new Quaternion());
        }
        Instantiate(boxOfMists, Vector3.zero, new Quaternion());
    }

    void Start()
    {
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        mistTime += Time.deltaTime;
        if (mistTime >= boxOfMists.GetComponent<Mist>().speed + delay)
        {
            Instantiate(boxOfMists, Vector3.zero, new Quaternion());
            mistTime = 0;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("health", playerStats.health);
        PlayerPrefs.SetInt("maxHealth", playerStats.maxHealth);
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
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
        playerStats.health = PlayerPrefs.GetInt("health", playerStats.health);
        playerStats.maxHealth = PlayerPrefs.GetInt("maxHealth", playerStats.maxHealth);
        playerStats.movementSpeed = PlayerPrefs.GetFloat("movementSpeed", playerStats.movementSpeed);
        playerStats.activeWeapon = PlayerPrefs.GetInt("activeWeapon", playerStats.activeWeapon);
        playerStats.progress = PlayerPrefs.GetInt("progress", playerStats.progress);
    }

    public void SaveReset()
    {
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("maxHealth", 100);
        PlayerPrefs.SetFloat("movementSpeed", playerStats.movementSpeed);
        PlayerPrefs.SetInt("activeWeapon", 1);
    }

    public void HardSaveReset()
    {
        SaveReset();
        PlayerPrefs.SetInt("progress", 0);
    }
}

