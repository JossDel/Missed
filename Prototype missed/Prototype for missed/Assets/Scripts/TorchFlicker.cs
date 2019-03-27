using System.Collections;
using UnityEngine;

public class TorchFlicker : MonoBehaviour
{
    Animator anim;

    [Header("Seconds before next random Range")]

    [SerializeField]
    float minWait = .1f;
    [SerializeField]
    float maxWait = .15f;

    [Header("Range of Range value in Light component")]

    [SerializeField]
    float minRange = 50;
    [SerializeField]
    float maxRange = 80;

    #region InspectorStuff
    [Space]

    [SerializeField]
    [Tooltip("This determines how smooth the flickering of the Light looks.\nThe higher the value the smoother it is.\n" +
        "The max value is currently 7 but it should be the difference between the max and min range values.")]
    [Range(0.01f,7)]
    #endregion
    float smooth = 5;

    Light light;

    Coroutine co;

    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        light = GetComponent<Light>();
        co = StartCoroutine(Flashing());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Mist"))
        {
            StopCoroutine(co);
            light.range = 40;
            StartCoroutine(Burnoff());
        }
    }

    IEnumerator Flashing()
    {
        while (true)
        {
            bool once = false;
            yield return new WaitForSecondsRealtime(Random.Range(minWait, maxWait));
            float newRange = Mathf.Lerp(minRange, maxRange, Random.Range(0f, 1f));
            while(light.range > newRange)
            {
                smooth = Mathf.Clamp(smooth, 0.01f, maxRange - minRange);
                light.range -= .1f * smooth;
                yield return new WaitForSecondsRealtime(.01f);
                if (light.range <= newRange)
                {
                    once = true;
                }
            }
            if (once)
                continue;
            while (light.range < newRange)
            {
                smooth = Mathf.Clamp(smooth, 0.01f, maxRange - minRange);
                light.range += .1f * smooth;
                yield return new WaitForSecondsRealtime(.01f);
            }
        }
    }

    IEnumerator Burnoff()
    {
        int two = 1;
        while (true)
        {
            light.range += 1f * two;
            yield return new WaitForSecondsRealtime(.01f);
            if (light.range >= 75f && two == 2)
            {
                anim.SetBool("InMist", true);
                Destroy(gameObject);
            }
            if (light.range >= 55f && two != 2)
                two = 2;
        }
    }
}
