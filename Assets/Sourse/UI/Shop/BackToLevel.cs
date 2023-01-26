using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevel : MonoBehaviour
{
    public void OnLevel()
    {
        SceneManager.LoadScene(1);
    }
}