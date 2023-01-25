using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out JumpPanel jumpPanel))
        {
            jumpPanel.Jump(transform);
        }
    }
}