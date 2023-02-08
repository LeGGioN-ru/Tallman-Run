using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedSkins : MonoBehaviour
{
    [SerializeField] private SkinChanger _skinChanger;

    private List<int> _unlockedButtons = new List<int>();

    public IReadOnlyList<int> UnlockedButtons => _unlockedButtons;

    public Action SkinUnlocked;

    public void UnlockHat(int hatIndex, int buttonIndex)
    {
        _skinChanger.SetNewHat(hatIndex);
        _unlockedButtons.Add(buttonIndex);
        SkinUnlocked?.Invoke();
    }

    public void UnlockColor(int colorIndex, int buttonIndex)
    {
        _skinChanger.SetNewColor(colorIndex);
        _unlockedButtons.Add(buttonIndex);
        SkinUnlocked?.Invoke();
    }
}