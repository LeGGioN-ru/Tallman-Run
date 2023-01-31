using System;
using UnityEngine;
using static DeformationChanger;

public class PlayerDeformation : MonoBehaviour
{
    [SerializeField] private Renderer _deformationMaterial;
    [SerializeField] private Transform _topSpine;
    [SerializeField] private Transform _botSpine;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private float _deformationSpeed;

    public Renderer DeformationMaterial => _deformationMaterial;
    public float Width => _width;
    public float Height => _height;

    public event Action<int> Deformated;

    private float _width;
    private float _height;
    private float _endValueWidth;
    private float _endValueHeight;
    private readonly float _additionalHeightOffset = 0.17f;
    private readonly float _widthMultiplier = 0.0005f;
    private readonly float _heightMultiplier = 0.01f;
    private readonly float _heightColliderMultiplier = 0.55f;
    private readonly float _yScaleCollider = 0.95f;

    private void Update()
    {
        if (_height != _endValueHeight)
            ChangeHeight();

        if (_width != _endValueWidth)
            ChangeWidth();
    }

    public void Execute(DirectionDeformation directionDeformation, int value)
    {
        if (directionDeformation == DirectionDeformation.Width)
            _endValueWidth += value;
        else if (directionDeformation == DirectionDeformation.Height)
            _endValueHeight += value;

        Deformated?.Invoke(value);
    }

    public void Execute(int value)
    {
        if (_endValueHeight + value > 0)
            _endValueHeight += value;
        else
            _endValueWidth += value;

        Deformated?.Invoke(value);
    }

    private void ChangeWidth()
    {
        _width = Mathf.MoveTowards(_width, _endValueWidth, _deformationSpeed * Time.deltaTime);
        _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    private void ChangeHeight()
    {
        _height = Mathf.MoveTowards(_height, _endValueHeight, _deformationSpeed * Time.deltaTime);
        _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
        _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
    }
}
