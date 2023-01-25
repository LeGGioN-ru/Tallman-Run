using UnityEngine;

public class Fence : Obstacle
{
    public override void Destroy()
    {
        gameObject.SetActive(false);
    }
}