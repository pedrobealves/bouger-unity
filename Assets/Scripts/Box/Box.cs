using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    public Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (player.GetComponent<CharacterStatus>().isDead)
        {
            transform.position = initialPosition;
        }
    }

    // Update is called once per frame
    public void swapPlayer()
    {
        player.GetComponent<Animator>().SetTrigger("swap");
        anim.SetTrigger("swap");
    }

    public void swap()
    {
        Vector3 playerTransform = player.transform.position;
        player.transform.position = transform.position;
        transform.position = playerTransform;
    }
}
