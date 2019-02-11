using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour {

    public float speed = 0.5f;

    public Rigidbody2D rb;
    [SerializeField] int amount;

    [SerializeField] float dmgTime = 2f;
    [SerializeField] float timer = 1f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            if (timer >= dmgTime)
            {
                PlayerStats corrupt = collision.GetComponent<PlayerStats>();
                
            }
                
                
        }
    }
}
