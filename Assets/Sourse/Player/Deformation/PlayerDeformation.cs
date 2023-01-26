using System;
using System.Collections;
using UnityEngine;
using static DeformationChanger;
using static UnityEngine.Rendering.DebugUI;

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
    private float _startWidth;
    private float _startHeight;
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

    public void UpgradeWidth(int value)
    {
        StartCoroutine(GrowWidth(value));
        _startWidth = _endValueWidth;
    }

    public void UpgradeHeight(int value)
    {
        StartCoroutine(GrowHeight(value));
        _startHeight = _endValueHeight;
    }

    private void LoadDeformation()
    {
        StartCoroutine(GrowWidth(_startWidth, false));
        StartCoroutine(GrowHeight(_startHeight, false));
    }

    private void ChangeWidth(int value)
    {
        StartCoroutine(GrowWidth(value));

        _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    private void ChangeHeight(int value)
    {
        StartCoroutine(GrowHeight(value));

        _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
        _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
    }

    private void ChangeEndValueDefromation(ref float endValue, float setValue, bool isAdd = true)
    {
        if (isAdd)
            endValue += setValue;
        else
            endValue = setValue;
    }

    private IEnumerator GrowWidth(float addValue, bool isAdd = true)
    {
        ChangeEndValueDefromation(ref _endValueWidth, addValue, isAdd);

        while (_width != _endValueWidth)
        {
            _width = Mathf.MoveTowards(_width, _endValueWidth, _deformationSpeed * Time.deltaTime);
            _deformationMaterial.material.SetFloat("_PushValue", _width * _widthMultiplier);
            yield return null;
        }
    }

    private IEnumerator GrowHeight(float addValue, bool isAdd = true)
    {
        ChangeEndValueDefromation(ref _endValueHeight, addValue, isAdd);

        while (_height != _endValueHeight)
        {
            _height = Mathf.MoveTowards(_height, _endValueHeight, _deformationSpeed * Time.deltaTime);
            _collider.transform.localScale = new Vector3(1, _yScaleCollider + _height * _heightMultiplier * _heightColliderMultiplier, 1);
            _topSpine.position = _botSpine.position + new Vector3(0, _height * _heightMultiplier + _additionalHeightOffset, 0);
            yield return null;
        }
    }
}
