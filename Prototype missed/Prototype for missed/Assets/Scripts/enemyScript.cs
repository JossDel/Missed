using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemyToProjectile))]
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

        if (!gameObject.name.Contains("shooter"))
            gameObject.GetComponent<Enemymovement>().enabled = false;
        else
            gameObject.GetComponent<Enemyshhoterboi>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        
        StartCoroutine(gameObject.GetComponent<EnemyToProjectile>().Transition(gameObject));
    }
}
