using UnityEngine;

[RequireComponent(typeof(PlayerDeformation))]
public class DeformationGameLoser : MonoBehaviour
{
    private PlayerDeformation _playerDeformation;

    private void Awake()
    {
        _playerDeformation = GetComponent<PlayerDeformation>();
    }

    private void OnEnable()
    {
        _playerDeformation.Deformated += OnDeformated;
    }

    private void OnDisable()
    {
        _playerDeformation.Deformated -= OnDeformated;
    }

    private void OnDeformated(int value)
    {
        if (_playerDeformation.Width < 0 || _playerDeformation.Height < 0)
            Debug.Log("lose");
    }
}
