using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterJump : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D body;
    private CharacterGround ground;
    [HideInInspector] public Vector2 velocity;


    [SerializeField] public float jumpHeight = 7.3f;
    [SerializeField] public float timeToJumpApex;
    [SerializeField] public float upwardMovementMultiplier = 1f;
    [SerializeField] public float downwardMovementMultiplier = 6.17f;
    [SerializeField] public int maxAirJumps = 0;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip jumpLandSound;
    [SerializeField] public float speedLimit;
    [SerializeField] public float jumpBuffer = 0.15f;

    public float jumpSpeed;
    private float defaultGravityScale;
    public float gravMultiplier;
    [SerializeField] public float coyoteTime = 0.15f;

    public bool canJumpAgain = false;
    private bool desiredJump;
    private float jumpBufferCounter;
    private float coyoteTimeCounter = 0;
    public bool onGround;
    private bool currentlyJumping;
    private Animator anim;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<CharacterGround>();
        defaultGravityScale = 1f;
        anim = GetComponent<Animator>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            desiredJump = true;
            anim.SetBool("isJumping", true);
        }
    }

    void Update()
    {
        setPhysics();

        onGround = ground.GetOnGround();


        if (jumpBuffer > 0)
        {
            if (desiredJump)
            {
                jumpBufferCounter += Time.deltaTime;

                if (jumpBufferCounter > jumpBuffer)
                {
                    desiredJump = false;
                    jumpBufferCounter = 0;
                }
            }
        }

        if (!currentlyJumping && !onGround)
        {
            coyoteTimeCounter += Time.deltaTime;
        }
        else
        {
            coyoteTimeCounter = 0;
        }
    }

    private void setPhysics()
    {

        Vector2 newGravity = new Vector2(0, (-2 * jumpHeight) / (timeToJumpApex * timeToJumpApex));
        body.gravityScale = (newGravity.y / Physics2D.gravity.y) * gravMultiplier;
    }

    private void FixedUpdate()
    {
        velocity = body.velocity;

        if (desiredJump)
        {
            DoAJump();
            body.velocity = velocity;
            return;
        }

        calculateGravity();
    }

    private void calculateGravity()
    {

        if (body.velocity.y > 0.01f)
        {
            if (onGround)
            {
                gravMultiplier = defaultGravityScale;
            }
            else
            {
                gravMultiplier = upwardMovementMultiplier;
            }
        }

        //Else if going down...
        else if (body.velocity.y < -0.01f)
        {

            if (onGround)

            {
                gravMultiplier = defaultGravityScale;
            }
            else
            {

                gravMultiplier = downwardMovementMultiplier;
            }

        }
        else
        {
            if (onGround)
            {
                if (currentlyJumping)
                    SoundManager.instance.PlaySound(jumpLandSound);
                currentlyJumping = false;
                anim.SetBool("isJumping", false);
            }

            gravMultiplier = defaultGravityScale;
        }


        body.velocity = new Vector3(velocity.x, Mathf.Clamp(velocity.y, -speedLimit, 100));
    }

    private void DoAJump()
    {

        if (onGround || (coyoteTimeCounter > 0.03f && coyoteTimeCounter < coyoteTime) || canJumpAgain)
        {
            SoundManager.instance.PlaySound(jumpSound);
            desiredJump = false;
            jumpBufferCounter = 0;
            coyoteTimeCounter = 0;

            canJumpAgain = (maxAirJumps == 1 && canJumpAgain == false);

            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * body.gravityScale * jumpHeight);


            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            else if (velocity.y < 0f)
            {
                jumpSpeed += Mathf.Abs(body.velocity.y);
            }


            velocity.y += jumpSpeed;
            currentlyJumping = true;

        }

        if (jumpBuffer == 0)
        {
            desiredJump = false;
        }
    }

    public void bounceUp(float bounceAmount)
    {
        body.AddForce(Vector2.up * bounceAmount, ForceMode2D.Impulse);
    }
}
