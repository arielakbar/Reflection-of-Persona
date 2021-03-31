using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Jongkok"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Jongkok"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        Debug.Log(crouch);
        jump = false;
    }
}
