using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;
    public int maxFireDamage;
    public float speed;
    Rigidbody2D rb;

    int tempDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(weapom.FindObjectOfType<weapom>().isActiveAndEnabled)
            rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (FireWeapon.FindObjectOfType<FireWeapon>().isActiveAndEnabled && !FireWeapon.FindObjectOfType<FireWeapon>().charging)
        {
            rb.velocity = transform.up * speed;
            damage = tempDamage;
            transform.GetComponent<Deathbytime>().enabled = true;
        }
        if (FireWeapon.FindObjectOfType<FireWeapon>().isActiveAndEnabled && FireWeapon.FindObjectOfType<FireWeapon>().charging)
        {
            transform.localScale = FireWeapon.FindObjectOfType<FireWeapon>().BulScale();
            tempDamage = CalculateDamage();
            Debug.Log(tempDamage);
        }
    }

    int CalculateDamage()
    {
        return Mathf.RoundToInt( Mathf.Lerp(damage, maxFireDamage, FireWeapon.FindObjectOfType<FireWeapon>().DamagePerc()));
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