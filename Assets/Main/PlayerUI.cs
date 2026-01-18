using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Image[] _health;
    [SerializeField] private GameObject _lossMenu;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.OnHealtChanged += HadleDamage;
        _playerHealth.OnPlayerDead += HandleDead;
    }

    private void HadleDamage(int health)
    {
        for (int i = 0; i < _health.Length; i++)
        {
            if (_health[i] != null) _health[i].enabled = (i < health);
        }
    }

    private void HandleDead()
    {
        _lossMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealtChanged -= HadleDamage;
        _playerHealth.OnPlayerDead -= HandleDead;
    }
}
