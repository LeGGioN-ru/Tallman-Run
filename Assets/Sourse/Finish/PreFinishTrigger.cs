using System;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private bool _finished = false;

    public bool Finished => _finished;

    public Action FinishTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            _finished = true;
            FinishTriggered?.Invoke();
            playerBehaviour.StartPreFinish();
        }
    }
}