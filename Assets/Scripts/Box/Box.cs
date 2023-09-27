using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    public void swapPlayer()
    {
        player.GetComponent<Animator>().SetTrigger("swap");
        StartCoroutine(swap());
    }

    public IEnumerator swap()
    {
        yield return new WaitForSeconds(0.25f);
        Vector3 playerTransform = player.transform.position;
        player.transform.position = transform.position;
        transform.position = playerTransform;
    }
}
