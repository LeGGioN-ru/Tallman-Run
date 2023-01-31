using UnityEngine;

public class SpeedUpgrade : Upgrader
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _speedUpgrade;

    protected override void Upgrade()
    {
        _playerMover.IncreaseMoveSpeed(_speedUpgrade);
    }
}
