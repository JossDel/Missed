using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject fireBall;
    public Transform firePoint;

    //primary weapon
    private float timeBtwShots;
    public float fireRate;

    //secondary weapon
    private float timeBtwShots2;
    public float secondaryFireRate;
    public float secondFireTimer = 0;

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
        if (timeBtwShots2 <= 0)
        {
            if (Input.GetButton("Fire2"))
            {
                secondFireTimer += Time.deltaTime;
                //code that charges the secondary fire
                // when button is released you fire away the charged bullet
                // resets the fire rate
            }
            if (Input.GetButtonUp("Fire2") && (secondFireTimer >= 2))
            {
                Instantiate(fireBall, firePoint.position, firePoint.rotation);
            }
        }
    }
    void Shootfire()
    {
        Instantiate(fireBall, firePoint.position, firePoint.rotation);
        timeBtwShots = fireRate;
    }
}
