using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Debug.Log("here");
            obstacle.DealDamage(_playerDeformation);
        }
    }
}