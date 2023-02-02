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

    private string _shopSceneName = "shop";

    private void Execute()
    {
        string newSceneName = string.Empty;

        if (SceneManager.GetActiveScene().name != _shopSceneName)
        {
            newSceneName = SceneManager.GetActiveScene().name;

        }
        else
        {
            string oldSave = PlayerPrefs.GetString(Save);
            newSceneName = PlayerPrefs.GetString(JsonConvert.DeserializeObject<Save>(oldSave).CurrentScene);
        }

        Save save = new Save(0, 0, newSceneName, _playerMoney.AllMoney, _unlockedSkins.UnlockedButtons, _playerDeformation.StartHeight, _playerDeformation.StartWidth);
        string jsonString = JsonConvert.SerializeObject(save);
        PlayerPrefs.SetString(Save, jsonString);
        PlayerPrefs.Save();
    }
}
