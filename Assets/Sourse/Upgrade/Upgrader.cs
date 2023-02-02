using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class Upgrader : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private int _priceIncrease;

    private int _level;
    private Button _button;

    public int Level => _level;
    public float Price => _price;

    public Action Clicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void EnableButton()
    {
        _button.interactable = true;
    }

    public void DisableButton()
    {
        _button.interactable = false;
    }

    private void OnClick()
    {
        Upgrade();
        _playerMoney.DecreaseMoney(_price);
        _price += _priceIncrease;
        _level++;
        Clicked?.Invoke();
    }

    protected abstract void Upgrade();
}
