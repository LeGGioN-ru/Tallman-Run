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

    private Save _previosSave = JsonConvert.DeserializeObject<Save>(PlayerPrefs.GetString(GameSaver.Save));

    public Save(int hatIndex, int colorIndex, int money, IReadOnlyList<int> unlockedButtons)
    {
        CurrentHatIndex = hatIndex;
        CurrentColorIndex = colorIndex;
        CurrentScene = _previosSave.CurrentScene;
        Money = money;
        UnlockedButtons = unlockedButtons;
        StartHeight = _previosSave.StartHeight;
        StartWidth = _previosSave.StartWidth;
    }

    public Save(string currentScene, int money, float startHeight, float startWidth)
    {
        CurrentHatIndex = _previosSave.CurrentHatIndex;
        CurrentColorIndex = _previosSave.CurrentColorIndex;
        CurrentScene = currentScene;
        Money = money;
        UnlockedButtons = _previosSave.UnlockedButtons;
        StartHeight = startHeight;
        StartWidth = startWidth;
    }
}
