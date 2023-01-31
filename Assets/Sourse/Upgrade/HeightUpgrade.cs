using UnityEngine;

public class HeightUpgrade : Upgrader
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private float _heightUpgrade;

    protected override void Upgrade()
    {
        _playerDeformation.UpgradeHeight(_heightUpgrade);
    }
}
