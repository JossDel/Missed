using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (gameObject.name == "Bossarmsup (1)")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().HardSaveReset();
            SceneManager.LoadScene(0);
            return;

        }
        GameObject.Find("EnemyDetector").GetComponent<Detection>().OnEnemyDestroyed();
        Destroy(gameObject);                        
    }
}
