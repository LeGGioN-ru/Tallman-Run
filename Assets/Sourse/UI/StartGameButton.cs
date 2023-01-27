using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;

    public void OnStartGame()
    {
        gameObject.SetActive(false);

        _playerBehaviour.Play();
    }    
}