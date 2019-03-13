using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    Rigidbody2D rb;

    float r, g, b;

    void Start()
    {
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