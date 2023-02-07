using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public void OnSwitchLevel(int nextLevel)
    {
        SceneManager.LoadScene(nextLevel);
    }
}