using UnityEngine;

public class Movement : PlayerStats
{
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    

    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, Input.GetAxisRaw("Vertical") * movementSpeed);

        //Camera and rotating stuff
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

        Vector2 direction = new Vector2(
            mousepos.x - transform.position.x,
            mousepos.y - transform.position.y
            );

        transform.up = direction;

    }
    
  
}
