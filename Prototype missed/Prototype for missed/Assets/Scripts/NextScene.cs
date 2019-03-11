using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public bool open;
    private void Start()
    {
        open = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (open)
            {
                NextRoom();
            }


        }
    }
    public void NextRoom()
    {
        if (SceneManager.GetActiveScene().name == "Checkpoint " + (GameObject.Find("Player").GetComponent<PlayerStats>().progress + 1))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Save(GameObject.Find("Player").GetComponent<PlayerStats>().progress + 1);
        }
        GameObject.Find("GameManager").GetComponent<GameManager>().Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
