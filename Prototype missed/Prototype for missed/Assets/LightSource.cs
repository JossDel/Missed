using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField]
    int healthBack = 10;
    public GameObject poof;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().health += healthBack;
            Instantiate(poof, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
