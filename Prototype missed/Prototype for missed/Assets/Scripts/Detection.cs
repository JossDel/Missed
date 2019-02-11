using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject mist;
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
            //remove mist
            mist.GetComponent<Mist>().amount = 0f;

            mist.GetComponent<Mist>().speed = 0f;

            mist.GetComponent<Mist>().rb.velocity = Vector2.zero;
            mist.AddComponent<FadeOut>();




            GameObject.Find("EnemyDetector").GetComponent<Detection>().OnEnemyDestroyed();
            //make it so that the player can move along to next level
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

