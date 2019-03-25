using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToProjectile : MonoBehaviour
{
    public GameObject projectileStill;
    public GameObject projectile;

    [Header("Projectile Damage to the Barrier")]
    [SerializeField]
    float SkeletonDamage = 1;
    [SerializeField]
    float MageDamage = 4;
    [SerializeField]
    float DraugrDamage = 6;

    [HideInInspector]
    public float DamageToBarrier;

    public IEnumerator Transition(GameObject enemy)
    {
        float scale;
        float r, g, b;
        float perc = 1f;

        GameObject stillProj = Instantiate(projectileStill, enemy.transform.position, new Quaternion());
        stillProj.transform.localScale = new Vector3(0.1f, 0.1f, stillProj.transform.localScale.z);

        while (perc != 0.00f)
        {
            yield return new WaitForSecondsRealtime(.01f);

            perc -= .03f;
            perc = Mathf.Clamp01(perc);

            stillProj.transform.localScale = new Vector3(Mathf.Lerp(1f, 0.1f, perc), Mathf.Lerp(1f, 0.1f, perc), stillProj.transform.localScale.z);
            stillProj.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Mathf.Lerp(1f, 0.1f, perc));

            if (enemy.gameObject.name.Contains("draugr"))
            {
                DamageToBarrier = DraugrDamage;

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
                DamageToBarrier = SkeletonDamage;

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
                DamageToBarrier = MageDamage;

                scale = Mathf.Lerp(0.4f, 1f, perc);

                enemy.transform.localScale = new Vector3(scale, scale, enemy.transform.localScale.z);

                if (perc == 0f)
                {
                    break;
                }
            }
            else
                Debug.LogError("WOW... EEEEY THERE BUDDY, calm down... Something went wrong in your coroutine");
        }

        if (GameObject.FindGameObjectWithTag("Barrier"))
        {
            if (GameObject.FindGameObjectWithTag("BulletForBarrier"))
            {
                GameObject[] buls = GameObject.FindGameObjectsWithTag("BulletForBarrier");
                float totalDamage = 0;
                for(int i = 0; i < buls.Length; i++)
                {
                    totalDamage += buls[i].GetComponent<BulletForBarrier>().GetDamage();
                }
                if (GameObject.FindGameObjectWithTag("Barrier").GetComponent<DoorBarrierScript>().DoesItLive(totalDamage))
                {
                    GameObject bul = Instantiate(projectile, enemy.transform.position, new Quaternion());
                    bul.GetComponent<BulletForBarrier>().SetDamage(DamageToBarrier);
                }
                else Debug.Log("The barrier would die so it doesn't spawn a projectile. Make it animate with poof");
            }
            else
            {
                GameObject bul = Instantiate(projectile, enemy.transform.position, new Quaternion());
                bul.GetComponent<BulletForBarrier>().SetDamage(DamageToBarrier);
            }
        }

        Destroy(stillProj);
        Destroy(enemy);
    }
}
