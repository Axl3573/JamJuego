using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    private float Horizontal;
    public float speed = 1.0f;
    public float jumpForce = 250f;
    private bool grounded;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        
    }

    
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        Animator.SetBool("walking", Horizontal != 0.0f);

        if (Horizontal <0.0f) transform.localScale = new Vector3(-0.16f, 0.16f, 0.16f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.45f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }


    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    
    }
}
