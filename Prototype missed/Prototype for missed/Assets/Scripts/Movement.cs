using UnityEngine;

public class Movement : PlayerStats
{
    Rigidbody2D rb;
    private Vector2 moveVeocity;

    public bool canMove = true;

    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVeocity = moveInput.normalized * movementSpeed;
        if (moveVeocity.x < 0)
            animator.SetInteger("Direction", 1);
        else if (moveVeocity.x > 0)
            animator.SetInteger("Direction", 3);
        else if (moveVeocity.y < 0)
            animator.SetInteger("Direction", 0);
        else if (moveVeocity.y > 0)
            animator.SetInteger("Direction", 2);
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
