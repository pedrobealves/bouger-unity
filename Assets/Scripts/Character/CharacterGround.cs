using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGround : MonoBehaviour
{
    private bool onGround;

    [SerializeField]
    private float groundLength = 0.95f;

    [SerializeField]
    private Vector3 colliderOffset;

    [SerializeField]
    private LayerMask groundLayer;

    private BoxCollider2D boxCollider2D;

    public float offset = 0.1f;

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        onGround = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, offset, groundLayer);
    }
    public bool GetOnGround() { return onGround; }
}
