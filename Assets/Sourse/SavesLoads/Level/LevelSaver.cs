using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSaver : GameSaver
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private HeightUpgrade _heightUpgrade;
    [SerializeField] private WidthUpgrade _widthUpgrade;
    [SerializeField] private SpeedUpgrade _speedUpgrade;
    [SerializeField] private PlayerMoney _playerMoney;

    protected override Save GetSave()
    {
        return new Save(SceneManager.GetActiveScene().name, _playerMoney.AllMoney, _playerDeformation.StartHeight, _playerDeformation.StartWidth, _heightUpgrade.Level, _widthUpgrade.Level, _speedUpgrade.Level);
    }
}
