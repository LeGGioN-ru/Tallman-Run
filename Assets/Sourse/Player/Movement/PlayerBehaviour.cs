using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(MoveAnimationsController))]
[RequireComponent(typeof(PreFinishMove))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PlayerMover _playerMover;
    private MoveAnimationsController _moveAnimationsController;
    private PreFinishMove _preFinishMove;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _moveAnimationsController = GetComponent<MoveAnimationsController>();
        _preFinishMove = GetComponent<PreFinishMove>();

        Stop();
    }

    public void Stop()
    {
        _preFinishMove.enabled = false;
        _playerMover.enabled = false;
        _moveAnimationsController.enabled = false;
    }

    public void Play()
    {
        _playerMover.enabled = true;
        _moveAnimationsController.enabled = true;
    }

    public void StartPreFinish()
    {
        _playerMover.enabled = false;
        _preFinishMove.enabled = true;
        _moveAnimationsController.StartFinish();
    }

    public void StartFinish()
    {
        _preFinishMove.enabled = false;
        _animator.SetBool(PlayerAnimationsController.Params.Dance, true);
    }
}