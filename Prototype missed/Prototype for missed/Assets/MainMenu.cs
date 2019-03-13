using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        if (GameObject.Find("Player").GetComponent<PlayerStats>().progress != 0)
            SceneManager.LoadScene("Checkpoint " + GameObject.Find("Player").GetComponent<PlayerStats>().progress);
        else
            SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().HardSaveReset();
        SceneManager.LoadScene("Level 1");
    }
}
