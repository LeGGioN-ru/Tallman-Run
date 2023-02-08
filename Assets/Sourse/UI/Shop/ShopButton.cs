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
            GameSaver.Execute(save);
            save.CurrentScene = SceneManager.GetActiveScene().name;
        }
        shop.Load();
    }
}