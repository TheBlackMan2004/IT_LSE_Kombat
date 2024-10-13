
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    private float horizontal1;
    private float horizontal2;
    public float currentSpeed = 8f;
    private float currentSpeed2 = 8f;
    public float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;
    private bool isFacingRight2 = false;
    [SerializeField] private Collider2D crouchCollider;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        if (IsGrounded())
        {
            horizontal1 = Input.GetAxisRaw("Horizontal1");
            
        }
        if (Input.GetButtonDown("Jump1") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonDown("Crouch1") && IsGrounded())
        {
            currentSpeed = 0;
            crouchCollider.enabled = false;
        }
        else if (Input.GetButtonUp("Crouch1"))
        {
            currentSpeed =speed;
            crouchCollider.enabled = true;
        }    
        Flip();
    }

    private void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontal1 * currentSpeed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal1 < 0f || !isFacingRight && horizontal1 > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

