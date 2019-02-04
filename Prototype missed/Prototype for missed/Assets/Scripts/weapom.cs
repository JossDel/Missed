using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class weapom : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject secondBullet;
    public int amountofbullets = 5;
    private int bulletsfired = 0;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float timeBtwShots2;
    public float startTimeBtwShots2;

    private float secondaryCooldown;
    public float startSecondaryCooldown = 2f;

    private void Start()
    {
        secondaryCooldown = startSecondaryCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {

            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (bulletsfired != amountofbullets)
        {
            if (timeBtwShots2 <= 0)
            {
                if (Input.GetButton("Fire2"))
                {
                    Instantiate(secondBullet, firePoint.position, firePoint.rotation);
                    bulletsfired++;
                    timeBtwShots2 = startTimeBtwShots2;
                }
            }
            else
            {
                timeBtwShots2 -= Time.deltaTime;
            }
        } else
        {
            if (secondaryCooldown <= 0)
            {
                secondaryCooldown = startSecondaryCooldown;
                bulletsfired = 0;
            }
            else
            {
                secondaryCooldown -= Time.deltaTime;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}