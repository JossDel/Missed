using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemies <= 0)
        {
            Debug.Log("You did it!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            numberOfEnemies++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            numberOfEnemies -- ;
        }
    }
    public void OnEnemyDestroyed()
    {
        numberOfEnemies--;
    }
} 

