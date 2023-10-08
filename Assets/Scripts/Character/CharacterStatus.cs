using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Animator animator;
    [SerializeField] public int maxBullet;
    [SerializeField] public int maxLife;
    [SerializeField] private AudioClip checkpointSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] Transform initialCheckpoint;
    [SerializeField] private Behaviour[] components;
    public bool isDead;

    public int life;

    public int Life
    {
        get { return life; }
        set
        {
            if (isDead) return;
            if (life <= 0)
            {
                isDead = true;
                GameEvents.instance.PlayerDeath();
                SwitchAllComponents(false);
                animator.SetTrigger("die");
                SoundManager.instance.PlaySound(deathSound);
                return;
            }
            life = value;
        }
    }


    public int bullets;

    public int Bullets
    {
        get { return bullets; }
        set
        {
            bullets = value;
            GameEvents.instance.UpdateBullets();
        }
    }
    private void Awake()
    {
        bullets = maxBullet;
        life = maxLife;
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

    public void AddBullets(int bullets)
    {
        this.Bullets += bullets;
        if (this.Bullets > maxBullet)
            this.Bullets = maxBullet;
    }

    public void Respawn()
    {
        animator.ResetTrigger("die");
        animator.Play("Player_idle");

        life = maxLife;

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
            SoundManager.instance.PlaySound(checkpointSound);
        }
    }
}
