using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10.0f;
    protected int jumpPower;
    private float leftWall = -4f;
    private float rightWall = 4f;

    protected Rigidbody2D rb;

    protected Vector2 jumpForce = new Vector2(0, 1);

    protected bool isJumping;
    protected bool canDoubleJump;

    private Animator anim;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(translation>0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if(translation < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        if (transform.position.x + translation < rightWall && transform.position.x + translation > leftWall)
        {
            transform.Translate(translation, 0, 0);
        }

        if(translation!=0)
        {
            anim.SetFloat("PlayerSpeed", speed);
        }
        else
        {
            anim.SetFloat("PlayerSpeed", 0);
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

}
