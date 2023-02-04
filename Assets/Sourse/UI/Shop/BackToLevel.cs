using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    public void OnLevel()
    {
        SceneManager.LoadScene(JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save)).CurrentScene);
    }
}