using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mist : MonoBehaviour {
    public float speed = 0.5f;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
