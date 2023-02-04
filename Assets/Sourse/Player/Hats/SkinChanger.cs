using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hats;
    [SerializeField] private List<Material> _colors;
    [SerializeField] private GameObject _currentHat;
    [SerializeField] private int _currentHatIndex;
    [SerializeField] private Material _currentColor;
    [SerializeField] private int _currentColorIndex;
    [SerializeField] private SkinnedMeshRenderer _mesh;

    public int CurrentHatIndex => _currentHatIndex;
    public int CurrentColorIndex => _currentColorIndex;

    public void LoadSkin(int colorIndex, int hatIndex)
    {
        _mesh.material = _colors[colorIndex];
        _hats[hatIndex].SetActive(true);

        _currentHat = _hats[hatIndex];
        _currentColor = _colors[colorIndex];

        _currentHatIndex = hatIndex;
        _currentColorIndex = colorIndex;
    }

    public void SetNewHat(int newHatIndex)
    {
        if (_currentHat != null)
            _currentHat.gameObject.SetActive(false);

        _hats[newHatIndex].gameObject.SetActive(true);
        _currentHat = _hats[newHatIndex];
        _currentHatIndex = newHatIndex;
    }

    public void SetNewColor(int newColorIndex)
    {
        _mesh.material = _colors[newColorIndex];
        _currentColor = _colors[newColorIndex];
        _currentColorIndex = newColorIndex;
    }
}