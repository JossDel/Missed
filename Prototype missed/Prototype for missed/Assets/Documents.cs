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
        gameObject.SetActive(false);
        Note.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowNote();
        }
    }
}
