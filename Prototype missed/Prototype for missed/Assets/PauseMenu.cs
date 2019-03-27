using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    private GameObject[] notes;

    // Update is called once per frame
    void Update()
    {
        notes = GameObject.FindGameObjectsWithTag("Notes");
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(NoteActive())
            {
                 if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
          
           
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
   void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
   
}
