using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToProjectile : MonoBehaviour
{
    GameObject projectile;
    void Awake()
    {
        projectile = (GameObject)Resources.Load("prefabs/LightSource", typeof(GameObject));
    }

    public IEnumerator Transition(GameObject enemy)
    {
        float scale;
        float r, g, b;
        float perc = 1f;

        while (perc != 0.00f)
        {
            yield return new WaitForSecondsRealtime(.01f);

            perc -= .01f;
            perc = Mathf.Clamp01(perc);



            if (enemy.gameObject.name.Contains("draugr"))
            {

                scale = Mathf.Lerp(0.5f, 1.3f, perc);

                enemy.transform.localScale = new Vector3(scale, scale, enemy.transform.localScale.z);

                r = Mathf.Lerp(160f, 255f, perc);
                g = Mathf.Lerp(0f, 255f, perc);
                b = Mathf.Lerp(200f, 255f, perc);

                enemy.gameObject.GetComponent<SpriteRenderer>().color = new Color(r / 255, g / 255, b / 255, enemy.gameObject.GetComponent<SpriteRenderer>().color.a);

                if (perc == 0f)
                {
                    break;
                }
            }
            else if (enemy.gameObject.name.Contains("skeleton"))
            {

                scale = Mathf.Lerp(0.7f, 1f, perc);

                enemy.transform.localScale = new Vector3(scale, scale, enemy.transform.localScale.z);

                r = Mathf.Lerp(80f, 255f, perc);
                g = Mathf.Lerp(0f, 255f, perc);
                b = Mathf.Lerp(100f, 255f, perc);

                enemy.gameObject.GetComponent<SpriteRenderer>().color = new Color(r / 255, g / 255, b / 255, enemy.gameObject.GetComponent<SpriteRenderer>().color.a);


                if (perc == 0f)
                {
                    break;
                }
            }
            else if (enemy.gameObject.name.Contains("enemyshooter"))
            {

                scale = Mathf.Lerp(3f, 7f, perc);

                enemy.transform.localScale = new Vector3(scale, scale, enemy.transform.localScale.z);

                r = Mathf.Lerp(70f, 150f, perc);
                g = Mathf.Lerp(0f, 81f, perc);
                b = Mathf.Lerp(100f, 81f, perc);

                enemy.gameObject.GetComponent<SpriteRenderer>().color = new Color(r / 255, g / 255, b / 255, enemy.gameObject.GetComponent<SpriteRenderer>().color.a);


                if (perc == 0f)
                {
                    break;
                }
            }
            else
                Debug.LogError("WOW... EEEEY THERE BUDDY, calm down... Something went wrong in your coroutine");


            // Instantiate projectile at the
            //Instantiate(projectile, enemy.transform.position)
        }

        if(GameObject.FindGameObjectWithTag("Barrier"))
            GameObject.FindGameObjectWithTag("Barrier").GetComponent<DoorBarrierScript>().TakeDamage(1);

        Destroy(enemy);
    }
}
