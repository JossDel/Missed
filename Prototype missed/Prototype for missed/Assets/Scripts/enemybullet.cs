using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour {

    public Animator anim;

    public float speed = 5f;
    public int damage = 5;

    private Transform player;
    private Vector2 target;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.takeDamage(damage);
            }
                DestroyProjectile();
        }
        if (other.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }

    }

    void DestroyProjectile()
    {
        anim.SetTrigger("LocReach");
        //Destroy(gameObject);
    }
}
