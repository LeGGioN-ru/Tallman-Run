using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class ADShower : MonoBehaviour
{
    public event Action OnVideoOpened;
    public event Action OnRewardedCallback;

    private void OnEnable()
    {
        OnVideoOpened += () =>
        {
            ChangeSoundVolume(0);
        };

        OnRewardedCallback += () =>
        {
            ChangeSoundVolume(1);
        };
    }

    private void OnDisable()
    {
        OnVideoOpened -= () =>
        {
            ChangeSoundVolume(0);
        };

        OnRewardedCallback -= () =>
        {
            ChangeSoundVolume(1);
        };
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    public void ChangeSoundVolume(int value)
    {
        if(SoundMuter.Instance.IsSoundMuted == false)
            AudioListener.volume = value;

        Time.timeScale = value;
    }

    public void ShowRewardedAD()
    {
        VideoAd.Show(OnVideoOpened, OnRewardedCallback);
    }

    public void ShowAD()
    {
        InterstitialAd.Show();
    }
}