using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _finish.SetActive(true);
        }
    }
}
