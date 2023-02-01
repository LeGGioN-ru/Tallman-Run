using UnityEngine;
using TMPro;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private void Start()
    {
        PlayerMoney.Instance.MoneyCountChanged += (int money) =>
        {
            ShowMoney(money);
        };
    }

    private void OnDisable()
    {
        PlayerMoney.Instance.MoneyCountChanged -= (int money) =>
        {
            ShowMoney(money);
        };
    }

    private void ShowMoney(int money)
    {
        _moneyText.text = money.ToString();
    }
}