using System;
using UnityEngine;
using static DeformationChanger;

public class PlayerDeformation : MonoBehaviour
{
    [SerializeField] private Renderer _deformationMaterial;
    [SerializeField] private Transform _topSpine;
    [SerializeField] private Transform _botSpine;
    [SerializeField] private CapsuleCollider _collider;

    public Renderer DeformationMaterial => _deformationMaterial;
    public int Width => _width;
    public int Height => _height;

    public event Action<int> Deformated;

    private int _width;
    private int _height;
    private readonly float _additionalHeightOffset = 0.17f;
    private readonly float _widthMultiplier = 0.0005f;
    private readonly float _heightMultiplier = 0.01f;
    private readonly float _heightColliderMultiplier = 0.55f;
    private readonly float _yScaleCollider = 0.95f;

    public void Execute(DirectionDeformation directionDeformation, int value)
    {
        if (directionDeformation == DirectionDeformation.Width)
            ChangeWidth(value);
        else if (directionDeformation == DirectionDeformation.Height)
            ChangeHeight(value);

        Deformated?.Invoke(value);
    }

    public void Execute(int value)
    {
        if (_height > 0)
            ChangeHeight(value);
        else if (_width > 0)
            ChangeWidth(value);

        Deformated?.Invoke(value);
    }

    private void ChangeWidth(int value)
    {
        _width += value;
        _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    private void ChangeHeight(int value)
    {
        _height += value;
        _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
        _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
    }
}
