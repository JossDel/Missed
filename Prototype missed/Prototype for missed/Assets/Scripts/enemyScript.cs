using UnityEngine;

public class enemyScript : MonoBehaviour {

    public int Health = 8;
 
    public void TakeDamage(int damage)
    {

        if (Health <= 0)
        {
            Die();
            return;
        }
        Health -= damage;
    }
    void Die()
    {
        GameObject.Find("EnemyDetector").GetComponent<Detection>().OnEnemyDestroyed();
        Destroy(gameObject);
    }
}
