using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private LevelSaver _levelSaver;

    private int _amountLevels = 25;
    private readonly string Level = nameof(Level);

    private int GetAmountLevels()
    {
        int sceneNumber = 1;

        while (SceneManager.GetSceneByName($"{Level} {sceneNumber}").IsValid())
        {
            sceneNumber++;
            Debug.Log(sceneNumber);
        }

        return sceneNumber;
    }

    public void OnSwitchLevel(int nextLevel)
    {
        _levelSaver.Execute();
        Save save = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString("Save"));

        if (_levelSaver.GetSave().LevelNumber > _amountLevels)
            SceneManager.LoadScene($"Level {Random.Range(1, _amountLevels)}");
        else
            SceneManager.LoadScene($"Level {save.LevelNumber}");
    }
}