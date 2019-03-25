using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForBarrier : MonoBehaviour
{
    [SerializeField]
    float speed = 100;
    float damage;

    void Start()
    {
        transform.up = GameObject.FindGameObjectWithTag("Barrier").transform.position - transform.position;
        transform.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    public void SetDamage(float projectileDamage)
    {
        damage = projectileDamage;
    }

    public float GetDamage()
    {
        return damage;
    }

    private void OnTriggerEnter2D(Collider2D barrier)
    {
        if (barrier.tag.Equals("Barrier"))
        {
            barrier.GetComponent<DoorBarrierScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
