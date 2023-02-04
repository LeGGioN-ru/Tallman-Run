using System;
using UnityEngine;

public class Gate : DeformationChanger
{
    [SerializeField] private GateView _gateView;

    public Action PlayerTouched;

    private void OnValidate()
    {
        if (_gateView != null)
            _gateView.UpdateView();
    }

    protected override void OnPlayerTouch()
    {
        base.OnPlayerTouch();
        PlayerTouched?.Invoke();
    }
}
