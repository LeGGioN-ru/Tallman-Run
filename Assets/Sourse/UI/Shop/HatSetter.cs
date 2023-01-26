using UnityEngine;

public class HatSetter : MonoBehaviour
{
    [SerializeField] private GameObject _hat;
    [SerializeField] private HatChooser _hatChooser;

    public void SetHat()
    {
        _hatChooser.SetNewHat(_hat);
    }
}