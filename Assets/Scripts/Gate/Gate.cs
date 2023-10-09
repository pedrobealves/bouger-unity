using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private AudioClip gateSound;
    private BoxCollider2D boxCollider2D;
    private Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        GameEvents.instance.OnButtonActive += GateToggle;
    }

    // Update is called once per frame
    private void GateToggle(int id)
    {
        if (id == this.id)
        {
            isOpen = !isOpen;
            anim.SetBool("isActive", isOpen);
            boxCollider2D.enabled = !isOpen;
            SoundManager.instance.PlaySound(gateSound);
        }
    }
}
