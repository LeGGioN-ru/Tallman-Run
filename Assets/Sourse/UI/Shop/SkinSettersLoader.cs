using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSettersLoader : MonoBehaviour
{
    [SerializeField] private SkinSetter[] _skinSetters;

    public void Execute(IReadOnlyList<int> openedButtons)
    {
        foreach (var skin in _skinSetters)
            if (openedButtons.Contains(skin.ButtonIndex))
                skin.LoadSkinButton();
    }
}
