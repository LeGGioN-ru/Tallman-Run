using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    [SerializeField] private ShopSaver _shopSaver;

    public void OnLevel()
    {
        _shopSaver.Execute();
        SceneManager.LoadScene(JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save)).CurrentScene);
    }
}