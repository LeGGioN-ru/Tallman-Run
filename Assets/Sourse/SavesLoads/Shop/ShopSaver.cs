using UnityEngine;

public class ShopSaver : GameSaver
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        _unlockedSkins.SkinUnlocked += Execute;
        _skinChanger.SkinChanged += Execute;
    }

    private void OnDisable()
    {
        _unlockedSkins.SkinUnlocked -= Execute;
        _skinChanger.SkinChanged -= Execute;
    }

    public override Save GetSave()
    {
        return new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
    }
}
