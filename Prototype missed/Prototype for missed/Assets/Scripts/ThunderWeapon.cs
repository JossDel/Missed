using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ThunderWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lightningPrefab;
    public GameObject lightFieldPrefab;

    public Slider cooldown;

    private float timeBetCasts;
    public float fireRate;

    private float timeBetCasts2;
    public float secondaryFireRate;

    private float secondaryCooldown;
    public float fireCooldown = 2f;

    private void Start()
    {
        secondaryCooldown = fireCooldown;
        cooldown.value = CooldownCalculate();
    }

    void Update()
    {
        if (timeBetCasts <= 0)
        {

            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            timeBetCasts -= Time.deltaTime;
        }

        if (bulletsfired != bulletAmmount)          // If you have more secondary bullets to shoot
        {
            if (timeBetCasts2 <= 0)
            {
                if (bulletsfired == 0)
                {
                    if (Input.GetButton("Fire2"))
                    {
                        Instantiate(lightFieldPrefab, firePoint.position, firePoint.rotation);
                        bulletsfired++;
                        timeBetCasts2 = secondaryFireRate;
                    }
                }
                else
                {
                    Instantiate(lightFieldPrefab, firePoint.position, firePoint.rotation);
                    bulletsfired++;
                    timeBetCasts2 = secondaryFireRate;
                }
            }
            else
            {
                timeBetCasts2 -= Time.deltaTime;
            }
        }
        else
        {
            if (secondaryCooldown <= 0)
            {
                secondaryCooldown = fireCooldown;
                bulletsfired = 0;
            }
            else
            {
                secondaryCooldown -= Time.deltaTime;
            }
        }
        cooldown.value = CooldownCalculate();
    }
    void Shoot()
    {
        Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
        timeBetCasts = fireRate;
    }

    float CooldownCalculate()
    {
        return (float)bulletsfired / (float)bulletAmmount;
    }
}