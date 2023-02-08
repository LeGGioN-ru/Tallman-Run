using UnityEngine;

public class LevelLoader : GameLoader
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private SpeedUpgrade _speedUpgrade;
    [SerializeField] private WidthUpgrade _widthUpgrade;
    [SerializeField] private HeightUpgrade _heightUpgrade;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SkinChanger _skinChanger;

    protected override void Execute(Save save)
    {
        _playerDeformation.SetStartCharacteristics(save.StartHeight, save.StartWidth);
        _playerMoney.LoadMoney(save.Money);
        _heightUpgrade.LoadLevel(save.HeightLevel);
        _speedUpgrade.LoadLevel(save.SpeedLevel);
        _widthUpgrade.LoadLevel(save.WidthLevel);
        _skinChanger.LoadSkin(save.CurrentColorIndex, save.CurrentHatIndex);
    }
}
