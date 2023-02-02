using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hats;
    [SerializeField] private List<Material> _colors;
    [SerializeField] private GameObject _currentHat;
    [SerializeField] private Material _currentColor;
    [SerializeField] private SkinnedMeshRenderer _mesh;

    public void SetNewHat(int newHatIndex)
    {
        if (_currentHat != null)
            _currentHat.gameObject.SetActive(false);

        _hats[newHatIndex].gameObject.SetActive(true);
        _currentHat = _hats[newHatIndex];
    }

    public void SetNewColor(int newColorIndex)
    {
        _mesh.material = _colors[newColorIndex];
        _currentColor = _colors[newColorIndex];
    }
}