﻿
using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class MovePlayer1 : MonoBehaviour
{
    public TextMeshProUGUI timeCounterText;
    int timeCounter=90;
   [SerializeField] int maxTime = 90;
    public GameObject backg;
    public GameObject meniuplayer1;
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
    public HealthBar healthBar1;
    public HealthBar healthBar2;
    [SerializeField] GameObject[] roundsWon;
    [SerializeField] float p1ResetPosX = -6.5f;
    [SerializeField] float p1ResetPosY = -4.39f;
    [SerializeField] float p2ResetPosX = 6.2f;
    [SerializeField] float p2ResetPosY = -4.39f;
    [SerializeField] GameObject winMenu1;
    [SerializeField] GameObject winMenu2;
    bool canAttack = true;
    public int p1Score;
    public int p2Score;
    public int maxScore=2;
  public  bool isReseting = false;
    private void Start()
    {
        timeCounter = maxTime;
        healthBar1.SetMaxHealth(player1.health);
        healthBar2.SetMaxHealth(player2.health);
        StartCoroutine(Clock());
    }

    private void Awake()
    {
        Time.timeScale = 1;
        backg.SetActive(true);
    }
    void Update()
    {
        healthBar1.SetHealth(player1.currentHealth);
        healthBar2.SetHealth(player2.currentHealth);
        if(p1Score==maxScore)
        {
            winMenu1.SetActive(true);
            Time.timeScale = 0;
        }
        if (p2Score == maxScore)
        {
            winMenu2.SetActive(true);
            Time.timeScale = 0;
        }
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
        if(player1.currentHealth<=0 || player2.currentHealth<=0 || timeCounter<=0)
        {
            if(!isReseting)
                ResetScene();
            
        }
        if(Input.GetButtonDown("Punch1") && canAttack)
        {
            StartCoroutine(Delay1(0.9f));
        }
        if (Input.GetButtonDown("Punch2") && canAttack)
        {
            StartCoroutine(Delay2(0.9f));
        }
        if (Input.GetButtonDown("Kick1") && canAttack)
        {
            StartCoroutine(Delay1(1.1f));
        }
        if (Input.GetButtonDown("Kick2") && canAttack)
        {
            StartCoroutine(Delay2(1.1f));
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
        StartCoroutine(Reset());
    }
    IEnumerator Delay1(float delay)
    {
        currentSpeed = 0;
        canAttack = false;
        yield return new WaitForSeconds(delay);
        currentSpeed = speed;
        canAttack = true;
    }
    IEnumerator Delay2(float delay)
    {
        currentSpeed2 = 0;
        canAttack = false;
        yield return new WaitForSeconds(delay);
        currentSpeed2 = speed;
        canAttack = true;
    }
    IEnumerator Clock()
    {
        while(timeCounter>0)
        {
            timeCounter--;
            timeCounterText.text = timeCounter.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator Reset()
    {
        isReseting = true;
        if (player1.currentHealth <= 0)
        {
            if (p2Score < maxScore) 
            p2Score++;
            roundsWon[p2Score + 1].SetActive(true);
        }
        else if(player2.currentHealth<=0)
        {
            if(p1Score<maxScore)
            p1Score++;
            roundsWon[p1Score - 1].SetActive(true);
        }
        else if(timeCounter<=0)
        {
            if (player1.currentHealth > player2.currentHealth)
            {
                if(p1Score<maxScore)
                p1Score++;
                roundsWon[p2Score + 1].SetActive(true);
            }

            else if(player2.currentHealth>player1.currentHealth)
            {
                if(p2Score<maxScore)
                p2Score++;
                roundsWon[p1Score - 1].SetActive(true);
            }
            else
            {
                if(p1Score<maxScore)
                p1Score++;
                if(p2Score<maxScore)
                p2Score++;
                roundsWon[p2Score + 1].SetActive(true);
                roundsWon[p1Score - 1].SetActive(true);
            }
            timeCounter = maxTime;
            StartCoroutine(Clock());
        }
        player1.transform.position = new Vector3(p1ResetPosX, p1ResetPosY, player1.transform.position.z);
        player2.transform.position = new Vector3(p2ResetPosX, p2ResetPosY, player2.transform.position.z);
        player1.currentHealth = player1.health;
        player2.currentHealth = player2.health;
        timeCounter = maxTime;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1;
        isReseting = false;
    }
}

