using UnityEngine;
using UnityEngine.UI;

public class ScrollViewChooser : MonoBehaviour
{
    [SerializeField] private ScrollRect _colors;
    [SerializeField] private ScrollRect _heads;

    public void OnColorButton()
    {
        _heads.gameObject.SetActive(false);
        _colors.gameObject.SetActive(true);
    }

    public void OnHeadsButton()
    {
        _colors.gameObject.SetActive(false);
        _heads.gameObject.SetActive(true);
    }
}
