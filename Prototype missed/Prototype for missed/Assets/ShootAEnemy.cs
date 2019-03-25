using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAEnemy : MonoBehaviour
{
    public GameObject projetile;
    //public Transform player;
    public Transform firePoint;

    public float minRange;
    public float maxRange;

    private float timeBtwShots;
    public float startTimeBtwShots;
    private int Hp;

    // Start is called before the first frame update
    void Start()
    {
        Hp = GetComponent<enemyScript>().Health;

        minRange = 6f;
        maxRange = 8f;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {


        if (timeBtwShots <= 0)
        {
            Instantiate(projetile, firePoint.position, firePoint.rotation);
            startTimeBtwShots = Random.Range(minRange, maxRange);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (Hp <= 200)
        {
            minRange = 3f;
            maxRange = 4.5f;
        }
    }
}
