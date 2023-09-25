using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{

    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootPoint;
    // Start is called before the first frame updat
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(shootPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
