using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanelUpdater : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // This is a (relatively slow/bad) way to grab the GameStatus
        GameObject go = GameObject.Find("GameStatus");
        if (go == null)
        {
            Debug.LogError("Failed to find an object named 'GameStatus'");
            this.enabled = false;
            return;
        }

        // It's the GameStatus script that we actually care about
        GameStatus gs = go.GetComponent<GameStatus>();

        GetComponent<Text>().text = "Score: " + gs.score + " Lives: " + gs.numLives;
    }
}
