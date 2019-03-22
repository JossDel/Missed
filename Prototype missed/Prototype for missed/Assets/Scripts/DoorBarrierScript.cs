using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBarrierScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10;
    
    void Update()
    {
        if (health <= 0)
        {
            DestroyBarrier(false /*check if it's visible*/);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //Make sound
    }

    void DestroyBarrier(bool visible) // make this a Coroutine
    {
        if (visible)
        {
            // fade the barrier
        }
        Debug.Log("Door Barrier destroyed");
        //Make sound
        Destroy(gameObject);
    }
}
