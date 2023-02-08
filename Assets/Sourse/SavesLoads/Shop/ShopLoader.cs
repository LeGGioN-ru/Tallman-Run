using UnityEngine;

public class ShopLoader : GameLoader
{
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private SkinSettersLoader _skinSettersLoader;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private UnlockedSkins _unlockedSkins;

    protected override void Execute(Save save)
    {
        _skinChanger.LoadSkin(save.CurrentColorIndex, save.CurrentHatIndex);
        _skinSettersLoader.Execute(save.UnlockedButtons ?? null);
        _playerMoney.LoadMoney(10000);
    }
}
