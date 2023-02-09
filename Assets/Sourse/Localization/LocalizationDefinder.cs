using System;
using System.Collections;
using Agava.YandexGames;
using Lean.Localization;
using UnityEngine;

public class LocalizationDefinder : MonoBehaviour
{
    [SerializeField] private Canvas _loadScreen;

    public event Action Initializeted;
    public static LocalizationDefinder Instance;

    private void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        //_loadScreen.gameObject.SetActive(false);
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();

        LeanLocalization.SetCurrentLanguageAll(YandexGamesSdk.Environment.i18n.lang);
        //_loadScreen.gameObject.SetActive(false);

        Initializeted?.Invoke();
    }
}