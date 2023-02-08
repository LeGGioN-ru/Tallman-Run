using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private bool _finished = false;

    public bool Finished => _finished;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            _finished = true;

            playerBehaviour.StartPreFinish();
        }
    }
}   