using IJunior.TypedScenes;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    public void OnLevel()
    {
        try
        {
            SceneManager.LoadScene(JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save)).CurrentScene);
        }
        catch (System.Exception)
        {
            Level_1.Load();
        }
    }
}