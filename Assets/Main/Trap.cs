using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

            playerHealth.TakeDamage(_damage);
        }
    }
}
