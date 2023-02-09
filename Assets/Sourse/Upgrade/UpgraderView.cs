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

    private void Awake()
    {
        _upgrader = GetComponent<Upgrader>();
    }

    private void Start()
    {
        LocalizationDefinder.Instance.Initializeted += UpdateView;
    }

    private void OnEnable()
    {
        _upgrader.Clicked += OnClicked;
        _upgrader.SaveLoaded += UpdateView;
    }

    private void OnDisable()
    {
        _upgrader.Clicked -= OnClicked;
        _upgrader.SaveLoaded -= UpdateView;

        LocalizationDefinder.Instance.Initializeted += UpdateView;
    }

    private void UpdateView()
    {
        _priceText.text = _upgrader.Price.ToString();
        _levelText.text = LeanLocalization.GetTranslationText("Level") + ":" + _upgrader.Level.ToString();
    }

    private void OnClicked()
    {
        UpdateView();
        Instantiate(_particles, _particlesPoint.position, Quaternion.identity).Play();
    }
}
