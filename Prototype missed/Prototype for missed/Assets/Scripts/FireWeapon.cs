using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Slider cooldown;

    private float timeBtwShots;
    public float fireRate;

    public bool charging = false;
    float chargingTime;
    readonly float chargingLimit = 2f;

    private void Start()
    {
        chargingTime = chargingLimit;
        cooldown.value = CooldownCalculate();
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0)) // 0 is left click 1 right click and 2 middle click
            {
                charging = true;
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
            if (Input.GetMouseButton(0) && charging)
            {
                Charge();
            }
            if (Input.GetMouseButtonUp(0) && charging)
            {
                Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        cooldown.value = CooldownCalculate();
    }
    void Shoot()
    {
        charging = false;
        chargingTime = chargingLimit;
        timeBtwShots = fireRate;
    }

    void Charge()
    {
        chargingTime -= Time.deltaTime;
        if (chargingTime <= 0)
        {
            Shoot();
        }
    }

    public Vector3 BulScale()
    {
        float scale = Mathf.Abs(chargingTime - 4f);
        return new Vector3(scale, scale, 0);
    }

    public float DamagePerc()
    {
        return Mathf.InverseLerp(0f, 2f, Mathf.Abs(chargingTime - 2f));
    }

    float CooldownCalculate()
    {
        if (timeBtwShots == fireRate)
            return 1;
        if (timeBtwShots <= 0)
            return 0;
        return timeBtwShots / fireRate;
    }
}