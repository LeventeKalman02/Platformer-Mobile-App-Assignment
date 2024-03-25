using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;

    [SerializeField] private float playerSpeed = 10f;
    //private Vector2 movement = new Vector2(1, 1);

    [SerializeField] private GameObject player;
    [SerializeField] private float jumpSpeed = 10f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        ProcessJump();
        ProcessRun();
    }

    //Move the player horizontally across the X axis
    private void ProcessRun()
    {
        float hInput = Input.GetAxis("Horizontal");
        rb.velocity = new(hInput * playerSpeed, rb.velocity.y);
    }

    //Allow the player to jump if the collider detects the Ground
    private void ProcessJump()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            //Debug.Log("Grounded");
            return;
        }
            
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0.0f, jumpSpeed);
            //Debug.Log("Jumped");
        }
    }
}
