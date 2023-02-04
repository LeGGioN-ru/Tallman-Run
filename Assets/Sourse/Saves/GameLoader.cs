using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private SkinSettersLoader _skinSettersLoader;
    [SerializeField] private SpeedUpgrade _speedUpgrade;
    [SerializeField] private WidthUpgrade _widthUpgrade;
    [SerializeField] private HeightUpgrade _heightUpgrade;

    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString(GameSaver.Save));
        Execute();
    }

    private void Execute()
    {
        Save save = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(GameSaver.Save));

        if (SceneManager.GetActiveScene().name == GameSaver.ShopSceneName)
            SetShopData(save);
        else
            SetGameData(save);
    }

    private void SetShopData(Save save)
    {
        _skinChanger.LoadSkin(save.CurrentColorIndex, save.CurrentHatIndex);
        _skinSettersLoader.Execute(save.UnlockedButtons);
        _playerMoney.LoadMoney(save.Money);
    }

    private void SetGameData(Save save)
    {
        _playerDeformation.SetStartCharacteristics(save.StartHeight, save.StartWidth);
        _playerMoney.LoadMoney(save.Money);
        _heightUpgrade.LoadLevel(save.HeightLevel);
        _speedUpgrade.LoadLevel(save.SpeedLevel);
        _widthUpgrade.LoadLevel(save.WidthLevel);
    }
}
