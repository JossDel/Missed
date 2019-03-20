using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireonground : MonoBehaviour
{
    [SerializeField] int damage = 5;
    public GameObject poof;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                player.takeDamage(damage);
                Instantiate(poof, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}