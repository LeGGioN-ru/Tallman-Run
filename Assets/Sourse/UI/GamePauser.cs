using UnityEngine;

public class GamePauser : MonoBehaviour
{
    [SerializeField] private GameObject _stopGamePanel;

    private bool _isGameOnPause = false;

    public void OnPauseGame()
    {
        if(Time.timeScale == 1)
        {
            _stopGamePanel.SetActive(true);

            _isGameOnPause = true;
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            _stopGamePanel.SetActive(false);

            _isGameOnPause = false;
            Time.timeScale = 1;
        }
    }
}