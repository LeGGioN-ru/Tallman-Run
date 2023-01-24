using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateView : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    [SerializeField] private Color _addValueColor;
    [SerializeField] private Color _reduceValueColor;
    [SerializeField] private float _alphaBottomPanel;
    [SerializeField] private PositiveWidthArrows _positiveWidthArrows;
    [SerializeField] private PositiveHeightArrows _positiveHeightArrows;
    [SerializeField] private NegativeWidthArrows _negativeWidthArrows;
    [SerializeField] private NegativeHeightArrows _negativeHeightArrows;
    [SerializeField] private Image _upperPanel;
    [SerializeField] private Image _bottomPanel;
    [SerializeField] private TMP_Text _text;
    [Header("For update OnValidate")]
    [SerializeField] private bool _update;

    private bool _isPositiveOrZeroValue => _gate.ValueDeformationChange >= 0;

    private void Start()
    {
        SetParametrs();
    }

    private void OnValidate()
    {
        CleanArrows();
        SetParametrs();
    }

    private void CleanArrows()
    {
        _negativeHeightArrows.gameObject.SetActive(false);
        _negativeWidthArrows.gameObject.SetActive(false);
        _positiveHeightArrows.gameObject.SetActive(false);
        _positiveWidthArrows.gameObject.SetActive(false);
    }

    private void SetParametrs()
    {
        if (_isPositiveOrZeroValue)
            SetPanelsColor(_addValueColor);
        else
            SetPanelsColor(_reduceValueColor);

        SetArrows();
        SetText();
    }

    private void SetText()
    {
        if (_isPositiveOrZeroValue)
            _text.text = $"+{_gate.ValueDeformationChange}";
        else
            _text.text = $"{_gate.ValueDeformationChange}";
    }

    private void SetPanelsColor(Color color)
    {
        _upperPanel.color = color;
        _bottomPanel.color = new Color(color.r, color.g, color.b, _alphaBottomPanel);
    }

    private void SetArrows()
    {
        if (_isPositiveOrZeroValue)
        {
            if (_gate.Direction == DeformationChanger.DirectionDeformation.Height)
                _positiveHeightArrows.gameObject.SetActive(true);
            else if (_gate.Direction == DeformationChanger.DirectionDeformation.Width)
                _positiveWidthArrows.gameObject.SetActive(true);
        }
        else
        {
            if (_gate.Direction == DeformationChanger.DirectionDeformation.Height)
                _negativeHeightArrows.gameObject.SetActive(true);
            else if (_gate.Direction == DeformationChanger.DirectionDeformation.Width)
                _negativeWidthArrows.gameObject.SetActive(true);
        }
    }
}
