using UnityEngine;

public class ShopSaver : GameSaver
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    public override Save GetSave()
    {
        Debug.Log($"Текущая шапка -> {_skinChanger.CurrentHatIndex} Текущий цвет -> {_skinChanger.CurrentColorIndex} Количество открытых кнопок ->{_unlockedSkins.UnlockedButtons.Count}");

        return new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
    }
}
