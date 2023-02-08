using UnityEngine;

public abstract class GameLoader : MonoBehaviour
{
    private void Start()
    {
        Save save = GameSaver.GetCurrentSave();
        Execute(save);
    }

    protected abstract void Execute(Save save);
}
