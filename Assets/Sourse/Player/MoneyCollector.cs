using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Collect();

            PlayerMoney.Instance.CollectCoin();
        }
    }
}