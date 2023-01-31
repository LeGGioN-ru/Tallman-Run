using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private float _price;
    [SerializeField] private PlayerMoney _playerMoney;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        OnMoneyCountChanged(_playerMoney.AllMoney);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Upgrade);
        _playerMoney.MoneyCountChanged += OnMoneyCountChanged;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Upgrade);
        _playerMoney.MoneyCountChanged -= OnMoneyCountChanged;
    }

    private void OnMoneyCountChanged(int currentMoney)
    {
        if (currentMoney < _price)
            _button.enabled = false;
        else
            _button.enabled = true;
    }

    protected abstract void Upgrade();
}
