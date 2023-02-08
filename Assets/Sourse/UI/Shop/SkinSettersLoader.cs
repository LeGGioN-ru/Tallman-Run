using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinSettersLoader : MonoBehaviour
{
    [SerializeField] private SkinSetter[] _skinSetters;

    public void Execute(IReadOnlyList<int> openedButtons)
    {
        if (openedButtons == null || openedButtons.Count == 0)
            return;

        for (int i = 0; i < openedButtons.Count; i++)
        {
            for (int j = 0; j < _skinSetters.Length; j++)
            {
                if (openedButtons[i] == _skinSetters[j].ButtonIndex)
                {
                    _skinSetters[j].LoadSkinButton();
                    _skinSetters[j].SetSkin();
                }
            }
        }
    }
}
