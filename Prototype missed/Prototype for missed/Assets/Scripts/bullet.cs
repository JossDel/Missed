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

    float dps;
    float tDps = 0;

    int tempDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (FireWeapon.FindObjectOfType<FireWeapon>().isActiveAndEnabled)
            transform.parent = GameObject.Find("pointoffire").transform;
        if (weapom.FindObjectOfType<weapom>().isActiveAndEnabled)
        {
            rb.velocity = transform.up * speed;
            transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (gameObject.name.Contains("ELECTRIC"))
            dps = GameObject.FindGameObjectWithTag("Player").GetComponent<ThunderWeapon>().dps;
    }

    void Update()
    {
        if (tDps > 0f && gameObject.name.Contains("ELECTRIC"))
            tDps -= Time.deltaTime;

        if (gameObject.name.Contains("FIRE") && !FireWeapon.FindObjectOfType<FireWeapon>().charging)
        {
            if (transform.parent != GameObject.FindGameObjectWithTag("Player").transform)
            {
                transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                damage = tempDamage;
                transform.GetComponent<Deathbytime>().enabled = true;
            }
            rb.velocity = transform.up * speed;
        }
        if (gameObject.name.Contains("FIRE") && FireWeapon.FindObjectOfType<FireWeapon>().charging)
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
        if (!gameObject.name.Contains("ELECTRIC"))
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
            {
                enemyScript enemy = collision.GetComponent<enemyScript>();
                if (enemy != null)
                {
                    Boom();
                    if(gameObject.name.Contains("Bulletprefab(") || gameObject.name.Contains("Bulletprefab weak("))
                        enemy.TakeDamage(damage, true);
                    else
                        enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            if (collision.CompareTag("Walls"))
            {
                Boom();
                Destroy(gameObject);
            }
        }

        if (gameObject.name.Contains("ELECTRIC("))
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
            {

                    enemyScript enemy = collision.GetComponent<enemyScript>();
                if (!collision.name.Contains("Boss"))
                {

                    if (enemy != null)
                    {
                        Boom(enemy.transform);
                        enemy.TakeDamage(damage, false);
                    }
                }
                else
                    enemy.TakeDamage(damage, false);

            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.name.Contains("ELECTRIC2") && Dps())
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
            {
                enemyScript enemy = collision.GetComponent<enemyScript>();
                if (enemy != null)
                {
                    Boom(enemy.transform);
                    enemy.TakeDamage(damage, false);
                    tDps = dps;
                }
            }
        }
    }
    void Boom()
    {
        Instantiate(poof, transform.position, transform.rotation);
    }
    
    void Boom(Transform pos)
    {
        Instantiate(poof, pos.position, transform.rotation);
    }

    bool Dps()
    {
        if (tDps <= 0f)
            return true;
        else
            return false;
    }
}
