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

    bool shooting = false;

    int moveSpeedBuff = 5;

    void Update()
    {
        if (timeBetCasts <= 0)
        {
            if (Input.GetMouseButton(0) && !shooting) // 0 is left click 1 right click and 2 middle click
            {
                shooting = true;
                gameObject.GetComponent<Movement>().movementSpeed += moveSpeedBuff;
            }
            if (Input.GetMouseButton(0) && shooting)
            {
                Shoot();
            }
        }
        else
        {
            timeBetCasts -= Time.deltaTime;
            if (timeBetCasts <= fireRate - .3f)
                gameObject.GetComponent<Movement>().canMove = true;
        }
        if (Input.GetMouseButtonUp(0) && shooting)
        {
            gameObject.GetComponent<Movement>().movementSpeed -= moveSpeedBuff;
            shooting = false;
        }

        if (timeBetCasts2 <= 0)
        {
            if (Input.GetMouseButton(1) && !shooting) // 0 is left click 1 right click and 2 middle click
            {
                shooting = true;
                gameObject.GetComponent<Movement>().movementSpeed += moveSpeedBuff;
            }
            if (Input.GetMouseButton(1) && shooting)
            {
                Shoot2();
            }
        }
        else
        {
            timeBetCasts2 -= Time.deltaTime;
            if (timeBetCasts2 <= secondaryFireRate - .3f)
                gameObject.GetComponent<Movement>().canMove = true;
        }
        if (Input.GetMouseButtonUp(1) && shooting)
        {
            gameObject.GetComponent<Movement>().movementSpeed -= moveSpeedBuff;
            shooting = false;
        }
        cooldown.value = CooldownCalculate();
    }
    void Shoot()
    {
        Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
        timeBetCasts = fireRate;
        gameObject.GetComponent<Movement>().canMove = false;
    }

    void Shoot2()
    {
        Instantiate(lightFieldPrefab, firePoint.position, Quaternion.identity);
        timeBetCasts2 = secondaryFireRate;
        gameObject.GetComponent<Movement>().canMove = false;
    }

    float CooldownCalculate()
    {
        return 1;
    }
}