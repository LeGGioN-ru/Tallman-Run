using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSettersLoader : MonoBehaviour
{
    [SerializeField] private SkinSetter[] _skinSetters;

    public void Execute(IReadOnlyList<int> openedButtons)
    {
        if (openedButtons == null)
            return;

        foreach (var item in openedButtons)
        {
        }

        foreach (var item in _skinSetters)
        {
            Debug.Log($"Скин -> {item.ButtonIndex}");
        }

        foreach (SkinSetter skin in _skinSetters)
            if (openedButtons.Contains(skin.ButtonIndex))
                skin.LoadSkinButton();
    }
}
