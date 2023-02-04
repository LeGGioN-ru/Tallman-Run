using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaver : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    public static readonly string Save = nameof(Save);

    public static readonly string ShopSceneName = "shop";

    public void Execute()
    {
        Save save;

        if (SceneManager.GetActiveScene().name == ShopSceneName)
            save = GetShopSave();
        else
            save = GetGameSave();

        PlayerPrefs.SetString(Save, JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }

    private Save GetGameSave()
    {
        return new Save(SceneManager.GetActiveScene().name, _playerMoney.AllMoney, _playerDeformation.StartHeight, _playerDeformation.StartWidth);
    }

    private Save GetShopSave()
    {
        return new Save(_skinChanger.CurrentHatIndex, _skinChanger.CurrentColorIndex, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons);
    }
}
