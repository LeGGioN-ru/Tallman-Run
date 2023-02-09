using UnityEngine;

public class LoadScreenStarter : MonoBehaviour
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private Canvas _loadScreen;

    public void Execute()
    {
        _mainCanvas.gameObject.SetActive(false);
        _loadScreen.gameObject.SetActive(true);
    }
}
