using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _allMoney = 0;
    [SerializeField] private int _moneyCollectedOnLevel = 0;

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
        MoneyCountChanged.Invoke(_allMoney);
    }

    public void CollectCoin()
    {
        _allMoney++;
        _moneyCollectedOnLevel++;

        MoneyCountChanged.Invoke(_allMoney);
    }

    public void DecreaseMoney(int money)
    {
        _allMoney -= money;
        MoneyCountChanged.Invoke(_allMoney);
    }
}