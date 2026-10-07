using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 2f;
    
    private Rigidbody2D rb2D;
        
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void LaunchProjectile(float direction)
    {
        rb2D.linearVelocity = new Vector2(speed * direction, rb2D.linearVelocity.y);   
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            enemy.Hit();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Floor")) 
        {
            Destroy(gameObject);
        }
    }
}