using UnityEngine;

[RequireComponent(typeof(PlayerDeformation))]
public class DeformationGameLoser : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private Animator _animator;

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
        if (_playerDeformation.EndWidth < 0 || _playerDeformation.EndHeight < 0)
        {
            DisableMove();
            _animator.Play(PlayerAnimationsController.States.Death);
        }
    }

    private void DisableMove()
    {
        _playerBehaviour.Stop();
    }
}
