using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    private Transform currentCheckpoint;
    [SerializeField] Transform initialCheckpoint;
    [SerializeField]
    private int life = 1;

    public int Life
    {
        get { return life; }
        set
        {
            if (life < 0)
            {
                Respawn();
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
    }

    public void TakeDamage(int damage)
    {
        this.Life -= damage;
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;

        Camera.main.GetComponent<CameraFollow>().SetNewPosition(currentCheckpoint.parent.position);
    }
}
