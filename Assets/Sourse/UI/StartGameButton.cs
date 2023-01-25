using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private MoveAnimationsController _moveAnimationsController;

    public void OnStartGame()
    {
        gameObject.SetActive(false);
        _playerMover.enabled = true;
        _moveAnimationsController.enabled = true;
    }    
}