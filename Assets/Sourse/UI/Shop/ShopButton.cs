using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public void OnShopButton()
    {
        SceneManager.LoadScene("shop");
    }
}