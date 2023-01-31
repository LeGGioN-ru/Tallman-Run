using UnityEngine;

public class BonusView : MonoBehaviour
{
    [SerializeField] private BonusChooser _bonusChooser;
    [SerializeField] private ADShower _aDShower;

    private int _bonusMoney;

    private void OnEnable()
    {
        _aDShower.OnRewardedCallback += () =>
        {
            AddMoney();
        };
    }

    private void OnDisable()
    {
        _aDShower.OnRewardedCallback -= () =>
        {
            AddMoney();
        };
    }

    private void AddMoney()
    {
        PlayerMoney.Instance.IncreaseMoney(_bonusMoney);
    }

    public void OnBonusButton()
    {
        _aDShower.ShowRewardedAD();
        _bonusMoney = _bonusChooser.ChooseBonus();
    }
}