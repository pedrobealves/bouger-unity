using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    public Vector3 initialPosition;
    [SerializeField] private AudioClip swapSound;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        GameEvents.instance.OnPlayerDeath += Respawn;
    }

    void Respawn()
    {
        transform.position = initialPosition;
    }

    // Update is called once per frame
    public void swapPlayer()
    {
        SoundManager.instance.PlaySound(swapSound);
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
