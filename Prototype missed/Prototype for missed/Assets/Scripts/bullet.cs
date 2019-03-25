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
        if (!gameObject.name.Contains("ELECTRIC"))
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
            {
                enemyScript enemy = collision.GetComponent<enemyScript>();
                if (enemy != null)
                {
                    Boom();

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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.name.Contains("ELECTRIC") && Dps())
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
            {
                enemyScript enemy = collision.GetComponent<enemyScript>();
                if (enemy != null)
                {
                    Boom(enemy.transform);
                    Debug.Log("damage boom man Electric");
                    enemy.TakeDamage(damage);
                    tDps = dps;
                    Debug.Log(dps);
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
