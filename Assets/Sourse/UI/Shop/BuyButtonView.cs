using UnityEngine;

[RequireComponent(typeof(BuyButton))]
[RequireComponent(typeof(HatSetter))]
public class BuyButtonView : MonoBehaviour
{
    private HatSetter _hatSetter;
    private BuyButton _buyButton;

    private void Start()
    {
        _buyButton = GetComponent<BuyButton>();
        _hatSetter =GetComponent<HatSetter>();
    }

    public void OnBuyButton()
    {
        if(_buyButton.enabled == true)
            _buyButton.Buy();

        _hatSetter.SetHat();
    }
}