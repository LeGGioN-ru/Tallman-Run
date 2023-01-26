using UnityEngine;

[RequireComponent(typeof(PlayerDeformation))]
public class DeformationGameLoser : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private MoveAnimationsController _moveAnimationsController;
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
        if (_playerDeformation.Width < 0 || _playerDeformation.Height < 0)
        {
            DisableMove();
            _animator.Play(PlayerAnimationsController.States.Death);
        }
    }

    private void DisableMove()
    {
        _playerMover.enabled = false;
        _moveAnimationsController.enabled = false;
    }
}
