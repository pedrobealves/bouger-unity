using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShoot : MonoBehaviour
{

    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootPoint;
    private CharacterStatus characterStatus;

    private void Awake()
    {
        characterStatus = GetComponent<CharacterStatus>();
    }

    public void onShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (characterStatus.Bullets > 0)
            {
                Instantiate(shootPrefab, shootPoint.position, shootPoint.rotation);
                characterStatus.Bullets = -1;
            }

        }
    }
}
