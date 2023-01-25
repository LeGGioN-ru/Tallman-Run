using System.Collections;
using UnityEngine;

public class DeformationView : MonoBehaviour
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private Color _addValueColor;
    [SerializeField] private Color _reduceValueColor;
    [SerializeField] private float _lerpTime;

    private Color _startColor;
    private float _time;
    private readonly float _borderColorChange = 0.9f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _startColor = _playerDeformation.DeformationMaterial.material.color;
    }

    private void OnEnable()
    {
        _playerDeformation.Deformated += OnDeformated;
    }

    private void OnDisable()
    {
        _playerDeformation.Deformated -= OnDeformated;
    }

    private void OnDeformated(int value)
    {
        if (_coroutine != null)
            return;

        if (value >= 0)
            _coroutine = StartCoroutine(BlickColor(_addValueColor));
        else
            _coroutine = StartCoroutine(BlickColor(_reduceValueColor));
    }

    private IEnumerator BlickColor(Color color)
    {
        while (_time < _borderColorChange)
        {
            _playerDeformation.DeformationMaterial.material.color = Color.Lerp(_playerDeformation.DeformationMaterial.material.color, color, _lerpTime * Time.deltaTime);
            _time = Mathf.Lerp(_time, 1f, _lerpTime * Time.deltaTime);
            yield return null;
        }

        _time = 0;

        while (_time < _borderColorChange)
        {
            _playerDeformation.DeformationMaterial.material.color = Color.Lerp(_playerDeformation.DeformationMaterial.material.color, _startColor, _lerpTime * Time.deltaTime);
            _time = Mathf.Lerp(_time, 1f, _lerpTime * Time.deltaTime);
            yield return null;
        }

        _time = 0;
        _coroutine = null;
    }
}
