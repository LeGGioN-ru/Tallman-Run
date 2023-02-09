using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LoadScreenStarter))]
public class ShopButton : MonoBehaviour
{
    private LoadScreenStarter _canvasDisabler;

    private void Start()
    {
        _canvasDisabler = GetComponent<LoadScreenStarter>();
    }

    public void OnShopButton()
    {
        Save save = GameSaver.GetCurrentSave();
        if (save != null)
        {
            GameSaver.Execute(save);
            save.CurrentScene = SceneManager.GetActiveScene().name;
        }

        _canvasDisabler.Execute();
        shop.Load();
    }
}