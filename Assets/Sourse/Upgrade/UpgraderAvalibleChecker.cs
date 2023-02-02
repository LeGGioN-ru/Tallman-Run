using UnityEngine;

public class UpgraderAvalibleChecker : MonoBehaviour
{
    [SerializeField] private Upgrader[] _upgraders;
    [SerializeField] private PlayerMoney _playerMoney;

    private void OnEnable()
    {
        foreach (Upgrader upgrader in _upgraders)
            upgrader.Clicked += Execute;
    }

    private void OnDisable()
    {
        foreach (Upgrader upgrader in _upgraders)
            upgrader.Clicked -= Execute;
    }

    private void Execute()
    {
        foreach (var upgrader in _upgraders)
        {
            if (upgrader.Price > _playerMoney.AllMoney)
                upgrader.DisableButton();
            else
                upgrader.EnableButton();
        }
    }
}
