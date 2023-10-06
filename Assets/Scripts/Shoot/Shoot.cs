using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D circleCollider;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        anim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Box>(out Box box))
        {
            box.swapPlayer();
            DestroyShoot();
        }
        else if (other.gameObject.tag != "Player")
        {
            circleCollider.enabled = false;
            rb.velocity = Vector3.zero;
            anim.SetTrigger("explode");
        }
    }

    void DestroyShoot()
    {
        Destroy(gameObject);
    }

}
