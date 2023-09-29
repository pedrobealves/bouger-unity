using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    private SimpleFlash flashEffect;

    [SerializeField]
    private int life = 2;
    public int Life
    {
        get { return life; }
        set
        {
            if (life < 0)
            {
                Destroy(this.gameObject);
            }
            life = value;
        }
    }

    private void Awake()
    {
        flashEffect = GetComponent<SimpleFlash>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shoot")
        {
            flashEffect.Flash();
            Life -= 1;
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterStatus>().TakeDamage(1);
        }
    }
}
