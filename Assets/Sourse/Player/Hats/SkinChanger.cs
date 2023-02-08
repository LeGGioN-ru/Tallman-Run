using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private DeformationColorView _deformationColorView;
    [SerializeField] private List<GameObject> _hats;
    [SerializeField] private List<Material> _colors;
    [SerializeField] private GameObject _currentHat;
    [SerializeField] private int _currentHatIndex;
    [SerializeField] private Material _currentColor;
    [SerializeField] private int _currentColorIndex;
    [SerializeField] private SkinnedMeshRenderer _mesh;

    public int CurrentHatIndex => _currentHatIndex;
    public int CurrentColorIndex => _currentColorIndex;

    public void LoadSkin(int? colorIndex, int? hatIndex)
    {
        if (colorIndex.HasValue)
        {
            _mesh.material = _colors[colorIndex.Value];
            _currentColor = _colors[colorIndex.Value];
            _currentColorIndex = colorIndex.Value;

            _deformationColorView.SetNewColor(_colors[colorIndex.Value].color);
        }

        if (hatIndex.HasValue)
        {
            _hats[hatIndex.Value].SetActive(true);
            _currentHat = _hats[hatIndex.Value];
            _currentHatIndex = hatIndex.Value;
        }
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