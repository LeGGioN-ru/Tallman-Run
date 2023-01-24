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
            DeformationChanger.ChangePlayerDeformation(playerDeformation, _directionDeformationChange, _valueDeformationChange);
            gameObject.SetActive(false);
        }
    }
}
