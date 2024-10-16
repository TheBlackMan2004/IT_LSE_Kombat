
using System;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    private float horizontal1;
    private float horizontal2;
    public float currentSpeed = 8f;
    private float currentSpeed2 = 8f;
    public float speed = 8f;
    private float jumpingPower = 10f;
    public Collider2D crouchCollider;
    public Collider2D crouchCollider2;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Transform groundCheck;
    public Transform groundCheck2;
    [SerializeField] private LayerMask groundLayer;
    public CharacterBase player1;
    public CharacterBase player2;
    void Update()
    {
        if (IsGrounded())
        {
            horizontal1 = Input.GetAxisRaw("Horizontal1");
            
        }
        if (IsGrounded2())
        {
            horizontal2 = Input.GetAxisRaw("Horizontal2");

        }
        if (Input.GetButtonDown("Jump1") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonDown("Jump2") && IsGrounded2())
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumpingPower);
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
        if (Input.GetButtonDown("Crouch2") && IsGrounded2())
        {
            currentSpeed2 = 0;
            crouchCollider2.enabled = false;
        }
        else if (Input.GetButtonUp("Crouch2"))
        {
            currentSpeed2 = speed;
            crouchCollider2.enabled = true;
        }
    }
 
    private void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontal1 * currentSpeed, rb.velocity.y);
       rb2.velocity = new Vector2(horizontal2 * currentSpeed2, rb2.velocity.y);
    }
    private bool IsGrounded2()
    {
        return Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

