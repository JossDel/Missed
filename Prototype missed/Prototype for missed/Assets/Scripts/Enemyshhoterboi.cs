using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshhoterboi : MonoBehaviour {

    public float speed;
    public float stopinDinstance;
    public float retreatDistance;

    public int canSeePlayer;
    public Transform player;
    public GameObject projetile;

    [SerializeField] float minReload;
    [SerializeField] float maxReload;
    private float timeBtwShots;
    public float startTimeBtwShots;

	// Use this for initialization
	void Start () {
        canSeePlayer = 0;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
	}
	
	// Update is called once per frame
	void Update () {
        if (canSeePlayer == 1)
        {
            if (Vector2.Distance(transform.position, player.position) > stopinDinstance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) < stopinDinstance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) < stopinDinstance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }


            if (timeBtwShots <= 0)
            {
                Instantiate(projetile, transform.position, Quaternion.identity);
                startTimeBtwShots = Random.Range(minReload, maxReload);
                timeBtwShots = startTimeBtwShots;
            } else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
	}
}
