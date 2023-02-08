using IJunior.TypedScenes;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private LevelSaver _levelSaver;
    [SerializeField] private GameSaver _gameSaver;

    private readonly string Level = nameof(Level);
    private List<TypedScene> _levels;

    private void Start()
    {
        _levels = new List<TypedScene>
        {
            new Level_1(),
            new Level_2(),
            new Level_3(),
            new Level_4(),
            new Level_5(),
            new Level_6(),
            new Level_7(),
            new Level_8(),
            new Level_9(),
            new Level_10(),
            new Level_11(),
            new Level_12(),
            new Level_13(),
            new Level_14(),
            new Level_15(),
            new Level_16(),
            new Level_17(),
            new Level_18(),
            new Level_19(),
            new Level_20(),
            new Level_21(),
            new Level_22(),
            new Level_23(),
            new Level_24(),
            new Level_25(),
        };
    }

    public void OnSwitchLevel(int nextLevel)
    {
        Save save = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString("Save"));
        save.LevelNumber++;
        PlayerPrefs.SetString("Save", JsonConvert.SerializeObject(save));
        PlayerPrefs.Save();
        _gameSaver.Execute();

        foreach (var level in _levels)
        {
            if (level.GetType().Name == $"Level_{save.LevelNumber}")
            {
                SceneManager.LoadScene(level.GetType().Name);
                return;
            }
        }

        SceneManager.LoadScene($"Level_{Random.Range(2, _levels.Count)}");
    }
}