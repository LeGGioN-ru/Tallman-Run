using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            //Player.ApplyDamage();
            Debug.Log("Damage!");

            obstacle.Destroy();
        }
    }
}