using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] CapsuleCollider2D capsuleCollider;

    [SerializeField] private float playerSpeed = 10f;
    //private Vector2 movement = new Vector2(1, 1);

    [SerializeField] private GameObject player;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isGrounded = false;
    private SpriteRenderer spriteRenderer;
    public bool isAlive = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        ProcessJump();
        ProcessRun();
        Animation();
    }

    //Move the player horizontally across the X axis
    private void ProcessRun()
    {
        //check if the player is alive to allow movement
        if (isAlive == true)
        {
            float hInput = Input.GetAxis("Horizontal");
            rb.velocity = new(hInput * playerSpeed, rb.velocity.y);
        }
        //stop the player from continuing to move 
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        //flip the sprite to the moving direction
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            spriteRenderer.flipX= false;
        }
    }

    //Allow the player to jump if the collider detects the Ground
    private void ProcessJump()
    {
        //check if the player is grounded
        isGrounded = capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        //let the player jump if player is grounded
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector2(0.0f, jumpSpeed);
            Debug.Log("Jumped");
            isGrounded = false;
        }
    }

    //control the animation for the player
    private void Animation()
    {
        //control the animation of the player jumping
        animator.SetBool("Jumping", !isGrounded);

        //control the animation of the player running and idle
        if (Mathf.Abs(rb.velocity.x) > 0 && isGrounded)
        {
            //set the animation to true to make player animate run
            animator.SetBool("Moving", true);
        }
        else
        {
            //set the animation to true to make player animate run
            animator.SetBool("Moving", false);
        }        
    }
}
