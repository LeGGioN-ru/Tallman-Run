using UnityEngine;

[RequireComponent(typeof(BuyButton))]
[RequireComponent(typeof(SkinSetter))]
public class BuyButtonView : MonoBehaviour
{
    private SkinSetter _skinSetter;
    private BuyButton _buyButton;

    private void Start()
    {
        _buyButton = GetComponent<BuyButton>();
        _skinSetter =GetComponent<SkinSetter>();
    }

    public void OnBuyButton()
    {
        if(_buyButton.enabled == true)
            _buyButton.Buy();

        _skinSetter.SetSkin();
    }
}