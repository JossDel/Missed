using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject poof;

    public int damage;
    public int maxFireDamage;
    public float speed;
    Rigidbody2D rb;

    int tempDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (weapom.FindObjectOfType<FireWeapon>().isActiveAndEnabled)
            transform.parent = GameObject.Find("pointoffire").transform;
        if (weapom.FindObjectOfType<weapom>().isActiveAndEnabled)
        {
            rb.velocity = transform.up * speed;
            transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (FireWeapon.FindObjectOfType<FireWeapon>().isActiveAndEnabled && !FireWeapon.FindObjectOfType<FireWeapon>().charging)
        {
            if (transform.parent != GameObject.FindGameObjectWithTag("Player").transform)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                damage = tempDamage;
                transform.GetComponent<Deathbytime>().enabled = true;
            }
            rb.velocity = transform.up * speed;
        }
        if (FireWeapon.FindObjectOfType<FireWeapon>().isActiveAndEnabled && FireWeapon.FindObjectOfType<FireWeapon>().charging)
        {
            if (transform.parent != GameObject.FindGameObjectWithTag("Player").transform)
            {
                transform.localScale = FireWeapon.FindObjectOfType<FireWeapon>().BulScale();
                tempDamage = CalculateDamage();
                transform.position = GameObject.Find("pointoffire").transform.position;
            }
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
                Boom();
                enemy.TakeDamage(damage);
            }
            
            if(!gameObject.name.Contains("ELECTRIC"))
            Destroy(gameObject);
        }
        if (collision.CompareTag("Walls"))
        {
            if (!gameObject.name.Contains("ELECTRIC")){
                Boom();
                Destroy(gameObject);
            }
        }
    }
    void Boom()
    {
        Instantiate(poof, transform.position, transform.rotation);
    }
}
