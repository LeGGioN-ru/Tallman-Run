using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            playerBehaviour.StartPreFinish();
        }
    }
}   