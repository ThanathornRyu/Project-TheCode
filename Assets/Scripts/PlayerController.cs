using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRigidbody;
    float horizontal;

    #region PlayerControlStatus

    float playerSpeed = 5f;
    float jumpHeight = 5f;
    float dashTime;
    float startDashTime = 0.1f;
    float dashSpeed = 10f;
    bool isGrounded;

    #endregion

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        if(playerRigidbody != null)
        {
            // GroundedCheck
            InputKey();
            // 1. Move (Left & Right)
            Move();
        }
    }
    void InputKey()
    {
        horizontal = Input.GetAxis("Horizontal");
        // 2. Jump (Up)
        if (Input.GetButtonDown("Jump"))
        {
            // isGrounded = true
            Jump();
        }

        // 3. Interact
        // 4. GetItem
    }
    void Move()
    {
        playerRigidbody.velocity = new Vector2(horizontal * playerSpeed, playerRigidbody.velocity.y);
        // 1.5 Dash & Run  (DoublePress)
    }
    void Jump()
    {
        // 2.5 WallJump & WallSlide (PressJump Again & PressDownMove For WallSlide)
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
    }
}
