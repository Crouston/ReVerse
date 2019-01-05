using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected Rigidbody2D rb;

    protected Vector2 movement = new Vector2(1, 0);
    protected Vector2 jumpForce = new Vector2(0, 1);

    protected uint speed;
    protected int jumpPower;

    protected bool isFacingRight;
    protected bool isJumping;
    protected bool canDoubleJump;

    private Animator anim;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    protected void Move()
    {
        switch (isFacingRight)
        {
            case true:
                transform.Translate(movement * speed * Time.deltaTime);
                break;

            case false:
                transform.Translate(movement * -speed * Time.deltaTime);
                break;
        }
    }

    void KeyDown()
    {

        if (Input.GetAxis("Horizontal") > 0)
        {
            isFacingRight = true;
            Move();
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            isFacingRight = false;
            Move();
        }

    }

    void Jump()
    {
        if (Input.GetKeyDown("up"))
        {
            if (!isJumping)
            {
                Debug.Log("jump!!");
                rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                canDoubleJump = true;
                isJumping = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    Debug.Log(" double jump!!");
                    canDoubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(jumpForce * jumpPower, ForceMode2D.Impulse);
                }
            }
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        isJumping = false;
        jumpPower = 5;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        KeyDown();
    }

}
