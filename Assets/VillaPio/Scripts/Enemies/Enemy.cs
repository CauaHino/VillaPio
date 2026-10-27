using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    protected Animator animator;
    private SpriteRenderer spriteRenderer;
    
    public Transform puntoA;
    public Transform puntoB;
    public float speed = 0.5f;
    private Transform objetivo;
    protected int vida;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objetivo = puntoB;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            objetivo.position, 
            Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, objetivo.position) < 0.1f)
        {
            if (objetivo == puntoA)
            {
                spriteRenderer.flipX = true;
                objetivo = puntoB;
            } else {
                spriteRenderer.flipX = false;
                objetivo = puntoA;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player  player = collision.GetComponent<Player>();
        if (collision.transform.CompareTag("Player"))
        {
            player.Hit();
        }
    }

    public void Hit()
    {
        animator.SetTrigger("Hit");
        vida--;
        if (vida == 0)
        {
            speed = 0;
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.5f); 
    }
}
