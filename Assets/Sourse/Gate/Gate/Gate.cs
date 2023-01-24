using UnityEngine;

public class Gate : MonoBehaviour
{
    public enum DirectionDeformation
    {
        Width,
        Height
    }

    [SerializeField] private int _valueDeformationChange;
    [SerializeField] private DirectionDeformation _directionDeformationChange;

    public int ValueDeformationChange => _valueDeformationChange;
    public DirectionDeformation Direction => _directionDeformationChange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerDeformation playerDeformation))
        {
            ChangePlayerDeformation(playerDeformation);
            gameObject.SetActive(false);
        }
    }

    private void ChangePlayerDeformation(PlayerDeformation playerDeformation)
    {
        if (_directionDeformationChange == DirectionDeformation.Width)
            playerDeformation.ChangeWidth(_valueDeformationChange);
        else if (_directionDeformationChange == DirectionDeformation.Height)
            playerDeformation.ChangeHeight(_valueDeformationChange);
    }
}
