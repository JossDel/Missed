using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    GameObject mist;
    GameObject lightUnderPlayer;

    public float fadeOutTime = 2f;

    void Start()
    {
        mist = GameObject.Find("MIST");
        lightUnderPlayer = GameObject.Find("Point Light");
        StartCoroutine(SpriteFadeOut(GetComponent<SpriteRenderer>()));
    }

    IEnumerator SpriteFadeOut(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;

        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.color = tmpColor;

            if (tmpColor.a <= 0f)
                tmpColor.a = 0.0f;

            yield return null;
        }
        _sprite.color = tmpColor;

        mist.SetActive(false);
        if (lightUnderPlayer != null)
        {
            lightUnderPlayer.SetActive(false);
        }
    }
}
