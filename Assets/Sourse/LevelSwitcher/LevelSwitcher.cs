using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private LevelSaver _levelSaver;

    private readonly string Level = nameof(Level);

    public void OnSwitchLevel(int nextLevel)
    {
        //Save save = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString("Save"));
        //save.LevelNumber++;
        //PlayerPrefs.SetString("Save", JsonConvert.SerializeObject(save));
        //PlayerPrefs.Save();
        //Debug.Log("Текущий уровень в сохранении=" + save.LevelNumber);

        //Debug.Log($"Открываем {Level} {save.LevelNumber}");

        //if (SceneManager.GetSceneByName($"{Level} {save.LevelNumber}"))
        //{
        //    SceneManager.LoadScene($"{save.LevelNumber - 1}");
        //}
        //else
        //    SceneManager.LoadScene($"{Level} {Random.Range(0, save.LevelNumber - 1)}");
    }
}