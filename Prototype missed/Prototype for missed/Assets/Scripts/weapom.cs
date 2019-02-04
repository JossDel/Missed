using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class weapom : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timeBtwShots;
    public float startTimeBtwShots;

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
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}