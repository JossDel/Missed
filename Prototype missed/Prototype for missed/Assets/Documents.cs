using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    public GameObject Note;
    void ShowNote()
    {
        PauseMenu.FindObjectOfType<PauseMenu>().GameIsPaused = true;
        Time.timeScale = 0f;
        Note.SetActive(true);
        PauseMenu.FindObjectOfType<PauseMenu>().finalNote = true;
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowNote();
        }
    }
}
