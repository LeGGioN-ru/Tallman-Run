using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
public class BuyButton : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private TMP_Text _costText;

    private Button _button;

    private void Start()
    {
        PlayerMoney.Instance.MoneyCountChanged += (int money) =>
        {
            EnableButton(money);
        };

        _button = GetComponent<Button>();
        _costText.text = _cost.ToString();

        EnableButton(PlayerMoney.Instance.AllMoney);
    }

    private void OnDisable()
    {
        PlayerMoney.Instance.MoneyCountChanged -= (int money) =>
        {
            EnableButton(money);
        };
    }

    private void EnableButton(int money)
    {
        if (money < _cost)
            _button.enabled = false;
    }

    public void TurnOff()
    {
        _costText.enabled = false;

        this.enabled = false;
    }

    public void Buy()
    {
        PlayerMoney.Instance.DecreaseMoney(_cost);
        TurnOff();
    }
}