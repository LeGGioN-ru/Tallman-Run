using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMoney))]
public class MoneyAdder : MonoBehaviour
{
    [SerializeField] private int _moneyAdd;

    private void Start()
    {
        PlayerMoney.Instance.LoadMoney(_moneyAdd);
    }
}
