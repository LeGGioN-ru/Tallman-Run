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
        _button = GetComponent<Button>();
        _costText.text = _cost.ToString();

        if (PlayerMoney.Instance.AllMoney <= _cost)
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