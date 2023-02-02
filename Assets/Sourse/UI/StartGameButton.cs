using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour _playerBehaviour;
    [SerializeField] private Button _shopButton;
    [SerializeField] private GameObject _upgrades;

    public void OnStartGame()
    {
        GameAnalyticsEvents.Instace.OnLevelStartGA();
        _shopButton.gameObject.SetActive(false);
        _upgrades.SetActive(false);
        _playerBehaviour.Play();

        gameObject.SetActive(false);
    }    
}