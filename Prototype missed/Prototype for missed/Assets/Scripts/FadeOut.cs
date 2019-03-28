using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public bool trueForOut = true;
    public float fadeOutTime = 2f;

    void Start()
    {
        StartCoroutine(SpriteFadeOut(trueForOut));
    }

    public IEnumerator SpriteFadeOut(bool outNotIn)
    {
        //if (!outNotIn)
        //{
        //    Time.timeScale = 0f;
        //    if (PauseMenu.FindObjectOfType<PauseMenu>())
        //        PauseMenu.FindObjectOfType<PauseMenu>().GameIsPaused = true;
        //}
        Color tmpColor = gameObject.GetComponent<Graphic>().color;

        if (outNotIn)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();

            while (tmpColor.a > 0f)
            {
                tmpColor.a -= Time.unscaledDeltaTime / fadeOutTime;
                gameObject.GetComponent<Graphic>().color = tmpColor;

                if (tmpColor.a <= 0f)
                    tmpColor.a = 0.0f;

                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (tmpColor.a < 1f)
            {
                tmpColor.a += Time.unscaledDeltaTime / fadeOutTime;
                gameObject.GetComponent<Graphic>().color = tmpColor;

                if (tmpColor.a >= 1f)
                    tmpColor.a = 1f;

                yield return new WaitForEndOfFrame();
            }
        }
        gameObject.GetComponent<Graphic>().color = tmpColor;

        yield return new WaitForSecondsRealtime(.5f);
        if (!outNotIn)
        {
            //if (PauseMenu.FindObjectOfType<PauseMenu>())
            //    if (PauseMenu.FindObjectOfType<PauseMenu>().GameIsPaused == true)
            //        Time.timeScale = 1f;
            //if (PauseMenu.FindObjectOfType<PauseMenu>())
            //    PauseMenu.FindObjectOfType<PauseMenu>().GameIsPaused = false;
            NextScene.FindObjectOfType<NextScene>().NextRoom();
        }
        if (SceneManager.GetActiveScene().name == "LogoScreen")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
