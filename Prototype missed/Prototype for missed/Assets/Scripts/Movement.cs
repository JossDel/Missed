using UnityEngine;

public class Movement : PlayerStats
{
    Rigidbody2D rb;
    private Vector2 moveVeocity;

    public bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVeocity = moveInput.normalized * movementSpeed;
    }


void FixedUpdate()
    {
        if (canMove)
            rb.MovePosition(rb.position + moveVeocity * Time.fixedDeltaTime);

        //Camera and rotating stuff
        Vector3 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);

        Vector2 direction = new Vector2(
            mousepos.x - transform.GetChild(0).position.x,
            mousepos.y - transform.GetChild(0).position.y
            );

        transform.GetChild(0).up = direction;

    }
}
