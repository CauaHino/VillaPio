using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public float jumpForce = 4f;
    public static int vida = 2;
    public static int intentos = 5;

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
    public static int municion = 10;

    // UIManager
    private UiManager uiManager;
    
    // Audio
    public AudioClip jumpAudio;
    public AudioClip gunShotAudio;
    private AudioSource audioSource;

    void Start()
    {
        uiManager = FindAnyObjectByType<UiManager>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.F) && municion > 0)
        {
            LaunchObject();
            municion--;
            uiManager.updateProyectileText(municion);
            audioSource.PlayOneShot(gunShotAudio);
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
            audioSource.PlayOneShot(jumpAudio);
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

    public void Hit()
    {
        anim.SetTrigger("Hit");
        intentos--;
        uiManager.updateTentativaText(intentos);
        if (intentos == 0)
        {
            Die();
        }
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
        vida--;
        intentos = 5;
        uiManager.updateVidaText(vida);
        uiManager.showMenu(vida); 
        
    }
}