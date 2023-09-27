using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        rb.velocity = Vector3.zero;

        if (other.TryGetComponent<Box>(out Box box))
        {
            box.swapPlayer();
            DestroyShoot();
        }
        else
        {
            anim.SetTrigger("explode");
        }
    }

    void DestroyShoot()
    {
        Destroy(gameObject);
    }

}
