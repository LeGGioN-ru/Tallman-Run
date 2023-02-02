using TMPro;
using UnityEngine;

public class UpgraderView : MonoBehaviour
{
    [SerializeField] private Upgrader _upgrader;
    [SerializeField] private Transform _particlesPoint;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _levelText;

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
        _levelText.text = _upgrader.Level.ToString();
        Instantiate(_particles, _particlesPoint.position, Quaternion.identity).Play();
    }
}
