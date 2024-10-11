using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Movement controller;
    public float speed = 40f;
    public float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal1")* speed;
        if (Input.GetButtonDown("Jump1"))
            jump = true;
        if (Input.GetKeyDown(KeyCode.S)) crouch = true;
        else if (Input.GetKeyUp(KeyCode.S)) crouch = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove* Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
