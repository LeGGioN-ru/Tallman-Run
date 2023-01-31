using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private float _price;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private Transform _particlesPoint;
    [SerializeField] private ParticleSystem _particles;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        OnMoneyCountChanged(_playerMoney.MoneyCount);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _playerMoney.MoneyCountChanged += OnMoneyCountChanged;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _playerMoney.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int currentMoney)
    {
        if (currentMoney < _price)
            _button.enabled = false;
        else
            _button.enabled = true;
    }

    private void OnClick()
    {
        Instantiate(_particles, _particlesPoint.transform).Play();
        Upgrade();
    }

    protected abstract void Upgrade();
}
