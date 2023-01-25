using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private PlayerMoney _playerMoney;
    [SerializeField] private TMP_Text _moneyText;

    private void OnEnable()
    {
        _playerMoney.MoneyCountChanged += (int money) =>
        {
            ShowMoney(money);
        };
    }

    private void OnDisable()
    {
        _playerMoney.MoneyCountChanged -= (int money) =>
        {
            ShowMoney(money);
        };
    }

    private void ShowMoney(int money)
    {
        _moneyText.text = money.ToString();
    }
}