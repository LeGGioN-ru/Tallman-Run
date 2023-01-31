using UnityEngine;
using UnityEngine.UI;

public class BonusChooser : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderSpeed = 0.001f;
    [SerializeField] private int _minBonus = 2;
    [SerializeField] private int _middleBonus = 3;
    [SerializeField] private int _maxBonus = 4;
    [SerializeField] private float[] _bonusBorders;

    private int _bonusIndex = -1;
    private bool _isValueMin = true;
    private bool _isNotChooseed = true;

    private void Update()
    {
        if(_isNotChooseed)
        {
            if (_isValueMin)
                MoveTo1();
            else
                MoveTo0();
        }
    }

    private void MoveTo1()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, 1, _sliderSpeed);

        if (_slider.value == 1)
            _isValueMin = false;
    }

    private void MoveTo0()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, 0, _sliderSpeed);

        if (_slider.value == 0)
            _isValueMin = true;
    }

    private int ChooseBonusIndex(int index)
    {
        switch(index)
        {
            case 0:
                return _minBonus;
            case 1:
                return _middleBonus;
            case 2:
                return _maxBonus;
            case 3:
                return _middleBonus;
            case 4:
                return _minBonus;
            default:
                return 1;
        }
    }

    public int ChooseBonus()
    {
        _isNotChooseed = false;

        for (int i = 0; i < _bonusBorders.Length; i++)
        {
            if (_slider.value < _bonusBorders[i])
            {
                _bonusIndex = i;
                break;
            }
        }

        if (_bonusIndex == -1)
            _bonusIndex = _bonusBorders.Length;

        return ChooseBonusIndex(_bonusIndex);
    }
}