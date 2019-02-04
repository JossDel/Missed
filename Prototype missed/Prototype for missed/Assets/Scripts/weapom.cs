using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class weapom : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject secondBullet;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private float timeBtwShots2;
    public float startTimeBtwShots2;

    // Use this for initialization
    void Start()
    {

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
        if (timeBtwShots2 <= 0)
        {
            if (Input.GetButton("Fire2"))
            {
                Instantiate(secondBullet, firePoint.position, firePoint.rotation);
                timeBtwShots2 = startTimeBtwShots2;
            } 
        } else
        {
            timeBtwShots2 -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}