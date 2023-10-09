using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{

    private Animator anim;
    public bool isActive = false;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private int id;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isOn = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.up, 1.0f, layerMask);

        if (isOn != isActive)
        {
            isActive = !isActive;
            ButtonActive();
        }
    }

    void ButtonActive()
    {
        anim.SetBool("isActive", isActive);
        GameEvents.instance.ButtonActive(id);
    }
}
