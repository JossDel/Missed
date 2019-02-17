using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    private float timeBtwAttack;
    public float attackRate;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            if (player != null)
            {
                if (timeBtwAttack <= 0)
                {
                    player.takeDamage(damage);
                    timeBtwAttack = attackRate;
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }
            }
            
        }
    }
}
