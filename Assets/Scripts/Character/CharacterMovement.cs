using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;

public class CharacterMovement : MonoBehaviour
{


    private Rigidbody2D body;
    CharacterGround ground;

    [SerializeField]
    public float maxSpeed = 10f;

    [SerializeField]
    private float friction;

    public float directionX;
    private Vector2 desiredVelocity;
    public Vector2 velocity;
    public bool onGround;
    public bool pressingKey;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<CharacterGround>();
        anim = GetComponent<Animator>();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        directionX = context.ReadValue<float>();
    }

    private void Update()
    {


        if (directionX != 0)
        {
            //transform.localScale = new Vector3(directionX > 0 ? 1 : -1, 1, 1);
            transform.rotation = Quaternion.Euler(0, directionX > 0 ? 0 : 180, 0);
            pressingKey = true;
        }
        else
        {
            pressingKey = false;
        }


        desiredVelocity = new Vector2(directionX, 0f) * Mathf.Max(maxSpeed - friction, 0f);

        anim.SetFloat("speed", Mathf.Abs(onGround ? directionX : 0));
    }

    private void FixedUpdate()
    {

        onGround = ground.GetOnGround();

        velocity = body.velocity;

        Run();
    }

    private void Run()
    {

        velocity.x = desiredVelocity.x;

        body.velocity = velocity;
    }

}
