using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondmistmovement : MonoBehaviour
{
    public float speed = 0.5f;

    public Rigidbody2D rb;

    public GameObject secondmist;
    // Use this for initialization
    void Start()
    {
        secondmist.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        
    }

}
