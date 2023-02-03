using UnityEngine;

public class GateRemover : MonoBehaviour
{
    [SerializeField] private Gate[] _gates;
    [SerializeField] private ParticleSystem _particlesNegativeRemove;
    [SerializeField] private ParticleSystem _particlesPositiveRemove;

    private void OnEnable()
    {
        foreach (Gate gate in _gates)
            gate.PlayerTouched += OnPlayerTouched;
    }

    private void OnDisable()
    {
        foreach (Gate gate in _gates)
            gate.PlayerTouched -= OnPlayerTouched;
    }

    private void OnPlayerTouched()
    {
        foreach (Gate gate in _gates)
        {
            if (gate.gameObject.activeSelf)
            {
                gate.gameObject.SetActive(false);

                if (gate.ValueDeformationChange > 0)
                    Instantiate(_particlesPositiveRemove, gate.transform.position, Quaternion.identity);
                else
                    Instantiate(_particlesNegativeRemove, gate.transform.position, Quaternion.identity);
            }
        }
    }
}
