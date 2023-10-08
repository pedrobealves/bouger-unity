using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIBulletBar : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<Image> bullets;

    [SerializeField] private CharacterStatus characterStatus;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.OnUpdateBullets += UpdateBullets;
        GameEvents.instance.OnAddMaxBullet += AddBullet;

        for (int i = 0; i < characterStatus.maxBullet; i++)
        {
            GameObject h = Instantiate(bullet, this.transform);
            bullets.Add(h.GetComponent<Image>());
        }

    }

    void UpdateBullets()
    {
        int bulletFill = characterStatus.Bullets;

        foreach (Image i in bullets)
        {
            i.fillAmount = bulletFill;
            bulletFill -= 1;
        }

    }

    void AddBullet()
    {
        foreach (Image i in bullets)
        {
            Destroy(i.gameObject);
        }
        bullets.Clear();
        for (int i = 0; i < characterStatus.maxBullet; i++)
        {
            GameObject h = Instantiate(bullet, this.transform);
            bullets.Add(h.GetComponent<Image>());
        }
    }
}
