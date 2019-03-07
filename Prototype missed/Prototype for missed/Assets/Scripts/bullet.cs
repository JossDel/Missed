using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject player;

    public int damage;
    public float speed;
    Rigidbody2D rb;

    float r, g, b;

    void Start()
    {
        player = GameObject.Find("Player");

        if (player.GetComponent<PlayerStats>().activeWeapon == 1)
        {
            r = 255f;
            g = 255f;
            b = 255f;
        }
        if (player.GetComponent<PlayerStats>().activeWeapon == 2)
        {
            r = 1f;
            g = 30f / 255f;
            b = 0f;
        }
        if (player.GetComponent<PlayerStats>().activeWeapon == 3)
        {
            r = 114f / 255f;
            g = 204f / 255f;
            b = 1f;
        }
        GetComponent<SpriteRenderer>().color = new Color(r, g, b);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
        {
            enemyScript enemy = collision.GetComponent<enemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
        if (collision.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}