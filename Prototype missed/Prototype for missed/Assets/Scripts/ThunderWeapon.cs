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
    public float secondaryTime = 1.4f;
    public float dps = 0.2f;

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

        if (timeBetCasts2 <= 0)
        {
            if (Input.GetMouseButton(1) && !shooting) // 0 is left click 1 right click and 2 middle click
            {
                shooting = true;
                gameObject.GetComponent<Movement>().movementSpeed += moveSpeedBuff;

                Shoot2();
            }
        }
        else
        {
            timeBetCasts2 -= Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(1) && shooting)
        {
            gameObject.GetComponent<Movement>().movementSpeed -= moveSpeedBuff;
            shooting = false;
        }

        if (Input.GetMouseButtonUp(0) && shooting)
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
        GameObject field = Instantiate(lightFieldPrefab, firePoint.position, Quaternion.identity);
        field.GetComponent<Deathbytime>().lifetime = secondaryTime;
        field.transform.parent = transform;
        field.GetComponent<StayWithPlayer>().player = gameObject;
        timeBetCasts2 = secondaryFireRate;
    }

    float CooldownCalculate()
    {
        if (timeBetCasts2 == secondaryFireRate)
            return 0;
        return (float)timeBetCasts2 / (float)secondaryFireRate;
    }

    void OnDisable()
    {
        if(shooting)
            gameObject.GetComponent<Movement>().movementSpeed -= moveSpeedBuff;
        shooting = false;
        timeBetCasts = 0;
        timeBetCasts2 = 0;
        gameObject.GetComponent<Movement>().canMove = true ;

    }
}