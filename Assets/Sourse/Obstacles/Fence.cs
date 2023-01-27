using UnityEngine;

public class Fence : Obstacle
{
    public override void DealDamage(PlayerDeformation playerDeformation)
    {
        base.DealDamage(playerDeformation);

        gameObject.SetActive(false);
    }
}