using DG.Tweening;
using System;
using UnityEngine;

public class FinishCameraBiaser : MonoBehaviour
{
    [SerializeField] private Vector3 _newPosition;
    [SerializeField] private Vector3 _newRotation;
    [SerializeField] private float _duration;
    [SerializeField] private Camera _camera;
    [SerializeField] private PreFinishTrigger _preFinishTrigger;

    private void OnEnable()
    {
        _preFinishTrigger.FinishTriggered += OnFinishTriggered;
    }

    private void OnDisable()
    {
        _preFinishTrigger.FinishTriggered -= OnFinishTriggered;
    }

    private void OnFinishTriggered()
    {
        _camera.transform.DOLocalMove(_newPosition, _duration);
        _camera.transform.DOLocalRotate(_newRotation, _duration);
    }
}
