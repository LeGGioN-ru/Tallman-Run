using UnityEngine;

public class ShopLoader : GameLoader
{
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private SkinSettersLoader _skinSettersLoader;
    [SerializeField] private PlayerMoney _playerMoney;

    protected override void Execute(Save save)
    {
        _skinChanger.LoadSkin(save.CurrentColorIndex, save.CurrentHatIndex);
        _skinSettersLoader.Execute(save.UnlockedButtons == null ? null : save.UnlockedButtons);
        _playerMoney.LoadMoney(save.Money);
    }
}
