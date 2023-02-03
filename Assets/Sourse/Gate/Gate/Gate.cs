using System;

public class Gate : DeformationChanger
{
    public Action PlayerTouched;

    protected override void OnPlayerTouch()
    {
        base.OnPlayerTouch();
        PlayerTouched?.Invoke();
    }
}
