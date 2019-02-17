using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;    // This along with the code in awake, makes sure that this script only exists once
    public RoomManager roomScript;

    private int room = 3;


    void Awake()
    {
        if (instance == null)                      // This sets the null istance to this one if there is none
            instance = this;
        else if (instance != this)                 // If there's already an instance and this gets called again, it deletes the new instance.
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);             // This makes sure that this script doesn't get destroyed after loading a new scene
        roomScript = GetComponent<RoomManager>();
        InitGame();
    }

    void InitGame()
    {
        //roomScript.SetupScene(room);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
