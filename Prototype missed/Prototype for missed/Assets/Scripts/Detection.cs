using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject mist;
    public int numberOfEnemies;
    public GameObject Door;
    // Update is called once per frame
    void LateUpdate()
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
            Door.GetComponent<NextScene>().open = true;
            this.enabled = false;
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("EnemyShooter"))
        {
            numberOfEnemies++;
        }
    }

    public void OnEnemyDestroyed()
    {
        numberOfEnemies--;
    }
} 

