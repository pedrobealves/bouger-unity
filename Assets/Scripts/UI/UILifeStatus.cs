using UnityEngine;
using UnityEngine.UI;


public class BulletsStatus : MonoBehaviour
{

    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private Image currentLife;

    void Update()
    {

        float life = characterStatus.Life > 0 ? (characterStatus.Life / (float)characterStatus.maxLife) : 0;
        currentLife.transform.localScale = new Vector3(life, life, 1);
    }
}
