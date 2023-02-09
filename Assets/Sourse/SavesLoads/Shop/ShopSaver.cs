using UnityEngine;

public class ShopSaver : GameSaver
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    public override Save GetSave()
    {
        return new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex ?? -1, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
    }
}
