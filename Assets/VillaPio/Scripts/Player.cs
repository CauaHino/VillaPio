using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 6f;
    
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;
    
    private Rigidbody2D rb2D;
    private float move;
    private bool isGrounded;
    private Animator anim;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(
                rb2D.linearVelocity.x,
                jumpForce
            );
        }
    }
}
