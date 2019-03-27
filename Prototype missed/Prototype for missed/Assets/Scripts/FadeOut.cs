using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    GameObject fdsfds;

    public float fadeOutTime = 2f;

    void Start()
    {
        fdsfds = gameObject;
        StartCoroutine(SpriteFadeOut(fdsfds));
    }

    IEnumerator SpriteFadeOut(GameObject _sprite)
    {
        Color tmpColor = _sprite.GetComponent<Graphic>().color;

        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.GetComponent<Graphic>().color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;

            yield return null;
        }
        _sprite.GetComponent<Graphic>().color = tmpColor;

        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        fdsfds.SetActive(false);
    }
}
