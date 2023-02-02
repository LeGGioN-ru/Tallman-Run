using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private float _price;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private float _priceIncrease;

    private int _level;
    private Button _button;

    public int Level => _level;
    public float Price => _price;

    public Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
        OnMoneyCountChanged(_playerMoney.AllMoney);
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
            _button.interactable = false;
        else
            _button.interactable = true;
    }

    private void OnClick()
    {
        Upgrade();
        _price += _priceIncrease;
        _level++;
        Clicked?.Invoke();
    }

    protected abstract void Upgrade();
}
