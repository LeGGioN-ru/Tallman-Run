using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _moneyCount = 0;

    public int MoneyCount => _moneyCount;

    public static PlayerMoney Instance;
    public event Action<int> MoneyCountChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MoneyCountChanged.Invoke(_moneyCount);
    }

    public void CollectCoin()
    {
        _moneyCount++;
        MoneyCountChanged.Invoke(_moneyCount);
    }

    public void DecreaseMoney(int money)
    {
        _moneyCount -= money;
        MoneyCountChanged.Invoke(_moneyCount);
    }
}