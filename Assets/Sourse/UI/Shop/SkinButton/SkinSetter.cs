using UnityEngine;

public class SkinSetter : MonoBehaviour
{
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private bool _isHat = true;

    [Header("Set hat number, if flag isHat true")]
    [SerializeField] private int _hatIndex;
    [SerializeField] private int _colorIndex;

    public void SetSkin()
    {
        if (_isHat)
            _skinChanger.SetNewHat(_hatIndex);
        else
            _skinChanger.SetNewColor(_colorIndex);
    }
}