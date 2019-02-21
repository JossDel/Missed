using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*                              FUTURE
 *   If there are tons of variables and it gets complex and messy saving single variables in PlayerPrefs,
 *   we can save one string that is basically one xml/json file with all the info.
 *   EXTRA EXTRA -- If it gets too big of a file or we run into other problems, consider custom save files.
 */

public class GameStatus : MonoBehaviour
{
    public int numLives = 3;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Load data from PlayerPrefs -- this might be from the
        // previous scene, or maybe even from the previous execution
        // (i.e. saved between quitting and reloading the game)
        // The second value in the parenthesies is optional. It is used in the event that the key
        // was not assosiated with anything/ didn't exist before now to set a default value to it.
        score = PlayerPrefs.GetInt("score", 0);
        numLives = PlayerPrefs.GetInt("lives", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This will happen whenever this object is destroyed,
    // which includes scene changes as well as simply exiting the program.
    private void OnDestroy()
    {
        Debug.Log("GameStatus was destroyed.");

        // We decided here to save the data when the scene gets destroeyd but
        // we could have decided as easely to save them in the AddScore function or anywhere for that matter
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("lives", numLives);
    }
    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
