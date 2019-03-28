using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    float timer = 0;
    private void Update()
    {
        if (timer > 1.5 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
        timer += Time.deltaTime;
    }

}
