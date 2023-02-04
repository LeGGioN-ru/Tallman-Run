using UnityEngine;

[RequireComponent(typeof(BuyButton))]
public class SkinSetter : MonoBehaviour
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private int _buttonIndex;
    [SerializeField] private bool _isHat = true;

    [Header("Set hat number, if flag isHat true")]
    [SerializeField] private int _hatIndex;
    [SerializeField] private int _colorIndex;

    public int ButtonIndex => _buttonIndex;

    private BuyButton _buyButton;

    private void Start()
    {
        _buyButton = GetComponent<BuyButton>();
    }

    public void LoadSkinButton()
    {
        _buyButton.TurnOff();
    }

    public void SetSkin()
    {
        if (_isHat)
            _unlockedSkins.UnlockHat(_hatIndex, _buttonIndex);
        else
            _unlockedSkins.UnlockColor(_colorIndex, _buttonIndex);
    }
}