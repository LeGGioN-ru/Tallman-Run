using Newtonsoft.Json;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private UnlockedSkins _unlockedSkins;
    [SerializeField] private SkinChanger _skinChanger;
    [SerializeField] private PlayerMoney _playerMoney;

    private void Execute()
    {
        string jsonString = PlayerPrefs.GetString(GameSaver.Save);
        Save save = JsonConvert.DeserializeObject<Save>(jsonString);
        SetData(save);
    }

    private void SetData(Save save)
    {
        _playerDeformation.SetStartCharacteristics(save.StartHeight, save.StartWidth);
    }
}
