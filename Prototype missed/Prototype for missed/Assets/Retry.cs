using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    float timer = 0;
    void Update()
    {
        if (timer > 1.5 && Input.anyKeyDown)
        {
            if (GameObject.Find("Player").GetComponent<PlayerStats>().progress != 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().SaveReset();
                SceneManager.LoadScene("Checkpoint " + GameObject.Find("Player").GetComponent<PlayerStats>().progress);
            }
            else
                SceneManager.LoadScene("Final Tutorial");
        }
        timer += Time.deltaTime;

    }
}
