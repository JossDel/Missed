using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSource : MonoBehaviour
{

    [SerializeField] int healthBack = 10;
    [SerializeField] float corruptionDown = 10f;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().health += healthBack;
            other.GetComponent<PlayerStats>().corruption -= corruptionDown;
            Destroy(gameObject);
        }
    }
}
