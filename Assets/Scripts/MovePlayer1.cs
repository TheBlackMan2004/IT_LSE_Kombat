
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

    [SerializeField] float p1ResetPosX = -6.5f;
    [SerializeField] float p1ResetPosY = -4.39f;
    [SerializeField] float p2ResetPosX = 6.2f;
    [SerializeField] float p2ResetPosY = -4.39f;
    public int p1Score;
    public int p2Score;
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
        if(player1.currentHealth<=0 || player2.currentHealth<=0)
        {
            ResetScene();
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
    private void ResetScene()
    {
        if (player1.currentHealth <= 0) p2Score++;
        else p1Score++;
        if (p2Score == 2) { Debug.Log(player2.characterName + " won"); return; }
        else if  (p1Score == 2){ Debug.Log(player1.characterName + " won"); return; }
        player1.transform.position = new Vector3(p1ResetPosX, p1ResetPosY, player1.transform.position.z);
        player2.transform.position = new Vector3(p2ResetPosX, p2ResetPosY, player2.transform.position.z);
        player1.currentHealth = player1.health;
        player2.currentHealth = player2.health;
    }
}

