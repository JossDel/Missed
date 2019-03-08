using UnityEngine;

public class enemyScript : MonoBehaviour {

    public int Health = 8;
 
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
            return;
        }
    }
    void Die()
    {
        Destroy(gameObject);                        
        GameObject.Find("EnemyDetector").GetComponent<Detection>().OnEnemyDestroyed();
    }
}
