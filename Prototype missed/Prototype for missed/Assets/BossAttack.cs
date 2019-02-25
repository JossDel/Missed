using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject projetile;
    public Transform player;
    public Transform firePoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {


        if (timeBtwShots <= 0)
        {
            Instantiate(projetile, firePoint.position, firePoint.rotation);
            startTimeBtwShots = Random.Range(0f, 1f);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
