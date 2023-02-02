using UnityEngine;

public class Fence : Obstacle
{
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private GameObject _model;

    public override void DealDamage(PlayerDeformation playerDeformation)
    {
        base.DealDamage(playerDeformation);

        _hitEffect.Play();
        _model.SetActive(false);
    }
}