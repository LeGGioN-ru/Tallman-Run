using UnityEngine;

public class SkinSetter : MonoBehaviour
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private int _buttonIndex;
    [SerializeField] private bool _isHat = true;

    [Header("Set hat number, if flag isHat true")]
    [SerializeField] private int _hatIndex;
    [SerializeField] private int _colorIndex;

    public void SetSkin()
    {
        if (_isHat)
            _unlockedSkins.UnlockHat(_hatIndex, _buttonIndex);
        else
            _unlockedSkins.UnlockColor(_colorIndex, _buttonIndex);
    }
}