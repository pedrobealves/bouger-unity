using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterShoot : MonoBehaviour
{

    [SerializeField] private GameObject shootPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip shootEmptySound;
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
                SoundManager.instance.PlaySound(shootSound);
                Instantiate(shootPrefab, shootPoint.position, shootPoint.rotation);
                characterStatus.Bullets -= 1;
            }
            else
            {
                SoundManager.instance.PlaySound(shootEmptySound);
            }

        }
    }
}
