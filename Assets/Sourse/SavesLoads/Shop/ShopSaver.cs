using System;
using UnityEngine;

public class ShopSaver : GameSaver
{
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private BuyButton[] _buyButtons;

    private void OnEnable()
    {
        foreach (var buyButton in _buyButtons)
            buyButton.ShinBuyed += OnSkinBuyed;
    }

    private void OnDisable()
    {
        foreach (var buyButton in _buyButtons)
            buyButton.ShinBuyed -= OnSkinBuyed;
    }

    private void OnSkinBuyed()
    {
        Execute();
    }

    public override Save GetSave()
    {
        return new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
    }
}
