using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 3;

    public Action<int> OnHealtChanged;
    public Action OnPlayerDead;
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            OnPlayerDead?.Invoke();
        }

        OnHealtChanged?.Invoke(_health);
    }
}
