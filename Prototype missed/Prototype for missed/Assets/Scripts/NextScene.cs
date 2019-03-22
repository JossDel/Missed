using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            NextRoom();
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
