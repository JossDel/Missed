using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class weapom : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject secondBullet;

    public Slider cooldown;

    public int bulletAmmount = 5;
    private int bulletsfired = 0;

    private float timeBtwShots;
    public float fireRate;

    private float timeBtwShots2;
    public float secondaryFireRate;

    private float secondaryCooldown;
    public float fireCooldown = 2f;

    private void Start()
    {
        secondaryCooldown = fireCooldown;
        cooldown.value = CooldownCalculate();
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
        if (bulletsfired == bulletAmmount)          // If you shot all secondary bullets
        {
            if (secondaryCooldown <= 0.1)
            {
                secondaryCooldown = fireCooldown;
                bulletsfired = 0;
            }
            else
            {
                secondaryCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (timeBtwShots2 <= 0)
            {
                if (bulletsfired == 0)
                {
                    if (Input.GetButton("Fire2"))
                    {
                        Instantiate(secondBullet, firePoint.position, firePoint.rotation);
                        bulletsfired++;
                        timeBtwShots2 = secondaryFireRate;
                    }
                }
                else
                {
                    Instantiate(secondBullet, firePoint.position, firePoint.rotation);
                    bulletsfired++;
                    timeBtwShots2 = secondaryFireRate;
                }
            }
            else
            {
                timeBtwShots2 -= Time.deltaTime;
            }
        }
        cooldown.value = CooldownCalculate();
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
    }

    float CooldownCalculate()
    {
        if (secondaryCooldown == fireCooldown && bulletsfired > 0)
            return 1;
        if (secondaryCooldown == fireCooldown)
            return 0;
        return (float)secondaryCooldown / (float)fireCooldown;
    }

    void OnDisable()
    {
        bulletsfired = 0;
        timeBtwShots = 0;
        timeBtwShots2 = 0;
        secondaryCooldown = fireCooldown;
    }
}