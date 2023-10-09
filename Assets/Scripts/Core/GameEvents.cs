using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameEvents instance;

    private void Awake() => instance = this;

    public event Action OnPlayerDeath;

    public void PlayerDeath() => OnPlayerDeath?.Invoke();

    public event Action OnUpdateBullets;
    public void UpdateBullets() => OnUpdateBullets?.Invoke();

    public event Action OnAddMaxBullet;

    public void AddMaxBullet() => OnAddMaxBullet?.Invoke();

    public event Action<int> OnButtonActive;

    public void ButtonActive(int id) => OnButtonActive?.Invoke(id);
}
