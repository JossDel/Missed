using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject fireBall;
    public Transform firePoint;

    private float timeBtwShots;
    public float fireRate;

    // Start is called before the first frame update
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
                Shootfire();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    void Shootfire()
    {
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
    }
}
