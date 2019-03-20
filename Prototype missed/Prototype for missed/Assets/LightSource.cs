using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField] int healthBack = 10;
    [SerializeField] float corruptionDown = 10f;
    public GameObject poof;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().health += healthBack;
            other.GetComponent<PlayerStats>().corruption -= corruptionDown;
            Instantiate(poof, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
