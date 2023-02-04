using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private HeightUpgrade _heightUpgrade;
    [SerializeField] private WidthUpgrade _widthUpgrade;
    [SerializeField] private SpeedUpgrade _speedUpgrade;
    [SerializeField] private bool _isExecuteOnStart;

    public static readonly string Save = nameof(Save);

    public static readonly string ShopSceneName = "shop";

    private void Start()
    {
        if (_isExecuteOnStart)
            Execute();
    }

    public void Execute()
    {
        Save save;

        if (SceneManager.GetActiveScene().name == ShopSceneName)
            save = new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
        else
            save = new Save(SceneManager.GetActiveScene().name, _playerMoney.AllMoney, _playerDeformation.StartHeight, _playerDeformation.StartWidth, _heightUpgrade.Level, _widthUpgrade.Level, _speedUpgrade.Level);

        PlayerPrefs.SetString(Save, JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }
}
