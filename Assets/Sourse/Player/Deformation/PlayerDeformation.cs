using System;
using System.Collections;
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

    private Coroutine _growWidth;
    private Coroutine _growHeight;
    private float _width;
    private float _height;
    private float _endValueWidth;
    private float _endValueHeight;
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
        ChangeEndValue(ref _endValueWidth, _width, value);

        _growWidth = null;
        _growWidth = StartCoroutine(GrowWidth(_endValueWidth));

        _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    private void ChangeHeight(int value)
    {
        ChangeEndValue(ref _endValueHeight, _height, value);

        _growHeight = null;
        _growHeight = StartCoroutine(GrowHeight(_endValueHeight));

        _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
        _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
    }

    private void ChangeEndValue(ref float endValue, float startValue, int addValue)
    {
        if (endValue < startValue)
            endValue = startValue + addValue;
        else
            endValue += addValue;
    }

    private IEnumerator GrowWidth(float endValue)
    {
        while (_width != endValue - 0.9f)
        {
            _width = Mathf.Lerp(_width, endValue, _deformationSpeed * Time.deltaTime);
            _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
            yield return null;
        }
    }

    private IEnumerator GrowHeight(float endValue)
    {
        while (_height != endValue - 0.9f)
        {
            _height = Mathf.Lerp(_height, endValue, _deformationSpeed * Time.deltaTime);
            _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
            _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
            yield return null;
        }
    }
}
