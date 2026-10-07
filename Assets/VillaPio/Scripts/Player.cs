using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool isDead = false;
    private float sightDirection;
    
    //Attack
    public Transform attackPoint;
    public float attackRadius = 0.5f;
    public LayerMask enemyLayer;
    
    // Projectile
    public GameObject projectilePrefab;
    public Transform throwPoint;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            LaunchObject();
        }
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);
        
        if (move != 0)
        {
            spriteRenderer.flipX = move < 0;
            sightDirection = move;
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Attack");
            Collider2D collider = Physics2D.OverlapCircle(
                attackPoint.position,
                attackRadius,
                enemyLayer);

            if (collider != null)
            {
                Slime slime = collider.GetComponent<Slime>();
                if (slime != null)
                {
                    slime.Hit();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    private void LaunchObject()
    {
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        if (sightDirection == 0)
        {
            sightDirection = 1;
        }
        projectile.GetComponent<Projectile>().LaunchProjectile(sightDirection);
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }
        rb2D.linearVelocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("isDead");
        Invoke(nameof(RecargarEscena), 0.5f);
    }

    // The animation will call this method on its last frame
    public void RecargarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
