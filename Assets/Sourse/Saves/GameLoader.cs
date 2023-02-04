using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    private void Start()
    {
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

    }

    private void SetGameData(Save save)
    {
        _playerDeformation.SetStartCharacteristics(save.StartHeight, save.StartWidth);
        _playerMoney.IncreaseMoney(save.Money);
    }
}
