using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnemyToProjectile))]
public class enemyScript : MonoBehaviour {

    public AudioSource SoundWhenHit;

    public int Health = 8;
    float lightOff;
    float debuffOff = 0;
    float enemyDefaultSpeed;

    void Update()
    {
        if (transform.Find("light").gameObject.activeSelf)
        {
            lightOff += Time.deltaTime;
            if (lightOff > 2)
                transform.Find("light").gameObject.SetActive(false);
        }

        if (debuffOff != 0)
        {
            debuffOff += Time.deltaTime;
            if (debuffOff > 3)
            {
                if (!gameObject.name.Contains("shooter"))
                    gameObject.GetComponent<Enemymovement>().speed = enemyDefaultSpeed;
                else
                    gameObject.GetComponent<Enemyshhoterboi>().speed = enemyDefaultSpeed;
                debuffOff = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        SoundWhenHit.Play();
        if (Health <= 0)
        {
            Die();
            return;
        }
    }

    public void TakeDamage(int damage, bool hitByLight)
    {
        TakeDamage(damage);
        if (hitByLight)
        {
            transform.Find("light").gameObject.SetActive(true);
            lightOff = 0;
        }
        else
        {
            if (debuffOff == 0)
            {
                if (!gameObject.name.Contains("shooter"))
                {
                    enemyDefaultSpeed = gameObject.GetComponent<Enemymovement>().speed;
                    gameObject.GetComponent<Enemymovement>().speed -= gameObject.GetComponent<Enemymovement>().speed * 0.5f;
                }
                else
                {
                    enemyDefaultSpeed = gameObject.GetComponent<Enemyshhoterboi>().speed;
                    gameObject.GetComponent<Enemyshhoterboi>().speed -= gameObject.GetComponent<Enemyshhoterboi>().speed * 0.3f;
                }
            }
            debuffOff = 1;
        }
    }

    void Die()
    {
        if (gameObject.name == "Boss")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().HardSaveReset();
            SceneManager.LoadScene("WinScreen");
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
