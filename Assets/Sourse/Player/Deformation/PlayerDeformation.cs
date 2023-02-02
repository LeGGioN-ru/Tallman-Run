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
    public float EndWidth => _endWidth;
    public float EndHeight => _endHeight;
    public float StartWidth => _startWidth;
    public float StartHeight => _startHeight;

    public event Action<int> Deformated;

    private float _startWidth;
    private float _startHeight;
    private float _currentWidth;
    private float _currentHeight;
    private float _endWidth;
    private float _endHeight;
    private readonly float _additionalHeightOffset = 0.17f;
    private readonly float _widthMultiplier = 0.0005f;
    private readonly float _heightMultiplier = 0.01f;
    private readonly float _heightColliderMultiplier = 0.55f;
    private readonly float _yScaleCollider = 0.95f;

    private void Update()
    {
        if (_currentHeight != _endHeight)
            ChangeHeight();

        if (_currentWidth != _endWidth)
            ChangeWidth();
    }

    public void Execute(DirectionDeformation directionDeformation, int value)
    {
        if (directionDeformation == DirectionDeformation.Width)
            _endWidth += value;
        else if (directionDeformation == DirectionDeformation.Height)
            _endHeight += value;

        Deformated?.Invoke(value);
    }

    public void Execute(int value)
    {
        if (_endHeight + value > 0)
            _endHeight += value;
        else
            _endWidth += value;

        Deformated?.Invoke(value);
    }

    public void Reload()
    {
        _endHeight = _startHeight;
        _endWidth = _startWidth;
    }

    public void UpgradeHeight(float valueUpgrade)
    {
        UpgradeCharacteristic(ref _startHeight, valueUpgrade);
    }

    public void UpgradeWidth(float valueUpgrade)
    {
        UpgradeCharacteristic(ref _startWidth, valueUpgrade);
    }

    public void SetStartCharacteristics(float startHeight, float startWidth)
    {
        _startHeight = startHeight;
        _startWidth = startWidth;
        Reload();
    }

    private void UpgradeCharacteristic(ref float value, float valueUpgrade)
    {
        value += valueUpgrade;
        Reload();
    }

    private void ChangeWidth()
    {
        _currentWidth = Mathf.MoveTowards(_currentWidth, _endWidth, _deformationSpeed * Time.deltaTime);
        _deformationMaterial.material.SetFloat("_PushValue", _currentWidth * _widthMultiplier);
    }

    private void ChangeHeight()
    {
        _currentHeight = Mathf.MoveTowards(_currentHeight, _endHeight, _deformationSpeed * Time.deltaTime);
        _collider.transform.localScale = new Vector3(1, _yScaleCollider + _currentHeight * _heightMultiplier * _heightColliderMultiplier, 1);
        _topSpine.position = _botSpine.position + new Vector3(0, _currentHeight * _heightMultiplier + _additionalHeightOffset, 0);
    }
}
