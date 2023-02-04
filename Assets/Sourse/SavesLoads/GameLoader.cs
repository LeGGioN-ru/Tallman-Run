using Newtonsoft.Json;
using UnityEngine;

public abstract class GameLoader : MonoBehaviour
{
    private void Start()
    {
        Save save = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save));
        Execute(save);
    }

    protected abstract void Execute(Save save);
}
