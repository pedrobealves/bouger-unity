using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private AudioClip endSound;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.instance.musicSource.Stop();
            SoundManager.instance.PlaySound(endSound);
            SceneManager.LoadScene(0);
        }
    }
}
