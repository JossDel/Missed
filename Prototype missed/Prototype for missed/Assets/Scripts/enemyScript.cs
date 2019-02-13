using UnityEngine;

public class enemyScript : MonoBehaviour {

    public int Health = 8;
    public
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject.Find("EnemyDetector").GetComponent<Detection>().OnEnemyDestroyed();
        Destroy(gameObject);
    }
}
