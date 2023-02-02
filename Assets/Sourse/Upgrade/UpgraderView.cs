using Lean.Localization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Upgrader))]
public class UpgraderView : MonoBehaviour
{
    [SerializeField] private Transform _particlesPoint;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;

    private Upgrader _upgrader;
    private bool _isFirstCheck = true;

    private void Awake()
    {
        _upgrader = GetComponent<Upgrader>();
    }

    private void Start()
    {
        OnClicked();
    }

    private void OnEnable()
    {
        _upgrader.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _upgrader.Clicked -= OnClicked;
    }

    private void OnClicked()
    {
        _priceText.text = _upgrader.Price.ToString();
        _levelText.text = LeanLocalization.GetTranslationText("Level") + ":" + _upgrader.Level.ToString();

        if (_isFirstCheck)
        {
            _isFirstCheck = false;
            return;
        }

        Instantiate(_particles, _particlesPoint.position, Quaternion.identity).Play();
    }
}
