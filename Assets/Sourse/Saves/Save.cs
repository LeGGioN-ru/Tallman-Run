using System;
using System.Collections.Generic;

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

    public Save(int hatIndex, int colorIndex, string currentScene, int money, IReadOnlyList<int> unlockedButtons, float startHeight, float startWidth)
    {
        CurrentHatIndex = hatIndex;
        CurrentColorIndex = colorIndex;
        CurrentScene = currentScene;
        Money = money;
        UnlockedButtons = unlockedButtons;
        StartHeight = startHeight;
        StartWidth = startWidth;
    }
}
