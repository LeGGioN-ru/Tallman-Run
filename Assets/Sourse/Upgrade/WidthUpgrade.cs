using UnityEngine;

public class WidthUpgrade : Upgrader
{
    [SerializeField] private PlayerDeformation _playerDeformation;
    [SerializeField] private float _widthUpgrade;

    protected override void Upgrade()
    {
        _playerDeformation.UpgradeWidth(_widthUpgrade);
    }
}
