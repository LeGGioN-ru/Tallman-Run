using System;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private int _moneyCount = 0;

    public event Action<int> MoneyCountChanged;

    private void Start()
    {
        MoneyCountChanged.Invoke(_moneyCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Coin coin))
        {
            _moneyCount++;
            coin.Collect();

            MoneyCountChanged.Invoke(_moneyCount);
        }
    }
}