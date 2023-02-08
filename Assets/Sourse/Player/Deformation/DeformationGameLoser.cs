using System;
using UnityEngine;

[RequireComponent(typeof(PlayerDeformation))]
public class DeformationGameLoser : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private PreFinishMove _preFinishMove;
    [SerializeField] private Animator _animator;

    private PlayerDeformation _playerDeformation;

    public event Action PlayerDead;

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
            PlayerDead.Invoke();

            _playerBehaviour.Stop();
            _animator.Play(PlayerAnimationsController.States.Death);
        }
    }
}
