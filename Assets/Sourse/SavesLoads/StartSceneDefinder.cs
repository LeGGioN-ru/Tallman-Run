using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneDefinder : MonoBehaviour
{
    private void Start()
    {
        Save save = GameSaver.GetCurrentSave();

        if (save == null)
            Level_1.Load();
        else
            SceneManager.LoadScene(save.CurrentScene);
    }
}
