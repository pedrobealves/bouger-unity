using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShoot : MonoBehaviour
{

    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootPoint;

    public void onShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
            Instantiate(shootPrefab, shootPoint.position, shootPoint.rotation);
    }
}
