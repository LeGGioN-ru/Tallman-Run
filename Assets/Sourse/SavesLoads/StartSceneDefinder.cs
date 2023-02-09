using System.Collections;
using IJunior.TypedScenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Agava.YandexGames;
using Lean.Localization;

[RequireComponent(typeof(LoadScreenStarter))]
public class StartSceneDefinder : MonoBehaviour
{
    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);

        Save save = GameSaver.GetCurrentSave();

        GetComponent<LoadScreenStarter>().Execute();

        if (save == null)
            Level_1.Load();
        else
            SceneManager.LoadScene(save.CurrentScene);

    }
}
