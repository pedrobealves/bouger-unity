using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public Transform wallCheck;
    private bool isFacingRight = true;
    public bool groundDetected;
    public bool wallDetected;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, 1f, LayerMask.GetMask("Foreground"));

        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, 0.5f, LayerMask.GetMask("Box") | LayerMask.GetMask("Foreground") | LayerMask.GetMask("Enemy"));

        Debug.DrawRay(groundCheck.position, Vector2.down * 1f, Color.red);
        Debug.DrawRay(wallCheck.position, transform.right * 0.5f, Color.green);

        if (!groundDetected || wallDetected)
        {
            flip();
        }
    }

    private void flip()
    {
        if (isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

            isFacingRight = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

            isFacingRight = true;
        }
    }
}
