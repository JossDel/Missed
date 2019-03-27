using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Note;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused == true)
        {
            Resume();
        }
        else
        {
            return;
        }
    }
    public void Resume()
    {
        Note.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Note.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pause();
            gameObject.SetActive(false);
        }
    }
}
