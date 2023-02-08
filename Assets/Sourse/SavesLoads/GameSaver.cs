using Newtonsoft.Json;
using UnityEngine;

public abstract class GameSaver : MonoBehaviour
{
    public abstract Save GetSave();

    public void Execute()
    {
        Save save = GetSave();
        PlayerPrefs.SetString(SaveConstants.Save, JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }

    public static void Execute(Save save)
    {
        PlayerPrefs.SetString(SaveConstants.Save, JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
    }

    public static Save GetCurrentSave()
    {
        return JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save));
    }
}
