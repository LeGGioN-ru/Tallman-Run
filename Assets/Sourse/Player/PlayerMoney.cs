using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private int _allMoney;
    private int _moneyCollectedOnLevel;

    public int AllMoney => _allMoney;
    public int MomeyCollectedOnLevel => _moneyCollectedOnLevel;

    public static PlayerMoney Instance;
    public event Action<int> MoneyCountChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MoneyCountChanged?.Invoke(_allMoney);
    }

    private void Update()
    {
        MoneyCountChanged?.Invoke(_allMoney);
    }

    public void CollectCoin()
    {
        _allMoney++;
        _moneyCollectedOnLevel++;

        MoneyCountChanged.Invoke(_allMoney);
    }

    public void LoadMoney(int money)
    {
        _allMoney = money;
        MoneyCountChanged?.Invoke(_allMoney);
    }

    public void DecreaseMoney(int money)
    {
        _allMoney -= money;
        MoneyCountChanged.Invoke(_allMoney);
    }

    public void IncreaseMoney(int bonus)
    {
        _allMoney += _moneyCollectedOnLevel * bonus;
        MoneyCountChanged.Invoke(_allMoney);
    }
}