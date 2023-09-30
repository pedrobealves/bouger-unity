using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Animator animator;
    [SerializeField] Transform initialCheckpoint;
    [SerializeField] private Behaviour[] components;
    public bool isDead;

    [SerializeField]
    private int life = 1;

    public int Life
    {
        get { return life; }
        set
        {
            if (isDead) return;
            if (life < 0)
            {
                isDead = true;
                SwitchAllComponents(false);
                animator.SetTrigger("die");
                return;
            }
            life = value;
        }
    }

    [SerializeField]
    private int bullets = 5;
    public int Bullets
    {
        get { return bullets; }
        set
        {
            bullets += value;
        }
    }
    private void Awake()
    {
        currentCheckpoint = initialCheckpoint;
        animator = GetComponent<Animator>();
    }

    private void SwitchAllComponents(bool value)
    {
        foreach (Behaviour component in components)
            component.enabled = value;
    }

    public void TakeDamage(int damage)
    {
        this.Life -= damage;
    }

    public void Respawn()
    {
        animator.ResetTrigger("die");
        animator.Play("Player_idle");

        life = 1;

        isDead = false;

        transform.position = currentCheckpoint.position;

        Camera.main.GetComponent<CameraFollow>().SetNewPosition(currentCheckpoint.parent.position);

        SwitchAllComponents(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("activate");
        }
    }
}
