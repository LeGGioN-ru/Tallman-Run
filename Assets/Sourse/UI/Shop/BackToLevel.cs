using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LoadScreenStarter))]
public class BackToLevel : MonoBehaviour
{
    [SerializeField] private ShopSaver _shopSaver;

    private LoadScreenStarter _loadScreenStarter;

    private void Start()
    {
        _loadScreenStarter = GetComponent<LoadScreenStarter>();
    }

    public void OnLevel()
    {
        _shopSaver.Execute();
        _loadScreenStarter.Execute();
        SceneManager.LoadScene(JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(SaveConstants.Save)).CurrentScene);
    }
}