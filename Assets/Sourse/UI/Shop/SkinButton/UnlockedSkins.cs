using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedSkins : MonoBehaviour
{
    [SerializeField] private SkinChanger _skinChanger;

    private List<int> _unlockedButtons = new List<int>();

    public void UnlockHat(int hatIndex)
    {
        _skinChanger.SetNewHat(hatIndex);
        _unlockedButtons.Add(hatIndex);
    }

    public void UnlockColor(int colorIndex)
    {
        _skinChanger.SetNewColor(colorIndex);
        _unlockedButtons.Add(colorIndex);
    }
}