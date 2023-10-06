using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private float count = 0;
    [SerializeField] private float displacement = 0.1f;
    private Vector2 initialPosition;
    [SerializeField] private float sizeX = 2;
    [SerializeField] private float sizeY = 2;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Mathf.Sin(count) * sizeX;
        float y = Mathf.Cos(count) * sizeY;

        count += displacement * Time.deltaTime;

        Vector2 newPosition = new Vector2(
                            initialPosition.x + x,
                            initialPosition.y + y);

        transform.position = newPosition;
    }
}
