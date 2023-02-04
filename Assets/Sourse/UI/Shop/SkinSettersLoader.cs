using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSettersLoader : MonoBehaviour
{
    private SkinSetter[] _skinSetters;

    private void Awake()
    {
        _skinSetters = GetComponentsInChildren<SkinSetter>();
    }

    public void Execute(IReadOnlyList<int> openedButtons)
    {
        foreach (var skin in _skinSetters)
            if (openedButtons.Contains(skin.ButtonIndex))
                skin.LoadSkinButton();
    }
}
