using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Save
{
    public int CurrentHatIndex;
    public int CurrentColorIndex;
    public string CurrentScene;
    public int Money;
    public IReadOnlyList<int> UnlockedButtons;
    public float StartHeight;
    public float StartWidth;
    public int HeightLevel;
    public int WidthLevel;
    public int SpeedLevel;
    public int LevelNumber;

    [JsonConstructor]
    public Save()
    {

    }

    public Save(int hatIndex, int colorIndex, int money, IReadOnlyList<int> unlockedButtons)
    {
        CurrentHatIndex = hatIndex;
        CurrentColorIndex = colorIndex;
        Money = money;
        UnlockedButtons = unlockedButtons;

        if (TryGetPreviosSave(out Save save))
        {
            StartHeight = save.StartHeight;
            StartWidth = save.StartWidth;
            CurrentScene = save.CurrentScene;
            LevelNumber = save.LevelNumber;
        }
    }

    public Save(string currentScene, int money, float startHeight, float startWidth, int heightLevel, int widthLevel, int speedLevel)
    {
        CurrentScene = currentScene;
        Money = money;
        StartHeight = startHeight;
        StartWidth = startWidth;
        HeightLevel = heightLevel;
        WidthLevel = widthLevel;
        SpeedLevel = speedLevel;

        if (TryGetPreviosSave(out Save save))
        {
            UnlockedButtons = save.UnlockedButtons;
            CurrentHatIndex = save.CurrentHatIndex;
            CurrentColorIndex = save.CurrentColorIndex;
            LevelNumber = save.LevelNumber;
        }
        else
        {
            LevelNumber = 1;
        }
    }

    public Save(Save save)
    {
        CurrentHatIndex = save.CurrentHatIndex;
        CurrentColorIndex = save.CurrentColorIndex;
        CurrentScene = save.CurrentScene;
        Money = save.Money;
        UnlockedButtons = save.UnlockedButtons;
        StartHeight = save.StartHeight;
        StartWidth = save.StartWidth;
        HeightLevel = save.HeightLevel;
        WidthLevel = save.WidthLevel;
        SpeedLevel = save.SpeedLevel;
        LevelNumber = save.LevelNumber;
    }

    private bool TryGetPreviosSave(out Save save)
    {
        string jsonSave = PlayerPrefs.GetString(SaveConstants.Save);
        save = null;

        if (jsonSave == null)
            return false;

        save = JsonConvert.DeserializeObject<Save>(jsonSave);

        if (save == null)
            return false;

        return true;
    }
}
