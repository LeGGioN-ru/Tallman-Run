using UnityEngine;

public class DeformationPickupBomb : DeformationChanger
{
    [SerializeField] private ParticleSystem _particles;

    protected override void OnPlayerTouch()
    {
        Instantiate(_particles, transform.position, Quaternion.identity).Play();
        base.OnPlayerTouch();
    }
}
