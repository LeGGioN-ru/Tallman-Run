using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    public void OnLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}