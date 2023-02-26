using System;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private bool _preFinished = false;

    public bool PreFinished => _preFinished;

    public Action FinishTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            _preFinished = true;
            FinishTriggered?.Invoke();
            playerBehaviour.StartPreFinish();
        }
    }
}