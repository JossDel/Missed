using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondmistmovement : MonoBehaviour
{
    public float speed = 0.5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
}
