using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraFollow cameraFollow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                cameraFollow.SetNewPosition(nextRoom.position);
            }
            else
            {
                cameraFollow.SetNewPosition(previousRoom.position);
            }
        }
    }
}
