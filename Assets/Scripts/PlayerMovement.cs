using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    private float groundCheckRadius = 0.2f;
    private SpriteRenderer spriteRenderer;
    public Animator animator; //adding animations transition

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Get the horizontal input axis (A and D or Left and Right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        //Animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, 0);

        // Move the player
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        // Flip the player's sprite based on the direction
        if ((horizontalInput > 0 && !isFacingRight) || (horizontalInput < 0 && isFacingRight))
        {
            Flip();
        }
    }

    void Flip()
    {
        // Switch the direction the player is facing
        isFacingRight = !isFacingRight;

        // Flip the sprite horizontally
        spriteRenderer.flipX = !isFacingRight;
    }
}
