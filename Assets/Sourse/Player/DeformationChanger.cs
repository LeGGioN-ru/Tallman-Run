using UnityEngine;

public class DeformationChanger : MonoBehaviour
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

    protected virtual void OnPlayerTouch()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerDeformation playerDeformation))
        {
            ChangePlayerDeformation(playerDeformation, _directionDeformationChange, _valueDeformationChange);
            OnPlayerTouch();
        }
    }

    private void ChangePlayerDeformation(PlayerDeformation playerDeformation, DirectionDeformation directionDeformation, int value)
    {
        if (directionDeformation == DirectionDeformation.Width)
            playerDeformation.ChangeWidth(value);
        else if (directionDeformation == DirectionDeformation.Height)
            playerDeformation.ChangeHeight(value);
    }
}
