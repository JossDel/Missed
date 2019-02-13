using UnityEngine;

public class Mist : MonoBehaviour {

    public float speed = 0.5f;

    public Rigidbody2D rb;
    public float amount; // What is amount?

    [SerializeField] float mistAttackRate = 1f;
    private float timer;

	// Use this for initialization
	void Start () {
       
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}
	

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            if (timer <= 0)
            { 
                collision.gameObject.GetComponent<PlayerStats>().corruption += amount;
                timer = mistAttackRate;
            }
            timer -= Time.deltaTime;
                
                
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timer = 0;
        }
    }
}
