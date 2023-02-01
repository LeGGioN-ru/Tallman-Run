using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _damage;

    public virtual void DealDamage(PlayerDeformation playerDeformation)
    {
        playerDeformation.Execute(_damage);
        Debug.Log("Damage!");
    }
}