using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float verticalSpeed = Input.GetAxisRaw("Vertical");

        body.velocity = new Vector2(horizontalSpeed * speed, verticalSpeed * speed);
    }
}
