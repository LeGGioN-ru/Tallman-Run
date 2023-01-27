using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(MoveAnimationsController))]
public class PlayerBehaviour : MonoBehaviour
{
    private PlayerMover _playerMover;
    private MoveAnimationsController _moveAnimationsController;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _moveAnimationsController = GetComponent<MoveAnimationsController>();

        Stop();
    }

    public void Stop()
    {
        _playerMover.enabled = false;
        _moveAnimationsController.enabled = false;
    }

    public void Play()
    {
        _playerMover.enabled = true;
        _moveAnimationsController.enabled = true;
    }
}
