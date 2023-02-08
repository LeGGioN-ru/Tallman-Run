using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public void OnShopButton()
    {
        Save save = GameSaver.GetCurrentSave();
        if (save != null)
        {
            save.CurrentScene = SceneManager.GetActiveScene().name;
            GameSaver.Execute(save);
        }

        shop.Load();
    }
}