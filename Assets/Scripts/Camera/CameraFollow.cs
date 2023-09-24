using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform player;
  public Vector3 offset;
  public float dampingTime;

  private Vector3 velocity = Vector3.zero;

  void Update()
  {
    Vector3 movePosition = player.position + offset;
    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, dampingTime);

    transform.position = new Vector3(smoothedPosition.x, 0, smoothedPosition.z);
  }

}
