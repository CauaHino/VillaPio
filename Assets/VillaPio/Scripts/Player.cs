using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 4f;
    
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    
    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);
        
        if (move != 0)
        {
            spriteRenderer.flipX = move < 0;
        }
        
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(
                rb2D.linearVelocity.x,
                jumpForce
            );
        }
        
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetFloat("VerticalVelocity", rb2D.linearVelocity.y);
        anim.SetBool("IsGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }
}
