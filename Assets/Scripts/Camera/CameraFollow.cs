using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform player;
  [SerializeField] private Vector3 offset;
  [SerializeField] private float dampingTime;
  private float currentPosX;

  private Vector3 velocity = Vector3.zero;

  private void Update()
  {
    //Vector3 movePosition = player.position + offset;
    Vector3 movePosition = new Vector3(currentPosX, transform.position.y, transform.position.z);

    transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, dampingTime);
  }

  public void SetNewPosition(Vector3 newPosition)
  {
    currentPosX = newPosition.x;
  }
}
