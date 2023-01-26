using UnityEngine;

public class HatChooser : MonoBehaviour
{
    [SerializeField] private GameObject _currentHat;

    public void SetNewHat(GameObject newHat)
    {
        if(_currentHat != null)
            _currentHat.gameObject.SetActive(false);

        newHat.gameObject.SetActive(true);
        _currentHat = newHat;
    }
}