using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private PreFinishTrigger _preFinishTrigger;
    [SerializeField] private FinishTrigger _finishTrigger;
    [SerializeField] private DeformationGameLoser _gameLoser;

    private void OnEnable()
    {
        _gameLoser.PlayerDead += () =>
        {
            OnPlayerDead();
        };
    }

    private void OnDisable()
    {
        _gameLoser.PlayerDead -= () =>
        {
            OnPlayerDead();
        };
    }

    private void OnPlayerDead()
    {
        if (_preFinishTrigger.Finished)
            _finishTrigger.WinGame();
        else
            _losePanel.SetActive(true);
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}