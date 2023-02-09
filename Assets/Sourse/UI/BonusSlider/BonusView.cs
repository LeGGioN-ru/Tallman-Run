using UnityEngine;

public class BonusView : MonoBehaviour
{
    [SerializeField] private GameObject _bonus;
    [SerializeField] private BonusChooser _bonusChooser;
    [SerializeField] private ADShower _aDShower;
    [SerializeField] private LevelSwitcher _levelSwitcher;

    private int _bonusMoney;

    private void OnEnable()
    {
        _aDShower.OnRewardedCallback += () =>
        {
            AddMoney();
            _levelSwitcher.OnSwitchLevel(0);
        };
    }

    private void OnDisable()
    {
        _aDShower.OnRewardedCallback -= () =>
        {
            AddMoney();
            _levelSwitcher.OnSwitchLevel(0);
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

        _bonus.SetActive(false);
    }
}